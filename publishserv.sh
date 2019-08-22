cd ~/dev/BMP280API/ &&
git pull --rebase &&
dotnet restore &&
dotnet publish -r linux-arm --configuration Release &&
rm -rf ~/deployment && mkdir ~/deployment &&
cp -r bin/Release/netcoreapp2.2/linux-arm/publish/. ~/deployment/ &&
fuser -k 5000/tcp &&
cd ~/deployment &&
rm -rf nohup.out
nohup dotnet ~/deployment/BMP280API.dll &