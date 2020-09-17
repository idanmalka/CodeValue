import { createRequire } from 'module';
const require = createRequire(import.meta.url);
import { Store } from "./model/Store.mjs";
const storeInitialData = require("./assets/storePreset");

console.log(`Creating store`);
const store = new Store();
console.log(`loading initial data`);
store.load(storeInitialData);
console.log(store);
console.log(`adding 3 valid orders and 1 invalid order`);
store.addOrder("0", "0", "1", "2");
store.addOrder("1", "1", "2", "3");
store.addOrder("2", "3");
store.addOrder("2", "3", "4", "5")
console.log(`saving store state`);
const storeCheckpointJsonString = store.save();
store.printOrders();
store.notify();
console.log(`creating new store and loading first store data:`);
const secondStore = new Store();
secondStore.load(storeCheckpointJsonString);
secondStore.printOrders();



