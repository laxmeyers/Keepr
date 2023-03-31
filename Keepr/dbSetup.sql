CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        coverImg VARCHAR(255)
    ) default charset utf8 COMMENT '';

Drop Table accounts;

create Table
    keeps(
        id int not null PRIMARY KEY,
        creatorId VARCHAR(255) not null,
        name VARCHAR(100) not NULL,
        description VARCHAR(255) not NULL,
        img VARCHAR(255) not null,
        views int not null DEFAULT 0,
        Foreign Key (creatorId) REFERENCES accounts(id) on delete CASCADE
    ) default charset utf8 COMMENT '';