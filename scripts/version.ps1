# update package version in nuspec file
Write-Output "Updating version in nuspec file"
$nuspecPath = "\projects\k4wrx\K4wRx\K4wRx.nuspec"
[xml]$xml = Get-Content $nuspecPath
$xml.package.metadata.version = $env:APPVEYOR_BUILD_VERSION
$xml.Save($nuspecPath)
