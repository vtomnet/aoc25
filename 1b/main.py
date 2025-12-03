FILE = 'input.txt'

dial = 50
count = 0

with open(FILE, 'r') as file:
    for line in file:
        line = line.strip()
        n = int(line[1:])
        q, r = divmod(n, 100)
        s = 1 if line[0] == 'R' else -1
        raw = dial + r * s
        if dial > 0 and (raw <= 0 or raw >= 100):
            count += q + 1
        else:
            count += q
        dial = raw % 100

print(count)
