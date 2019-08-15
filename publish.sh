#!/usr/bin/env bash

dotnet publish -r linux-arm --configuration Release
scp -r -P 52600 ./bin/Release/netcoreapp2.2/linux-arm/publish/ pi@176.159.24.54:~/deployment/