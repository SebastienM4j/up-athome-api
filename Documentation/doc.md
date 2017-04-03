## Créer un Passage ponctuel

Crée un passage ponctuel

**/api/Sejour/PassagePonctuel/commands/CreerPassagePonctuelCommand/Execute**

### Paramètres

- `SejourId` : ID du séjour *(decimal)*
- `TypeIntervenantId` : ID du séjour *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `HeureDebut` : Heure de début du passage, D:HH:MM:SS *(string)*
- `HeureFin` : Heure de fin du passage, D:HH:MM:SS *(string)*
- `Obligatoire` : *(bool)*
- `Commentaire` : *(string)*
- `ActeIds` : Liste d'ID d'actes *(array d'int)*

### Retour

Si la création réussie, l'ID du passage créé.

## Mettre-à-jour un Passage ponctuel

Met-à-jour le passage ponctuel spécifié.

**/api/Sejour/PassagePonctuel/commands/MettreAJourPassagePonctuelCommand/Execute**

### Paramètres

- `PassagePonctuelId` : ID du passage *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `HeureDebut` : Heure de début du passage, D:HH:MM:SS *(string)*
- `HeureFin` : Heure de fin du passage, D:HH:MM:SS *(string)*
- `Obligatoire` : *(bool)*
- `Commentaire` : *(string)*
- `ActeIds` : Liste d'ID d'actes *(array d'int)*

## Supprimer un Passage ponctuel

Supprime le passage spécifié.

**/api/Sejour/PassagePonctuel/commands/SupprimerPassagePonctuelCommand/Execute**

### Paramètres

- `PassagePonctuelId` : ID du passage *(decimal)*

## Obtenir un passage ponctuel

Retourne une liste de passages ponctuels.

**/api/Sejour/PassagePonctuel/queries/GetPassagePonctuelParSejourEtDatesQuery**

### Paramètres

- `SejourId` : ID du séjour *(decimal)*
- `DateDebut` : Date de début du passage, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : Date de fin du passage, YYYY-MM-DDTHH:MM:SS *(string)*

### Retour

En cas de succès la liste des passages associés au séjour.

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

## Ajouter un type de plage horaire

**/api/RH/TimeSlot/commands/AjouterTypePlageHoraireCommand/Execute**

### Paramètres

- `LibelleLong` : *(string)*
- `LibelleCourt` : *(string)*
- `VersionDate` : YYYY-MM-DDTHH:MM:SS *(string)*
- `Presence` : *(bool)*
- `ImpactCompteurs` : *(bool)*

### Retour

- `ID` : ID de la plage horaire _(string, GUID)_

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

## Affecter un horaire de travail à un salarié

**/api/RH/TimeSlot/commands/AffecterHoraireDeTravailCommand/Execute**

### Paramètres

- `SalarieId` : ID du salarié *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `HeureDebut` : D:HH:MM:SS _(string)_
- `HeureFin` : D:HH:MM:SS _(string)_
- `AntenneId` : ID de l'antenne _(decimal)_
- `TypeHoraireDeTravailId` : Type d'horaire de travail _(string, GUID)_

### Retour

- `TimeSlotId` : ID du timeslot _(string, GUID)_

## Désaffecter un horaire de travail d'un salarié

**/api/RH/TimeSlot/commands/DesaffecterHoraireDeTravailCommand/Execute**

### Paramètres

- `SalarieId` : ID du salarié *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `HeureDebut` : D:HH:MM:SS _(string)_
- `HeureFin` : D:HH:MM:SS _(string)_
- `TypeHoraireDeTravailId` : Type d'horaire de travail _(string, GUID)_
