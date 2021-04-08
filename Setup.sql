-- USE gregslistcsharp1;

-- CREATE TABLE cars
-- (
--     id INT AUTO_INCREMENT,
--     make VARCHAR(255) NOT NULL UNIQUE,
--     model VARCHAR(255) NOT NULL UNIQUE,
--     description VARCHAR(255),
--     price DECIMAL(6, 2) NOT NULL,

--     PRIMARY KEY (id)
-- );

-- INSERT INTO cars 
-- (make, model, description, price)
-- VALUES
-- ("Chevy", "Camaro", "average car", 40000)

-- -- Get ALL of a Collection
-- SELECT * FROM cars;

-- SELECT * FROM cars WHERE description="average car" OR id=1;

-- DELETE FROM cars WHERE id=1;

-- DELETE cars;
-- TRUNCATE cars;