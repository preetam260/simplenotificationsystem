-- Create notificationdb database
CREATE DATABASE notificationdb;

-- Connect to notificationdb and create tables
\c notificationdb;

-- Create users table
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    number VARCHAR(20) NOT NULL
);

-- Create notifications table
CREATE TABLE notifications (
    id SERIAL PRIMARY KEY,
    userid INTEGER NOT NULL REFERENCES users(id),
    title VARCHAR(200),
    message TEXT NOT NULL,
    notificationtype VARCHAR(50) NOT NULL,
    sentat TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
