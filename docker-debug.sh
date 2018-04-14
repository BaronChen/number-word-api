#!/bin/bash

projectName="number-word-api"
serviceName="numberword.api"
containerName="${projectName}_${serviceName}_1"

containerId=$(sudo docker ps -f "name=$containerName" -q -n=1)

if [[ -z $containerId ]]; then
    echo "Could not find a container named $containerName"
else
    sudo docker exec -i $containerId /vsdbg/vsdbg --interpreter=vscode
fi