# StompySharps
StompySharps is a utility tool written in C# (.NET Framework) designed to "stomp" (alter) the timestamps of specified files and directories. You can choose to recursively apply the timestamp to files within a directory and even leverage specific credentials to access files and directories.

## Usage
```
StompySharps.exe -path <path> -newTimestamp <datetime> [-recurse] [-username <username> -password <password>]
```

## Parameters:

- `-path`: Specifies the path of the file or directory whose timestamp you wish to modify.

- `-newTimestamp`: The new datetime value you wish to apply. This value should be provided in a valid datetime format (e.g., "2023-10-10 10:10:10").

- `-recurse` (Optional): If set, and if the path is a directory, it will recursively apply the timestamp to all files within that directory.

- `-username` (Optional): The username to be used if the file or directory requires specific credentials for access.

- `-password` (Optional): The password corresponding to the provided username.

## Example Execution

To modify the timestamp of all files in C:\ExampleFolder to "2023-10-10 10:10:10", you would run:
```
StompySharps.exe -path C:\ExampleFolder -newTimestamp "2023-10-10 10:10:10" -recurse
```

To modify the timestamp of a specific file `C:\Example.txt`:
```
StompySharps.exe -path C:\Example.txt -newTimestamp "2023-10-10 10:10:10"
```

If you need to provide specific credentials:
```
StompySharps.exe -path \\server\share\Example.txt -newTimestamp "2023-10-10 10:10:10" -username "DOMAIN\Username" -password "Password123"
```
