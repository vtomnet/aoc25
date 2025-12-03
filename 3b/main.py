FILE = 'example.txt'

N = 12
total = 0

def max_idx(a):
    max_v = a[0]
    max_i = 0
    for i in range(1, len(a)):
        if a[i] > max_v:
            max_v = a[i]
            max_i = i
    return max_v, max_i

with open(FILE) as file:
    for line in file:
        a = [int(char) for char in line.strip()]
        v = 0
        start = 0
        for i in range(N):
            end = len(a) - N + i + 1
            max_n, max_i = max_idx(a[start:end])
            start += max_i + 1
            v = v * 10 + max_n
        total += v

print(total)
