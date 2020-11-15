const events = require('events');
const emitter = new events.EventEmitter();

function init() {
    intervalSubscription = setInterval(() => {
        emitter.emit('numbersGenerated', Math.floor(Math.random() * 1000), Math.floor(Math.random() * 1000));
     }, 1000);
}

module.exports = {
    init,
    emitter
}