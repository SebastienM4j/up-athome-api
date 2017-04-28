# Plans de soins

## Obtenir des plans de soins

### A) Par Séjours ID et Dates

Retourne une liste de plans de soins correspondants aux IDs de séjours donnés.

**GetPlansSoinsParSejoursEtDatesQuery**

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

**GetPlansSoinsParIdQuery**

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

**CreerPlanDeSoinSalarieCommand**

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

**MettreAJourPlanDeSoinSalarieCommand**

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

**SupprimerPlanSoinCommand**

### Paramètres

- `PlanSoinId` : ID du plan de soins *(decimal)*
