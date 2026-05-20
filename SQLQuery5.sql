DELETE FROM Users;

DBCC CHECKIDENT ('Users', RESEED, 0);

INSERT INTO Users (Username, Password)
VALUES ('admin', '1234');

SELECT * FROM Users;