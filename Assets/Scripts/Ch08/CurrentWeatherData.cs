using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
// 왜 Serializable이 없지 ? 
public class CurrentWeatherData
{
    public WeatherCommon.Coord coord;
    public WeatherCommon.Weather[] weather;
    public string _base;
    public WeatherCommon.Main main;
    public int visibility;
    public WeatherCommon.Wind wind;
    public WeatherCommon.Clouds clouds;
    public int dt;
    public WeatherCommon.Sys sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;
}

