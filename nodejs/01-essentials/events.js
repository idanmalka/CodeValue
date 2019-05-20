const events = require('events');

const eventEmitter = new events.EventEmitter();

//Create an event handler:
var myEventHandler = function () {
  console.log('Hello from Event Handler!');
}

//Assign the event handler to an event:
eventEmitter.on('speak', myEventHandler);
eventEmitter.on('error', function(err) { console.log('Oops', err); });

//Fire the 'speak' event:
eventEmitter.emit('speak');
eventEmitter.emit('error', new Error('Bad'));

console.log('Done');