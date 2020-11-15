const http = require('http');

function init() {
    http.Server((request, result) => {
        console.log('request received');
        sleep(2000);
        result.writeHead(200);
        result.end();
    }).listen(8001, () => console.log('server is up'));
}

function sleep(ms) {
    Atomics.wait(new Int32Array(new SharedArrayBuffer(4)), 0, 0, ms);
}

module.exports = {
    init
}