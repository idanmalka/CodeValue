const http = require("http");

function sleep(ms) {
    Atomics.wait(new Int32Array(new SharedArrayBuffer(4)), 0, 0, ms);
}

http.createServer((req, res) => {
    sleep(2000);
    console.log(req);
    res.end("Completed request");
}).listen(8080, () => {
    console.log("listening...");
})