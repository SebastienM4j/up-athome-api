# Tournées

## Créer une tournée

**CreerTourneeCommand**

### Paramètres

- `Nom` : Nom de la tournée *(string)*
- `AntenneId` : ID de l'antenne associée *(decimal)*

### Retour

Si succès, ID de la tournée.

##Obtenir une tournée par son Id

Retourne la tournée dont l'identifiant est passé en paramètre

## Modifier une tournée

**ModifierTourneeCommand**

### Paramètres
- `Id` : Identifiant unique de la tournée *(Guid)*
- `Nom` : Nom de la tournée
- `AntenneId` : Identifiant unique de l'antenne préférentielle (nullable)

### Retour
Message de succès ou d'erreur.

## Récupérer une tournée par son Id

**GetTourneeParIdQuery**

### Paramètres
- `Id` : Identifiant unique de la tournée *(Guid)*

### Retour
Si l'identifiant est valide et la tournée existe
- `Id` : Identifiant de la tournée
- `Nom` : Nom de la tournée
- `AntenneId` : Identifiant unique de l'antenne préférentielle (nullable)

## Obtenir une tournée par son nom

Retrouve une tournée en fonction du nom donné.

**GetTourneeParNomQuery**

### Paramètres

- `Nom` : Nom de la tournée *(string)*

### Retour

Si succès, ID (GUID) et nom de la tournée.

## Obtenir le contenu d'une tournée

Retourne le contenu de la tournée (lignes de plan de soins).

**GetTourneeContenuParIdQuery**

### Paramètres

- `Id` : ID de la tournée *(string, GUID)*
- `Debut` : YYYY-MM-DDTHH:MM:SS *(string)*
- `Fin` : YYYY-MM-DDTHH:MM:SS *(string)*

### Retour

- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `Salaries` : Liste d'ID de salaries _(array de decimal)_
- `Passages` : Liste des passages (array de [HeureDebut, HeureFin, PassageId])


## Affecter un salarié à une tournée

Affecte un salarié à une tournée

**AffecterSalarieATourneeCommand**

### Paramètres

- `TourneeId` : ID de la tournée *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `SalarieId` : ID du salarié *(decimal)*
- `EstPonctuel` : Ponctuel ou pas ? *(bool)*

## Affecter un passage à une tournée

Affecte un passage à une tournée

**AffecterPassageATourneeCommand**

### Paramètres

- `TourneeId` : ID de la tournée *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `PassageId` : ID du passage *(decimal)*
- `EstPonctuel` : Ponctuel ou pas ? *(bool)*
## Désaffecter un salarié à une tournée

Désaffecte un salarié d'une tournée

**DesaffecterSalarieATourneeCommand**

### Paramètres

- `TourneeId` : ID de la tournée *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `SalarieId` : ID du salarié *(decimal)*
- `EstPonctuel` : Ponctuel ou pas ? *(bool)*

## Désaffecter un passage à une tournée

Désaffecte un passage d'une tournée

**DesaffecterPassageATourneeCommand**

### Paramètres

- `TourneeId` : ID de la tournée *(decimal)*
- `Date` : YYYY-MM-DDTHH:MM:SS *(string)*
- `PassageId` : ID du passage *(decimal)*, pour affecter un passage ponctuel utilisez le `PassagePonctuelId`, pour une ligne de plan de soin utilisez `LignePlanSoinsId`
- `EstPonctuel` : Ponctuel ou pas ? *(bool)*
