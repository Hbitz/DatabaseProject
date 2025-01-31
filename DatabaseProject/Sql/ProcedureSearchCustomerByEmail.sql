USE BestWebshopDB
GO

CREATE PROCEDURE [dbo].[GetCustomerByEmail]
    @Email NVARCHAR(100)
AS
BEGIN
    SELECT CustomerID, FirstName, LastName, Email, Address, City, PostalCode, RegisterDate
    FROM Customers
    WHERE Email = @Email;
END;
GO