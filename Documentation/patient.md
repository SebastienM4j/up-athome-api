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
