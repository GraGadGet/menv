#!/usr/bin/env bash

# If any command fails, it will be aborted.
set -o errexit 

menv_csproj="./src/GraGadGet.Menv/GraGadGet.Menv.csproj"

help() {
cat <<EOF
Usage: sh $(basename "$0") command

Build assistant.

Command:
  build     Run "dotnet build".
  publish   Run "dotnet publish".
EOF
}

parse_args() {
    if [ "$#" -eq 0 ]; then
        help
        exit 1
    fi
    command="$1"
}

os_type() {
    if [ "$COMSPEC" == "" ]; then
        case `uname` in
            "Darwin")
                echo "macOS"
                ;;          
            "Linux")
                echo "Linux"
                ;;          
            *)
                echo "Unsupported"
                ;;    
        esac
    else
        if [ `uname | sed 's/.\+/\U\0/' | grep "MINGW"` ]; then
            echo "MINGW"
        elif [ `uname | sed 's/.\+/\U\0/' | grep "MSYS"` ]; then
            echo "MSYS"
        elif [ `uname | sed 's/.\+/\U\0/' | grep "CYGWIN"` ]; then
            echo "CYGWIN"
        else
            echo "Unsupported"
        fi
    fi 
}

build() {
    if [ `os_type` == "macOS" ] || [ `os_type` == "Linux" ]; then
        dotnet build $menv_csproj
    elif [ `os_type` == "MINGW" ] || [ `os_type` == "MSYS" ] || [ `os_type` == "CYGWIN" ]; then
        "`cygpath "C:\Program Files\dotnet/dotnet.exe"`" build $menv_csproj
    else
        echo "Unsupported"
    fi 
}

publish() {
    if [ `os_type` == "macOS" ] || [ `os_type` == "Linux" ]; then
        dotnet publish $menv_csproj -c Release -r osx-x64 /p:PublishSingleFile=true -o ./build/osx-x64
        dotnet publish $menv_csproj -c Release -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true -o ./build/win-x64
        dotnet publish $menv_csproj -c Release -r linux-x64 /p:PublishSingleFile=true -o ./build/linux-x64
    elif [ `os_type` == "MINGW" ] || [ `os_type` == "MSYS" ] || [ `os_type` == "CYGWIN" ]; then
        "`cygpath "C:\Program Files\dotnet/dotnet.exe"`" publish $menv_csproj -c Release -r osx-x64 -o ./build/osx-x64     # /p:PublishSingleFile=true 
        "`cygpath "C:\Program Files\dotnet/dotnet.exe"`" publish $menv_csproj -c Release -r win-x64 -o ./build/win-x64     # /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true  
        "`cygpath "C:\Program Files\dotnet/dotnet.exe"`" publish $menv_csproj -c Release -r linux-x64 -o ./build/linux-x64 # /p:PublishSingleFile=true 
    else
        echo "Unsupported"
    fi
}

parse_args "$@"
case "$command" in
    "build")
        build
        exit 0
        ;;
    "publish")
        publish
        exit 0
        ;;        
esac
