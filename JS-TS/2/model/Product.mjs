export class Product {
    id = "";
    name = "";
    itemsInStock = 0;

    constructor(id, name, itemsInStock) {
        this.id = id;
        this.name = name;
        this.itemsInStock = itemsInStock;
    }

    toString() {
        return `ID: ${this.id}, Name: ${this.name}, Items in stock: ${this.itemsInStock}`;
    }
}