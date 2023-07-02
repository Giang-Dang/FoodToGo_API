create trigger updateMerchantRating on MerchantRatings
for update, delete, insert
as
begin
	if exists (select top 1 1 from deleted)
	begin
		declare @deleteMerchantId int = (select top 1 ToMerchantId from deleted);
		declare @deleteAvgRating float = (select avg(Rating) from MerchantRatings where ToMerchantId = @deleteMerchantId);
		update Merchants set Rating = @deleteAvgRating where MerchantId = @deleteMerchantId;
	end
	
	if exists (select top 1 1 from inserted)
	begin
		declare @insertMerchantId int = (select top 1 ToMerchantId from inserted);
		declare @insertAvgRating float = (select avg(Rating) from MerchantRatings where ToMerchantId = @insertMerchantId);
		update Merchants set Rating = @insertAvgRating where MerchantId = @insertMerchantId;
	end
end;

drop trigger updateShipperRating;


create trigger updateUserRating on UserRatings
for update, delete, insert
as
begin
	if exists (select top 1 1 from deleted)
	begin
		declare @deleteToUserId int = (select top 1 ToUserId from deleted);
		declare @deleteToUserType nvarchar(max) = (select top 1 ToUserType from deleted);
		declare @deleteAvgRating float = (select AVG(Rating) from UserRatings where ToUserId = @deleteToUserId and ToUserType like @deleteToUserType);
		
		if(@deleteToUserType like 'Customer')
		begin
			update Customers set Rating = @deleteAvgRating where CustomerId = @deleteToUserId
		end

		if(@deleteToUserType like 'Shipper')
		begin
			update Shippers set Rating = @deleteAvgRating where UserId = @deleteToUserId
		end

	end
	
	if exists (select top 1 1 from inserted)
	begin
		declare @insertToUserId int = (select top 1 ToUserId from inserted);
		declare @insertToUserType nvarchar(max) = (select top 1 ToUserType from inserted);
		declare @insertAvgRating float = (select AVG(Rating) from UserRatings where ToUserId = @insertToUserId and ToUserType like @insertToUserType);
		
		if(@insertToUserType like 'Customer')
		begin
			update Customers set Rating = @insertAvgRating where CustomerId = @insertToUserId
		end

		if(@insertToUserType like 'Shipper')
		begin
			update Shippers set Rating = @insertAvgRating where UserId = @insertToUserId
		end
	end
end

create trigger updateMenuItemRating on MenuItemRatings
for update, delete, insert
as
begin
	if exists (select top 1 1 from deleted)
	begin
		declare @deleteMenuItemId int = (select top 1 MenuItemId from deleted);
		declare @deleteAvgRating float = (select AVG(Rating) from MenuItemRatings where MenuItemId = @deleteMenuItemId);
		update MenuItems set Rating = @deleteAvgRating where Id = @deleteMenuItemId;
	end

	if exists (select top 1 1 from inserted)
	begin
		declare @insertMenuItemId int = (select top 1 MenuItemId from inserted)
		declare @insertAvgRating float = (select AVG(Rating) from MenuItemRatings where MenuItemId = @insertMenuItemId);
		update MenuItems set Rating = @insertAvgRating where Id = @insertMenuItemId;
	end
end

