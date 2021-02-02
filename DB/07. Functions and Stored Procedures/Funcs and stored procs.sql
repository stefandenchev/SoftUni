--05. Salary Level Function
CREATE /*OR ALTER*/ FUNCTION  ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	IF @Salary IS NULL
		RETURN NULL
	IF @Salary < 30000
		RETURN 'Low'
	ELSE IF @Salary <= 50000
		RETURN 'Average'
	ELSE
		RETURN 'High'
	RETURN NULL
END