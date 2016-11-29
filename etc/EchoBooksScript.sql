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

	INSERT INTO books (title, author, mainCharacter, setting, genre, dateAdded)
    VALUES ('Lily the Cat', 'Somerville, Amelia', 'Detective Brandon', 'Cleveland, OH', 'Pet Mystery', '08-17-2016'),
    ('Fly Over the Moon', 'Robellard, Nora', 'Nancy Draw', 'Japan', 'Travel Mystety', '09-12-2016'),
    ('In the Bleak Midwinter', 'Adams, Larry', 'Constable Finn', 'Scotland', 'Police Mystery', '09-18-2016'),
	('To the Moon and Back', 'Sanders, Bradon', 'Professor Qwark', 'Outer Space', 'Science Fiction', '09-18-2016'),
	('No Peace in the Village', 'Winston, Catrina', 'Detective Dan', 'Africa', 'Mystery', '10-02-2016'),
	('Duck Mysteries', 'Feathers, Gerald', 'Commander Quack', 'New York City', 'Police Mystery', '10-12-2016'),
	('A Tree Falls in the Forest', 'Adams, Larry', 'Constable Finn', 'Scotland', 'Police Mystery', '10-29-2016'),
	('The Cat in the Woods: A Luna Mystery', 'Sanderson, Syd', 'Luna Cat', 'Oregon', 'Pet Mystery', '10-30-2016'),
	('A Lion at Dinner', 'Somerville, Amelia', 'Colonel Mustard', 'San Francisco', 'Food Mystery', '11-01-2016'),
	('Are You Scared of Lightning?', 'Fisher, Paul', 'Detective Caroline', 'Florida', 'Thriller', '11-07-2016'),
	('The Mystery in Mexico', 'Slane, Luisa', 'April Showers', 'Mexico', 'Mystery', '11-07-2016'),
	('Hickory Dickory Sock', 'Sloopy, Sheldon', 'Theodore Mouse', 'London', 'Juvenile Mystery', '11-10-2016'),
	('The Blood on the Floor', 'Hamlin, Vanessa', 'Nurse Wendy', 'New York City', 'Murder Mystery', '11-11-2016'),
	('The Face in the Window', 'Winston, Jessica', 'Shirley Anne', 'Chicago', 'Thriller', '11-12-2016'),
	('The Cat with No Dinner', 'Somerville, Amelia', 'Detective Brandon', 'Cleveland, OH', 'Pet Mystery', '11-20-2016'); 