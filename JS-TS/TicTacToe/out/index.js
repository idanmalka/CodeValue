"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const game_1 = require("./models/game");
const game = new game_1.Game(3); // rows/cols count
game.addPlayer({ name: 'John', sign: 'x' }); //hint: 'addPlayer' gets an object of interface type
game.addPlayer({ name: 'Jane', sign: 'o' });
game.board.print(); // simple console.log is fine (prints empty board)
console.log(game_1.GameStatus[game.status]); // game status - InProgress/Completed (enum)
game.printSummary(); // InProgress - "Game is in progress" + moves history (console.log is fine)
// nextMove - sets the next player's move. The next player is determined by the order they were added
// Returns a boolean - false if the game is over or the cell is already occupied, otherwise true
console.log(game.nextMove(0, 0)); // row, col - sets 'x' in the top left cell, prints true
console.log(game.nextMove(0, 0)); // does nothing and prints false (cell is already occupied)
console.log(game.nextMove(1, 1)); // sets 'o' in the center, prints true
console.log(game.nextMove(0, 2)); // sets 'x' in the top right cell, prints true
console.log(game.nextMove(2, 2)); // sets 'o' in the bottom right cell, prints true
console.log(game.nextMove(0, 1)); // sets 'x' in the top center cell, prints true
console.log(game.nextMove(2, 1)); // does nothing and prints false (Game over, John won)
// console.log(game.nextMove(0, 0)); //    x   o   o
// console.log(game.nextMove(0, 2)); //        x   o
// console.log(game.nextMove(1, 1)); //            x
// console.log(game.nextMove(0, 1)); //
// console.log(game.nextMove(2, 2)); //
// console.log(game.nextMove(1, 2)); //
// console.log(game.nextMove(0, 0)); //    x       o
// console.log(game.nextMove(0, 2)); //        x   o
// console.log(game.nextMove(1, 1)); //    x       o
// console.log(game.nextMove(1, 2)); //
// console.log(game.nextMove(2, 0)); //
// console.log(game.nextMove(2, 2)); //
// console.log(game.nextMove(2, 0)); //    o   o   o
// console.log(game.nextMove(0, 2)); //        x   
// console.log(game.nextMove(1, 1)); //    x       x
// console.log(game.nextMove(0, 1)); //
// console.log(game.nextMove(2, 2)); //
// console.log(game.nextMove(0, 0)); //
// console.log(game.nextMove(0, 2)); //    o       x
// console.log(game.nextMove(1, 2)); //        x   o
// console.log(game.nextMove(1, 1)); //    x       o
// console.log(game.nextMove(2, 2)); //
// console.log(game.nextMove(2, 0)); //
// console.log(game.nextMove(2, 0)); //
// console.log(game.nextMove(0, 0)); //
game.board.print(); // simple console.log is fine
game.printSummary(); // Completed - "John Doe won!" + moves history
//# sourceMappingURL=index.js.map