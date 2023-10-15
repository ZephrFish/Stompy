# Stompy
A PowerShell function to perform timestomping on specified files and directories. The function can modify timestamps recursively for all files in a directory. There's also a C# version [linked in the same repo here](https://github.com/ZephrFish/Stompy/tree/main/StompySharps).

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
![image](https://github.com/ZephrFish/Stompy/assets/5783068/0ba615ca-ba50-4435-be5c-2e9b0983bc2b)


![image](https://github.com/ZephrFish/Stompy/assets/5783068/e8f9ae8e-bcdd-4a1d-8d68-7f787021164e)
