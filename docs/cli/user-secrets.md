dotnet user-secrets list

"ConnectionStrings":{
        "DefaultConnection":"Data Source=Test.db"
    },
    "Jwt":{
        "Secret":"YourSecretKeyHereandmust-be-long-enough-for-security-256bits-length-okay",
        "Issuer":"CJ-API",
        "Audience":"CJ-Users",
        "AccessTokenExpirationMinutes":60
    }