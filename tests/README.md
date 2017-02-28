# Tests

Des tests pour les APIs sont disponibles, pour les utiliser il faut installer [Postman](https://www.getpostman.com/ "postman").

## I) Importer les tests

Il suffit pour ça d'importer le fichier [tests.json](https://raw.githubusercontent.com/up-arcan/WebAPI/master/tests/tests.json).

## II) Créer un environnement de test

Dans les environnements de Postman, importer [environnement.json](https://raw.githubusercontent.com/up-arcan/WebAPI/master/tests/environnement.json), et renseigner les variables.

- `ATHOME_URL` : URL be base du site AtHome (ex: https://dev.arcan.fr/AtHome)
- `ATHOME_LOGIN` : login
- `ATHOME_PASSWORD_HASH` : sha256 du mot-de-passe
- `SEJOUR_ID_EXTERNE` : ID externe d'un séjour (lien AtHome <-> TELEVITALE/GeoSoin)
- `DATE_DEBUT_SEJOUR` : YYYY-MM-DDTHH:MM:SS (ex: 2017-01-01T08:00:00)
- `DATE_FIN_SEJOUR` : YYYY-MM-DDTHH:MM:SS (ex: 2017-06-30T08:00:00)

![cfg environnement](https://raw.githubusercontent.com/up-arcan/WebAPI/master/tests/cfg-environnement.png "cfg environnement")

## III) Lancer les tests

Lancer le runner et sélectionner le dossier **AtHome WebAPI** et l'environnement **Arcan Tests**.

![Exemple](https://raw.githubusercontent.com/up-arcan/WebAPI/master/tests/example1.png "Exemple")
