#!/bin/sh

die() { printf '%s\n' "$*" >&2; exit 1; }

if [ ${#1} -ne 2 ] || [ ! -d "$1" ]; then
    die "Bad argument: $1"
fi

cd "$1"

case $1 in
1a) node main.js ;;
1b) python3 main.py ;;
2a) cc -Wall -o main main.c && ./main ;;
2b) lua main.lua ;;
3a) gforth main.fs ;;
3b) python3 main.py ;;
esac
