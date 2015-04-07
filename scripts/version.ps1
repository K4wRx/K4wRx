Param (
    $srcFolder,
    $projectName,
    $projectVersion
)
 
# update package version in nuspec file
Write-Output "Updating version in nuspec file"
$nuspecPath = "$srcFolder\projects\$projectName\K4wRx\K4wRx.nuspec"
[xml]$xml = Get-Content $nuspecPath
$xml.package.metadata.version = "$projectVersion"
$xml.Save($nuspecPath)
