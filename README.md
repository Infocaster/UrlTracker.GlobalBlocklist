<h3 align="center">
<img height="100" src="https://raw.githubusercontent.com/Infocaster/.github/main/assets/infocaster_nuget_yellow.svg">
</h3>

<h1 align="center">
UrlTracker GlobalBlocklist

</h1>

*This package is an extension of the UrlTracker. For more information about the UrlTracker please check out [our GitHub page](https://github.com/Infocaster/UrlTracker)*

## Requirements
The UrlTracker.GlobalBlocklist package requires an installation of the UrlTracker with a minimal version of v10.


## Getting started
There is no configuration required to start using this package. By installing the package a filter is added that retreives the global [list](https://github.com/Infocaster/.github/blob/main/UrlTracker_globalSettings.json).

We have tried to include as many items as possible in this list but if you feel that something is missing we highly encourage you to create a pull request so it can be added.

## Good to know
When the filter does not contain any items a request is made to get the list. This list is then cached for 24 hours.
This means that the list is refreshed once a day, dependent on when the last restart of your application took place.

## Credits
Created by [Infocaster](https://infocaster.net)

<a href="https://github.com/Infocaster/UrlTracker.GlobalBlocklist/graphs/contributors">
<img src="https://contrib.rocks/image?repo=Infocaster/UrlTracker.GlobalBlocklist" />
</a>

*Made with [contributors-img](https://contrib.rocks).*
-----

<a href="https://infocaster.net">
<img align="right" height="200" src="https://raw.githubusercontent.com/Infocaster/.github/main/assets/Infocaster_Corner.png?raw=true">
</a>
