# Est�gio de constru��o
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copie o arquivo do projeto e restaure as depend�ncias
COPY ["Attendance.Api/Attendance.Api.csproj", "Attendance.Api/"]
RUN dotnet restore "Attendance.Api/Attendance.Api.csproj"

# Copie o restante do c�digo-fonte
COPY . .

# Construa a aplica��o
WORKDIR "/src/Attendance.Api"
RUN dotnet build "Attendance.Api.csproj" -c Release -o /app/build

# Est�gio final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Copie a aplica��o constru�da do est�gio de constru��o
COPY --from=build /app/build .

# Set the environment variables
ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT Production

# Expor a porta para o Nginx
EXPOSE 80

# Execute a aplica��o
ENTRYPOINT ["dotnet", "Attendance.Api.dll"]