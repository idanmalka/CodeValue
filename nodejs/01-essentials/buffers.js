var b1 = Buffer.from('hello');
var b2 = Buffer.from([ 104, 101, 108, 108, 111 ]);

console.log('Buffer1: ', b1.toString());
console.log('Buffer2: ', b2.toString());
console.log('Buffer1 JSON: ', b1.toJSON());
