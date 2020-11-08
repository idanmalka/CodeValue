"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Board = exports.Sign = void 0;
var Sign;
(function (Sign) {
    Sign["x"] = "x";
    Sign["o"] = "o";
    Sign["EMPTY"] = " ";
})(Sign = exports.Sign || (exports.Sign = {}));
class Board {
    constructor(width, height) {
        this.items = [];
        this.maxWidth = width;
        this.maxHeight = height;
        for (let i = 0; i < height; ++i) {
            this.items.push(Array(width).fill(Sign.EMPTY));
        }
    }
    playTurn(row, column, sign) {
        if (row < 0 ||
            column < 0 ||
            row >= this.maxHeight ||
            column >= this.maxWidth ||
            this.items[row][column] !== Sign.EMPTY) {
            return false;
        }
        this.items[row][column] = sign;
        return true;
    }
    getBoardCopy() {
        return JSON.parse(JSON.stringify(this.items));
    }
    print() {
        let output = "";
        this.items.forEach((row) => {
            row.forEach((item) => {
                output += `${item || ` `} `;
            });
            output += "\n";
        });
        console.log(output);
    }
}
exports.Board = Board;
//# sourceMappingURL=board.js.map