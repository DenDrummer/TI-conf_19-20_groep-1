#!/usr/bin/env bash

set -e -u -x -o pipefail

cd "$(dirname "$0")/../"

# Get shared CI
ci/bootstrap.sh

dotnet run -p ./.shared-ci/tools/Packer/Packer.csproj
