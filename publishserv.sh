#!/usr/bin/env bash
git pull --rebase &&
dotnet restore &&
rm -rf ~/deployment && mkdir ~/deployment &&
dotnet publish -r linux-arm --configuration Release -o ../../deployment/ &&
fuser -k 5000/tcp &&
rm -rf nohup.out
nohup dotnet ~/deployment/BMP280API.dll &