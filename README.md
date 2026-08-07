# EquipIT — Gestion de prêt de matériel

Bienvenue dans le projet **EquipIT** ! 🚀

Vous développez une application full-stack pour une start-up qui souhaite mieux gérer le prêt de son matériel informatique. L’équipe doit pouvoir consulter les équipements disponibles, suivre les prêts et enregistrer les personnes concernées.

Le front-end fourni contient déjà une interface et des données mockées. Votre objectif est de compléter progressivement le back-end, puis de remplacer les données fictives par les données de la véritable API.

Lorsqu’un prêt est créé, un formulaire permet notamment de renseigner le **prénom** et le **nom** de la personne qui emprunte le matériel. Le projet est un fil rouge en deux exercices : vous commencez par implémenter la logique métier, puis vous exposez cette logique au moyen d’une API REST et connectez le front-end.

---

## Prérequis

Avant de commencer, assurez-vous d’avoir :

- installé le **SDK .NET 10** ;
- un IDE adapté, par exemple **Visual Studio 2026**, **JetBrains Rider** ou **Visual Studio Code** avec les extensions C#/.NET ;
- **Git** pour versionner votre travail ;
- les bases de C#, de la programmation orientée objet et des commandes du terminal ;
- relu les principes de code maintenable : **POO, SOLID, DRY, Clean Code** et séparation des responsabilités.

Vérifiez votre installation :

```bash
dotnet --version
```

La version affichée doit être compatible avec .NET 10.

---

## Démarrer le projet

Placez-vous à la racine du dépôt, là où se trouve le fichier `.sln` ou le projet `.csproj`.

### Restaurer les dépendances et compiler

```bash
dotnet restore
dotnet build
```

### Lancer les tests

Pour exécuter tous les tests :

```bash
dotnet test
```

Pendant votre travail, relancez régulièrement les tests. Ils constituent votre filet de sécurité et vous indiquent précisément les comportements attendus.

### Lancer l’application

Si la solution contient plusieurs projets, utilisez le projet web/API :

```bash
dotnet run --project <chemin-vers-le-projet-API>
```

Sinon, depuis le dossier du projet web :

```bash
dotnet run
```

L’adresse locale est indiquée dans la sortie du terminal. Ouvrez ensuite cette adresse dans votre navigateur. Si Swagger/OpenAPI est activé dans la configuration fournie, l’interface de documentation sera accessible à l’URL `/swagger` (par exemple `https://localhost:<port>/swagger`).

> **Astuce :** ne devinez pas le port. Copiez l’URL affichée par `dotnet run` et acceptez le certificat HTTPS de développement si votre environnement vous le demande.

---

## Exercice 1 — EF Core et logique métier

### Objectif

Implémenter le comportement métier de la gestion des équipements et des prêts dans `EquipmentService`, en vous appuyant sur **Entity Framework Core (EF Core)** et sur les tests fournis.

### Travail demandé

1. Explorez la codebase avant de modifier le code : entités, contexte EF Core, repositories éventuels, services, tests et front-end mocké.
2. Identifiez les méthodes incomplètes ou à corriger dans `EquipmentService`.
3. Implémentez l’accès aux données avec EF Core en respectant le modèle existant et les conventions du projet.
4. Implémentez les règles métier attendues, notamment autour :
   - de la consultation des équipements ;
   - de leur disponibilité ;
   - de la création et du suivi d’un prêt ;
   - des informations du formulaire, dont le prénom et le nom de l’emprunteur ;
   - des cas invalides ou impossibles à traiter.
5. Respectez la séparation des responsabilités : le service porte la logique métier, tandis que l’accès aux données reste confié à EF Core et aux abstractions prévues par le starter kit.
6. Ajoutez une validation simple lorsque cela est attendu par les tests et évitez de dupliquer la logique.
7. Utilisez l’IA comme partenaire de développement : formulez un prompt précis, demandez des explications, vérifiez le code généré et adaptez-le au projet. Vous restez responsable de chaque ligne de code livrée.
8. Faites passer la suite de tests au vert :

   ```bash
   dotnet test
   ```

### Critères de réussite

