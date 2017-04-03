# Tournées

## Créer une tournée

Crée une tournée

**/api/RH/Tour/commands/CreerTourneeCommand/Execute**

### Paramètres

- `Nom` : Nom de la tournée *(string)*
- `AntenneId` : ID de l'antenne associée *(decimal)*

### Retour

Si succès, ID de la tournée.

## Obtenir une tournée par son nom

Retrouve une tournée en fonction du nom donné.

**/api/RH/Tour/queries/GetTourneeParNomQuery**

### Paramètres

- `Nom` : Nom de la tournée *(string)*

### Retour

Si succès, ID (GUID) et nom de la tournée.

## Obtenir le contenu d'une tournée

Retourne le contenu de la tournée (lignes de plan de soins).

**/api/RH/Tour/queries/GetTourneeContenuParIdQuery**

### Paramètres

- `Id` : ID de la tournée *(string, GUID)*
- `Debut` : YYYY-MM-DDTHH:MM:SS *(string)*
- `Fin` : YYYY-MM-DDTHH:MM:SS *(string)*

### Retour

- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `Salaries` : Liste d'ID de salaries _(array de decimal)_
- `LignePlanSoinSalaries` : Lignes de plans de soins _(array de **LignePlanSoinSalaries**)_

## Obtenir un type de plage horaire

**/api/RH/TimeSlot/queries/GetTypePlageHoraireParNomQuery**

### Paramètres

- `Libelle` : Nom du type *(string)*

### Retour

ID (GUID) de la plage horaire.

## Affecter un salarié à une tournée

Affecte un salarié à une tournée

**/api/RH/Tour/commands/AffecterSalarieATourneeCommand/Execute**

### Paramètres

- `TourneeId` : ID de la tournée *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `SalarieId` : ID du salarié *(decimal)*
- `EstPonctuel` : Ponctuel ou pas ? *(bool)*

## Affecter un passage à une tournée

Affecte un passage à une tournée

**/api/RH/Tour/commands/AffecterPassageATourneeCommand/Execute**

### Paramètres

- `TourneeId` : ID de la tournée *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `PassageId` : ID du passage *(decimal)*
- `EstPonctuel` : Ponctuel ou pas ? *(bool)*
## Désaffecter un salarié à une tournée

Désaffecte un salarié d'une tournée

**/api/RH/Tour/commands/DesaffecterSalarieATourneeCommand/Execute**

### Paramètres

- `TourneeId` : ID de la tournée *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `SalarieId` : ID du salarié *(decimal)*
- `EstPonctuel` : Ponctuel ou pas ? *(bool)*

## Désaffecter un passage à une tournée

Désaffecte un passage d'une tournée

**/api/RH/Tour/commands/DesaffecterPassageATourneeCommand/Execute**

### Paramètres

- `TourneeId` : ID de la tournée *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `PassageId` : ID du passage *(decimal)*
- `EstPonctuel` : Ponctuel ou pas ? *(bool)*
