using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour
{
    // Referencing Object
    public GameObject CurrentWeather;
    public TextMeshProUGUI CurrentTempText;
    public TextMeshProUGUI TempDescriptionText;


    // Weather Data 
    //private CurrentWeatherData CurrentWeather;
    //private ThreeHoursWeatherData ThreeHoursWeather;
    public ThreeHoursWeatherData weatherData;

    // Weather Api
    private string AppId = "a03c0c3ba01a8eb56dc2dd62f96171be";
    private string City = "seoul";


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetCurreuntWeatherFromApi());
        StartCoroutine(GetThreeHoursWeatherFromApi());
    }

    public IEnumerator GetCurreuntWeatherFromApi()
    {
        CurrentWeatherData weatherData;
        string apiUrl = "https://api.openweathermap.org/data/2.5/weather?" +
            "q={city name}&appid={API key}&units=metric";

        apiUrl = apiUrl.Replace("{city name}", City);
        apiUrl = apiUrl.Replace("{API key}", AppId);

        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        // error
        if (request.result == UnityWebRequest.Result.ProtocolError
            || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
            yield break;
        }

        string json = request.downloadHandler.text;
        json = json.Replace("\"base\"", "\"_base\"");

        weatherData = JsonUtility.FromJson<CurrentWeatherData>(json);

        Debug.Log($" Today's Weather" +
            $" id: {weatherData.weather[0].id}, " +
            $"name: {weatherData.name}, " +
            $"main: {weatherData.weather[0].main}, " +
            $"desciption: {weatherData.weather[0].description}, " +
            $"temp: {weatherData.main.temp}");

        // json ?
        // server에서 client로 데이터를 보낼 때 사용하는 형식
        DisplayCurrentWeather(weatherData);
    }

    public IEnumerator GetThreeHoursWeatherFromApi()
    {
        string apiUrl = "https://api.openweathermap.org/data/2.5/forecast?" +
            "q={city name}&appid={API key}&cnt=10&units=metric";
        apiUrl = apiUrl.Replace("{city name}", City);
        apiUrl = apiUrl.Replace("{API key}", AppId);

        Debug.Log(apiUrl);
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest(); // 왜 yield return? ( request에 대한 응답을 받을때까지 기다리나봐)

        // error
        if (request.result == UnityWebRequest.Result.ProtocolError
            || request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(request.error);
            yield break;
        }

        string json = request.downloadHandler.text;
        weatherData = JsonUtility.FromJson<ThreeHoursWeatherData>(json);
        Debug.Log(weatherData);

        foreach (DetailWeatherInfo data in weatherData.list)
        {
            Debug.Log($"dt_txt: {data.dt_txt} | temp: {data.main.temp} " +
                $"| main: {data.weather[0].main} | description: {data.weather[0].description}");
        }

    }

    private void DisplayCurrentWeather(CurrentWeatherData data)
    {
        CurrentTempText.text = data.main.temp.ToString();
        TempDescriptionText.text = data.weather[0].description;
    }




}
