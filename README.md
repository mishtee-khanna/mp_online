# Practice Repo: C# Collections & SQL Exercises

This repository contains a mix of learning exercises split into two parts:

1. A **C# console project (`Collections`)** demonstrating core .NET collection types, custom comparers/comparables, generics, equality/hashing, and sorting techniques.
2. A set of **SQL practice scripts** covering database creation, joins, subqueries, views, and stored procedures using MySQL.

---

## 1. C# Collections Project

**Project file:** `Collections.csproj` (targets `.NET 10.0`, console app)

### Entry Point
- `Program.cs` — main entry point. Runs `Demo1.m1()` and contains homework notes on the .NET Collection Framework, `Equals`, and `GetHashCode`.

### Collection Demos
- **`Demo1.cs`** — covers `List<T>`, `Dictionary<TKey, TValue>`, `Stack<T>`, `HashSet<T>`, and `Hashtable`. Also includes a menu-driven "Student Record" console program (add/display/search/delete by ID using a dictionary).
- **`QueueDemo.cs`** — demonstrates `Queue<T>` operations: `Enqueue`, `Dequeue`, and `Peek`.
- **`SortingList.cs`** — demonstrates `LinkedList<T>` with `AddLast` and iteration.
- **`IEnumExample.cs`** — demonstrates `IEnumerable<T>` and the `yield return` keyword to lazily generate even numbers from a collection.

### Sorting & Comparers
- **`Sorting.cs`** — basic array/list sorting using `Array.Sort()` and `List<T>.Sort()`, including descending order via `Reverse()`.
- **`CustomSort.cs`** — implements `IComparer<string>` (`FilePriorityComparer`) to sort filenames by priority prefix (`URGENT`, `NORMAL`, other).
- **`Order.cs`** — implements `IComparer<string>` (`PriorityDate`) to sort order records by embedded date, both oldest-to-newest and newest-to-oldest.
- **`StudentSort.cs`** — implements `IComparable<T>` on `Student` and `Customer` classes to sort by name and age respectively, including a console-driven input version (`Test2`).
- **`StudentSort2.cs`** — demonstrates sorting via `IComparable`-style `Compare` plus a separate `IComparer<Student2>` (`StudentRollComparer`) to sort by name or by roll number.

### Generics
- **`MyGenericClass.cs`** — defines a generic wrapper class `GenericClass<T>` with `GetValue()`/`SetValue()`. 
  > ⚠️ **Note:** `MyGenericClass` itself currently has incomplete/invalid syntax (`Console.WriteLine(intobj.)`) and field-initializer statements placed directly in the class body — this needs to be moved into a `Main`/method body to compile.

### Equality & Hashing
- **`equalsexample.cs`** — overrides `Equals()` on `Person2` to compare by `Name` and `Age`.
- **`hashcodeEqualsExample.cs`** — compares behavior of a class with only `Equals()`/`GetHashCode()` overridden (`Person1`) vs. a class with neither (`Person`), demonstrating how `HashSet<T>` deduplication depends on both methods.

### Unfinished / Placeholder
- **`Songs.cs`** — contains a commented-out menu-driven playlist manager (add/display/search/delete songs) using a `Dictionary<string, string>`. Not currently active.

### Solution Files
- `console_framework.slnx`, `first_csharp.slnx` — solution files referencing other small console projects (`console_framework`, `first_csharp`) not included in this listing.

---

## 2. SQL Practice Scripts

### `11.6.26-sql-mpo.sql`
- Creates database **`mp_online`** with tables:
  - `account` — sample bank accounts with city/balance data; includes a `MIN(balance)` query.
  - `customer` — customer records with a default `country` of `"india"`.
  - `ticket_booking` — train/flight-style ticket bookings (source/destination city, journey date, fare).
- Creates database **`assignment_one`** with:
  - `accounts` table (with a `CHECK (balance >= 0)` constraint) and a **stored procedure `transfer_money`** that transfers funds between accounts inside a transaction, with an insufficient-balance check via `SIGNAL SQLSTATE`.
  - `product` table and a **stored procedure `total_stock_value`** that computes `SUM(price * quantity)`.

### `12.6.26-sql-mpo.sql`
- Creates `customers`, `orders`, and `orderdetails` tables (with foreign keys) and sample data.
  > ⚠️ **Note:** The `INSERT INTO ... VALUES(...)` statements for `customers` and `orders` use a single set of nested parentheses around multiple rows — this is invalid MySQL syntax and would need to be rewritten as `VALUES (row1), (row2), ...` (without the extra outer parentheses) to run correctly.
- Demonstrates **subqueries**:
  - Customers with above-average order totals.
  - Products ordered by customers in Mumbai.
  - Highest-spending customer (by order count).
- Creates database **`assignment_two`** with a `Users` table (age `CHECK (Age > 18)`) and demonstrates:
  - `WHERE ... > (subquery)`, `WHERE ... IN (subquery)`, `EXISTS`, correlated subqueries, and scalar subqueries in `SELECT`.
- Creates a **view** `customersalessummary` in `mp_online` joining `customers` and `orders` to summarize total spend and order count per customer.
- Adds `departments` and `employees` tables (with FK relationship) to `assignment_two`, and demonstrates:
  - Employees earning above average salary.
  - Employees in Pune-based departments.
  - Correlated subquery showing each employee alongside their department's average salary.
  - `GROUP BY ... HAVING` for departments with average salary > 50000.
  - `EXISTS` to find departments with at least one employee.
  - Employees belonging to the HR department.

  > ⚠️ **Note:** The `departments` table is created twice (duplicate `CREATE TABLE` statement) — the second statement would fail if run after the first succeeds.

---

## How to Run

### C# Project
```bash
cd Collections
dotnet run
```
Note: some files (`CustomSort.cs`, `Demo1.cs`, `IEnumExample.cs`, `QueueDemo.cs`, `Sorting.cs`) each define their own `Main` method. Only one entry point can be active per build — `Program.cs` is the active entry point as currently set up (top-level statements), so other `Main` methods would need to be invoked manually or renamed if you want to run them individually.

### SQL Scripts
Run in a MySQL client (e.g., MySQL Workbench or `mysql` CLI):
```bash
mysql -u <user> -p < 11.6.26-sql-mpo.sql
mysql -u <user> -p < 12.6.26-sql-mpo.sql
```
Run `11.6.26-sql-mpo.sql` first since `12.6.26-sql-mpo.sql` references the `mp_online` database it creates. Fix the noted syntax issues (duplicate table creation, malformed `INSERT ... VALUES`) before running the second script end-to-end.

---

## Suggested Next Steps
- Fix the syntax issues flagged above (`MyGenericClass.cs`, duplicate `departments` table, malformed `INSERT` statements).
- Consolidate multiple `Main` methods into a single menu-driven demo runner.
- Complete the commented-out playlist manager in `Songs.cs`.
