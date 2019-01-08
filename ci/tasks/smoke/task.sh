#!/bin/sh
set -e 


STATUSCODE=$(curl -k --silent --output /dev/stderr --write-out "%{http_code}" ${app_url})

if test $STATUSCODE -ne 200; then
   exit 1
fi