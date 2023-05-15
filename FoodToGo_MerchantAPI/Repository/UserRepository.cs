using AutoMapper;
using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Models.Enums;
using FoodToGo_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FoodToGo_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private string secretKey;
        private int saltLength = 32;
        private int daysUntilJwtExpiration;
        public UserRepository(ApplicationDbContext db, IMapper mapper, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:JWTSecret");
            daysUntilJwtExpiration = configuration.GetValue<int>("ApiSettings:daysUntilJwtExpiration");
        }
        public async Task<bool> IsUniqueUser(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());

            return (user == null);
        }

        public async Task<LoginResponseDTO?> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _db.Users.FirstOrDefaultAsync(
                u => u.Username.ToLower() == loginRequestDTO.UserName.ToLower()
            );

            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    User = null,
                    Token = "",
                    IsSuccess = false,
                    ErrorMessage = "The username or password is incorrect."
                };
            }

            bool isPasswordCorrect = user.Password == PBKDF2_Hash(loginRequestDTO.Password, user.Salt);
            if (!isPasswordCorrect)
            {
                return new LoginResponseDTO()
                {
                    User = null,
                    Token = "",
                    IsSuccess = false,
                    ErrorMessage = "The username or password is incorrect."
                };
            }

            //if user was found and input password was correct.
            
            if(user.IsBanned)
            {
                if(DateTime.Now <= user.BanStartTime.Add(user.BanLength))
                {
                    return new LoginResponseDTO()
                    {
                        User = null,
                        Token = "",
                        IsSuccess = false,
                        ErrorMessage = 
                            $"User {user.Username} has been banned since {user.BanStartTime.ToShortDateString}."
                            + $"The ban period is {user.BanLength.Days} day(s)."
                    };
                }
            }

            //Generate JWT token
            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            LoginResponseDTO loginResponseDTO = new()
            {
                User = userDTO,
                Token = GenerateToken(userDTO, loginRequestDTO.loginFromApp),
                IsSuccess = true,
                ErrorMessage = ""
            };
            return loginResponseDTO;
        }

        public async Task<UserCreateDTO> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            User user = _mapper.Map<User>(registerationRequestDTO);

            user.Salt = CreateSalt(saltLength);
            user.Password = PBKDF2_Hash(user.Password, user.Salt);
            user.IsBanned = false;
            user.Role = UserRole.User.ToString();

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            user.Password = "";
            user.Salt = "";

            UserCreateDTO userCreateDTO = _mapper.Map<UserCreateDTO>(user);
            return userCreateDTO;
        }

        public async Task<User> Update(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }

        private string GenerateToken(UserDTO userDTO, string loginFromApp)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDTO.Id.ToString()),
                    new Claim(ClaimTypes.Role, userDTO.Role),
                    new Claim("LoginFromApp", loginFromApp)
                }),
                Expires = DateTime.UtcNow.AddDays(daysUntilJwtExpiration),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private string CreateSalt(int size)
        {
            byte[] salt = new byte[size];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        private string PBKDF2_Hash(string input, string salt)
        {
            int iterations = 1000;
            byte[] saltBytes = Convert.FromBase64String(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, saltBytes, iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);
            return Convert.ToBase64String(hash);
        }
    }
}
