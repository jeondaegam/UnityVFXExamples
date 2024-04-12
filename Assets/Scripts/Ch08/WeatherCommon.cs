using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCommon
{
    [Serializable]
    public class Main
    {
        public int temp; // float > int (소숫점도 받고싶으면 float, 아니면 int)
        public float feels_like;
        public int temp_min;// float > int 
        public int temp_max;// float > int 
        public int pressure;
        public int humidity;
        public int sea_level;
        public int grnd_level;

        // Only ThreeHours Api field
        public int temp_kf;

    }

    [Serializable]
    public class Wind
    {
        public float speed;
        public int deg;
        public float gust;

    }
    [Serializable]
    public class Clouds
    {
        public int all;
    }

    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }


    [Serializable]
    public class Sys
    {
        // Only CurrentWeather Api Field
        public int type;
        public int id; // city id
        public string country;
        public int sunrise;
        public int sunset;

        // Only ThreeHours Api Field
        public string pod;
    }

    [Serializable]
    public class Coord
    {
        public float lon;
        public float lat;
    }
}