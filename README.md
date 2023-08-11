
# Restaurant App




## Documentation


Le projet est basé sur: 
- .Net core 6 WEB API

- Entity Framework Core 

- SQL Server pour la base de données

- Architecture CQRS (Command Query Responsibility Segregation) basé sur le design pattern Mediator

- Xunit pour le test unitaire



## Installation

Cloner le projet à partir de repo 

```bash
git clone https://github.com/skavor/RestaurantApp.git
cd RestaurantApp/RestaurantApp.API
```

Dans visual studio, Ouvrir Package Manager Console et lancer les commandes suivantes:

```bash
add-migration YourCustomEntityChanges
update-database
```



Lancer l'application sur local

```bash
cd RestaurantApp/RestaurantApp.API
dotnet run
```
Mettre ce URL dans le navigateur pour la documentation des API's avec swagger

```bash
https://localhost:7189/swagger/index.html
```
Executer les tests

```bash
cd RestaurantApp/RestaurantApp.Test
dotnet test
```
## API Reference

#### Ajouter de nouveaux restaurants 

```http
  POST /api/Restaurant/AddRestaurant

```



#### Lister les restaurants disponibles

```http
  GET /api/Restaurant/ListRestaurant

```

#### Afficher les plats disponibles dans un restaurant (Nom + Image)


```http
  GET /api/Meal/ListMeals/{RestaurantId}

```
#### Afficher une vue détaillée d’un plat (Nom, Image, Catégorie, Ingrédients et quantités)

```http
  GET /api/Meal/{MealId}

```
#### Pouvoir ajouter de nouveaux plats dans le menu d’un restaurant

```http
  POST /api/Meal/AddMeal/{RestaurantId}

```

