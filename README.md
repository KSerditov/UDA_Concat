Since MS SQL Server 2017 this is not needed anymore.

There is built-in [STRING_AGG](https://learn.microsoft.com/en-us/sql/t-sql/functions/string-agg-transact-sql?view=sql-server-2017) function now that does a great job on string contatenation.
Here is an example:
```sql
SELECT STRING_AGG([Name],', ' ) WITHIN GROUP (ORDER BY [id] ASC)
FROM [dbo].[Employees]
```
Assuming the following Employees table:
| Id          | Name  |
| ----------- | ----------- |
| 1      | John        |
| 2      | Mary        |
| 3      | Bob         |
| 4      | Jane        |
| 5      | Mike        |

It produces the following result:
```John, Mary, Bob, Jane, Mike```
