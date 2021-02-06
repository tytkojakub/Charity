# Charity

## Opis

Projektem jest strona umożliwiająca użytkownikowi (zalogowanemu i niezalogowanemu) zgłoszenie chęci oddania przedmiotów. Ustala się przy tym kategorię, ilość, adresata, adres, datę obioru. Zebrane dane zapisywane są w bazie danych. Zalogowany użytkownik ma możliwość zobaczenia listy swoich zgłoszeń. 

## Technologia
### Języki
* C#
* JavaScript
* HTML/CSS

### Frameworki i biblioteki
* .NET Core MVC
* .NET Core Identity
* Entity Framework (code first)
* Linq
* Bootstrap

### Baza danych
* MS SQL

## Konfiguracja projektu z bazą danych.

1. W folderze znajduje plik "Charity.bak", dodaj bazę danych do MS SQL.
2. Ścieżkę do połączenia z bazą danych (connection string) znajdziesz się w pliku konfiguracyjnym `appsettings.json`. Podmień go zgodnie ze ścieżką właściwą dla swojej konfiguracji.

## Stan realizacji 

- [x] Utworzenie zgłoszenia przekazania darów.
- [x] Walidacja zgłoszenia.
- [x] Rejestracja użytkownika.
- [x] Logowanie / wylogowaniu użytkownika.
- [x] Lista zgłoszeń użytkownika (po zalogowaniu)