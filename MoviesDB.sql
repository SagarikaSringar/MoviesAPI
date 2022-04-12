CREATE TABLE Actors (
actorId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
actorName VARCHAR(50) NOT NULL
);

CREATE TABLE Producers (
producerId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
producerName VARCHAR(50) NOT NULL
);

CREATE TABLE Movies (
movieId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
movieName VARCHAR(100) NOT NULL,
dateOfRelease DATE NOT NULL,
producerId INT NOT NULL,
FOREIGN KEY (producerId) REFERENCES Producers(producerId)
);

CREATE TABLE MovieCasting (
movieId INT NOT NULL,
actorId INT NOT NULL,
PRIMARY KEY (movieId, actorId),
FOREIGN KEY (movieId) REFERENCES Movies(movieId),
FOREIGN KEY (actorId) REFERENCES Actors(actorId)
);

INSERT INTO Actors VALUES ('Shah Rukh Khan')
INSERT INTO Actors VALUES ('Deepika Padukone'), ('Shahid Kapoor'), ('Katrina Kaif')

SELECT * FROM Actors

INSERT INTO Producers VALUES ('Gauri Khan'), ('Sanjay Leela Bhansali'), ('Ekta Kapoor'), ('Ritesh Sidhwani')

SELECT * FROM Producers

INSERT INTO Movies VALUES
('Om Shanti Om', '2007-11-09', '3'),
('Bajirao Mastani', '2015-12-18', '2')

SELECT * FROM Movies

INSERT INTO MovieCasting VALUES
('1', '1'),
('1', '2'),
('2', '2'),
('2', '3')

SELECT * FROM MovieCasting



