export function isGreatPromise(number) {
    return new Promise((resolve, reject) => {
        setTimeout(() =>
            number > 10 ?
                resolve(`number ${number} is greater than 10`) :
                reject(`number ${number} is not greater than 10`),
            500);
    });

}

export async function isGreatAsync(number) {
    try {
        const asyncRes = await isGreatPromise(number);
        console.log(`async res resolved:`, asyncRes);
    }
    catch(e) {
        console.log(`async res rejected:`, e);
    }
}