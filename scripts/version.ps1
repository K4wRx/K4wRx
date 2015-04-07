Param (
    $srcFolder,
    $projectName,
    $projectVersion
)
 
# update package version in nuspec file
Write-Output "Updating version in nuspec file"
$nuspecPath = "$srcFolder\projects\k4wrx\K4wRx\K4wRx.nuspec"
[xml]$xml = Get-Content $nuspecPath
$xml.package.metadata.version = "$projectVersion"
$xml.Save($nuspecPath)
