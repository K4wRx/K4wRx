Param (
    $parameters = @{},
    $srcFolder,
    $scriptFolder,
    $projectName,
    $projectVersion
)
 
# update package version in nuspec file
Write-Output "Updating version in nuspec file"
$nuspecPath = "$srcFolder\K4wRx\K4wRx.nuspec"
[xml]$xml = Get-Content $nuspecPath
$xml.package.metadata.version = $projectVersion
$xml.Save($nuspecPath)
 
# build NuGet package
Write-Output "Building NuGet package"
."$srcFolder\.nuget\NuGet.exe" pack $nuspecPath