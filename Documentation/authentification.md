# Authentification

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
