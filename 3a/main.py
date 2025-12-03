FILE = 'input.txt'

total = 0

def max_idx(a):
    max_i = 0
    for i in range(1, len(a)):
        if a[i] > a[max_i]:
            max_i = i
    return max_i

with open(FILE) as file:
    for line in file:
        a = [int(char) for char in line.strip()]
        max_i = max_idx(a[:-1])
        total += a[max_i] * 10 + max(a[max_i+1:])

print(total)
