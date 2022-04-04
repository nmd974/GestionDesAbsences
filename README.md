# Gestion des Absences 

## Installation 

- Cloner le dépot, générer/regénérer une solution
- La bdd se génère automatiquement, ainsi que les factories pour les tests
>  Db.Bdd.Database.EnsureCreated(); <br />
Db.Seed();
- Si la BDD est vide, effacer le fichier Absencedb.db dans le dossier bin/debug/release

## Côté technique

- Modèle MVVM 
- Le fichier AppSettings.json est nécessaire, demander à Mr BOYER Gilles le fichier, ou regarder sur le serveur CDA Simplon, salon groupe 2 

## Modèle MVVM

### Dossier Model

On définit les propriétés (et types) des objets/entités et les relations entre objets/entités. 

### Dossier Views

Toutes les fenêtres accessibles à l'utilisateur se trouvent à l'intérieur de ce dossier. 

### Dossier ViewModel

Les fichiers "class" à l'intérieur permettent de faire le lien entre la BDD et les "vues". 
Ils servent de "controllers #laravel", les CRUDS back et la logique sont définis dans ces fichiers. 
Ce dossier est "connecté" au dossier "Views" par les bindings et les datacontext.


## Frameworks utilisés 

- .Net 5.0
- MaterialDesignThemes 4.3.0
- Faker.net 2.0.154
- Microsoft.EntityFrameworkCore.sqlite 5.0.15

## Ce qui est fait à ce  jour 

04/04/2022 : Architecture du projet/dossier - Création bdd - Seeding Bdd - Connexion bdd -  Login - Email - Vue Apprenant - Back Crud

## Notes de mise à jour 

Version 1.0 : 
- 

## Ressources 

- https://trello.com/b/zPxfskK0/gestion-des-absences