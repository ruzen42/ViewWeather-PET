# WhatWeather
![image](https://github.com/user-attachments/assets/61fce856-8d92-40fa-b602-47c358ef69ef)
![image](https://github.com/user-attachments/assets/3a5debc7-c067-4680-a20b-1f149ba47489) 

WhatWeather is a simple C# application using the GTK library to display the current weather in a specified city. The app fetches weather data from the OpenWeatherMap API.
Features

    User input for city name.
    Displays temperature and a brief weather description.
    Simple and minimalist interface.

Requirements

    .NET SDK 6.0 or newer.
    GTK 3.0 (install if not already installed).
    An account and API key from OpenWeatherMap.
    NuGet packages:
        Newtonsoft.Json
        DotNetEnv

Installation

    Clone the repository:

git clone https://github.com/your_repository/WhatWeather.git
cd WhatWeather

Install dependencies:

Ensure GTK 3.0 is installed:

### For Debian:

    sudo apt update
    sudo apt install libgtk-3-dev

### For Fedora:

    sudo dnf install gtk3-devel

### For Windows:

    Install GTK 3 for Windows.

Add required NuGet packages:

dotnet add package Newtonsoft.Json
dotnet add package DotNetEnv

Add the API key:

    Create a .env file in the project root directory and add your API key:

    OPENWEATHERMAP_API_KEY=your_api_key

    Register and obtain an API key at OpenWeatherMap.

## Build and run:

Compile and start the application:

    dotnet run

## Usage

    Launch the application.
    Enter the name of a city in the input field.
    Click the start button.
    The app will display the current weather information for the specified city.

Example Output

Input: New York
Output: Weather in New York: clear sky, 12.0 °C

## License

This project is licensed under the MIT License. See the LICENSE file for details.
Author

Built using GTK and OpenWeatherMap API.
Jaroslav | ruzen42

Enjoy! 🌤️
