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
        id int not null AUTO_INCREMENT PRIMARY KEY,
        creatorId VARCHAR(255) not null,
        name VARCHAR(100) not NULL,
        description VARCHAR(500) not NULL,
        img VARCHAR(500) not null,
        views int not null DEFAULT 0,
        Foreign Key (creatorId) REFERENCES accounts(id) on delete CASCADE
    ) default charset utf8 COMMENT '';

ALTER TABLE keeps MODIFY COLUMN img varchar(500);

DROP table keeps;

create Table
    vaults(
        id int not null AUTO_INCREMENT PRIMARY KEY,
        creatorId VARCHAR(255) not null,
        name VARCHAR(100) not NULL,
        description VARCHAR(500) not NULL,
        img VARCHAR(255) not null,
        isPrivate BOOLEAN not null,
        Foreign Key (creatorId) REFERENCES accounts(id) on delete CASCADE
    ) default charset utf8 COMMENT '';

DROP table vaults;

create Table
    vaultKeeps(
        id int not null AUTO_INCREMENT PRIMARY KEY,
        creatorId VARCHAR(255) not null,
        vaultId int not null,
        keepId int not NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) on delete CASCADE,
        Foreign Key (vaultId) REFERENCES vaults(id) on delete CASCADE,
        Foreign Key (keepId) REFERENCES keeps(id) on delete CASCADE
    ) default charset utf8 COMMENT '';

Select
    vk.*,
    keeps.*,
    accounts.*
from vaultKeeps vk
    join keeps on keeps.id = vk.keepId
    join accounts on accounts.id = keeps.creatorId
where vk.vaultId = 11;

join keeps k on k.id = vk.keepId
join accounts keepsCreator on keepsCreator.id on k.keepsCreatorId k.*,
keepsCreator.*;

Select
    k.*,
    acct.*,
    Count(vk.*)
from keeps k
    join accounts acct on acct.id = k.creatorId
    join vaultKeeps vk on vk.keepId = k.id
where k.id = 55;

Select
    k.*,
    COUNT(*) as kept,
    acct.*
from keeps k
    join accounts acct on acct.id = k.creatorId
    join vaultKeeps vk on vk.keepId = k.id
where k.id = 55
group by k.id;

Select k.*, Count(*) as kept
from keeps k
    right join vaultKeeps vk on vk.keepId = k.id
where k.id = 55
group by k.id;

select * from keeps where id = 75;

Select
    k.*,
    COUNT(vk.id) as kept,
    acct.*
from keeps k
    join accounts acct on acct.id = k.creatorId
    left join vaultKeeps vk on vk.keepId = k.id
where k.id = 83
group by k.id;