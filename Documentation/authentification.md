# Authentification

Avant de pouvoir utiliser les APIs une authentification est nécéssaire, elle se déroule en 2 étapes. Pour cela une **APIKEY** et une **APISECRET** vous sont fournis.

## 1) Obtenir l'URL du site AtHome et une réponse SAML

Appeler **https://auth.arcan.fr/api/ApiLogin/GetAuthData?apiKey=APIKEY&apiSecret=APISECRET&uniqueCode=UNIQUECODE** avec les paramètres suivants :

- `APIKEY`
- `APISECRET`
- `UNIQUECODE` : disponible sur la page d'authentification d'AtHome (généralement 320XXXX).

Exemple avec cURL :

```
curl "https://auth.arcan.fr/api/ApiLogin/GetAuthData?apiKey=APIKEY&apiSecret=APISECRET&uniqueCode=UNIQUECODE"
```

Exemple de requête HTTP :

```
GET /api/ApiLogin/GetAuthData?apiKey=APIKEY&apiSecret=APISECRET&uniqueCode=UNIQUECODE HTTP/1.1
Host: auth.arcan.fr
User-Agent: curl/7.52.1
Accept: */*
```

Si l'authentification réussie, la réponse contient une **URL** et une réponse **SAML**. C'est sur cette URL que les appels d'APIs devront être faits.

Exemple de réponse HTTP :

```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Server: Microsoft-IIS/8.5
X-AspNet-Version: 4.0.30319
X-Powered-By: ASP.NET
Access-Control-Allow-Origin: *
Access-Control-Allow-Headers: Content-Type
Access-Control-Allow-Methods: GET
Content-Length: 5951

{
  "Entity": {
    "Url": "https://onehome.arcan.fr/AtHome",
    "Saml": "PHNhbW...2U+"
  },
  "Succeeded": true,
  "Messages": null
}
```

## 2) S'authentifier sur le site AtHome

Pour cela il faut appeler l'URL obtenue à l'étape précédente suivie de `/api/Authentification/Login` et passer le SAML en *POST* et le *Content-Type* `application/x-www-form-urlencoded`, exemple :

**https://dev.arcan.fr/api/Authentification/Login**

> A noter que le jeton SAML passé dans le body doit être "URL encodé" et précédé de `=`

Exemple de requête avec cURL :

```
curl -X POST "https://dev.arcan.fr/api/Authentification/Login" \
-d "=PHNhbW...2U%2B" \
-H "Content-Type: application/x-www-form-urlencoded" \
-H "Expect:"
```

Exemple de requête HTTP :

```
POST /AtHome/api/Authentification/Login HTTP/1.1
Host: dev.arcan.fr
User-Agent: curl/7.52.1
Accept: */*
Content-Type: application/x-www-form-urlencoded
Content-Length: 5905

=PHNhbW...2U%2B
```

Si l'authentification réussie un cookie **ArcanCookieAuth** est renvoyé, il faut alors le réutiliser dans les appels aux APIs.

Exemple de réponse HTTP :

```
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Server: Microsoft-IIS/8.5
X-AspNet-Version: 4.0.30319
Set-Cookie: ASP.NET_SessionId=54qenyk3ck0y2viny5dia4sz; path=/; HttpOnly
Set-Cookie: ArcanCookieAuth=; expires=Mon, 11-Oct-1999 22:00:00 GMT; path=/; HttpOnly
Set-Cookie: ArcanCookieAuth=A87...7F0; expires=Fri, 26-Jan-2018 12:02:46 GMT; path=/; HttpOnly

{
  "Name": "ArcanCookieAuth",
  "Path": "/",
  "Secure": false,
  "Shareable": false,
  "HttpOnly": true,
  "Domain": null,
  "Expires": "2018-01-26T13:05:58.573865+01:00",
  "Value": "A87...7F0",
  "HasKeys": false,
  "Values": [null]
}
```
