# 🚀 Projet EquipIT - Starter Code

Bienvenue sur **EquipIT** !

Il s'agit d'une application web interne permettant aux employés d'une entreprise de consulter et d'emprunter du matériel informatique (écrans, claviers, ordinateurs portables, etc.).

L'entité principale manipulée est simple : 
`Equipment (Id, Name, Category, IsAvailable, BorrowerFirstName, BorrowerLastName)`

La solution est divisée en plusieurs projets :
- **EquipIT.Api** : Le Back-end (.NET 10 Web API) avec une base de données locale SQLite préconfigurée.
- **EquipIT.Front** : L'interface utilisateur (Blazor Web App .NET 10).
- **EquipIT.Tests** : Le projet de tests unitaires (xUnit).

Ce dépôt contient le code de départ ("Starter Code"). Le Front-end tourne actuellement avec des données simulées (mockées), et certaines fonctionnalités comme le multilingue (i18n) ou la lo[...]
Des commentaires `// TODO:` ont été laissés dans le code pour te guider. Réfère-toi à ton scénario de cours pour accomplir tes missions !

---

## 🛠️ Comment lancer l'application

Pour que le Front-end puisse communiquer avec l'API, **tu dois impérativement lancer les deux projets en même temps**.

### Via Visual Studio
1. Ouvre la solution `EquipIT.sln`.
2. Fais un clic droit sur la Solution (tout en haut de l'Explorateur de solutions) et sélectionne **Configurer les projets de démarrage** (*Configure Startup Projects*).
3. Coche l'option **Plusieurs projets de démarrage** (*Multiple startup projects*).
4. Pour `EquipIT.Api` et `EquipIT.Front`, change l'action de "Aucune" à **Démarrer** (*Start*).
5. Clique sur "Appliquer" puis "OK", et lance le débogage (F5).
