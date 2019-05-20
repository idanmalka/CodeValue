var http = require('http');

var count = 0
function handleResponse(data) {
    console.log(count++);
};

module.exports.makeRequests = function () {
    console.log("entered makeRequests");
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    http.get('http://localhost:8080', handleResponse);
    console.log("finished Requests");
}