import { createRequire } from "module";
import { proccessPizza } from "./model/pizza.mjs";

const require = createRequire(import.meta.url);
const fs = require(`fs`);

async function proccess(data) {
    try {
        const res = await proccessPizza(data);
        console.log(res);
    } catch (err) {
        console.log(`pizza proccess threw exception: ${err}`);
    }
}

fs.readFile("./assets/small.in", "utf-8", (err, data) => {
    if (err) {
        console.log(err);
        return;
    }
    proccess(data);
    console.log("DONE");
});