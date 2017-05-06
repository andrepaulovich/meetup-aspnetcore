FROM microsoft/aspnetcore:1.0
ARG source
WORKDIR /app
EXPOSE 80
COPY . .
ENTRYPOINT ["dotnet", "Meetup.Security.WebApi.dll"]
