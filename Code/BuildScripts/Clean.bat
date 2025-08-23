REM Clean.bat
cd D:\Dev\CMS\Code\CMS.Maui
rmdir /s /q bin
rmdir /s /q obj
cd D:\Dev\CMS\Code\CMS.Domain
rmdir /s /q bin
rmdir /s /q obj
cd D:\Dev\CMS\Code\CMS.Shared
rmdir /s /q bin
rmdir /s /q obj
cd D:\Dev\CMS\Code\CMS.Api
rmdir /s /q bin
rmdir /s /q obj
rmdir /s /q D:\Dev\CMS\Code\.vs
dotnet clean