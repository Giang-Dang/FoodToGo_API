using AutoMapper;
using FoodToGo_API.Data;
using FoodToGo_API.Models.DbEntities;
using FoodToGo_API.Models.DTO;
using FoodToGo_API.Models.Enums;
using FoodToGo_API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
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
        internal DbSet<User> dbSet;
        public UserRepository(ApplicationDbContext db, IMapper mapper, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:JWTSecret");
            daysUntilJwtExpiration = configuration.GetValue<int>("ApiSettings:daysUntilJwtExpiration");
            this.dbSet = db.Set<User>();
        }

        public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>>? filter, int pageSize, int pageNumber)
        {
            IQueryable<User> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (pageSize > 0)
            {
                if (pageSize > 100)
                {
                    pageSize = 100;
                }
                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            }
            return await query.ToListAsync();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter = null, bool tracked = true)
        {
            IQueryable<User> query = _db.Users;
            if (tracked == false)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }
        public async Task<bool> IsUniqueUser(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());

            return (user == default);
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
            bool isloginFromAppValueExist = Enum.IsDefined(typeof(LoginFromApp), loginRequestDTO.loginFromApp);
            if (isloginFromAppValueExist == false)
            {
                return new LoginResponseDTO()
                {
                    User = null,
                    Token = "",
                    IsSuccess = false,
                    ErrorMessage = "loginFromApp value is not valid."
                };
            }

            //if user was found and input password was correct.

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

        public async Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            User user = _mapper.Map<User>(registerationRequestDTO);

            user.Salt = CreateSalt(saltLength);
            user.Password = PBKDF2_Hash(user.Password, user.Salt);
            user.Role = UserRole.User.ToString();

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            user.Password = "";
            user.Salt = "";

            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<User> UpdateAsync(User user)
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
