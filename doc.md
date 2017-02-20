# Patients

## Obtenir un patient

Retourne le patient associé à l'ID donné.

http://dev.arcan.fr/AtHome/api/Patient/Patient/queries/GetPatientParIdQuery

### Paramètres

- `PatientId` : ID du patient *(decimal)*

### Retour

En cas de succès une entité **Patient** :

- `PatientId` : ID du patient *(decimal)*
- `IdentifiantExterne` : ID externe *(string)*
- `Sexe` : "F" ou "M" *(string)*
- `Civilite` : "Mr", "Mme" ou "Mlle" *(string)*
- `Nom` : *(string)*
- `Prenom` : *(string)*
- `NomJeuneFille` : Nom de naissance *(string)*
- `DateNaissance` : YYYY-MM-DD *(string)*
- `DateDeces` : YYYY-MM-DD *(string)*
- `TelephoneFixe` : *(string)*
- `TelephonePortable` : *(string)*
- `Email` : *(string)*
- `Fax` : *(string)*
- `Adresses` : Liste d'adresse _(array d'**Adresse**)_

Entité **Adresse** :

- `DateApplication` : Date à partir du quel l'adresse est utilisée, YYYY-MM-DD *(string)*
- `Libelle` : *(string)*
- `VilleId` : ID de la ville *(int)*
- `VilleNom` : Nom de la ville *(string)*
- `CodePostal` : *(string)*
- `Rue1` : *(string)*
- `Rue2` : *(string)*
- `Rue3` : *(string)*
- `CEDEX` : *(string)*
- `TelephoneFixe` : *(string)*
- `Latitude` : *(decimal)*
- `Longitude` : *(decimal)*
- `CodePorte` : *(string)*
- `Allee` : *(string)*
- `Entree` : *(string)*
- `Etage` : *(string)*
- `Escalier` : Y a t-il un escalier *(bool)*
- `Ascenseur` : Y a t-il un ascenseur *(bool)*

---

# Séjours

## Obtenir un séjour

Retourne un séjour compris entre une date de début et de fin.

http://dev.arcan.fr/AtHome/api/Sejour/Sejour/queries/GetSejourParDateQuery

### Paramètres

- `DateDebut` : Date de début, YYYY-MM-DD *(string)*
- `DateFin` : Date de fin, YYYY-MM-DD *(string)*

### Retour

En cas de succès une entité **Sejour** :

- `SejourId` : ID du séjour *(decimal)*
- `IdentifiantExterne` : ID externe *(string)*
- `PatientId` : ID du patient *(decimal)*
- `DateDebut` : YYYY-MM-DD *(string)*
- `DateDebutPrevisionnel` : YYYY-MM-DD *(string)*
- `DateFin` : YYYY-MM-DD *(string)*
- `DateFinPrevisionnelle` : YYYY-MM-DD *(string)*
- `AntenneId` : ID de l'antenne *(decimal)*
- `AntenneNom` : Nom de l'antenne *(string)*
- `UniteServiceId` : ID de l'unité de service *(decimal)*
- `UniteServiceNom` : Nom de l'unité de service *(string)*

---

# Plans de soins

## Obtenir une liste d'actes prédéfinis

Retourne la liste des actes existants sur AtHome.

http://dev.arcan.fr/AtHome/api/Sejour/Sejour/queries/GetActesQuery

### Paramètres

- `Aucun`

### Retour

En cas de succès la liste d'actes définie dans AtHome :

- `ActeId` : ID de l'acte *(int)*
- `Libelle` : Nom de l'acte *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*

## Obtenir la liste de type d'intervenants

Retourne la liste des types d'intervenants existants sur AtHome.

http://dev.arcan.fr/AtHome/api/Sejour/Sejour/queries/GetTypesIntervenantsQuery

### Paramètres

- `Aucun`

### Retour

En cas de succès la liste des types d'intervenants définis dans AtHome :

- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*
- `Libelle` : Nom du type d'intervenant *(string)*

## Obtenir des plans de soins

Retourne une liste de plans de soins correspondants aux IDs de séjours donnés.

http://dev.arcan.fr/AtHome/api/Sejour/Sejour/queries/GetPlansSoinsParSejoursQuery

### Paramètres

- `SejourIds` : Liste d'ID de séjours *(array)*

### Retour

- `PlanSoinsId` : ID du plan de soins *(decimal)*
- `SejourId` : ID du séjour *(decimal)*
- `DateDebut` : Date de début du plan de soins, YYYY-MM-DD *(string)*
- `DateFin` : Date de fin, YYYY-MM-DD *(string)*
- `DateFinPrevisonnelle` : Date de fin prévisionelle, YYYY-MM-DD *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(string)*
- `TypeIntervenantLibelle` : Nom du type d'intervenant *(string)*
- `Lignes` : Liste de lignes de soins _(array de **LignePlanSoins**)_

Entité **LignePlanSoins** :

- `LignePlanSoinsId` : ID de la ligne de soins *(decimal)*
- `Jour` : Entier compris entre 0 et 6. 0 = Dimanche, 1 = Lundi… *(int)*
- `HeureDebut` : HH:MM:SS* (string)*
- `HeureFin` : HH:MM:SS* (string)*
- `Obligatoire` : *(bool)*
- `Actes` : Liste des actes _(array d'**Acte**)_

Entité **Acte** :

- `ActeId` : ID de l'acte *(decimal)*
- `Libelle` : Nom de l'acte *(string)*

## Créer un plan de soins

Crée un plan de soin pour un séjour.

http://dev.arcan.fr/AtHome/api/Sejour/PlanSoinSalarie/commands/CreerPlanDeSoinSalarieCommand/Execute

### Paramètres

- `SejourId` : ID du séjour *(decimal)*
- `DateDebut` : Date de début du plan de soins, YYYY-MM-DD *(string)*
- `DateFin` : Date de fin du plan de soins, YYYY-MM-DD *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*
- `Commentaire` : Commentaire *(string)*
- `Lignes` : Liste de lignes de soins _(array de **LignePlanSoins**)_

Entité **LignePlanSoins** :

- `Jour` : Entier compris entre 0 et 6, 0 pour Dimanche, 6 pour Samedi *(int)*
- `HeureDebut` : Heure de début du passage, HH:MM:SS *(string)*
- `HeureFin` : Heure de fun du passage, HH:MM:SS *(string)*
- `Obligatoire` : *(bool)*
- `ActeIds` : Liste d'ID d'actes *(array d'int)*

### Retour


