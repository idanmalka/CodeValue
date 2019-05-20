var child_process = require('child_process');


var forked = child_process.fork(__dirname + '/'+'child.js');
forked.on('message', (msg) => {
  console.log('Message from child', msg);
});

forked.send({ hello: 'world' });