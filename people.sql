CREATE DATABASE People;
use People;

CREATE TABLE people (

    id INT AUTO_INCREMENT PRIMARY KEY,
	first_name VARCHAR(100),
	last_name VARCHAR(100)
    );
INSERT INTO people (first_name, last_name) VALUES ('Nagy', 'Beno');
INSERT INTO people (first_name, last_name) VALUES ('Kis', 'Erno');
INSERT INTO people (first_name, last_name) VALUES ('Jhone', 'Snow');
INSERT INTO people (first_name, last_name) VALUES ('Ragnar', 'Lodbrock');
INSERT INTO people (first_name, last_name) VALUES ('Vasdereku', 'Bjorn');
INSERT INTO people (first_name, last_name) VALUES ('Anakin', 'Szkajvoker');

SELECT * FROM people;
