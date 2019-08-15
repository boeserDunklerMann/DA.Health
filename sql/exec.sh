#!/bin/bash

echo $1
if [ "$1" != "./0000_InitDB.sql" -a "$1" != "./0000_create.basics.sql" ]
    then
     mysql -u health -pgesundheit Health < $1
fi
