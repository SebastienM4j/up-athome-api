# Séjours

## Obtenir un séjour

### A) Par date

Retourne une liste de séjours comprise entre une date de début et de fin.

**/api/Sejour/Sejour/queries/GetSejoursParDateQuery**

#### Paramètres

- `DateDebut` : Date de début, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : Date de fin, YYYY-MM-DDTHH:MM:SS *(string)*

#### Retour

En cas de succès une liste d'entité **Sejour** :

- `SejourId` : ID du séjour *(decimal)*
- `IdentifiantExterne` : ID externe *(string)*
- `PatientId` : ID du patient *(decimal)*
- `DateDebut` : YYYY-MM-DDTHH:MM:SS *(string)*
- `DateDebutPrevisionnel` : YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFinPrevisionnelle` : YYYY-MM-DDTHH:MM:SS *(string)*
- `AntenneId` : ID de l'antenne *(decimal)*
- `AntenneNom` : Nom de l'antenne *(string)*
- `UniteServiceId` : ID de l'unité de service *(decimal)*
- `UniteServiceNom` : Nom de l'unité de service *(string)*

### B) Par ID externe

Retourne un séjour correspondant à l'ID externe donné.

**/api/Sejour/Sejour/queries/GetSejourParIdExterneQuery**

#### Paramètres

- `IdentifiantExterne` : *(string)*

#### Retour

En cas de succès une entité **Sejour** :

- `SejourId` : ID du séjour *(decimal)*
- `IdentifiantExterne` : ID externe *(string)*
- `PatientId` : ID du patient *(decimal)*
- `DateDebut` : YYYY-MM-DDTHH:MM:SS *(string)*
- `DateDebutPrevisionnel` : YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFinPrevisionnelle` : YYYY-MM-DDTHH:MM:SS *(string)*
- `AntenneId` : ID de l'antenne *(decimal)*
- `AntenneNom` : Nom de l'antenne *(string)*
- `UniteServiceId` : ID de l'unité de service *(decimal)*
- `UniteServiceNom` : Nom de l'unité de service *(string)*
