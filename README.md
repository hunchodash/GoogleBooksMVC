# GoogleBooksMVC
📚 Google Books MVC – Progetto ASP.NET Core

Descrizione:
Questo progetto è un'applicazione web sviluppata con ASP.NET Core MVC che permette di cercare libri tramite l'API pubblica di Google Books.
L'utente può inserire una parola chiave e visualizzare una lista di risultati con titolo, autori, anteprima e immagine di copertina.

Funzionalità principali:
- Form di ricerca con selezione del numero di risultati (5, 10, 20)
- Visualizzazione dinamica dei risultati con layout responsive (Bootstrap)
- Integrazione asincrona con l’API Google Books tramite HttpClient
- Codice strutturato in MVC (Model, View, Controller) con Services

Tecnologie usate:
- ASP.NET Core 8 MVC
- C#
- Bootstrap 5 + Bootstrap Icons
- API REST (Google Books)
- Docker (esecuzione containerizzata)

Requisiti:
- .NET 8 SDK
- Connessione Internet per interrogare le API
- Docker (per esecuzione containerizzata)

## 🐳 Esecuzione con Docker

Puoi eseguire l'app direttamente tramite Docker seguendo questi passaggi:

1. Costruisci l'immagine Docker:
   ```bash
   docker build -t googlebooks .
2. Avvia il container:
   ```bash
   docker run -d -p 8080:80 --name googlebooks-container googlebooks
3. Apri il browser e vai all'indirizzo: http://localhost:8080

   

