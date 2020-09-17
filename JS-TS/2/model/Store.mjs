import { Product } from "./Product.mjs";
import { Customer } from "./Customer.mjs";
import { Order } from "./Order.mjs";

export class Store {
    products = [];
    customers = [];
    orders = [];

    addOrder(customerId, ...productIds) {
        const customer = this.customers.find(c => c.id === customerId);
        const products = productIds.filter(productId => {
            const product = this.products.find(p => p.id === productId);
            return product && product.itemsInStock > 0
        }).map(productId => this.products[productId]);

        if (!customer || products.length < productIds.length) {
            console.log(`new order rejected`);
            return false;
        }
        
        products.forEach(p => p.itemsInStock--);
        const newOrder = new Order(customer, products);
        this.orders.push(newOrder);
        console.log(`order added sccessfuly: `, newOrder);
        return true;
    }

    printOrders() {
        console.log("AAAAAND the orders are:");
        for (const order of this.orders) {
            let printStr = `Customer: ${this.customers[order.customer.id].toString()}\nProducts:\n`;
            for (const product of order.products) {
                printStr += `ID: ${product.id}, Name: ${product.name}\n`;
            }
            console.log(printStr);
        }
    }

    save() {
        const stringThis = JSON.stringify(this);
        console.log(stringThis);
        return stringThis;
    }

    load(state) {
        let stateObj = state;
        if (typeof state === 'string') {
            stateObj = JSON.parse(state);
        }
        
        for (const product of stateObj.products) {
            this.products.push(new Product(product.id, product.name, product.itemsInStock));
        }
        for (const customer of stateObj.customers) {
            this.customers.push(new Customer(customer.id, customer.name, customer.address));
        };
        for (const order of stateObj.orders) {
            const customer = this.customers.find(c => c.id === order.customer.id);
            const products = this.products.filter(existingProduct => order.products.find(orderedProduct => existingProduct.id === orderedProduct.id));
            this.orders.push(new Order(customer, products));
        };
    }

    notify() {
        setTimeout(() => {
            console.log('products that are out of stock:');
            console.log(this.products.filter(product => !product.itemsInStock));
        }, 10000);
    }
}