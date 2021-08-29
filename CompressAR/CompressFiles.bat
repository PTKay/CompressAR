@echo off
cd /d "%~dp0"

if "%~1" == "" (
  CompressAR
  exit /b
)

CompressAR -c "%~1"