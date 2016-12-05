	CREATE TABLE books
	(
	bookID int identity (1,1) not null primary key,
	title varchar(200) not null,
	author varchar(100) not null,
	mainCharacter varchar(80),
	setting varchar(100),
	genre varchar(100),
	dateAdded date,
	description varchar(Max),
	imageLink varchar(Max) 
	)



Create Table users
(
userID int identity (1,1) not null primary key,
isAdmin bit not null,
Username varchar(200) not null,
password varchar(200) not null,
salt varchar (100) not null
)


create table readingList
(
bookID int not null,
userID int not null,
hasRead bit not null,
Constraint pk_bookUser Primary KEY (bookID, userID)
)

Alter table readingList ADD FOREIGN KEY (userID) REFERENCES users(userID);

Alter table readingList ADD FOREIGN KEY (bookID) REFERENCES books(bookID);

Create Table reviews
(
reviewID int identity (1,1) not null primary key,
userID int not null,
bookID int not null,
review varchar(Max) not null
)

Alter table reviews ADD FOREIGN KEY (userID) REFERENCES users(userID);

Alter table reviews ADD FOREIGN KEY (bookID) REFERENCES books(bookID);


create table categories
(
categoryID int identity (1,1) not null primary key,
categoryName varchar(200) not null
)

create table threads
(
threadID int identity (1,1) not null primary key,
userID int not null,
categoryID int not null,
threadName varchar(300) not null
)

alter table threads Add foreign key (categoryID) references categories(categoryID);

Alter table threads Add foreign key (userID) references users(userID);

create table posts
(
postID int identity (1,1) not null primary key,
threadID int not null,
userID int not null,
postBody varchar(MAX) not null,
postDate datetime not null
)

alter table posts add foreign key (userID) references users(userID);

alter table posts add foreign key (threadID) references threads(threadID);


	insert into categories (categoryName) Values ('Recommendations Needed'), ('Plot Reviews'), ('Fan Fiction'), ('Off Topic');

	INSERT INTO books (title, author, mainCharacter, setting, genre, dateAdded, description, imageLink)
    VALUES ('Lily the Cat', 'Somerville, Amelia', 'Detective Brandon', 'Cleveland, OH', 'Pet Mystery', '08-17-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.','https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
    ('Fly Over the Moon', 'Robellard, Nora', 'Nancy Draw', 'Japan', 'Travel Mystety', '09-12-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
    ('In the Bleak Midwinter', 'Adams, Larry', 'Constable Finn', 'Scotland', 'Police Mystery', '09-18-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('To the Moon and Back', 'Sanders, Bradon', 'Professor Qwark', 'Outer Space', 'Science Fiction', '09-18-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('No Peace in the Village', 'Winston, Catrina', 'Detective Dan', 'Africa', 'Mystery', '10-02-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('Duck Mysteries', 'Feathers, Gerald', 'Commander Quack', 'New York City', 'Police Mystery', '10-12-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('A Tree Falls in the Forest', 'Adams, Larry', 'Constable Finn', 'Scotland', 'Police Mystery', '10-29-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('The Cat in the Woods: A Luna Mystery', 'Sanderson, Syd', 'Luna Cat', 'Oregon', 'Pet Mystery', '10-30-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('A Lion at Dinner', 'Somerville, Amelia', 'Colonel Mustard', 'San Francisco', 'Food Mystery', '11-01-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('Are You Scared of Lightning?', 'Fisher, Paul', 'Detective Caroline', 'Florida', 'Thriller', '11-07-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('The Mystery in Mexico', 'Slane, Luisa', 'April Showers', 'Mexico', 'Mystery', '11-07-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('Hickory Dickory Sock', 'Sloopy, Sheldon', 'Theodore Mouse', 'London', 'Juvenile Mystery', '11-10-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('The Blood on the Floor', 'Hamlin, Vanessa', 'Nurse Wendy', 'New York City', 'Murder Mystery', '11-11-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('The Face in the Window', 'Winston, Jessica', 'Shirley Anne', 'Chicago', 'Thriller', '11-12-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'),
	('The Cat with No Dinner', 'Somerville, Amelia', 'Detective Brandon', 'Cleveland, OH', 'Pet Mystery', '11-20-2016', 'Lorem ipsum dolor sit amet, et his fuisset perpetua dignissim, ad justo elitr oporteat pri. Quo minim graece ad, scribentur disputationi eu qui. Ad vim integre imperdiet, in ubique torquatos nec. Democritum efficiendi vim in, pro munere voluptatum an. Sed ei dolorum indoctum, est sonet vivendum cu.', 'https://images-na.ssl-images-amazon.com/images/I/51PxQCRCx0L._AC_US240_FMwebp_QL65_.jpg'); 

	Delete From books;
	Drop table books;