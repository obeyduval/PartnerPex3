:: Creates a Variable for the Output File
@SET file="pex_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

:: ----------------------------------------
:: TITLE
:: ----------------------------------------
echo PEX TEST CASES (C1C Unnamed) >> %file%

:: ----------------------------------------
:: GOOD EXAMPLES
:: ----------------------------------------
::echo Testing Identifiers >> %file%
::bin\Debug\ConsoleApplication.exe testcases\pex1\test1.txt >> %file%
::echo. >> %file%

:: ----------------------------------------
:: BAD EXAMPLES
:: ----------------------------------------
::echo Running Incorrect Test Cases >> %file%
::echo. >> %file%

pause