
find .PublishFiles/ -type f -and ! -path '*/wwwroot/images/*' ! -name 'appsettings.*' |xargs rm -rf
dotnet build;
rm -rf /home/HW/HW.Api/bin/Debug/.PublishFiles;
dotnet publish -o /home/HW/HW.Api/bin/Debug/.PublishFiles;
rm -rf /home/HW/HW.Api/bin/Debug/.PublishFiles/WMBlog.db;
# cp -r /home/HW/HW.Api/bin/Debug/.PublishFiles ./;
awk 'BEGIN { cmd="cp -ri /home/HW/HW.Api/bin/Debug/.PublishFiles ./"; print "n" |cmd; }'
echo "Successfully!!!! ^ please see the file .PublishFiles";