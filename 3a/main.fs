s" input.txt" 2constant FILENAME$

256 constant max-line
create linebuf max-line chars allot
create digitbuf max-line cells allot
variable ndigits

: 3drop ( a b c -- ) 2drop drop ;
: is-digit? ( c -- flag ) dup [char] 0 >= swap [char] 9 <= and ;
: >digit ( c -- n ) [char] 0 - ;
: reset-digits ( -- ) 0 ndigits ! ;
: print-digits ( -- ) ndigits @ 0 DO digitbuf i cells + @ . LOOP ;

: ?store-digit ( c -- )
    dup is-digit? IF
        >digit
        digitbuf ndigits @ cells + !
        1 ndigits +!
    ELSE
        drop
    THEN ;

: nth-digit ( i -- n ) digitbuf swap cells + @ ;

: max-index ( i0 i1 -- i2 )    \ i2 is idx of max value in [i0,i1]
    over ?DO
        dup nth-digit
        i nth-digit
        < IF
            drop i
        THEN
    LOOP ;

: process-bank ( -- n )
    ndigits @ 0 over 1- max-index
    dup 1+ rot max-index nth-digit
    swap nth-digit 10 * + ;

: process-line ( c-addr u -- n )
    reset-digits
    over + swap DO
        i c@ ?store-digit
    LOOP
    process-bank ;

: process-file ( fileid -- n )
    >r 0    \ accumulate process-line result
    BEGIN
        linebuf dup max-line r@ read-line throw
    WHILE
        process-line +
    REPEAT
    r> 3drop ;

: main ( -- )
    FILENAME$ r/o open-file throw
    dup process-file . cr
    close-file throw ;

main bye
