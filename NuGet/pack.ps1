$root = (split-path -parent $PSScriptRoot)

Write-Host "ROOT - " + $root -ForegroundColor Green

$version = [System.Reflection.Assembly]::LoadFile("$root\Haarlemmertrekvaart\bin\Release\Haarlemmertrekvaart.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr" -ForegroundColor Green

$content = (Get-Content $root\NuGet\Haarlemmertrekvaart.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\nuget\Haarlemmertrekvaart.compiled.nuspec

Invoke-Expression "$($root)\NuGet\NuGet.exe pack $root\nuget\Haarlemmertrekvaart.compiled.nuspec -Version $($version)"