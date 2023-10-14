# Stompy
A PowerShell function to perform timestomping on specified files and directories. The function can modify timestamps recursively for all files in a directory.

- Change timestamps for individual files or directories.
- Recursively apply timestamps to all files in a directory.
- Option to use specific credentials for remote paths or privileged files.

## Usage
- `-Path`: The path to the file or directory whose timestamps you wish to modify.
- `-NewTimestamp`: The new DateTime value you wish to set for the file or directory.
- `-Credentials`: (Optional) If you need to specify a different user's credentials.
- `-Recurse`: (Switch) If specified, apply the timestamp recursively to all files in the given directory.

## Usage Examples
Specify the `-Recurse` switch to apply timestamps recursively:

1. Change the timestamp of an individual file:
```
Invoke-Stompy -Path "C:\path\to\file.txt" -NewTimestamp "01/01/2023 12:00:00 AM"
```

2. Recursively change timestamps for all files in a directory:
```
Invoke-Stompy -Path "C:\path\to\file.txt" -NewTimestamp "01/01/2023 12:00:00 AM" -Recurse 
```

3. Use specific credentials:
```
$creds = Get-Credential
Invoke-Stompy -Path "C:\path\to\file.txt" -NewTimestamp "01/01/2023 12:00:00 AM" -Recurse -Credential $creds
```

## Demo:
![image](https://github.com/ZephrFish/Stompy/assets/5783068/81b42583-59cc-4084-acd8-8b41972195a0)
