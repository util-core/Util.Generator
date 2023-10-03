Write-Host "remove bin,obj..."
Get-ChildItem .\ -Include bin,obj -Recurse | Where-Object {$_.FullName -notmatch 'node_modules' } | foreach ($_) { remove-item $_.fullname -Force -Recurse }
Write-Host "remove completed."