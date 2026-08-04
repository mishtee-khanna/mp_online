# MP ONLINE — C#, SQL & Web Practice Repo

This repo is a running dump of coursework and self-practice exercises — mostly C# (.NET 10) and SQL, with a few standalone HTML/CSS pages. It's grown organically across a semester rather than being planned upfront, so it's organized as a flat file list rather than one folder per project. See the ⚠️ notes below before trying to build anything.

---

## ⚠️ Before You Build Anything

Every `.cs` file, and all six `.csproj`/project files (`Collections.csproj`, `EntityFramework.csproj`, `MVC_ConsoleApp.csproj`, `StudentRegistrationWebApp.csproj`, `WebApplication1.csproj`, `WebApplication2.csproj`), live in the **same root folder**. By default, an SDK-style `.csproj` automatically includes *every* `.cs` file sitting next to it — so running `dotnet build` in this folder as-is will pull in files with conflicting `Main` entry points (`Program.cs`, `HospitalProgram.cs`, `ShoppingCartApp.cs`, and the `Main()` methods inside `Demo1.cs`, `QueueDemo.cs`, `Sorting.cs`, `CustomSort.cs`, `IEnumExample.cs`) and fail with a multiple-entry-point error.

**To actually run something here:** copy the specific file(s) you want into their own folder alongside a single `.csproj`, or open the individual file in an IDE and run it in isolation.

---

## 1. C# Collections & OOP Practice

**Project file:** `Collections.csproj` (targets `.NET 10.0`, console app)

> ⚠️ **Note:** `Program.cs` no longer runs the Collections demos — it was overwritten with the ASP.NET Core bootstrap code for the `StudentRegistrationWebApp` project (see §4 below). The files below are complete and working individually, but nothing currently wires them up as the active entry point.

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
  > ⚠️ **Note:** currently has incomplete/invalid syntax (`Console.WriteLine(intobj.)`) and field-initializer statements placed directly in the class body — needs to move into a `Main`/method body to compile.

### Equality & Hashing
- **`equalsexample.cs`** — overrides `Equals()` on `Person2` to compare by `Name` and `Age`.
- **`hashcodeEqualsExample.cs`** — compares behavior of a class with only `Equals()`/`GetHashCode()` overridden (`Person1`) vs. a class with neither (`Person`), demonstrating how `HashSet<T>` deduplication depends on both methods.

### Unfinished / Placeholder
- **`Songs.cs`** — contains a commented-out menu-driven playlist manager (add/display/search/delete songs) using a `Dictionary<string, string>`. Not currently active.

---

## 2. MVC Pattern Console Demos

Three separate walkthroughs of the Model-View-Controller pattern applied to plain console apps (no web framework involved — "MVC" here means the classic separation of concerns, not ASP.NET MVC).

- **`BankingMVC.cs`** *(namespace `MVC_ConsoleApp`)* — `BankAccount` model, `BankView` for console output, `BankController` tying them together with in-memory data.
- **`StudentMVC.cs`** *(namespace `MVC_ConsoleApp`)* — same pattern applied to a `Student` model (`id`, `name`) with a matching `StudentView`/`StudentController`.
- **`MVCDB.cs`** *(namespace `MVC_BankingApp`)* — a second, SQL-Server-backed take on the banking MVC demo using `Microsoft.Data.SqlClient` instead of in-memory data.

> ⚠️ **Note:** `BankingMVC.cs` and `StudentMVC.cs` share the namespace `MVC_ConsoleApp` — fine on their own, but if both get pulled into the same project build, watch for member/type clashes.

---

## 3. ADO.NET / SQL Server Practice

Raw ADO.NET demos using `Microsoft.Data.SqlClient` directly (no ORM):

- **`HospitalProgram.cs`** — a menu-driven Doctor Appointment System (book/cancel/view appointments, monthly report) connecting to a local `HospitalDB`.
- **`ShoppingCartApp.cs`** — pulls products from a `ShoppingDB` and builds a running cart total.

Both use a hardcoded local connection string (`Server=localhost` / `Server=YOUR_SERVER_NAME`) — swap that for your own SQL Server instance before running.

---

## 4. Entity Framework Core + ASP.NET Core MVC Web App

**Project file:** `StudentRegistrationWebApp.csproj` (targets `.NET 10.0`, ASP.NET Core Web App with EF Core SQL Server provider)

This is the start of a proper ASP.NET Core MVC + EF Core web app (student registration), but only the entry-point scaffolding has been committed so far:

- **`Program.cs`** — standard ASP.NET Core bootstrap: registers MVC, wires up `ApplicationDbContext` via `AddDbContext`, sets `Students`/`Index` as the default route.
- **`appsettings.json`** / **`appsettings.Development.json`** — connection string pointing at a local `StudentRegistrationDB` via `(localdb)\MSSQLLocalDB`.
- **`StudentRegistrationWebApp.docx`** — assignment write-up/documentation for this project.

