import { isGreatPromise, isGreatAsync } from "./promise.mjs";

// chainable
isGreatPromise(100)
    .then(res => console.log(res))
    .catch(reason => console.log(reason));

// async/await
isGreatAsync(5);
