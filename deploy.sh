#!/bin/sh
set -e

cd ./Trappist/src/Promact.Trappist.Web
dotnet publish -c Release -o published
git log --format="%h" -n 1 > ./published/.revision
cd ../../../
docker build -t promact/trappist:$CIRCLE_BRANCH .
docker login -u=$DOCKER_USERNAME -p=$DOCKER_PASSWORD
docker push promact/trappist:$CIRCLE_BRANCH
