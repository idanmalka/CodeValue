//using the Built-In module 'os'
//Provides information about the computer's operating system
const os = require('os');

console.log("Platform: " + os.platform());//Returns information about the operating system's platform
console.log("Architecture: " + os.arch());// Returns the operating system CPU architecture
console.log('Host: ' + os.hostname());//Returns the hostname of the operating system