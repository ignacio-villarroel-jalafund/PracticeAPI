CREATE TABLE IF NOT EXISTS Users (
    Id uuid PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Occupation VARCHAR(50) NOT NULL
)