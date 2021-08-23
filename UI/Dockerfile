FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 443/udp
COPY ./build .
ENTRYPOINT ["dotnet", "UI.dll"]