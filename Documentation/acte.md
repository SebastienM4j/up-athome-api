 # Actes

## Obtenir une liste d'actes prédéfinis

Retourne la liste des actes existants sur AtHome.

**GetActesQuery**

### Paramètres facultatifs

- `Libelle` : Libellé de l'acte *(string)* (égalité stricte case sensitive)
- `LibelleCourt` : Libellé court de l'acte *(string)*  (égalité stricte case sensitive)

### Retour

En cas de succès la liste d'actes définie dans AtHome :

- `ActeId` : ID de l'acte *(int)*
- `Libelle` : Nom de l'acte *(string)*
- `LibelleCourt` : Nom court de l'acte *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*

## Obtenir un Acte par ID

Retourne l'acte correspondant à l'ID donné.

**GetActeParIdQuery**

### Paramètres

- `ActeId` : ID de l'acte *(int)*

### Retour

En cas de succès la liste d'actes définie dans AtHome :

- `ActeId` : ID de l'acte *(int)*
- `Libelle` : Nom de l'acte *(string)*
- `LibelleCourt` : Nom court de l'acte *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*

## Créer un Acte

Crée un acte et retourne son ID.

**CreerActeCommand**

### Paramètres

- `Libelle` : Nom de l'acte *(string)*
- `LibelleCourt` : Nom de l'acte, version courte *(string)*
- `TypeIntervenantId` : ID du type d'intervenant *(decimal)*

### Retour

En cas de succès l'id de l'acte créé :

- `ActeId` : *(int)*