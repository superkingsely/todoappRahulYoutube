

dotnet ef migrations add init \\
--project infrastructure/infrastructure.csproj \\
--startup-project api/api.csproj

dotnet ef database update \\
--project infrastructure/infrastructure.csproj \\
--startup-project api/api.csproj