> ⚠️ **Note:** `Program.cs` references `StudentRegistrationWebApp.Data.ApplicationDbContext` and a `StudentsController`, but no `Data/`, `Controllers/`, or `Views/` folders exist in this repo yet — this project won't build or run until those are added. `StudentContext.cs` (namespace `EntityFramework`, empty stub class) looks like an earlier, abandoned attempt at the same idea under a different project (`EntityFramework.csproj`) and isn't wired to this one.

---

## 5. SQL Practice Scripts

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
  > ⚠️ **Note:** the `INSERT INTO ... VALUES(...)` statements for `customers` and `orders` use a single set of nested parentheses around multiple rows — invalid MySQL syntax; needs to be rewritten as `VALUES (row1), (row2), ...` to run correctly.
- Demonstrates **subqueries**: customers with above-average order totals, products ordered by customers in Mumbai, highest-spending customer by order count.
- Creates database **`assignment_two`** with a `Users` table (`CHECK (Age > 18)`) and demonstrates `WHERE ... > (subquery)`, `WHERE ... IN (subquery)`, `EXISTS`, correlated subqueries, and scalar subqueries in `SELECT`.
- Creates a **view** `customersalessummary` in `mp_online` joining `customers` and `orders` to summarize total spend and order count per customer.
- Adds `departments` and `employees` tables (FK relationship) to `assignment_two`, and demonstrates above-average-salary lookups, Pune-based department filters, a correlated subquery for department-average salary, `GROUP BY ... HAVING`, `EXISTS`, and an HR-department filter.
  > ⚠️ **Note:** `departments` is created twice (duplicate `CREATE TABLE`) — the second statement fails if run after the first succeeds.

---

## 6. Standalone HTML/CSS Pages

A handful of independent static pages — no shared stylesheet or linking between them, each is self-contained.

| File | Page |
|:---|:---|
| `reg_form.html` | Registration form |
| `normal_form.html` | Sign-up form |
| `employee.html` | Employee status table |
| `table.html` | Generic table layout |
| `table_two.html` | Sales data table |
| `quaterly_sales_report.html` | Quarterly sales report *(note: "quaterly" typo in the filename)* |
| `photography_blog_gallery.html` | Photo journal / gallery layout |
| `res.html` | "La Fiamma" restaurant landing page |

Just open any of them directly in a browser — no build step needed.

---

## 7. Orphaned Solution Files

These `.slnx` files reference project folders that aren't included in this repo, so they won't open/build as-is:

| Solution file | Points to |
|:---|:---|
| `Database.slnx` | `Database/Database.csproj` |
| `Eval_Assignment.slnx` | `Eval_Assignment/Eval_Assignment.csproj` |
| `StudentADO.slnx` | `WebApplication2/WebApplication2.csproj` |
| `WebApplication1.slnx` | `WebApplication1/WebApplication1.csproj` |
| `console_framework.slnx` | `console_framework/console_framework.csproj` |
| `first_csharp.slnx` | `first_csharp/first_csharp.csproj` |

Likely local-only projects that never got committed. Safe to ignore unless you're recreating the matching folders yourself.

---

## How to Run

### C# files (Collections / MVC demos / ADO.NET demos)
Move the file(s) you want into their own folder, add a matching `.csproj`, then:
```bash
dotnet run
```
Remember: with everything in one root folder, `dotnet build` here will hit multiple-entry-point errors (see the warning at the top).

### StudentRegistrationWebApp
Won't run yet — add the missing `Data/`, `Controllers/`, and `Views/` folders first (see §4).

### SQL Scripts
Run in a MySQL client (e.g., MySQL Workbench or `mysql` CLI):
```bash
mysql -u <user> -p < 11.6.26-sql-mpo.sql
mysql -u <user> -p < 12.6.26-sql-mpo.sql
```
Run `11.6.26-sql-mpo.sql` first since `12.6.26-sql-mpo.sql` references the `mp_online` database it creates. Fix the noted syntax issues (duplicate table creation, malformed `INSERT ... VALUES`) before running the second script end-to-end.

### HTML Pages
Open the `.html` file directly in a browser.

---

## Suggested Next Steps
- Split this into one folder per project — fixes the multiple-entry-point issue and makes each `.csproj` buildable on its own.
- Fix the syntax issues flagged above (`MyGenericClass.cs`, duplicate `departments` table, malformed `INSERT` statements).
- Add the missing `Data/`, `Controllers/`, `Views/` for `StudentRegistrationWebApp`, or drop `StudentContext.cs` if it's superseded.
- Consolidate multiple `Main` methods into a single menu-driven demo runner for the Collections project.
- Complete the commented-out playlist manager in `Songs.cs`.
- Fix the `quaterly_sales_report.html` filename typo.
