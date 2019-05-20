const http = require('http');
const cluster = require("cluster");
const childProc = require("child_process");

if (cluster.isMaster) {
    for (let i = 0; i < 4; i++)
        cluster.fork();
} else {
    console.log(`worker started ${process.pid}`);
    http.createServer((req, res) => {
        let subWorker = childProc.fork("./calcsum");
        subWorker.on("message", msg => {
            console.log("worker received response: " + msg)
            res.end("done");
        });
        subWorker.send({ num1: Math.random() * 10, num2: Math.random() * 10 });
    }).listen(8080, () => console.log(`worker ${process.pid} listening...`));
}