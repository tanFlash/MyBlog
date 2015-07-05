use MyBlog
SET IDENTITY_INSERT [User] on;
INSERT INTO [User] (Id, FirstName, LastName, [Login], [Password], IsAdmin, IsEnable) VALUES
	(1 , 'Tania', 'Mazurok', 'tania', '123456', 1,1), -- вага 
	(2 , 'Vasyl', 'Borovyk', 'borovyk', '123456', 0,1);
	
SET IDENTITY_INSERT [User] off;

SET IDENTITY_INSERT Article on;
INSERT INTO Article (Id, AuthorId, Title, CreationTime, Published, Content) VALUES
	(1 , 1, 'Wheather', GETDATE(), 1, null), -- вага 
	(2 , 1, 'Sport', GETDATE(), 1, null),
	(3 , 1, 'Politics', GETDATE(), 1, null),
	(4 , 1, 'IT', GETDATE(), 0, null),
	(5 , 1, 'Food', GETDATE(), 1, null);
	
SET IDENTITY_INSERT Article off;

