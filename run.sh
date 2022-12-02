#!/usr/bin/env bash

if [ $# -eq 0 ]; then
    echo "Usage: $(basename "$0") <project> [input]"
    exit 1
fi

# check if a second argument is given
if [ $# -eq 2 ]; then
    args=$(readlink -f "$2")
else
    args=$(readlink -f "$1"/exampleInput.txt)
fi

echo "Using input file: $args"

# change to the directory of this script
pushd "$(dirname "$0")" > /dev/null || exit 2



cd "$1" || (echo "Could not find $1" && exit 3)
echo "Running the exacutable for $1"
dotnet run "$args"

popd > /dev/null || exit 4