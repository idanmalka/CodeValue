var http = require("http");

var count = 0;
 for (let i = 0; i < 10; i++)
    http.get("http://localhost:8080", (res) => console.log(`${count++}`));

/*
 Completed 4 at a time
*/