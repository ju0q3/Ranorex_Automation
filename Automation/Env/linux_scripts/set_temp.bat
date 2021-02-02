set tempdir=%TEMP%
set tempdir=%tempdir:~3%
set tempdir=%tempdir:\=/%

setx WIN_TEMP /cygdrive/c/%tempdir%

