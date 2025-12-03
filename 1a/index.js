import fs from 'fs';
import readline from 'readline';

const FILE = 'input.txt';

function mod(a, b) {
  return a % b >= 0 ? a % b : b + (a % b);
}

const stream = fs.createReadStream(FILE);
const rl = readline.createInterface({
  input: stream,
});

let dial = 50;
let count = 0;
for await (const line of rl) {
  const s = line[0] === 'R' ? 1 : -1;
  const n = Number(line.substring(1)) * s;
  dial = mod(dial + n, 100);
  if (dial === 0) {
    count += 1;
  }
}

console.log(count);
