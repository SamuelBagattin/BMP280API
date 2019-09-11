#!/usr/bin/env bash
dotnet restore &&
rm -rf ./build && mkdir ./build &&
dotnet publish -r linux-arm --configuration Release -o ./build &&
fuser -k 5000/tcp &&
rm -rf nohup.out
nohup dotnet ./build/BMP280API.dll &
