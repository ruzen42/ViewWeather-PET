WhatWeather

WhatWeather — это простое приложение на C# с использованием библиотеки GTK для отображения текущей погоды в указанном городе. Приложение взаимодействует с API OpenWeatherMap для получения данных о погоде.
Особенности

    Пользовательский ввод города.
    Отображение температуры и краткого описания погоды.
    Простой и минималистичный интерфейс.

Требования

    .NET SDK 6.0 или новее.
    GTK 3.0 (установите, если не установлено).
    Учетная запись и API-ключ на OpenWeatherMap.
    Библиотеки NuGet:
        Newtonsoft.Json
        DotNetEnv

Установка

    Клонируйте репозиторий:

git clone https://github.com/ваш_репозиторий/WhatWeather.git
cd WhatWeather

Установите зависимости:

Убедитесь, что у вас установлен GTK 3.0:

Для Ubuntu/Debian:

    sudo apt update
    sudo apt install libgtk-3-dev

Для Fedora:

    sudo dnf install gtk3-devel

Для Windows:
    Установите GTK 3 для Windows.

Установите библиотеки NuGet:

    dotnet add package Newtonsoft.Json
    dotnet add package DotNetEnv

Добавьте API-ключ:

    Создайте файл .env в корне проекта и добавьте ваш API-ключ:

    OPENWEATHERMAP_API_KEY=ваш_api_ключ

    Зарегистрируйтесь и получите API-ключ на сайте OpenWeatherMap.

Сборка и запуск:

Скомпилируйте и запустите приложение:

    dotnet run

Использование

    Запустите приложение.
    Введите название города в текстовое поле.
    Нажмите кнопку start.
    На экране появится информация о текущей погоде в выбранном городе.

Пример работы

Этот проект распространяется под лицензией MIT. Подробности см. в файле LICENSE.
Автор

Создан с использованием GTK и OpenWeatherMap API.
Ваше имя | Ваш GitHub профиль

Enjoy! 🌤️