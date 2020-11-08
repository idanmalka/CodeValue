"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Game = exports.GameStatusDescription = exports.GameStatus = void 0;
const board_1 = require("./board");
var GameStatus;
(function (GameStatus) {
    GameStatus["InProgress"] = "InProgress";
    GameStatus["Completed"] = "Completed";
})(GameStatus = exports.GameStatus || (exports.GameStatus = {}));
var GameStatusDescription;
(function (GameStatusDescription) {
    GameStatusDescription["InProgress"] = "Game is in progress";
    GameStatusDescription["Completed"] = "Game is Completed";
})(GameStatusDescription = exports.GameStatusDescription || (exports.GameStatusDescription = {}));
class Game {
    /**
     * create num x num sized tic tac toe board
     */
    constructor(num) {
        this.log = [];
        this.players = [];
        this.board = new board_1.Board(num, num);
        this.status = GameStatus.InProgress;
    }
    addPlayer(player) {
        if (!this.players.length) {
            this.turn = player;
        }
        this.players.push(player);
        this.log.push(`Player ${player.name} joined the game as ${player.sign}`);
    }
    printSummary() {
        let summaryString = `${GameStatusDescription[this.status]}\nMoves:\n`;
        this.log.forEach((entry) => (summaryString += `${entry}\n`));
        console.log(summaryString);
    }
    nextMove(row, column) {
        if (this.isGameOver) {
            return false;
        }
        const res = this.board.playTurn(row, column, board_1.Sign[this.turn.sign]);
        if (res) {
            this.log.push(`player ${this.turn.name} set in [${row},${column}]`);
            if (this.checkGameOver()) {
                this.log.push(`Game Over, ${this.players.filter((player) => player.sign === this.turn.sign)[0]
                    .name} Won`);
            }
            const nextTurnIndex = (this.players.indexOf(this.turn) + 1) % this.players.length;
            this.turn = this.players[nextTurnIndex];
        }
        return res;
    }
    checkGameOver() {
        if (this.isGameOver) {
            return true;
        }
        const board = this.board.getBoardCopy();
        //rows
        if (board.filter((row) => row.every((sign) => sign === this.turn.sign)).length) {
            this.isGameOver = true;
        }
        //columns
        for (let i = 0; i < board.length; ++i) {
            if (board.every((row) => row[i] === this.turn.sign)) {
                this.isGameOver = true;
            }
        }
        //diagonals
        let i = 0;
        let j = 0;
        while (board[i] && board[i][i] === this.turn.sign) {
            ++i;
        }
        while (board[j] && board[j][board[j].length - 1 - j] === this.turn.sign) {
            ++j;
        }
        if (i === board.length || j === board.length) {
            this.isGameOver = true;
        }
        if (this.isGameOver) {
            this.status = GameStatus.Completed;
        }
        return this.isGameOver;
    }
}
exports.Game = Game;
//# sourceMappingURL=game.js.map