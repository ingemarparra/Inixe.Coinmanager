# Inixe Coin Manager

The goal of the project is to create a tool that can help users on the Mexican Crypto Currency exchange to analyse and have a better control on their day to day operations.
May be at some point in time this will evolve in toa bot, but at the time it's not the main goal.

In order to achieve the main goal we must understand how the mexican market reacts to changes. The web is flooded with tools for analyzing cryptocurrencies having the US dollar as reference. The project is going to incorcoporate the market data of the mexican exchanges
to analyze the cryptocurrencies behavior from a Mexican peso reference perspective.

## Road Map

* Mexican Cryptocurrencies API libraries - *Beta* -
* Reference Market data API libraries
  * Kraken - *On It's way* -
  * Gemini
  * GDAX
  * Bitfinex
* Analyzers
  * Trends Analyzers
* Indicators
  * MACD
  
### Prerequisites

The project has no external dependencies at the time, but those comming from NuGet.

* [RestSharp](http://restsharp.org/)
* [Fluent Validation](https://github.com/JeremySkinner/FluentValidation)
* [Moq](https://github.com/moq/moq)

### Installing

There's no installation procedure yet.

## Running the tests

Currently the tests are based on MS Test. In order to run the Private API Tests of the Mexican Cryptocurrency Market you need to create a *.runsettings* file with the following data on it.

```
<?xml version="1.0" encoding="utf-8" ?>
<RunSettings>
  <TestRunParameters>
    <Parameter name="ApiKey" value="API_KEY" />
    <Parameter name="ApiSecret" value="API_SECRET" />
    <!--This is the actual production server URL-->
    <Parameter name="ServerUrl" value="https://api.bitso.com/v3/" />
  </TestRunParameters> 
</RunSettings>
```

Please refer to the API documentation in order to create your API Keys [here](https://bitso.com/api_info)


## Contributing

Please read [Contributing](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Ingemar Parrra H.** - *Initial work* -

## License

This project is licensed under the MIT License - see the [License](LICENSE.md) file for details

## Acknowledgments

* The API access clients in this project are unofficial versions. If you want to use an official client version, please refer to the corresponding Market Exchange Platform.

