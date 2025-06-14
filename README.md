# SqlExec

[![.NET](https://github.com/iberisoft/SqlExec/actions/workflows/dotnet.yml/badge.svg)](https://github.com/iberisoft/SqlExec/actions/workflows/dotnet.yml)

This tool executes scripts in Microsoft SQL Server.

Usage: `SqlExec script-file [output-file]`. If `output-file` is defined, the script is treated as a query, resulting in rows being output to
CSV file.

## Configuration

The tool is configured in the file `appsettings.json`.

The database connection is defined below:
```
{
  "ConnectionString": "Server=(local)\\SQLEXPRESS;Database=XPacs;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
}
```
