create table customers(
	customerid int primary key, customer_name nvarchar(100), city nvarchar(50)
);

create table orders(
	orderid int primary key,
	customerid int,
	orderdate date,
    totalamount decimal(10,2),
    foreign key (customerid) references customers(customerid)
);
create table orderdetails(
	orderdetailid int primary key,
    orderid int,
    productname nvarchar(100),
    quantity int,
    totalamount decimal(10,2),
    foreign key (orderid) references orders(orderid)

);
insert into customers values(
	(1, "joshi" , "mumbai"),
    (2, "kulkarni", "delhi"),
    (3, "deshpande", "pune")
);

insert into orders values(
	(101, 1 , "2024-01-15" , 5000.00),
    (102, 2 , "2024-02-10", 3000.00),
    (103, 1 , "2024-03-05" , 7000.00),
    (104, 3, "2024-03-05" , 2000.00)
);

INSERT INTO orderdetails VALUES
(1, 101, 'Laptop', 2, 1200.00),
(2, 102, 'Wireless Mouse', 5, 125.00),
(3, 103, 'Keyboard', 3, 225.00),
(4, 104, 'Monitor', 1, 350.00);

select customer_name 
from customers 
where customerid in (
	select customerid
    from orders
    where totalamount > (select avg(totalamount) from orders)
);

select productname
from orderdetails
where orderid in (
	select orderid
    from orders
    where customerid in (
		select customerid
		from customers
        where city = "mumbai"
	)
);
-- find highest spending customer

select customer_name
from customers
where customerid = (
    select customerid
    from orders
    group by customerid
    order by count(*) desc
    limit 1
);

create database assignment_two;
use assignment_two;

-- Create Table
CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Username VARCHAR(50),
    Email VARCHAR(100),
    Age INT CHECK (Age > 18)
);

-- Insert Sample Data
INSERT INTO Users (Id, Username, Email, Age)
VALUES
(1, 'John', 'john@gmail.com', 22),
(2, 'Alice', 'alice@gmail.com', 28),
(3, 'Bob', 'bob@gmail.com', 35),
(4, 'Emma', 'emma@gmail.com', 25),
(5, 'David', 'david@gmail.com', 40);

-- 1. Find users older than the average age
SELECT *
FROM Users
WHERE Age > (
    SELECT AVG(Age)
    FROM Users
);

-- 2. Find users whose age matches one of the ages greater than 25
SELECT *
FROM Users
WHERE Age IN (
    SELECT Age
    FROM Users
    WHERE Age > 25
);

-- 3. Check whether there is at least one user older than 30
SELECT CASE
    WHEN EXISTS (
        SELECT 1
        FROM Users
        WHERE Age > 30
    )
    THEN 'Yes'
    ELSE 'No'
END AS HasUserOlderThan30;

-- 4. Find users older than the average age of all other users
SELECT *
FROM Users u1
WHERE Age > (
    SELECT AVG(u2.Age)
    FROM Users u2
    WHERE u2.Id <> u1.Id
);

-- 5. Show each user along with the overall average age
SELECT
    Id,
    Username,
    Email,
    Age,
    (SELECT AVG(Age) FROM Users) AS OverallAverageAge
FROM Users;

-- ------------------------
show databases;
use mp_online;
create view customersalessummary as 
select 
	c.customerid,
    c.customer_name,
    sum(o.totalamount) as totalspent,
    count(o.orderid) as ordercount
from customers c
inner join orders o on c.customerid = o.customerid
group by c.customerid, c.customer_name;

select * from customersalessummary;

use assignment_two;

-- create departments table
create table departments (
    departmentid int primary key,
    departmentname varchar(50),
    city varchar(50)
);

-- create departments table
create table departments (
    departmentid int primary key,
    departmentname varchar(50),
    city varchar(50)
);

-- create employees table
create table employees (
    employeeid int primary key,
    employeename varchar(50),
    salary decimal(10,2),
    departmentid int,
    foreign key (departmentid) references departments(departmentid)
);

-- insert departments
insert into departments (departmentid, departmentname, city)
values
(1, 'hr', 'pune'),
(2, 'it', 'mumbai'),
(3, 'finance', 'pune'),
(4, 'marketing', 'delhi');

-- insert employees
insert into employees (employeeid, employeename, salary, departmentid)
values
(101, 'arjun', 60000, 1),
(102, 'neha', 45000, 2),
(103, 'rohan', 70000, 3),
(104, 'kavya', 55000, 1),
(105, 'aditya', 80000, 2);

-- 1. find employees whose salaries are above the company's average salary
select *
from employees
where salary > (
    select avg(salary)
    from employees
);

-- 2. list the names of employees who work in departments located in pune
select employeename
from employees
where departmentid in (
    select departmentid
    from departments
    where city = 'pune'
);

-- 3. show each employee with the average salary of their department
select
    employeename,
    salary,
    departmentid,
    (
        select avg(salary)
        from employees e2
        where e2.departmentid = e1.departmentid
    ) as department_average_salary
from employees e1;

-- 4. compute average salary per department and return only departments
-- with average salary above 50000
select
    departmentid,
    avg(salary) as average_salary
from employees
group by departmentid
having avg(salary) > 50000;

-- 5. return names of departments that have at least one employee
select departmentname
from departments d
where exists (
    select 1
    from employees e
    where e.departmentid = d.departmentid
);

-- 6. list the names of employees who belong to the hr department
select employeename
from employees
where departmentid = (
    select departmentid
    from departments
    where departmentname = 'hr'
);


