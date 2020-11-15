const app = require('./app');
const src = require('./source');

const event = src.emitter;

event.on('numbersGenerated', (number1, number2) => {
    app.sum(number1, number2)
        .catch(err => console.log(err))
        .then(result => console.log(result));
});

src.init();
