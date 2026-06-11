show databases;
create database mp_online;
use mp_online;

create table account(id int primary key, name varchar(50), city varchar(50), balance int);
INSERT INTO account (id, name, city, balance) VALUES
(101, 'Amit Sharma', 'Delhi', 5000),
(102, 'Priya Singh', 'Mumbai', 12000),
(103, 'Rahul Verma', 'Bangalore', 8000),
(104, 'Neha Gupta', 'Chennai', 15000),
(105, 'Vikram Patel', 'Ahmedabad', 7000),
(106, 'Sneha Reddy', 'Hyderabad', 20000),
(107, 'Arjun Mehta', 'Pune', 9500),
(108, 'Kavya Nair', 'Kochi', 11000),
(109, 'Rohan Das', 'Kolkata', 6000),
(110, 'Anjali Jain', 'Jaipur', 17500);

select *from  account;

SELECT MIN(balance) AS minimum_balance
FROM account;

create table customer(cust_id int primary key, c_name varchar(50), city varchar(50), country varchar(50) default "india");

INSERT INTO customer (cust_id, c_name, city) VALUES
(1, 'Amit Sharma', 'Delhi'),
(2, 'Priya Singh', 'Mumbai'),
(3, 'Rahul Verma', 'Bangalore'),
(4, 'Neha Gupta', 'Chennai'),
(5, 'Arjun Mehta', 'Pune');
INSERT INTO customer (cust_id, c_name, city, country) VALUES
(6, 'John Smith', 'New York', 'USA'),
(7, 'Emma Brown', 'London', 'UK'),
(8, 'Liam Wilson', 'Sydney', 'Australia');

select * from customer;

CREATE TABLE ticket_booking (
    ticket_id INT PRIMARY KEY,
    passenger_name VARCHAR(50) NOT NULL,
    source_city VARCHAR(50) NOT NULL,
    destination_city VARCHAR(50) NOT NULL,
    journey_date DATE NOT NULL,
    fare DECIMAL(10,2)
);

INSERT INTO ticket_booking
(ticket_id, passenger_name, source_city, destination_city, journey_date, fare)
VALUES
(101, 'Amit Sharma', 'Delhi', 'Mumbai', '2026-07-10', 2500.00),
(102, 'Priya Singh', 'Bangalore', 'Chennai', '2026-07-15', 1200.00),
(103, 'Rahul Verma', 'Hyderabad', 'Pune', '2026-07-20', 1800.00),
(104, 'Neha Gupta', 'Kolkata', 'Delhi', '2026-07-25', 2200.00),
(105, 'Arjun Mehta', 'Ahmedabad', 'Jaipur', '2026-08-01', 1500.00),
(106, 'Sneha Reddy', 'Chennai', 'Bangalore', '2026-08-05', 1100.00),
(107, 'Vikram Patel', 'Mumbai', 'Goa', '2026-08-10', 3000.00),
(108, 'Kavya Nair', 'Kochi', 'Trivandrum', '2026-08-12', 900.00),
(109, 'Rohan Das', 'Delhi', 'Lucknow', '2026-08-15', 1700.00),
(110, 'Anjali Jain', 'Jaipur', 'Udaipur', '2026-08-20', 1300.00);

select * from ticket_booking;

create database assignment_one;
use assignment_one;

-- 1. create accounts table
create table accounts (
    account_no int primary key,
    name varchar(50),
    balance decimal(10,2),
    check (balance >= 0)
);

-- 2. insert dummy data
insert into accounts (account_no, name, balance)
values
(101, 'amit', 10000.00),
(102, 'priya', 5000.00),
(103, 'rahul', 8000.00),
(104, 'neha', 12000.00);

-- 3. create stored procedure for money transfer
delimiter //

create procedure transfer_money(
    in sender_acc int,
    in receiver_acc int,
    in amount decimal(10,2)
)
begin
    declare sender_balance decimal(10,2);

    -- get sender balance
    select balance
    into sender_balance
    from accounts
    where account_no = sender_acc;

    -- check sufficient balance
    if sender_balance >= amount then

        start transaction;

        -- debit sender
        update accounts
        set balance = balance - amount
        where account_no = sender_acc;

        -- credit receiver
        update accounts
        set balance = balance + amount
        where account_no = receiver_acc;

        commit;

    else
        signal sqlstate '45000'
        set message_text = 'insufficient balance';
    end if;
end //

delimiter ;

-- 4. view data before transfer
select * from accounts;

-- 5. call procedure (transfer money)
call transfer_money(101, 102, 2000);

-- 6. view data after transfer
select * from accounts;

-- Q. calculate the total stock value for the product table

-- create table
create table product (
    product_id int primary key,
    product_name varchar(50),
    price decimal(10,2),
    quantity int
);

-- insert dummy data
insert into product (product_id, product_name, price, quantity)
values
(1, 'laptop', 50000.00, 10),
(2, 'mobile', 20000.00, 25),
(3, 'headphones', 1500.00, 50),
(4, 'keyboard', 1000.00, 30),
(5, 'mouse', 500.00, 40);

-- stored procedure for total stock value
delimiter //

create procedure total_stock_value()
begin
    select sum(price * quantity) as total_stock_value
    from product;
end //

delimiter ;

-- call procedure
call total_stock_value();
