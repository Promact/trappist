#!/bin/sh
set -e

cd ./Trappist/src/Promact.Trappist.Web
dotnet ef migrations add prod
dotnet publish -o published
git log --format="%H" -n 1 > ./published/.revision
cd ../../../
docker build -t promact/trappist:$TRAVIS_BRANCH .
docker login -u=$DOCKER_USERNAME -p=$DOCKER_PASSWORD
docker push promact/trappist:$TRAVIS_BRANCH