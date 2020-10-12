const fs = require('fs')


for(let i = 0; i < 10000; i++){
    const num = Math.floor(Math.random() * 100);
    fs.appendFileSync('data.txt', num + '\n')
}

