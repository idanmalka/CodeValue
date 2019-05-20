const http = require('http');

function sleep(ms) {
    Atomics.wait(new Int32Array(new SharedArrayBuffer(4)), 0, 0, ms);
}

module.exports.init = function () {
    http.createServer((requset, result) => {
        sleep(2000);
        result.end("received request");
    }).listen(8080, () => {
        console.log("listening...");
    })
}