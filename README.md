Currencies - Kalkulator Kursów Walut
Aplikacja Windows Forms do przeliczania polskich złotych na wybrane waluty zagraniczne na podstawie aktualnych kursów z NBP (Narodowy Bank Polski).
Funkcjonalności

Automatyczne pobieranie kursów: Aplikacja pobiera aktualne kursy walut z API NBP przy uruchomieniu
Przeliczanie walut: Konwersja kwoty w PLN na wybraną walutę zagraniczną
Intuicyjny interfejs: Prosty interfejs użytkownika z polem tekstowym, listą rozwijaną i przyciskiem
Obsługa błędów: Wyświetlanie komunikatów o błędach w przypadku problemów z połączeniem lub nieprawidłowych danych


![image](https://github.com/user-attachments/assets/d866ff30-6591-4f76-b780-51ad1dba4154)


Użytkowanie
Uruchom aplikację
Poczekaj na załadowanie kursów walut z API NBP
Wprowadź kwotę w złotych polskich w polu tekstowym
Wybierz docelową walutę z listy rozwijanej
Kliknij przycisk do przeliczania
Wynik zostanie wyświetlony w oknie dialogowym

API NBP
Aplikacja korzysta z publicznego API Narodowego Banku Polski:
Endpoint: http://api.nbp.pl/api/exchangerates/tables/A/?format=json
Format: JSON
Tabela A: Kursy średnie walut obcych

Obsługa błędów
Aplikacja obsługuje następujące sytuacje błędne:
Brak połączenia z internetem
Nieprawidłowa odpowiedź z API NBP
Błędne dane wprowadzone przez użytkownika
Problemy z deserializacją JSON

Licencja
Projekt jest dostępny na licencji open source. Możesz go modyfikować i dystrybuować zgodnie z potrzebami.
Autor Anna Nowak email: a.nowak.024@studms.ug.edu.pl
Projekt napisany w C# z wykorzystaniem Windows Forms i API NBP.
