# Plans de soins

---- 

## Obtenir une liste d'actes prédéfinis

Retourne la liste des actes existants sur AtHome.

**/api/Sejour/Sejour/queries/GetActesQuery**

### Paramètres

- `Aucun`

### Retour

En cas de succès la liste d'actes définie dans AtHome :

- `ActeId` : ID de l'acte *(int)*
- `Libelle` : Nom de l'acte *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*

## Obtenir un Acte par ID

Retourne l'acte correspondant à l'ID donné.

**/api/Sejour/Sejour/queries/GetActeParIdQuery**

### Paramètres

- `ActeId` : ID de l'acte *(int)*

### Retour

En cas de succès la liste d'actes définie dans AtHome :

- `ActeId` : ID de l'acte *(int)*
- `Libelle` : Nom de l'acte *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*

## Créer un Acte

Crée un acte et retourne son ID.

**/api/Sejour/Acte/commands/CreerActeCommand/Execute**

### Paramètres

- `Libelle` : Nom de l'acte *(string)*
- `LibelleCourt` : Nom de l'acte, version courte *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*

### Retour

En cas de succès l'id de l'acte créé :

- `ActeId` : *(int)*

## Obtenir la liste de type d'intervenants

Retourne la liste des types d'intervenants existants sur AtHome.

**/api/Sejour/Sejour/queries/GetTypesIntervenantsQuery**

### Paramètres

- `Aucun`

### Retour

En cas de succès la liste des types d'intervenants définis dans AtHome :

- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*
- `Libelle` : Nom du type d'intervenant *(string)*

## Obtenir des plans de soins

### A) Par Séjours ID et Dates

Retourne une liste de plans de soins correspondants aux IDs de séjours donnés.

**/api/Sejour/PlanSoinSalarie/queries/GetPlansSoinsParSejoursEtDatesQuery**

#### Paramètres

- `SejourIds` : Liste d'ID de séjours *(array)*
- `DateDebut` : Date de début du plan de soins, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : Date de fin, YYYY-MM-DDTHH:MM:SS *(string, optionnel)*

#### Retour

- `PlanSoinsId` : ID du plan de soins *(decimal)*
- `SejourId` : ID du séjour *(decimal)*
- `DateDebut` : Date de début du plan de soins, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : Date de fin, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFinPrevisonnelle` : Date de fin prévisionelle, YYYY-MM-DDTHH:MM:SS *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(string)*
- `TypeIntervenantLibelle` : Nom du type d'intervenant *(string)*
- `Lignes` : Liste de lignes de soins _(array de **LignePlanSoins**)_

Entité **LignePlanSoins** :

- `LignePlanSoinsId` : ID de la ligne de soins *(decimal)*
- `Jour` : Entier compris entre 0 et 6. 0 = Dimanche, 1 = Lundi… *(int)*
- `HeureDebut` : D:HH:MM:SS\* (string)\*
- `HeureFin` : D:HH:MM:SS\* (string)\*
- `Obligatoire` : *(bool)*
- `Actes` : Liste des actes _(array d'**Acte**)_

Entité **Acte** :

- `ActeId` : ID de l'acte *(decimal)*
- `Libelle` : Nom de l'acte *(string)*

### B) Par Plan de Soins ID

Retourne une liste de plans de soins correspondants aux IDs de séjours donnés.

**/api/Sejour/PlanSoinSalarie/queries/GetPlansSoinsParIdQuery**

#### Paramètres

- `PlanSoinsId` : ID du plan de soins *(array)*

#### Retour

- `PlanSoinsId` : ID du plan de soins *(decimal)*
- `SejourId` : ID du séjour *(decimal)*
- `DateDebut` : Date de début du plan de soins, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : Date de fin, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFinPrevisonnelle` : Date de fin prévisionelle, YYYY-MM-DDTHH:MM:SS *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(string)*
- `TypeIntervenantLibelle` : Nom du type d'intervenant *(string)*
- `Lignes` : Liste de lignes de soins _(array de **LignePlanSoins**)_

Entité **LignePlanSoins** :

- `LignePlanSoinsId` : ID de la ligne de soins *(decimal)*
- `Jour` : Entier compris entre 0 et 6. 0 = Dimanche, 1 = Lundi… *(int)*
- `HeureDebut` : D:HH:MM:SS\* (string)\*
- `HeureFin` : D:HH:MM:SS\* (string)\*
- `Obligatoire` : *(bool)*
- `Actes` : Liste des actes _(array d'**Acte**)_

Entité **Acte** :

- `ActeId` : ID de l'acte *(decimal)*
- `Libelle` : Nom de l'acte *(string)*

## Créer un plan de soins

Crée un plan de soin pour un séjour.

**/api/Sejour/PlanSoinSalarie/commands/CreerPlanDeSoinSalarieCommand/Execute**

### Paramètres

- `SejourId` : ID du séjour *(decimal)*
- `DateDebut` : Date de début du plan de soins, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : Date de fin du plan de soins, YYYY-MM-DDTHH:MM:SS *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*
- `Commentaire` : Commentaire *(string)*
- `EtatPlanSoin` : 0 = Brouillon, 1 = Validé, 2 = Cloturé *(int)*
- `Lignes` : Liste de lignes de soins _(array de **LignePlanSoins**)_

Entité **LignePlanSoins** :

- `Jour` : Entier compris entre 0 et 6, 0 pour Dimanche, 6 pour Samedi *(int)*
- `HeureDebut` : Heure de début du passage, D:HH:MM:SS *(string)*
- `HeureFin` : Heure de fin du passage, D:HH:MM:SS *(string)*
- `Obligatoire` : *(bool)*
- `ActeIds` : Liste d'ID d'actes *(array d'int)*

### Retour

Si la création a réussi l'id du plan de soin créé.

## Mettre-à-jour un plan de soins

Met un plan de soins à jour.

**/api/Sejour/PlanSoinSalarie/commands/MettreAJourPlanDeSoinSalarieCommand/Execute**

### Paramètres

- `PlanSoinId` : ID du plan de soins *(decimal)*
- `SejourId` : ID du séjour *(decimal)*
- `DateDebut` : Date de début du plan de soins, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : Date de fin du plan de soins, YYYY-MM-DDTHH:MM:SS *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*
- `Commentaire` : Commentaire *(string)*
- `EtatPlanSoin` : 0 = Brouillon, 1 = Validé, 2 = Cloturé *(int)*
- `Lignes` : Liste de lignes de soins _(array de **LignePlanSoins**)_

Entité **LignePlanSoins** :

- `Jour` : Entier compris entre 0 et 6, 0 pour Dimanche, 6 pour Samedi *(int)*
- `HeureDebut` : Heure de début du passage, D:HH:MM:SS *(string)*
- `HeureFin` : Heure de fin du passage, D:HH:MM:SS *(string)*
- `Obligatoire` : *(bool)*
- `ActeIds` : Liste d'ID d'actes *(array d'int)*


## Supprimer un plan de soins

Supprime le plan de soins correspondant à l'ID donné.

**/api/Sejour/PlanSoinSalarie/commands/SupprimerPlanSoinCommand/Execute**

### Paramètres

- `PlanSoinId` : ID du plan de soins *(decimal)*

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
