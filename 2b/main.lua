FILE = 'input.txt'

function countDigits(n)
    r = 0
    while n > 0 do
        n = n // 10
        r = r + 1
    end
    return r
end

function partsEqual(n, base)
    local a = n % base

    while n >= base do
        n = n // base
        if n % base ~= a then
            return false
        end
    end

    return true
end

function isSymmetric(n)
    local ndigits = countDigits(n)

    for exp = 1, ndigits // 2 do
        if ndigits % exp == 0 and partsEqual(n, 10 ^ exp) then
            return true
        end
    end
    return false
end

local content = io.open(FILE, 'r'):read('*a')
local total = 0

for first, last in string.gmatch(content, '(%d+)-(%d+)') do
    first, last = tonumber(first), tonumber(last)
    n = first
    while n <= last do
        if isSymmetric(n) then
            total = total + n
        end
        n = n + 1
    end
end

print(total)
