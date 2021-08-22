FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /App
COPY ./build .
EXPOSE 80/tcp
EXPOSE 443/udp
ENTRYPOINT ["dotnet", "API.dll"]