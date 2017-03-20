# Authentification

----

Avant de pouvoir utiliser les APIs une authentification est nécéssaire, elle se déroule en 2 étapes. Pour cela une **APIKEY** et une **APISECRET** vous sont fournis.

## 1) Obtenir l'URL du site AtHome et une réponse SAML

Appeler **https://auth.arcan.fr/api/ApiLogin/GetAuthData?apiKey=APIKEY&apiSecret=APISECRET&uniqueCode=UNIQUECODE** avec les paramètres suivants :

- `APIKEY`
- `APISECRET`
- `UNIQUECODE` : disponible sur la page d'authentification d'AtHome (généralement 320XXXX).

Si l'authentification réussie, la réponse contient une **URL** et une réponse **SAML**. C'est sur cette URL que les appels d'APIs devront être faits.

## 2) S'authentifier sur le site AtHome

Pour cela il faut appeler l'URL obtenue à l'étape précédente et passer le SAML en *POST* au format *JSON*, exemple :

**https://dev.arcan.fr/api/Authentification/Login**

Si l'authentification réussie un cookie **ArcanCookieAuth** est renvoyé, il faut alors le réutiliser dans les appels aux APIs.

# Patients

----

## Obtenir un patient

Retourne le patient associé à l'ID donné.

**/api/Patient/Patient/queries/GetPatientParIdQuery**

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
- `DateNaissance` : YYYY-MM-DDTHH:MM:SS *(string)*
- `DateDeces` : YYYY-MM-DDTHH:MM:SS  *(string)*
- `TelephoneFixe` : *(string)*
- `TelephonePortable` : *(string)*
- `Email` : *(string)*
- `Fax` : *(string)*
- `Adresses` : Liste d'adresse _(array d'**Adresse**)_

Entité **Adresse** :

- `DateApplication` : Date à partir du quel l'adresse est utilisée, YYYY-MM-DDTHH:MM:SS *(string)*
- `Libelle` : ID de l'adresse *(string)*
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

---

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

---

# Plans de soins

---

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

**/api/Sejour/VisiteSalarie/commands/CreerVisiteSalarieCommand/Execute**

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
