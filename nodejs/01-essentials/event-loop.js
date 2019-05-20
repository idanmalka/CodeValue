var maxWaitTime = 1000;

// each call is taking random amount of wait time < 1s
var evenUploadSquare = function (v, callback) {
    var waitTime = Math.floor(Math.random() * (maxWaitTime + 1));
    setTimeout(function () {
        callback(v * v, waitTime);
    }, waitTime);
};

//Using anonymous function and track callbacks to print "Done!" message
var count = 0;

for (var i = 0; i < 10; i++) {
    console.log("Calling evenUploadSquare for value: " + i);

    evenUploadSquare(i, function (results, time) {
        console.log("The results are: " + results + " (" + time + " ms)");

        if (++count === 10) {
            console.log("Completed processing all items!");
        }
    });
};

console.log("Main execution is complete!")
console.log("-----");