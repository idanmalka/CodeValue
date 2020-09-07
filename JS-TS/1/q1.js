for (let i = 1; i < 101; ++i) {
    let res = "";
    if (!(i % 3)) {
        res += "fizz";
    }
    if(!(i % 5)) {
        res += "buzz";
    }
    if (res)
        console.log(`${res} ${i}`);
}