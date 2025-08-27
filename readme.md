# Contact List Web Application

## Opis projektu

Aplikacja webowa do zarządzania kontaktami. Użytkownicy mogą przeglądać listę kontaktów, dodawać nowe oraz edytować istniejące. Projekt posiada mechanizm logowania i autoryzacji z użyciem tokenów JWT.

## Technologie

* **Backend:** .NET 9 (ASP.NET Core Web API)
* **ORM / Baza danych:** Entity Framework Core
* **Frontend:** Vue.js 3 + Composition API
* **Routing:** Vue Router
* **HTTP Client:** Axios
* **Autoryzacja:** JWT (JSON Web Token)
* **Konteneryzacja:** Docker

## Podstrony i routing

| Ścieżka        | Nazwa         | Komponent        | Opis                                                                                     |
| -------------- | ------------- | ---------------- | ---------------------------------------------------------------------------------------- |
| `/`            | `ContactList` | `ContactList`    | Strona główna wyświetlająca listę kontaktów.                                             |
| `/login`       | `Login`       | `LoginForm`      | Formularz logowania użytkownika.                                                         |
| `/contact/:id` | `Contact`     | `ContactItem`    | Widok szczegółów kontaktu. Parametr `:id` określa konkretny kontakt. Wymaga autoryzacji. |
| `/contact/add` | `AddContact`  | `AddContactItem` | Formularz dodawania nowego kontaktu. Wymaga autoryzacji.                                 |

## Funkcjonalności

* **Autoryzacja użytkowników**

  * Logowanie za pomocą nazwy użytkownika i hasła
  * Generowanie tokenów JWT
  * Ochrona tras wymagających zalogowania

* **Zarządzanie kontaktami**

  * Wyświetlanie listy kontaktów
  * Dodawanie nowych kontaktów
  * Edycja istniejących kontaktów
  * Dynamiczne formularze (wybór kategorii i podkategorii)

* **Interakcja frontend-backend**

  * Pobieranie i wysyłanie danych z użyciem Axios
  * Walidacja danych po stronie backendu (Data Annotations EF)

* **Infrastruktura**

  * Możliwość uruchomienia aplikacji w kontenerach Docker
  * Oddzielenie backendu od frontendowego SPA

## Uruchamianie projektu

1. Skonfiguruj plik `.env` w frontendzie z adresem backendu (`VUE_APP_API_URL`).
2. Uruchom backend:
   W folderze ContactListApi
   
   ```bash
   docker compose --env-file .env up -d --force-recreate --build --no-deps
   ```
3. Uruchom frontend:
   W folderze contact-list-web

   ```bash
   npm install
   npm run serve
   ```

## Token JWT

WIP - feature nie został do końca zaimplementowany
* Token generowany podczas logowania (`POST /api/login`)
* Wysyłany w nagłówku `Authorization: Bearer <token>` przy żądaniach do tras chronionych
