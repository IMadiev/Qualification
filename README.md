# Qualification

Данный репозиторий содержит тесты GUI mail.ru. 
## Содержание
1. Source - исходный код автотестов.
2. nunit-console - средство запуска.
3. configuration.xml - конфигурационный файл.
4. start.bat - bat для быстрого запуска тестов
5. Drivers - драйверы браузеров.

## Первичная настройка тестового окружения
1. Установить последние версии браузеров FireFox и Chrome

## Порядок запуска автотестов:
- Клонировать репозиторий на локальную машину. ([Основы работы с git])
- Отредактировать конфигурационный файл под свои нужды.
- Запустить bat-файл, либо выполнить из папки с репозиторием команду
```bat
"nunit-console/nunit3-console.exe" Qualification.csproj
```
- После прогона тестов результаты будуть записаны в TestResult.xml в папке с репозиторием.

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [Основы работы с git]: <http://dev-lab.info/2013/08/%D1%88%D0%BF%D0%B0%D1%80%D0%B3%D0%B0%D0%BB%D0%BA%D0%B0-%D0%BF%D0%BE-git-%D0%BE%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D1%8B%D0%B5-%D0%BA%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4%D1%8B-%D1%81%D0%BB%D0%B8%D1%8F%D0%BD/>
   
