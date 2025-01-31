-- Search name via user input text
USE BestWebshopDB
GO

CREATE PROCEDURE SearchCustomersByName
    @Keyword NVARCHAR(50)
AS
BEGIN
    SELECT CustomerID, FirstName, LastName, Email, City, Address, PostalCode, RegisterDate
    FROM Customers
    WHERE FirstName LIKE '%' + @Keyword + '%' OR LastName LIKE '%' + @Keyword + '%'
    ORDER BY FirstName;
END;
