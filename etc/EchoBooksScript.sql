	CREATE TABLE books
	(
	bookID int identity (1,1) not null primary key,
	title varchar(200) not null,
	author varchar(100) not null,
	mainCharacter varchar(80),
	setting varchar(100),
	genre varchar(100),
	dateAdded date
	)
