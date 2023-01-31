# Async Inn

## Lab 12 - Intro to Entity Framework

> ## [Home](../README.md)

---

For this part of the lab, follow along with the steps in the demo below.

[Entity Framework Setup Guide](http://bit.ly/3jrpetP)

---

### Application Specifications

### *Startup File*

1. Create a new Empty `.NET Core Web Application` and implement the basic setup to create your API server:
    - Add explicit routing of Controllers in your `Configure` method
    - Enable the use of MVC controllers in your `ConfigureServices` method
    - DBContext registered in `ConfigureServices`

---

### *Simple Models & The Database*

1. Create a new `Models` folder, to contain the basic entities from your ERD.
    - Create a `Hotel` model, that contains the same properties defined in the ERD.
    - Don't worry about adding in the Navigation properties yet. We'll add those in later.
2. Create a new `Data` folder, and add a file named `AsyncInnDbContext`.
    - Make your new class derive from the `DbContext` class, as well as creating the constructor with the proper parameters.
    - Use the demo code as an example.
3. Register your `DbContext` in your startup file.
    - Configure your `appsettings.json` file to include your connection string.
4. Go back to your `AsyncInnDbContext` file, and add a new property to include a new table into your database.
    - `public DbSet<Hotel> Hotels {get; set;}`. 
    - Be sure to include the `Models` namespace into our current cs file.
5. Now that you have your database registered, and a single table property inside of your `DbContext` file, create a new migration to see the script that creates and adds that table to the database:
    - Terminal: `dotnet ef migrations add AddHotelsTable`
    - Package Manager Console: `Add-Migration AddHotelsTable`
6. Once you create the migration, apply it to your database:
    - Terminal: `dotnet ef database update`
    - Package Manager Console: `Update-Database`
7. Confirm in your local database that the `Hotels` table has been added.

> ---

Now, let’s add the other two tables, except this time, we can just add the tables at the same time and have the script include both of them when adding to the database.

1. Go back to your `Models` folder and add two new class files; `Room` and `Amenity`.
2. Populate each of these classes with the same properties that you have defined inside of your ERD.
3. Go back into your `AsyncInnDbContext` file and add the two additional properties to represent the `Room` and the `Amenity` models.
    - `public DbSet<Room> Rooms {get; set;}`
    - `public DbSet<Amenity> Amenities {get; set;}`
4. Create a new migration to include the creation of these two new tables:
    - Terminal: `dotnet ef migrations add AddRoomsAndAmenitiesTables`
    - Package Manager Console `Add-Migration AddRoomsAndAmenitiesTables`
5. Finally, apply migrations and watch those two new tables get added to the database. Confirm locally that the tables exist.
    - Terminal: `dotnet ef database update`
    - Package Manager Console: `Update-Database`

---

### *Seeding Data*

Let’s add some default data into our tables on its initial launch.

1. Within your `AsyncInnDbContext` add a new **override** method for the `OnModelCreating` method under your constructor.
2. Seed in some default data for all three of your simple models:
    - 3 hotels
    - 3 rooms
    - 3 amenities

> ---

Here is an example of adding a single default item into a table. (*See more here: [Microsoft Docs - Data Seeding](https://bit.ly/3jrpetP)*)

```C#
modelBuilder.Entity<Blog>().HasData(new Blog {BlogId = 1, Url = "http://sample.com"});
```

---

After creating the seeded data, you will now want to create a new migration so that the seeded data can get added to the database tables:

1. Create a new migration:
    - Terminal: `dotnet ef migrations add AddSeedData`
    - Package Manager Console: `Add-Migration AddSeedData`
2. Apply migrations so that the data gets added to the table:
    - Terminal: `dotnet ef database update`
    - Package Manager Console: `Update-Database`
3. Confirm that the data was added to your local database for all 3 tables.

---

### *Controllers*

Now that we have completed our “Code First Migrations” in the directions above. 

Let’s add some routes so that we can access the data through an API.

1. Create a new folder named `Controllers` in your project.
2. Right click on the folder, and choose `Add » Controller`.
3. Choose the `Entity Framework Scaffold for API` option.
4. Select the `Hotel` Entity for your model.
5. Select your `AsyncInnDbContext` as your DbContext.
6. After it’s been scaffolded, confirm through [**Postman**](https://www.postman.com/) that your can do basic CRUD operations on the `Hotels` route.
7. Follow the instructions above to scaffold out the `Room` and `Amenity` Controllers as well.

---
