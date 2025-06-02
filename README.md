# SqlExec

[![.NET Framework](https://github.com/iberisoft/SqlExec/actions/workflows/dotnet.yml/badge.svg)](https://github.com/iberisoft/SqlExec/actions/workflows/dotnet.yml)

This tool executes scripts in Microsoft SQL Server.

Usage: `SqlExec script-file [output-file]`. If `output-file` defined the script is treated as a query, resulting rows output to
the file in CSV format.

## Configuration

The tool is configured in file `appsettings.json`.

Database connection is defined below:
```
{
  "ConnectionString": "Server=(local)\\SQLEXPRESS;Database=XPacs;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
}
```
