<img alt="Logo" src="http://coderslab.pl/svg/logo-coderslab.svg" width="400">

# PortfolioLab .NET

Witaj w PortfolioLab, w którym samodzielnie wykonasz projekt `Oddam w dobre ręce`. Wykonaj zadania przygotowane na `tablicy Trello` dostępnej pod linkiem dostarczonym w pakiecie kursanta.

## Przygotowanie

### Technologia

Do wykonania projektu użyj technologii `ASP.NET Core MVC` z `EntityFramework Core`. W wersji rozszerzonej projektu użyj `ASP.NET Core Identity`. Używaj wiedzy i technik poznanych podczas zajęć z wykładowcą i mentorem. Możesz również używać dodatkowej wiedzy poznanej poza zajęciami.

### Projekt `Charity.Mvc`

Nie twórz projektu od początku. Przygotowaliśmy dla Ciebie bazowy projekt `Charity.Mvc`, który możesz umieścić na swoim GitHubie.
Projekt posiada referencje do pakietu NuGet `Microsoft.AspNetCore.All` i stronę główną w formie szablonu dostarczonego przez UX i frontend developera. Uważaj, nie ma w tym projekcie pliku `_Layout.cshtml`. Utworzysz go w ramach jednego z zadań.

### Połączenie z bazą danych i praca na DbContext

1. W `EntityFramework` skorzystaj z podejścia `Code First`.
1. Ścieżkę do połączenia z bazą danych przechowuj w pliku konfiguracyjnym `appsettings.json`.
1. Pamiętaj, aby w klasie kontekstu wykorzystać dziedziczenie z odpowiedniego bazowego `DbContext`.
1. Pamiętaj, aby zawsze dostarczać odpowiednie migracje baz danych.
1. W folderze `resources\sql` znajduje się plik `insert.sql`, który dodaje do bazy danych przykładowe dane. Użyj tego pliku w porcjach dodając poszczególne wpisy dot. pojedynczej tabeli po utworzeniu migracji lub poczekaj, aż będzie kompletny model bazy danych i dodaj komplet danych.

### Zabezpiecz aplikację w rozszerzonej wersji projektu

1. Używaj atrybutów zapewniających dostęp do odpowiednich kontrolerów i akcji zalogowanym użytkownikom.
1. Jeżeli dane są pobierane dla bieżącego zalogowanego użytkownika skorzystaj z właściwości `User.Identity.Name` dostępnej w kontrolerze, aby przekazać nazwę bieżącego zalogowanego użytkownika do metody pobierającej dane.

### Inne porady

1. Wykorzystaj `Dependency Injection`, np. do wstrzykiwania kontekstu i innych serwisów.
1. Pamiętaj o dobrych praktykach `DRY` (Don't Repeat Yourself) i `KISS` (Keep It Sweet and Simple).

Powodzenia :)