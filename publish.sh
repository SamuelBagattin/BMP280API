#!/usr/bin/env bash
printf ' pass : '
read pass
printf  "$pass\n$pass\n$pass" | (
dotnet publish -r linux-arm --configuration Release &&
ssh pi@176.159.24.54 -p 52022 ' rm -rf ~/deployment && mkdir ~/deployment ' &&
scp -r -P 52022 ./bin/Release/netcoreapp2.2/linux-arm/publish/. pi@176.159.24.54:~/deployment/ &&
ssh pi@176.159.24.54 -p 52022 ' export DOTNET_ROOT=$HOME/dotnet &&
export PATH=$PATH:$HOME/dotnet && nohup dotnet ~/deployment/publish/BMP280API.dll'
)