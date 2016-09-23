@set pa=x86
@reg query "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Environment" /v PROCESSOR_ARCHITECTURE | find /i "amd64"
@if %errorlevel% equ 0 set pa=amd64
@set pa=x86
@title MetadaneORTO_convert.exe (%PA%)
@echo MetadaneORTO_convert.exe (%PA%)

@call bin\setLIB.cmd

@set schema=zdj_metadane
@for %%f in (metadane\%schema%_*.*) do @copy %schema%\%schema%%%~xf metadane_zdj\%%~nf%%~xf
@for %%f in (metadane\%schema%_*.dbf) do @ogr2ogr -append metadane_zdj metadane %%~nf%
@pause