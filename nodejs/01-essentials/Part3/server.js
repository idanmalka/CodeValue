const http = require('http');
var cluster = require("cluster");

function sleep(ms) {
    Atomics.wait(new Int32Array(new SharedArrayBuffer(4)), 0, 0, ms);
}

if (cluster.isMaster) {
    console.log(`master started: ${process.pid}`);
    for (let i = 0; i < 4; i++)
        cluster.fork();  
} else {
    http.createServer((req, res) => {
        sleep(2000);
        res.end("Completed request");
    }).listen(8080, () => console.log(`worker started: ${process.pid}`));
}