USE BestWebshopDB
GO

CREATE VIEW ProductView AS
SELECT 
    p.ProductID, 
    p.ProductName, 
    p.Description, 
    p.Price, 
    p.StockQuantity, 
    c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID;
