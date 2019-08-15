#!/bin/bash

mysql -p<insertRootPasswdHere> < ./0000_InitDB.sql

#find ./ -maxdepth 1 -type f -name '*.sql' -execdir ./exec.sh {} \; | sort
#find ./ -maxdepth 1 -type f -name '*.sql' -execdir cat \< {} \; | sort
find ./ -maxdepth 2 -type f -name '*.sql' | sort | xargs -i ./exec.sh {}
