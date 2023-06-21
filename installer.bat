@echo off
setlocal
set "source_folder=%cd%\nunit\net6.0"
set "target_folder=%cd%\MyFramework\bin\Debug\net6.0"
xcopy /E /Y "%source_folder%\*" "%target_folder%"
endlocal