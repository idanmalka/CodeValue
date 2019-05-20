process.on('message', (msg) => {
    console.log('Message from parent:', msg);
});

let counter = 0;
for (var index = 0; index < 5; index++) {
    setInterval(() => {
        process.send({ counter: counter++ });
    }, 1000);
}
