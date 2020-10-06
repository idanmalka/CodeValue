class IngridientCell {
    // x = 0;
    // y = 0;
    // type = null;
    // taken = false;

    constructor(x, y, type) {
        this.x = x;
        this.y = y;
        this.type = type;
        this.taken = false;
    }
}

export function proccessPizza(data) {
    return new Promise((resolve, reject) => {
        try {
            const pizza = new Pizza(data);
            const slices = pizza.slice();
            resolve(parseOutput(slices));
        } catch (e) {
            reject(e);
        }
    });
}

function parseOutput(slices) {
    let outputString = `${slices.length}`;
    slices.forEach(slice => {
        outputString = `${outputString}
  ${slice.out.join(' ')}`;
    });
    return outputString;
}

export class Pizza {
    // rows = 0;
    // columns = 0;
    // minIngridientCellsInSlice = 0;
    // maxCellsInSlice = 0;
    // pizzaMatrix = [];
    // slices = [];

    constructor(instructionsString) {
        const instructionLines = instructionsString.split("\n");
        const firstRow = instructionLines[0].split(" ");
        this.rows = firstRow[0];
        this.columns = firstRow[1];
        this.minIngridientCellsInSlice = firstRow[2];
        this.maxCellsInSlice = firstRow[3];
        this.pizzaMatrix = [];
        this.slices = [];
        instructionLines.splice(0, 1);
        this.preparePizza(instructionLines);
    }

    preparePizza(ingridientsCompositionRows) {
        ingridientsCompositionRows.forEach(
            (row, i) =>
                this.pizzaMatrix.push(
                    row.split("").map((t, j) => new IngridientCell(i, j, t))
                )
        );
    }

    toString() {
        let pizzaString = "";
        this.pizzaMatrix.forEach(row => {
            row.forEach(cell => pizzaString += cell);
            pizzaString += "\n";
        });
        return pizzaString;
    }

    getCell(x, y) {
        if (x < 0 || y < 0 || x >= this.cols || y >= this.rows) return null;
        return this.pizzaMatrix[y][x];
    }

    takeSlice(cell, w, h) {
        let slice = {};
        const cells = [];
        const ingredients = { M: 0, T: 0 };
        for (var x = cell.x; x < cell.x + w; x += 1) {
            for (var y = cell.y; y < cell.y + h; y += 1) {
                const cell = this.getCell(x, y);
                if (!cell || cell.taken) return null;
                ingredients[cell.type] += 1;
                cells.push(cell);
            }
        }
        if (ingredients.M < this.minIngridientCellsInSlice ||
            ingredients.T < this.minIngridientCellsInSlice) {
            return null;
        }
        cells.forEach((c) => { c.taken = true; });
        slice = {
            cells,
            out: [cell.y, cell.x, cell.y + h - 1, cell.x + w - 1],
        };

        return slice;
    }

    getDivisors(n) {
        const flags = {};
        const divisors = [];
        for (let i = 1; i < n; i++) {
            if (n % i === 0) {
                var f = i;
                var s = n / i;
                if (!flags[`${f}/${s}`]) {
                    flags[`${f}/${s}`] = true;
                    divisors.push([f, s]);
                }
                if (!flags[`${s}/${f}`]) {
                    flags[`${s}/${f}`] = true;
                    divisors.push([s, f]);
                }
            }
        }
        return divisors;
    }

    slice() {
        let divs = [];
        let slices = [];
        for (var i = this.maxCellsInSlice; i >= this.minIngridientCellsInSlice * 2; i--) {
            divs = divs.concat(this.getDivisors(i));
        }

        this.pizzaMatrix.flat().forEach((cell) => {
            divs.forEach((d) => {
                var w = d[0];
                var h = d[1];
                const slice = this.takeSlice(cell, w, h);
                if (slice) {
                    slices.push(slice);
                }
            })
        });

        return slices;
    }
}

