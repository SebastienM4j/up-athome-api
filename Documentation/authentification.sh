#!/bin/bash
#
# Requires
# - curl
# - jq

#
# Args
#

while [ "$1" != "" ]; do
	case $1 in
		-k | --api-key )
			shift
			APIKEY=$1
			;;

		-s | --api-secret )
			shift
			APISECRET=$1
			;;

		-c | --unique-code )
			shift
			UNIQUECODE=$1
			;;
      
    -v )
      shift
  		VERBOSE=true
  	  ;;

		*)
			echo "unknowed parameter $1"
			exit 1
	esac
	shift	
done

if [[ -z "$APIKEY" ]]; then
        echo "API key is required (-k | --api-key)"
        exit 1
fi
if [[ -z "$APISECRET" ]]; then
        echo "API secret is required (-s | --api-secret)"
        exit 1
fi
if [[ -z "$UNIQUECODE" ]]; then
        echo "Unique code is required (-c | --unique-code)"
        exit 1
fi

#
# URL Encode
#

urlencode() {
    # urlencode <string>
    local length="${#1}"
    for (( i = 0; i < length; i++ )); do
        local c="${1:i:1}"
        case $c in
            [a-zA-Z0-9.~_-]) printf "$c" ;;
            *) printf '%s' "$c" | xxd -p -c1 |
                   while read c; do printf '%%%s' "$c"; done ;;
        esac
    done
}

#
# Request for get SAML token
#

saml_resp=$(curl "https://auth.arcan.fr/api/ApiLogin/GetAuthData?apiKey=$APIKEY&apiSecret=$APISECRET&uniqueCode=$UNIQUECODE")
if [ $VERBOSE ]; then
    echo "SAML_RESP=$saml_resp"
fi

url=$(echo "$saml_resp" | jq -r ".Entity.Url")
if [ $VERBOSE ]; then
    echo "URL=$url"
fi

saml=$(echo "$saml_resp" | jq -r ".Entity.Saml")
if [ $VERBOSE ]; then
    echo "SAML=$saml"
fi    

if [ $VERBOSE ]; then
    saml_decoded=$(echo "$saml" | base64 --decode)
    echo "SAML_DECODED=$saml_decoded"
fi

#
# Request for authentication
#

saml_urlencode=$(urlencode "$saml")

auth_resp=$(curl -X POST "$url/api/Authentification/Login" -d "=$saml_urlencode" -H "Content-Type: application/x-www-form-urlencoded" -H "Expect:")
if [ $VERBOSE ]; then
    echo "AUTH_RESP=$auth_resp"
fi

cookieName=$(echo "$auth_resp" | jq -r ".Name")
cookieValue=$(echo "$auth_resp" | jq -r ".Value")

echo "Cookie: $cookieName=$cookieValue"
