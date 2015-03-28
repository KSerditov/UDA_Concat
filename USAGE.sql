CREATE ASSEMBLY ClrCustomConcatFunction 
from 'C:\Users\Urich\Documents\Visual Studio 2013\Projects\CustomConcat\CustomConcat\bin\Release\CustomConcat.dll' ;

CREATE AGGREGATE dbo.CustomConcat (@value nvarchar(max))
RETURNS nvarchar(max)
EXTERNAL NAME ClrCustomConcatFunction.[CustomConcat.CustomConcat];

--Example of use
SELECT dbo.CustomConcat(firstname) FROM HR.Employees
GROUP BY mgrid;