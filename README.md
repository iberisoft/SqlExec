# SqlExec

![.NET Framework](https://github.com/iberisoft/SqlExec/workflows/.NET%20Framework/badge.svg)

This tool executes scripts in Microsoft SQL Server.

Usage: `SqlExec script-file [output-file]`. If `output-file` defined the script is treated as a query, resulting rows output to
the file in CSV format.

## Configuration

The tool is configured in file SqlExec.exe.config.

Database connection is defined below:
```
    <connectionStrings>
        <add name="SqlExec.Properties.Settings.ConnectionString" connectionString="Data Source=(local)\SQLEXPRESS;Initial Catalog=Ndt;Integrated Security=True"
            providerName="System.Data.SqlClient" />
    </connectionStrings>
```
