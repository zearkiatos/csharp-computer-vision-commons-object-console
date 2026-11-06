@echo off
REM Console application runner script for Windows
REM This script provides commands to build and run the Computer Vision Console

setlocal enabledelayedexpansion

if "%1"=="run" (
    dotnet run --project ComputerVisionCommonsObjectConsole.csproj
    goto end
)


if "%1"=="build" (
    dotnet build ComputerVisionCommonsObjectConsole.csproj
    goto end
)

if "%1"=="" (
    echo Usage: run.bat [command]
    echo.
    echo Commands:
    echo   run       - Build and run the console application
    echo   build     - Build the console application only
    goto end
)

echo Unknown command: %1
echo Use 'run.bat' with no arguments to see available commands.

:end
endlocal