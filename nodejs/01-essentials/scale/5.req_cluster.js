const cluster = require('cluster');
const http = require('http');

if (cluster.isMaster) {

  // Keep track of http requests
  let numReqs = 0;
  let workerCount = 0;

  // Count requests
  function messageHandler(msg) {
    if (msg.cmd && msg.cmd === 'notifyRequest') {
      numReqs += 1;
      console.log()
    }

    if (numReqs >= workerCount) {
      console.log('Done');
      cluster.disconnect(() => {
        console.log('Cluster disconnected');
        process.exit(0);
      })
    }
  }

  cluster.on('message', messageHandler);

  // Start workers and listen for messages containing notifyRequest
  workerCount = require('os').cpus().length;
  for (let i = 0; i < workerCount; i++) {
    var worker = cluster.fork({workerId: i});
    worker.on('message', messageHandler);
  }

  console.log('[MASTER] Created ' + workerCount + ' workers.');

} else {
  // Worker processes have a http server.
  http
    .get('http://localhost:8000', function(resp) {
      let data = '';

      // A chunk of data has been recieved.
      resp.on('data', (chunk) => {
        data += chunk;
      });

      // The whole response has been received. Print out the result.
      resp.on('end', () => {
        console.log('Response completed: ' + data);
        process.send({ cmd: 'notifyRequest' });
      });
    })
    .on('error', function(err) { console.log(err); });
}