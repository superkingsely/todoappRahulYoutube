

dotnet ef migrations add init-user \\
--project infrastructure/infrastructure.csproj \\
--startup-project api/api.csproj

dotnet ef database update \\
--project infrastructure/infrastructure.csproj \\
--startup-project api/api.csproj