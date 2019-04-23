#!/bin/sh

docker build -t fsharp-koans . && docker run --rm -v `pwd`:/koans -ti fsharp-koans
