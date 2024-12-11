using Gtk;

namespace ShowWeather
{
	class Program
	{
		public static void Main()
		{
			Application.Init();
			var app = new WeatherApp();
			app.Resizable = false;
			app.DeleteEvent += delegate { Application.Quit(); };
			Application.Run();
		}
	}
}
