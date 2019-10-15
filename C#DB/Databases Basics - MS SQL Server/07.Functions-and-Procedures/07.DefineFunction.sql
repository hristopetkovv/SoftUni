CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
		DECLARE @Index INT = 1
		WHILE (@Index <= LEN(@word))
		BEGIN
			DECLARE @Symbol NVARCHAR(1) = SUBSTRING(@word, @Index, 1)
				IF(CHARINDEX(@Symbol, @setOfLetters, 1) = 0)
				BEGIN
				RETURN 0
				END
				SET @Index = 1
		END
	RETURN 1
END
