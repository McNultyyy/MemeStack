FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as build
WORKDIR /webapi

# copy csproj and restore
COPY *.csproj ./aspnetapp/
RUN cd ./aspnetapp/ && dotnet restore 

# copy all files and build
COPY ./ ./aspnetapp/
WORKDIR /webapi/aspnetapp
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine as runtime
WORKDIR /webapi
COPY --from=build /webapi/aspnetapp/out ./
ENTRYPOINT [ "dotnet", "webapi.dll" ]