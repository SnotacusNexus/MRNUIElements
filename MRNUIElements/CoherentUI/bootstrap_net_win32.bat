@echo off
@echo Bootstrapping Coherent UI installation...

call :CopyLocales
call :BootDebugger

IF EXIST Samples call :BootSamples

IF EXIST Activator\Activator.exe Activator\Activator.exe --host bin\Win32

goto :EOF


:CopyLocales
@echo Copying locales...
mkdir bin\Win32\locales
xcopy bin\locales\* bin\Win32\locales /E /i
goto :EOF

:BootDebugger
@echo Bootstrapping Debugger...
mkdir Debugger\host
xcopy bin\Win32\* Debugger\Win32\host /E /i
xcopy Debugger\html\* Debugger\Win32\html /E /i
goto :EOF

:BootSamples
@echo Bootstrapping Samples...
xcopy bin\Win32\* Samples\UI\bin /E /i
copy License.cs Samples\UI\C#\
goto :EOF
