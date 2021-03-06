export class Order {
    customer = {};
    products = [];

    constructor(customer, products = []) {
        this.customer = customer;
        this.products = products;
    }

    toString() {
        let printString = `${this.customer.toString()}\n`;
        this.products.forEach(p => printString += `${p.toString()}\n`);
        return printString;
    }
}