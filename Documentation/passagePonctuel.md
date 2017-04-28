# Passages ponctuels

## Créer un Passage ponctuel

Crée un passage ponctuel

**CreerPassagePonctuelCommand**

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

**MettreAJourPassagePonctuelCommand**

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

**SupprimerPassagePonctuelCommand**

### Paramètres

- `PassagePonctuelId` : ID du passage *(decimal)*

## Obtenir un passage ponctuel

Retourne une liste de passages ponctuels.

**GetPassagePonctuelParSejourEtDatesQuery**

### Paramètres

- `SejourId` : ID du séjour *(decimal)*
- `DateDebut` : Date de début du passage, YYYY-MM-DDTHH:MM:SS *(string)*
- `DateFin` : Date de fin du passage, YYYY-MM-DDTHH:MM:SS *(string)*

### Retour

En cas de succès la liste des passages associés au séjour.