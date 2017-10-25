@echo off
@echo Bootstrapping Coherent UI installation...

call :CopyLocales
call :BootDebugger

IF EXIST Samples call :BootSamples

IF EXIST Activator\Activator.exe Activator\Activator.exe --host bin\Win64

goto :EOF


:CopyLocales
@echo Copying locales...
mkdir bin\Win64\locales
xcopy bin\locales\* bin\Win64\locales /E /i
goto :EOF

:BootDebugger
@echo Bootstrapping Debugger...
mkdir Debugger\host
xcopy bin\Win64\* Debugger\Win64\host /E /i
xcopy Debugger\html\* Debugger\Win64\html /E /i
goto :EOF

:BootSamples
@echo Bootstrapping Samples...
xcopy bin\Win64\* Samples\UI\bin /E /i
copy License.cs Samples\UI\C#\
goto :EOF
