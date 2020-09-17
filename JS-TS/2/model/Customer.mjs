export class Customer {
    id = "";
    name = "";
    address = "";

    constructor(id, name, address) {
        this.id = id;
        this.name = name;
        this.address = address;
    }

    toString() {
        return `ID: ${this.id}, Name: ${this.name}, Address: ${this.address}`;
    }
}