#!/usr/bin/env bash

#check if an argument is given
if [ $# -eq 0 ]; then
    echo "Usage: $(basename "$0") <project>"
    exit 1
fi

pushd "$(dirname "$0")" > /dev/null || exit 2

dotnet new console -o "$1" -f net7.0

touch "$1"/exampleInput.txt