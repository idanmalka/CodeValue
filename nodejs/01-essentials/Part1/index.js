const server = require('./server');
const client = require('./client');

server.init();
client.makeRequests();

/*
 1. Requests are processed sequentially 
    (sleep sends the thread to idle mode until the interval ends,
    node is single threaded so as long as there is a sleep in process no other jobs will be executed) 
 2. a) the callbacks are executed after all the sleeps are done
    b) all
 */ 