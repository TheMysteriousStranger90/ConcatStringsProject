FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ConcatStringsProject/ConcatStringsProject.csproj", "ConcatStringsProject/"]
RUN dotnet restore "ConcatStringsProject/ConcatStringsProject.csproj"
COPY . .
WORKDIR "/src/ConcatStringsProject"
RUN dotnet build "ConcatStringsProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConcatStringsProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConcatStringsProject.dll"]
