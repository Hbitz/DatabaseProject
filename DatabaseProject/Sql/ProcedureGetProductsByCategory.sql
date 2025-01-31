USE BestWebshopDB
GO

-- Gets all the products in a chosen category determined by catergoryID
CREATE PROCEDURE GetProductsByCategory
    @CategoryID INT
AS
BEGIN
    SELECT 
        Products.ProductID, 
        Products.ProductName, 
        Products.Description, 
        Products.Price, 
        Products.StockQuantity, 
		Products.CategoryID,
        Categories.CategoryName
    FROM Products
    INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID
    WHERE Products.CategoryID = @CategoryID
    ORDER BY Products.ProductName;
END;
GO
