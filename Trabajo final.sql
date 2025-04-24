DROP DATABASE IF EXISTS reservations;
CREATE DATABASE reservations;

USE reservations;

DROP TABLE IF EXISTS users;
CREATE TABLE users (
	user_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,	
	name VARCHAR(20) NOT NULL UNIQUE,
	email VARCHAR(30) NOT NULL UNIQUE,
	password VARCHAR(100) NOT NULL,
	rol VARCHAR(15)

--	CONSTRAINT CHK_email CHECK (email LIKE '_%@gmail.com')
); 

DROP TABLE IF EXISTS services;
CREATE TABLE services (
	service_id INT IDENTITY(1,1) PRIMARY KEY,
	service_name VARCHAR(20),
	description VARCHAR(50),
	price FLOAT,
	duration FLOAT
);

DROP TABLE IF EXISTS bookings;
CREATE TABLE bookings(
	booking_id INT IDENTITY(1,1),
	user_id UNIQUEIDENTIFIER FOREIGN KEY REFERENCES users(user_id),
	service INT FOREIGN KEY REFERENCES services(service_id),
	date DATETIME,
	state VARCHAR(15)
);

ALTER TABLE bookings
ADD CONSTRAINT unique_reservation UNIQUE(service, date);

ALTER TABLE bookings
ADD CONSTRAINT unique_reservation_user UNIQUE(service, user_id);

INSERT INTO users (name, email, password, rol)
VALUES ('jayslen', 'jayslen134@gmail.com', 'naruto098', 'admin'),
		('diosly', 'diosly@gmail.com', 'rojas123', 'user');


INSERT INTO services (service_name, description, price, duration)
VALUES ('Cardiologo', 'Cita con un cardiologo',100, 1), ('Dentista', 'Limpieza dental profunda', 150, 1)

INSERT INTO bookings (user_id, service, date, state)
VALUES ((SELECT user_id FROM users WHERE name = 'jayslen'),2,'2025-04-19 17:00:00', 'En cola')


DROP VIEW IF EXISTS reservations;
CREATE VIEW reservations AS
SELECT u.user_id, b.booking_id, u.name, s.service_name, b.date, b.state FROM bookings AS b
LEFT JOIN users AS u ON u.user_id = b.user_id
LEFT JOIN services AS s ON s.service_id = b.service;
