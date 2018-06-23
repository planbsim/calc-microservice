#!/bin/bash
cd /pipeline/source/publish
dotnet WebCalculator.Api.dll --server.urls=http://0.0.0.0:${PORT-"8000"}