USE BestWebshopDB;
GO

-- Create Read-Only User
CREATE LOGIN ReadOnlyUser WITH PASSWORD = 'SecurePassword123';
CREATE USER ReadOnlyUser FOR LOGIN ReadOnlyUser;

-- Grant Read-Only Access
EXEC sp_addrolemember 'db_datareader', 'ReadOnlyUser';


-- Create Owner User
CREATE LOGIN DbOwnerUser WITH PASSWORD = 'VerySecurePassword456';
CREATE USER DbOwnerUser FOR LOGIN DbOwnerUser;

-- Grant Full Access
EXEC sp_addrolemember 'db_owner', 'DbOwnerUser';



---- Optional testing queries to see if permissions work
--USE BestWebshopDB;

--EXECUTE AS LOGIN = 'ReadOnlyUser';  -- Switch to ReadOnlyUser
---- This should work ✅
--SELECT * FROM Customers;
---- Try inserting a new customer (should fail ❌)
--INSERT INTO Customers (FirstName, LastName, Email, Address, City, PostalCode)
--VALUES ('John', 'Doe', 'john.doe@example.com', '123 Street', 'Stockholm', '10001');
---- Switch back to the original user
--REVERT;


---- Testing as owner
--USE BestWebshopDB;

--EXECUTE AS LOGIN = 'DbOwnerUser';  -- Switch to DbOwnerUser
---- Select customers (should work ✅)
--SELECT * FROM Customers;

---- Insert a new customer (should work ✅)
--INSERT INTO Customers (FirstName, LastName, Email, Address, City, PostalCode)
--VALUES ('Jane', 'Smith', 'jane.smith@example.com', '456 Avenue', 'Gothenburg', '40010');

---- Check if the new customer exists (should show the inserted row ✅)
--SELECT * FROM Customers WHERE Email = 'jane.smith@example.com';

---- Switch back to the original user
--REVERT;