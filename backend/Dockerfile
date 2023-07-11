FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GuestBook.WebAPI/GuestBook.WebAPI.csproj", "GuestBook.WebAPI/"]
COPY ["GuestBook.DAL/GuestBook.DAL.csproj", "GuestBook.DAL/"]
COPY ["GuestBook.Common/GuestBook.Common.csproj", "GuestBook.Common/"]
COPY ["GuestBook.BLL/GuestBook.BLL.csproj", "GuestBook.BLL/"]
RUN dotnet restore "GuestBook.WebAPI/GuestBook.WebAPI.csproj"
COPY . .
WORKDIR "/src/GuestBook.WebAPI"
RUN dotnet build "GuestBook.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GuestBook.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuestBook.WebAPI.dll"]
