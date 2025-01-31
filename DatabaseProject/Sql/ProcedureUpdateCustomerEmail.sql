USE BestWebshopDB
GO

CREATE PROCEDURE [dbo].[UpdateCustomerEmail]
    @CustomerID INT,
    @NewEmail NVARCHAR(100)
AS
BEGIN
    UPDATE Customers
    SET Email = @NewEmail
    WHERE CustomerID = @CustomerID;
END;
GO
