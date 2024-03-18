@echo off

:START
echo #############################################################################
echo sourceFolder：代表你的vs生成项目的路径Debug
echo md5File：代表所有文件执行的md5加密效验值
echo destinationFolder ：代表更新的数据,全部
echo differentialFolder：代表差异更新的文件(如需要更新,只需要更新这部分)
echo 修改目录路径,请使用编辑文本;或者参数,直接写到vs生成后事件,获取路径即可
echo 如果使用vs生成后 请填写:  call "C:\Users\Administrator.DESKTOP-KTHCAT9\Desktop\差分更新.bat" $(ProjectName) $(ProjectDir) 前面你的命令存放位置
echo 你想要压缩的格式,目录 "E:\WinRar\WinRAR.exe" a -r -ep1 -u -x"002.bat" "C:\Users\Administrator.DESKTOP-KTHCAT9\Desktop\!ProjectName!.zip"
echo #############################################################################

echo 继续执行下面的命令...

setlocal enabledelayedexpansion

rem 下面是你的命令部分
set "sourceFolder=%2\bin\Debug"
set "md5File=md5_hashes.txt"
set "destinationFolder=%2\bin\Update"
set "differentialFolder=%2\bin\DiffUpDate"
set ProjectName=%1

if not exist "%destinationFolder%" mkdir "%destinationFolder%"
if not exist "%differentialFolder%" mkdir "%differentialFolder%"

cd /d "%sourceFolder%"

(for %%F in (*) do (
    set "fileName=%%F"
    for /f %%H in ('certutil -hashfile "%%F" MD5 ^| findstr /i /v "MD5 CertUtil 完成"') do (
        echo !fileName! : %%H
    )
)) > "%destinationFolder%\%md5File%"

cd /d "%destinationFolder%"
set "updateCount=0"

for /f "tokens=1,2" %%A in (%md5File%) do (
    set "fileName=%%A"
    set "hash=%%B"
    set "existingFile=%sourceFolder%\!fileName!"
    set "destinationFile=%destinationFolder%\!fileName!"

    if not exist "!destinationFile!" (
        copy "!existingFile!" "%destinationFolder%\!fileName!" > nul
        echo Copied: "!fileName!"
        set /a updateCount+=1
    ) else (
        certutil -hashfile "!existingFile!" MD5 | findstr /i /v "MD5 CertUtil 完成" > "%destinationFolder%\temp_hash.txt"
        certutil -hashfile "!destinationFile!" MD5 | findstr /i /v "MD5 CertUtil 完成" > "%destinationFolder%\temp_hash_dest.txt"
        fc /b "%destinationFolder%\temp_hash.txt" "%destinationFolder%\temp_hash_dest.txt" > nul

        if errorlevel 1 (
            copy "!existingFile!" "%destinationFolder%\!fileName!" > nul
            echo Updated: "!fileName!"
            set /a updateCount+=1
            copy "!existingFile!" "%differentialFolder%" > nul
        )

        del /q "%destinationFolder%\temp_hash.txt" "%destinationFolder%\temp_hash_dest.txt" > nul
    )
)

if %updateCount% gtr 0 (
    echo Files Updated. Copying updated files to A folder...
  "E:\WinRar\WinRAR.exe" a -r -ep1 -u -x"002.bat" "C:\Users\Administrator.DESKTOP-KTHCAT9\Desktop\!ProjectName!.zip" "%2\bin\DiffUpDate\*.*"
) else (
    echo No updates found.
)

pause
endlocal
