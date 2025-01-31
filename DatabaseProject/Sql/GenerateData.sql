USE BestWebshopDB
GO
-- Insert example data into Customers (15 entries)
INSERT INTO Customers (FirstName, LastName, Email, Address, City, PostalCode)
VALUES
('Anna', 'Svensson', 'anna.svensson@email.com', 'Main Street 1', 'Stockholm', '11122'),
('Bjorn', 'Karlsson', 'bjorn.karlsson@email.com', 'King Street 5', 'Gothenburg', '41137'),
('Cecilia', 'Johansson', 'cecilia.johansson@email.com', 'Lund Road 12', 'Malmo', '21748'),
('David', 'Andersson', 'david.andersson@email.com', 'West Street 7', 'Uppsala', '75321'),
('Erika', 'Nilsson', 'erika.nilsson@email.com', 'South Road 3', 'Helsingborg', '25223'),
('Frank', 'Olsson', 'frank.olsson@email.com', 'Hill Road 18', 'Lund', '22234'),
('Grace', 'Larsson', 'grace.larsson@email.com', 'Lake Street 10', 'Vasteras', '72132'),
('Hugo', 'Berg', 'hugo.berg@email.com', 'Forest Road 25', 'Linkoping', '58134'),
('Isabella', 'Lind', 'isabella.lind@email.com', 'River Road 15', 'Orebro', '70371'),
('Jack', 'Ek', 'jack.ek@email.com', 'Sunny Street 9', 'Stockholm', '11456'),
('Karen', 'Nord', 'karen.nord@email.com', 'Elm Street 13', 'Gothenburg', '41255'),
('Leo', 'Sand', 'leo.sand@email.com', 'Valley Road 2', 'Malmo', '21625'),
('Mia', 'Hill', 'mia.hill@email.com', 'Mountain Road 17', 'Uppsala', '75434'),
('Oscar', 'Palm', 'oscar.palm@email.com', 'Bridge Street 4', 'Helsingborg', '25112'),
('Sophia', 'Strand', 'sophia.strand@email.com', 'Ocean Road 8', 'Lund', '22143');

INSERT INTO Categories (CategoryName)
VALUES
('Elektronik'),
('Böcker'),
('Kläder'),
('Hem och Trädgård'),
('Sport och Fritid');

-- Insert example data into Products (18 entries)
INSERT INTO Products (ProductName, Description, Price, StockQuantity, CategoryID)
VALUES
('Smartphone', 'Modern smartphone with 128GB storage', 5999.99, 50, 1),
('Laptop', '14-inch laptop with 16GB RAM', 8999.99, 30, 1),
('Tablet', 'High-performance tablet with 10-inch screen', 4999.99, 40, 1),
('Novel', 'Exciting novel by a renowned author', 199.99, 100, 2),
('Cookbook', 'A collection of gourmet recipes', 299.99, 80, 2),
('Children''s Book', 'Illustrated book for kids', 99.99, 120, 2),
('T-Shirt', 'Soft cotton t-shirt in various colors', 249.99, 75, 3),
('Jeans', 'Comfortable and durable jeans', 599.99, 50, 3),
('Jacket', 'Stylish winter jacket', 999.99, 25, 3),
('Grill', 'Charcoal grill for summer barbecues', 1299.99, 20, 4),
('Chair', 'Ergonomic office chair', 1499.99, 35, 4),
('Table Lamp', 'LED desk lamp with adjustable brightness', 399.99, 60, 4),
('Soccer Ball', 'Official FIFA match ball', 399.99, 40, 5),
('Tennis Racket', 'Professional tennis racket', 799.99, 30, 5),
('Yoga Mat', 'Non-slip yoga mat for exercises', 299.99, 50, 5),
('Headphones', 'Wireless noise-canceling headphones', 1999.99, 20, 1),
('Backpack', 'Waterproof backpack with multiple compartments', 599.99, 60, 3),
('Watch', 'Smartwatch with fitness tracking', 2499.99, 15, 1);

-- Insert example data into Orders (15 entries)
INSERT INTO Orders (CustomerID, TotalAmount)
VALUES
(1, 6199.98),
(2, 249.99),
(3, 1299.99),
(4, 399.99),
(5, 199.99),
(6, 599.99),
(7, 1499.99),
(8, 3999.98),
(9, 499.98),
(10, 899.98),
(11, 1299.99),
(12, 6999.98),
(13, 3499.97),
(14, 199.99),
(15, 2499.99);


-- Insert example data into OrderDetails (45 entries)
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price)
VALUES
(1, 1, 1, 5999.99),
(1, 2, 1, 899.99),
(2, 7, 1, 249.99),
(3, 10, 1, 1299.99),
(4, 13, 1, 399.99),
(5, 4, 1, 199.99),
(6, 8, 1, 599.99),
(7, 11, 1, 1499.99),
(8, 16, 2, 1999.99),
(9, 5, 2, 249.99),
(10, 12, 2, 449.99),
(11, 6, 3, 99.99),
(12, 1, 1, 5999.99),
(12, 15, 1, 999.99),
(13, 9, 3, 999.99),
(14, 4, 1, 199.99),
(15, 18, 1, 2499.99),
(1, 3, 2, 4999.99),
(2, 5, 2, 299.99),
(3, 6, 3, 99.99),
(4, 7, 2, 249.99),
(5, 8, 1, 599.99),
(6, 9, 2, 999.99),
(7, 10, 1, 1299.99),
(8, 11, 1, 1499.99),
(9, 12, 2, 399.99),
(10, 13, 1, 399.99),
(11, 14, 2, 799.99),
(12, 15, 1, 999.99),
(13, 16, 2, 1999.99),
(14, 17, 1, 599.99),
(15, 18, 1, 2499.99),
(1, 5, 1, 299.99),
(2, 9, 1, 999.99),
(3, 11, 1, 1499.99),
(4, 2, 1, 899.99),
(5, 8, 1, 599.99),
(6, 3, 1, 4999.99),
(7, 6, 2, 99.99),
(8, 14, 1, 799.99),
(9, 4, 1, 199.99),
(10, 12, 1, 399.99),
(11, 10, 1, 1299.99),
(12, 18, 2, 2499.99);


-- Insert example data into Payments (15 entries)
INSERT INTO Payments (OrderID, PaymentDate, Amount, PaymentMethod)
VALUES
(1, GETDATE(), 6199.98, 'Credit Card'),
(2, GETDATE(), 249.99, 'Swish'),
(3, GETDATE(), 1299.99, 'Invoice'),
(4, GETDATE(), 399.99, 'Credit Card'),
(5, GETDATE(), 199.99, 'Swish'),
(6, GETDATE(), 599.99, 'PayPal'),
(7, GETDATE(), 1499.99, 'Credit Card'),
(8, GETDATE(), 3999.98, 'Credit Card'),
(9, GETDATE(), 499.98, 'Swish'),
(10, GETDATE(), 899.98, 'PayPal'),
(11, GETDATE(), 1299.99, 'Invoice'),
(12, GETDATE(), 6999.98, 'Credit Card'),
(13, GETDATE(), 3499.97, 'Credit Card'),
(14, GETDATE(), 199.99, 'Swish'),
(15, GETDATE(), 2499.99, 'Credit Card');
