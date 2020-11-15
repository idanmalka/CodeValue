const http = require('http');

function makeRequests(url, ammount) {
    Array(ammount).fill().forEach(x => {
        console.log('sending request');
        http.get(url, res => {
            console.log('response received');
        });
    })
}

module.exports = {
    makeRequests
}