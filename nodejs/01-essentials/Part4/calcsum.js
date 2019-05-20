function sleep(ms) {
    Atomics.wait(new Int32Array(new SharedArrayBuffer(4)), 0, 0, ms);
}

process.on('message', data => {
    sleep(2000);
    process.send(data.num1 + data.num2);
});