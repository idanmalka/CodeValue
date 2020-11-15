const server = require('./server');
const client = require('./client');
const cluster = require('cluster');

if (process.argv[2] === 'server') {
    server.init();
    return;
}

if (process.argv[2] === 'client') {
    client.makeRequests('http://localhost:8001', 10);
    return;
}

if (cluster.isWorker) {
    console.log('i am Worker');
    client.makeRequests('http://localhost:8001', 10);
    return;
}

console.log('i am Master');
server.init();
cluster.fork();
