# Horaire de travail

## Obtenir un type de plage horaire

**GetTypePlageHoraireParNomQuery**

### Paramètres

- `Libelle` : Nom du type *(string)*

### Retour

ID (GUID) de la plage horaire.

## Ajouter un type de plage horaire

**AjouterTypePlageHoraireCommand**

### Paramètres

- `LibelleLong` : *(string)*
- `LibelleCourt` : *(string)*
- `VersionDate` : YYYY-MM-DDTHH:MM:SS *(string)*
- `Presence` : *(bool)*
- `ImpactCompteurs` : *(bool)*

### Retour

- `ID` : ID de la plage horaire _(string, GUID)_
## Affecter un horaire de travail à un salarié

**AffecterHoraireDeTravailCommand**

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

**DesaffecterHoraireDeTravailCommand**

### Paramètres

- `SalarieId` : ID du salarié *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `HeureDebut` : D:HH:MM:SS _(string)_
- `HeureFin` : D:HH:MM:SS _(string)_
- `TypeHoraireDeTravailId` : Type d'horaire de travail _(string, GUID)_