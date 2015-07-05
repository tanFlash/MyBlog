create database MyBlog

create table [User]
(
	Id int not null identity (1,1),
	FirstName nvarchar (255) not null,
	LastName nvarchar (255) not null,
	[Login] nvarchar (50) not null,
	[Password] nvarchar (50) not null,
	IsAdmin bit not null,
	IsEnable bit not null
 );

 alter table [User] add constraint PK_User_Id primary key (Id);

 alter table [User] add constraint UQ_User_Login unique ([Login]);
 use MyBlog;
 create table Article
(
	Id int not null identity (1,1),
	AuthorId int not null,
	Title nvarchar (255) not null,
	CreationTime dateTime not null,
	Content nvarchar(max) null,
	Published bit not null
 );
 alter table Article add constraint PK_Article_Id primary key (Id);
 alter table Article add constraint FK_AuthorId_Id foreign key (AuthorId) references [User] (Id);