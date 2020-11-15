function sum(num1, num2) {
    return new Promise((resolve, reject) => { 
        setTimeout(() => {
            if (isNaN(num1) || isNaN(num2)) {
                reject('invalid input');
            }
            resolve(num1 + num2);
         }, 1000);
    });
}

module.exports = {
    sum
}