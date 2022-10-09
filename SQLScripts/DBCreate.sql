CREATE DATABASE MessengerV3Db;

GO

USE MessengerV3Db;     

CREATE TABLE [User](
Id int not null identity(1,1), 
Name nvarchar(30) not null,
Email nvarchar(40) not null,
AboutUser nvarchar(100) null,
Password nvarchar(30) not null
CONSTRAINT PK_User Primary Key(Id));


CREATE TABLE [Chat](
Id int not null identity(1,1),
ChatName nvarchar(35) not null,
MultipleChat bit not null,
CreatorId int not null,  -- del
CONSTRAINT PK_Id Primary Key(Id),
CONSTRAINT FK_Creator_Id FOREIGN KEY (CreatorId) references [User](Id));

CREATE TABLE [ChatUsers](
ChatId int not null,
UserId int not null,
-- add IsChatCreator int not null 
CONSTRAINT PK_Cnat_User_Id Primary Key(ChatId, UserId),
CONSTRAINT FK_Chat__Id FOREIGN KEY (ChatId) references [Chat](Id),
CONSTRAINT FK_User__Id FOREIGN KEY (UserId) references [User](Id));

CREATE TABLE [Message](
Id int not null identity(1,1),
ChatId int  not null,
MessageSenderId int not null,
MessageText nvarchar(MAX) not null,
MessageDate datetime2(3) not null,
CONSTRAINT PK_Message_Id Primary Key(Id),
CONSTRAINT FK_Chat_Id FOREIGN KEY(ChatId) references [dbo].[Chat](Id),
CONSTRAINT FK_Message_Sender_Id FOREIGN KEY (MessageSenderId) references [User](Id));
