 select *
from INFORMATION_SCHEMA.COLUMNS
where TABLE_NAME='emp'
 


 DECLARE @tab NVARCHAR(50), @col1 NVARCHAR(50),@col2 NVARCHAR(50), @st NVARCHAR(MAX); SET @tab = N'Orders'; SET @col1 = N'OrderID'; SET @col2 = N'OrderDate'; SET @st = N'SELECT '+ @col1 +' , ' + @col2 +' FROM ' + @tab;EXEC sp_executesql @st; 


CREATE PROCEDURE PARSETABLETOXML @OUTPUTXML XML=''OUT 
AS
BEGIN
	SET @OUTPUTXML=(SELECT *	
					FROM Orders
					FOR XML PATH('OrderRow'),ROOT('Orders'))

END

DECLARE @OUTPUT_XML XML
EXEC PARSETABLETOXML @OUTPUT_XML OUT
SELECT @OUTPUT_XML

-------

CREATE TABLE EMP(EMPNO INT, EMPNAME NVARCHAR(20), SALARY NUMERIC(10,2))

Alter PROCEDURE PARSEXMLTOTABLE (@INPUTXML XML)
AS
BEGIN
   INSERT INTO EMP(EMPNO,EMPNAME,SALARY)
	SELECT
    RESULTS.EMPLOYEELIST.value('EMPNO[1]','INT') AS EMPNO,
	RESULTS.EMPLOYEELIST.value('EMPNAME[1]','NVARCHAR(20)') AS EMPNAME,
	RESULTS.EMPLOYEELIST.value('SALARY[1]','NUMERIC(10,2)') AS SALARY
	FROM @INPUTXML.nodes('EMPLOYEELIST/EMPLOYEE') RESULTS(EMPLOYEELIST)
	SELECT * FROM EMP
END

DECLARE @FILEXML XML = '
<EMPLOYEELIST>
    <EMPLOYEE>
  <EMPNO>10</EMPNO>
  <EMPNAME>BHAVANA</EMPNAME>
  <SALARY>4000</SALARY>
</EMPLOYEE>
    <EMPLOYEE>
  <EMPNO>11</EMPNO>
  <EMPNAME>VISHAL</EMPNAME>
  <SALARY>3000</SALARY>
</EMPLOYEE>
<EMPLOYEE>
  <EMPNO>12</EMPNO>
  <EMPNAME>AMIT</EMPNAME>
  <SALARY>3500</SALARY>
</EMPLOYEE>
</EMPLOYEELIST>'


EXEC ParseXMLToTable @FILEXML;

SELECT * FROM EMP



