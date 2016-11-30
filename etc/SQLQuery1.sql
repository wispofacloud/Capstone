Create Table users
(
userID int identity (1,1) not null, primary key,
isAdmin bit not null,
Username varchar(Max) not null,
password varchar(1000) not null
)

Create Table opinions
(
Review varchar(Max) not null, primary key,
userID int not null, foreign key,
bookID int not null, foreign key
)


Create Table awards
(
Category varchar(Max) not null,
listOfTitles varchar(Max) not null,
listOfCharacters varchar(Max) null,
endDate date not null
) 
