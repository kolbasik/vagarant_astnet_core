FROM microsoft/aspnetcore:1.1.0
ENTRYPOINT ["dotnet", "aspnetweb.dll"]
ARG source=.
WORKDIR /app
EXPOSE 80
COPY $source .
