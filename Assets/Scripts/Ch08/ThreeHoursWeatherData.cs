using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ThreeHoursWeatherData
{
    public string cod;
    public int message;
    public int cnt;
    public DetailWeatherInfo[] list;
    public City city;
}

[Serializable]
public class DetailWeatherInfo
{
    public int dt;
    public WeatherCommon.Main main;
    public WeatherCommon.Weather[] weather;
    public WeatherCommon.Clouds clouds;
    public WeatherCommon.Wind wind;
    public int visibility;
    public int pop;
    public WeatherCommon.Sys sys;
    public string dt_txt;
}

[Serializable]
public class City
{
    public int id;
    public string name;
    public WeatherCommon.Coord coord;
    public string country;
    public int population;
    public int timezone;
    public int sunrise;
    public int sunset;

}
