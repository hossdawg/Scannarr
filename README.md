[![GitHub issues](https://img.shields.io/github/issues/DarkSupremo/Sonarr-Scanner.svg?maxAge=60&style=flat-square)](https://github.com/DarkSupremo/Sonarr-Scanner/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/DarkSupremo/Sonarr-Scanner.svg?maxAge=60&style=flat-square)](https://github.com/DarkSupremo/Sonarr-Scanner/pulls)
[![Github Releases](https://img.shields.io/github/downloads/DarkSupremo/Sonarr-Scanner/total.svg?maxAge=60&style=flat-square)](https://github.com/DarkSupremo/Sonarr-Scanner/releases/latest)

# arr_Scannarr (WIP)
Keep monitoring the Sonarr and Radarr wanted list and send an search request to then at every X minutes or on Wake Event, forcing an Automatic Search instead of relying on RSS based search, this way it will be more suitable to home based systems.

The software was completly rewritten to .NET Core (cross platform)

## Settings 

To start using it, you just need to configure **'settings_sonarr.json'** and/or **'settings_radarr.json'**, make sure to put the correect API Key.  

### settings_sonarr.json
```
{
  "URL": "http://sonarr:8989",
  "Interval": 120,
  "ScanOnWake": true,
  "ScanOnInterval": false,
  "ScanOnStart": true,  
  "ForceImport": false,
  "ForceImportInterval": 1,
  "ForceImportMode": "Copy",
  "APIKey": ""
}
```
_Valid options for **ForceImportMode**: "Copy" or "Move"_

### settings_radarr.json
```
{
  "URL": "http://radarr:7878",
  "Interval": 1440,
  "ScanOnWake": true,
  "ScanOnInterval": false,
  "ScanOnStart": true,
  "APIKey": ""
}
```

### settings_4kradarr.json
```
{
  "URL": "http://4kradarr:7878",
  "Interval": 1440,
  "ScanOnWake": true,
  "ScanOnInterval": false,
  "ScanOnStart": true,
  "APIKey": ""
}
```
_All the interval properties are in minutes._

If the setting **'ScanOnStart'** is **true**, and both **'ScanOnWake'** and **'ScanOnInterval'** are **false**, it will start, scan and exit the app, otherwise it will stay open.

## Running on Docker
You can omit any arr instance and use only the ones you wish you wish.
```sh
docker run -it --rm \
-v /path/to/settings_sonarr.json:/app/settings_sonarr.json:ro \
-v /path/to/settings_4ksonarr.json:/app/settings_4ksonarr.json:ro \
-v /path/to/settings_radarr.json:/app/settings_radarr.json:ro \
-v /path/to/settings_4kradarr.json:/app/settings_4kradarr.json:ro \
-v /path/to/settings_3dradarr.json:/app/settings_3dradarr.json:ro \
ghcr.io/hossdawg/arr_scanner:latest
```
