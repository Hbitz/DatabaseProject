USE BestWebshopDB
GO

CREATE VIEW CustomerOrderSummary AS
SELECT 
    c.CustomerID, 
    c.FirstName + ' ' + c.LastName AS CustomerName,
    COUNT(o.OrderID) AS TotalOrders,
    COALESCE(SUM(o.TotalAmount), 0) AS TotalSpent,
    COALESCE(SUM(od.Quantity), 0) AS TotalProducts 
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
LEFT JOIN OrderDetails od ON o.OrderID = od.OrderID  -- Join OrderDetails to get product quantity
GROUP BY c.CustomerID, c.FirstName, c.LastName;
