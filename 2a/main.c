#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include <sys/types.h>

static const char *FILENAME = "input.txt";

int count_digits(long n) {
    int r = 0;
    while (n /= 10) {
        r++;
    }
    return r + 1;
}

int main(void) {
    FILE *fp = fopen(FILENAME, "r");
    if (!fp) {
        fprintf(stderr, "Error opening file %s\n", FILENAME);
        return 1;
    }

    char *part = NULL;
    size_t partcap = 0;
    ssize_t len;
    long first, last, total = 0;
    int ndigits;
    ldiv_t qr;

    while ((len = getdelim(&part, &partcap, ',', fp)) > 0) {
        char *cursor = part;

        first = strtol(strsep(&cursor, "-"), (char**)NULL, 10);
        last = strtol(strsep(&cursor, "-"), (char**)NULL, 10);

        for (long n = first; n <= last; n++) {
            ndigits = count_digits(n);
            if (ndigits % 2 != 0) {
                n = powl(10, ndigits);
                continue;
            }
            qr = ldiv(n, powl(10, ndigits/2));
            if (qr.quot == qr.rem) {
                total += n;
            }
        }
    }

    printf("%ld\n", total);

    free(part);
    fclose(fp);
    return 0;
}
