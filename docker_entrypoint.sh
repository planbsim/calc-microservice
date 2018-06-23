#!/bin/bash
cd /WebCalculator.Api/WebCalculator.Api/publish
dotnet WebCalculator.Api.dll --server.urls=http://0.0.0.0:${PORT-"8000"}