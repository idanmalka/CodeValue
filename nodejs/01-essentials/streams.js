var fs = require('fs');

var readableStream = fs.createReadStream('./srcFile.txt');
var writableStream = fs.createWriteStream('./dstFile.txt');

readableStream.setEncoding('utf8');

// //option 1
// readableStream.on('data', function (chunk) {
//     writableStream.write(chunk);
// });

//option 2
// Pipe the read and write operations
// read input.txt and write data to output.txt
readableStream.pipe(writableStream);

readableStream.on('end', function (chunk) {
    console.log("Finished writing file")
});