- Les fonctionnalités demandées sont opérationnelles.
- Les tests existants passent sans erreur.
- Le code est lisible, cohérent et maintenable.
- Vous êtes capable d’expliquer vos choix d’implémentation, les règles métier et l’utilisation d’EF Core.
- Vous avez réalisé des commits réguliers et explicites.

Ne passez pas à l’exercice 2 tant que le comportement métier de l’exercice 1 n’est pas fiable. En cas de doute, demandez une première vérification à votre agent IA, puis faites valider votre avancement par votre mentor.

---

## Exercice 2 — API REST et connexion du front-end

### Objectif

Structurer l’application et exposer la logique de `EquipmentService` au travers d’une API REST claire, documentée et consommable par le front-end.

### Travail demandé

1. Analysez la structure actuelle de l’application et repérez les responsabilités de chaque couche.
2. Complétez `EquipmentController` avec les endpoints REST nécessaires à la consultation des équipements et à la gestion des prêts, en suivant les routes et modèles déjà prévus dans le starter kit.
3. Utilisez l’**injection de dépendances** : le contrôleur doit dépendre du service (ou de l’abstraction) approprié et ne doit pas contenir la logique métier ni créer directement ses dépendances.
4. Retournez des réponses HTTP adaptées (`200`, `201`, `400`, `404`, etc.) et gérez les cas d’erreur de façon compréhensible.
5. Ajoutez ou complétez les validations basiques attendues par l’application.
6. Configurez la documentation **OpenAPI/Swagger** dans `Program.cs` afin que les endpoints puissent être explorés et testés facilement. Vérifiez que les services, le contexte EF Core et les contrôleurs sont correctement enregistrés dans le conteneur d’injection de dépendances.
7. Testez les endpoints avec Swagger, votre IDE, `curl` ou un autre outil adapté. Vérifiez les scénarios nominaux et les erreurs.
8. Remplacez progressivement les données mockées du front-end par les appels à la vraie API :
   - configurez l’URL de base de l’API ;
   - appelez les bons endpoints ;
   - adaptez les modèles ou noms de propriétés si nécessaire ;
   - connectez le formulaire de prêt en envoyant notamment le prénom et le nom ;
   - vérifiez visuellement que les équipements et les prêts affichés correspondent aux données du back-end.
9. Relancez les tests après chaque refactor important :

   ```bash
   dotnet test
   dotnet build
   ```

### Critères de réussite

- `EquipmentController` expose les opérations attendues et délègue le traitement à `EquipmentService`.
- L’injection de dépendances est utilisée correctement.
- OpenAPI/Swagger est disponible et décrit les endpoints.
- Les réponses HTTP et les validations sont cohérentes.
- Le front-end fonctionne avec l’API réelle et non plus uniquement avec les données mockées.
- Le code reste lisible et les fonctionnalités de l’exercice 1 ne sont pas cassées.
- Vous pouvez présenter l’application localement et expliquer votre architecture, vos choix de conception et les difficultés rencontrées.

---

## Bonnes pratiques pendant le projet

- Commitez souvent, avec des messages qui décrivent clairement l’intention du changement.
- Lisez et comprenez le code généré par l’IA avant de l’intégrer.
- Ne modifiez pas un test uniquement pour le faire passer : cherchez d’abord à comprendre le comportement attendu.
- Testez les cas nominaux, les données invalides et les ressources inexistantes.
- Gardez les contrôleurs fins et la logique métier dans les services.
- Documentez brièvement les décisions importantes et les difficultés rencontrées.
- En cas de blocage, réduisez le problème à un exemple simple, consultez les erreurs affichées, puis demandez de l’aide avec un contexte précis.

## Pour la session de bilan

Préparez une démonstration de l’application locale et soyez prêt à expliquer :

- les fonctionnalités ajoutées ;
- le rôle d’EF Core et de `EquipmentService` ;
- la structure des couches et l’injection de dépendances ;
- les endpoints de `EquipmentController` ;
- la configuration OpenAPI/Swagger ;
- la connexion entre le front-end et l’API réelle ;
- votre utilisation critique de l’IA et les vérifications effectuées.

Bon courage : avancez étape par étape, testez souvent et faites-vous confiance ! 💪
