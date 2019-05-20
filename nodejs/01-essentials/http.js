const http = require('http');

http.Server((req, res) => {
    res.writeHead(200);
    res.end('hello world\n');
}).listen(8001);

console.log('Server is up, making a HTTP call..');

http.get('http://localhost:8001/test', resp => {
    let data = '';

    // A chunk of data has been recieved.
    resp.on('data', (chunk) => {
        data += chunk;
    });

    // The whole response has been received. Print out the result.
    resp.on('end', () => {
        console.log('Response completed: ' + data);
    });
});
