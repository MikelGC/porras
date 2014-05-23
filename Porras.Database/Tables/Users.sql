CREATE TABLE [dbo].[AppUsers]
(
	UserId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Users PRIMARY KEY,
	UserEmail nvarchar(256) NOT NULL,
	UserName nvarchar(256) NOT NULL,
	PasswordHash binary(64) NOT NULL,
	PasswordSalt binary(32) NOT NULL,
	CreatedDate datetimeoffset NOT NULL,
	CreatedBy int NOT NULL,
	ModifiedDate datetimeoffset NOT NULL,
	ModifiedBy int NOT NULL
)
