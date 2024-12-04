using Gtk;
using Newtonsoft.Json.Linq;
using DotNetEnv;

internal class WeatherApp : Window
{
    // City entry
    private Entry _cityinput;
    private Label _temperatureLabel;
    private string? _apikey;

    private WeatherApp() : base("WhatWeather")
    {
        Env.Load();
        _apikey = Environment.GetEnvironmentVariable("OPENWEATHERMAP_API_KEY");
        SetDefaultSize(400, 200);
        SetPosition(WindowPosition.Center);

        _cityinput = new Entry { PlaceholderText = "Enter city here" };
        var getWeatherButton = new Button("start");

        // This function is called when the getTheWeather button is clicked
        getWeatherButton.Clicked += GetTheWeather;

        _temperatureLabel = new Label();

        // Create vertical box container
        var vertbox = new Box(Orientation.Vertical, 0);
        vertbox.PackStart(_cityinput, false, false, 5);
        vertbox.PackStart(getWeatherButton, false, false, 5);
        vertbox.PackStart(_temperatureLabel, false, false, 5);

        Add(vertbox);
        ShowAll();
    }

    private async void GetTheWeather(object? sender, EventArgs e)
    {
        string currentcity = _cityinput.Text;
        string WeatherInfo = "";
        
        if (string.IsNullOrEmpty(currentcity))
        {
            _temperatureLabel.Text = "NULL";
            return;
        }
        
        try
        {
            WeatherInfo = await GetStringAsync(currentcity);
        }
        catch (Exception ex)
        {
            _temperatureLabel.Text = $"{currentcity} not exist";
            Console.WriteLine(ex.Message);
        }
        
        _temperatureLabel.Text = WeatherInfo;
    }

    private async Task<string> GetStringAsync(string city)
    {
        string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apikey}&units=metric";

        var client = new HttpClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        var weatherData = JObject.Parse(responseBody);

        string description;
        string temp;

        description = weatherData["weather"]?[0]?["description"]?.ToString() ?? "NULL";
        temp = weatherData["main"]?["temp"]?.ToString() ?? "NULL";

        return $"Погода в {city}: {description}, {temp} °C";
    }

    public static void Main()
    {
        Application.Init();
        var mainApp = new WeatherApp();
        mainApp.DeleteEvent += delegate
        {
            Console.WriteLine("App is closed");
            Application.Quit();
        };
        
        Application.Run();
    }

}

