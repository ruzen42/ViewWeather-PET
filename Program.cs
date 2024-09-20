using Gtk;
using Newtonsoft.Json.Linq;
using DotNetEnv;

class WeatherApp : Window
{
    // City entry
    private Entry cityinput;
    private Label temperatureLabel;
    private string? apikey;

    public WeatherApp() : base("Weather App")
    {
        Env.Load();
        apikey = Environment.GetEnvironmentVariable("OPENWEATHERMAP_API_KEY");
        SetDefaultSize(400, 200);
        SetPosition(WindowPosition.Center);

        cityinput = new Entry { PlaceholderText = "Введи свой город вонючий" };
        Button getWeatherButton = new Button("Покажи погоду");

        // This function is called when the getTheWeather button is clicked
        getWeatherButton.Clicked += GetTheWeather;

        temperatureLabel = new Label("Хуевая погода");

        // Create vertical box container
        Box vertbox = new Box(Orientation.Vertical, 0);
        vertbox.PackStart(cityinput, false, false, 5);
        vertbox.PackStart(getWeatherButton, false, false, 5);
        vertbox.PackStart(temperatureLabel, false, false, 5);

        Add(vertbox);
        ShowAll();
    }

    private async void GetTheWeather(object? sender, EventArgs e)
    {
        string currentcity = cityinput.Text;
        if (string.IsNullOrEmpty(currentcity))
        {
            temperatureLabel.Text = "Введи ебучий город пожайлуста";
            return;
        }
        string WeatherInfo = "1488";
        try
        {
            WeatherInfo = await GetStringAsync(currentcity);
        }
        catch (Exception ex)
        {
            temperatureLabel.Text = $"Вашего мухосранска {currentcity} не существует";
            Console.WriteLine(ex.Message);
        }
        temperatureLabel.Text = WeatherInfo;
    }

    private async Task<string> GetStringAsync(string city)
    {
        string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apikey}&units=metric";

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        JObject weatherData = JObject.Parse(responseBody);

        string description;
        string temp;

        description = weatherData["weather"]?[0]?["description"]?.ToString() ?? "нечего";
        temp = weatherData["main"]?["temp"]?.ToString() ?? "нечего";

        return $"Погода в {city}: {description}, {temp} °C";
    }

    public static void Main()
    {
        Application.Init();
        WeatherApp MainApp = new WeatherApp();
        MainApp.DeleteEvent += delegate
        {
            Console.WriteLine("App is closed");
            Application.Quit();
        };
        Application.Run();
    }

}

