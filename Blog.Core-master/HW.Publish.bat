color B

del  .PublishFiles\*.*   /s /q

dotnet restore

dotnet build

cd HW.Api

dotnet publish -o ..\HW.Api\bin\Debug\net7.0\

md ..\.PublishFiles

xcopy ..\HW.Api\bin\Debug\net7.0\*.* ..\.PublishFiles\ /s /e 

echo "Successfully!!!! ^ please see the file .PublishFiles"

cmd