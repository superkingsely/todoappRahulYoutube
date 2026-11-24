

healthchecks for the api
req= /health

res
healthy



healthchecks for the db
req= /health

res
{
  "status": "Healthy",
  "totalDuration": 12127.6978,
  "checks": [
    {
      "name": "TodoAppDbContext",
      "status": "Healthy",
      "duration": 3979.0509,
      "description": null
    }
  ]
}