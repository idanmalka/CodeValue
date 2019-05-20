const http = require('http');
var cluster = require("cluster");

if (cluster.isMaster) {
    http.createServer((req, res) => {
        let worker = cluster.fork();
        worker.on("message", msg => {
            console.log("master received response: " + msg)
            res.end("done");
        });
        worker.send({ num1: Math.random() * 10, num2: Math.random() * 10 });
    }).listen(8080, () => console.log(`master started: ${process.pid}`));
} else {
    console.log(`worker started ${process.pid}`);
    require("./calcsum")
}