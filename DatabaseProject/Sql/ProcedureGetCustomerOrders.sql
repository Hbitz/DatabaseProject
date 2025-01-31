USE BestWebshopDB
GO

-- Get all the orders of a customer 
CREATE PROCEDURE GetCustomerOrders
    @CustomerID INT
AS
BEGIN
    SELECT 
        Orders.OrderID, 
        Orders.OrderDate, 
        Orders.TotalAmount, 
        OrderDetails.ProductID, 
        Products.ProductName, 
        OrderDetails.Quantity, 
        OrderDetails.Price AS ItemPrice
    FROM Orders
    INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
    INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
    WHERE Orders.CustomerID = @CustomerID
    ORDER BY Orders.OrderDate DESC;
END;
GO

