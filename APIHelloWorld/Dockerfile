FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY APIHelloWorld/APIHelloWorld.csproj APIHelloWorld/
RUN dotnet restore "APIHelloWorld/APIHelloWorld.csproj"
COPY . .
WORKDIR "/src/APIHelloWorld"
RUN dotnet build "APIHelloWorld.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIHelloWorld.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD dotnet APIHelloWorldHerokuDocker.dll
