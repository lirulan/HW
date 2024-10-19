#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#这种模式是直接在构建镜像的内部编译发布dotnet项目。
#注意下容器内输出端口是9291
#如果你想先手动dotnet build成可执行的二进制文件，然后再构建镜像，请看.Api层下的dockerfile。


#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HW.Api/HW.Api.csproj", "HW.Api/"]
COPY ["HW.Extensions/HW.Extensions.csproj", "HW.Extensions/"]
COPY ["HW.EventBus/HW.EventBus.csproj", "HW.EventBus/"]
COPY ["HW.Common/HW.Common.csproj", "HW.Common/"]
COPY ["HW.Model/HW.Model.csproj", "HW.Model/"]
COPY ["HW.Serilog.Es/HW.Serilog.Es.csproj", "HW.Serilog.Es/"]
COPY ["Ocelot.Provider.Nacos/Ocelot.Provider.Nacos.csproj", "Ocelot.Provider.Nacos/"]
COPY ["HW.Services/HW.Services.csproj", "HW.Services/"]
COPY ["HW.IServices/HW.IServices.csproj", "HW.IServices/"]
COPY ["HW.Repository/HW.Repository.csproj", "HW.Repository/"]
COPY ["HW.Tasks/HW.Tasks.csproj", "HW.Tasks/"]
COPY ["build", "build/"]
RUN dotnet restore "HW.Api/HW.Api.csproj"
COPY . .
WORKDIR "/src/HW.Api"
RUN dotnet build "HW.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HW.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 9291 
ENTRYPOINT ["dotnet", "HW.Api.dll"]
