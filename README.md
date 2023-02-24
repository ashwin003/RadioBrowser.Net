# RadioBrowser.Net

Wrapper for https://www.radio-browser.info/

Documentation for the API can be found [here](http://de1.api.radio-browser.info/#General)

## How to use

Register the interfaces in your DI container as follows:

```C#
services.AddRadioBrowserServices(<User-Agent>)
```

Please keep the User-Agent descriptive as it helps the API maintainer.
It can be something like `<APP_NAME>/<APP_VERSION>`.

## Interfaces exposed

| Interface | Exposed Services |
| ----------- | ----------- |
| ```ICodecService``` | Fetches all codecs available in the API |
| ```ICountryService``` | Fetches all countries available in the API |
| ```ILanguageService``` | Fetches all languages available in the API |
| ```IServerService``` | Fetches server configurations and mirrors from the API |
| ```IStateService``` | Fetches all states available in the API |
| ```IStationService``` | Allows you to search for stations | 