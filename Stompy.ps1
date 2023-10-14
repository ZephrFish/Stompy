# Stompy
# ZephrFish 2023
function Invoke-Stompy {
    param(
        [Parameter(Mandatory=$true)]
        [string]$Path,

        [Parameter(Mandatory=$true)]
        [datetime]$NewTimestamp,

        [Parameter(Mandatory=$false)]
        [pscredential]$Credentials,

        [Parameter(Mandatory=$false)]
        [switch]$Recurse
    )

    $scriptBlock = {
        param(
            [string]$Path,
            [datetime]$NewTimestamp,
            [switch]$Recurse
        )

        # Resolve the items to be processed
        $items = if ($Recurse) {
            Get-ChildItem -Path $Path -File -Recurse
        } else {
            Get-Item -Path $Path
        }

        # Process each item
        foreach ($item in $items) {
            # Timestomp
            Write-Host "Modifying timestamps for $($item.FullName) to $NewTimestamp..."
            $item.CreationTime = $NewTimestamp
            $item.LastAccessTime = $NewTimestamp
            $item.LastWriteTime = $NewTimestamp
        }

        Write-Host "Timestamps modified successfully."

    }

    if ($Credentials) {
        $session = New-PSSession -Credential $Credentials
        Invoke-Command -Session $session -ScriptBlock $scriptBlock -ArgumentList $Path, $NewTimestamp, $Recurse
        Remove-PSSession $session
    }
    else {
        & $scriptBlock -Path $Path -NewTimestamp $NewTimestamp -Recurse:$Recurse.IsPresent
    }
}
