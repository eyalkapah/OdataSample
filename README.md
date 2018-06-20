Test from Sam:

---
Sam Xu "saxu@microsoft.com"

## My changes

1. Update to the following nightly build
```
7.0.0-Nightly201806192313
```

2. I did some changes for the connection string. 
3. I changed the port, because 5000 is used by other process.
4. Nothing else

## Query with $select

```C#
Get http://localhost:5009/odata/Teams?$select=Name
```

I got the following response body:

```json
{
    "@odata.context": "http://localhost:5009/odata/$metadata#Teams(Name)",
    "value": [
        {
            "Name": "Russia"
        },
        {
            "Name": "Saudi Arabia"
        },
        {
            "Name": "Egypt"
        },
        {
            "Name": "Uruguay"
        },
        {
            "Name": "Portugal"
        },
        {
            "Name": "Spain"
        },
        {
            "Name": "Morocco"
        },
        {
            "Name": "Iran"
        },
        {
            "Name": "France"
        },
        {
            "Name": "Australia"
        },
        {
            "Name": "Peru"
        },
        {
            "Name": "Denmark"
        },
        {
            "Name": "Argentina"
        },
        {
            "Name": "Iceland"
        },
        {
            "Name": "Croatia"
        },
        {
            "Name": "Nigeria"
        },
        {
            "Name": "Brazil"
        },
        {
            "Name": "Switzerland"
        },
        {
            "Name": "Costa Rica"
        },
        {
            "Name": "Serbia"
        },
        {
            "Name": "Germany"
        },
        {
            "Name": "Mexico"
        },
        {
            "Name": "Sweden"
        },
        {
            "Name": "South Korea"
        },
        {
            "Name": "Belgium"
        },
        {
            "Name": "Panama"
        },
        {
            "Name": "Tunisia"
        },
        {
            "Name": "England"
        },
        {
            "Name": "Poland"
        },
        {
            "Name": "Senegal"
        },
        {
            "Name": "Colombia"
        },
        {
            "Name": "Japan"
        }
    ]
}
```

from the debug window:
```C#
dbug: Microsoft.EntityFrameworkCore.Database.Command[20100]
      Executing DbCommand [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [t].[Name] AS [Value0], [t].[Id] AS [Value]
      FROM [Teams] AS [t]
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (71ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [t].[Name] AS [Value0], [t].[Id] AS [Value]
      FROM [Teams] AS [t]
dbug: Microsoft.EntityFrameworkCore.Database.Command[20300]
      A data reader was disposed.
```

## Query with $expand

```C#
http://localhost:5009/odata/Teams(1)?$expand=Players
```

```json
{
    "@odata.context": "http://localhost:5009/odata/$metadata#Teams",
    "value": [
        {
            "Id": 1,
            "GroupId": 1,
            "Name": "Russia",
            "Rank": 61,
            "Players": []
        }
    ]
}
```
from the debug window:
```C#
dbug: Microsoft.EntityFrameworkCore.Database.Command[20100]
      Executing DbCommand [Parameters=[@__entity_0_Id='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT [t].[Id], [t].[GroupId], [t].[Name], [t].[Rank]
      FROM [Teams] AS [t]
      WHERE [t].[Id] = @__entity_0_Id
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (27ms) [Parameters=[@__entity_0_Id='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT [t].[Id], [t].[GroupId], [t].[Name], [t].[Rank]
      FROM [Teams] AS [t]
      WHERE [t].[Id] = @__entity_0_Id
dbug: Microsoft.EntityFrameworkCore.Database.Command[20300]
      A data reader was disposed.
dbug: Microsoft.EntityFrameworkCore.Database.Command[20100]
      Executing DbCommand [Parameters=[@_outer_Id='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT [p].[Id], [p].[BirthDate], [p].[Name], [p].[Position], [p].[TeamId]
      FROM [Players] AS [p]
      WHERE @_outer_Id = [p].[TeamId]
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (73ms) [Parameters=[@_outer_Id='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT [p].[Id], [p].[BirthDate], [p].[Name], [p].[Position], [p].[TeamId]
      FROM [Players] AS [p]
      WHERE @_outer_Id = [p].[TeamId]
dbug: Microsoft.EntityFrameworkCore.Database.Command[20300]
      A data reader was disposed.
```


## Query with nested $select

```C#
GET https://localhost:44349/odata/Groups(1)?$expand=Teams($select=Name)
```

I can get the following information:

```json
{
    "@odata.context": "http://localhost:5009/odata/$metadata#Groups(Teams(Name))",
    "value": [
        {
            "Id": 1,
            "Name": "A",
            "Teams": [
                {
                    "Name": "Russia"
                },
                {
                    "Name": "Saudi Arabia"
                },
                {
                    "Name": "Egypt"
                },
                {
                    "Name": "Uruguay"
                }
            ]
        }
    ]
}
```

from the debug window:
```C#
dbug: Microsoft.EntityFrameworkCore.Database.Command[20100]
      Executing DbCommand [Parameters=[@_outer_Id='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT N'940ea125-8238-4103-a89d-3f2af0b70dbb' AS [ModelID], N'Name' AS [Name1], [t0].[Name] AS [Value0], N'Id' AS [Name0], [t0].[Id] AS [Value]
      FROM [Teams] AS [t0]
      WHERE @_outer_Id = [t0].[GroupId]
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (22ms) [Parameters=[@_outer_Id='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT N'940ea125-8238-4103-a89d-3f2af0b70dbb' AS [ModelID], N'Name' AS [Name1], [t0].[Name] AS [Value0], N'Id' AS [Name0], [t0].[Id] AS [Value]
      FROM [Teams] AS [t0]
      WHERE @_outer_Id = [t0].[GroupId]
dbug: Microsoft.EntityFrameworkCore.Database.Command[20300]
      A data reader was disposed.
```


