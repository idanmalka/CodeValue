import { Player } from "./player";
import { Board, Sign } from "./board";

export enum GameStatus {
  InProgress = "InProgress",
  Completed = "Completed",
}

export enum GameStatusDescription {
  InProgress = "Game is in progress",
  Completed = "Game is Completed",
}

export class Game {
  public board: Board;
  public status: GameStatus;

  private log: string[] = [];
  private turn: Player;
  private players: Player[] = [];
  private isGameOver: boolean;

  /**
   * create num x num sized tic tac toe board
   */
  constructor(num: number) {
    this.board = new Board(num, num);
    this.status = GameStatus.InProgress;
  }

  public addPlayer(player: Player): void {
    if (!this.players.length) {
      this.turn = player;
    }
    this.players.push(player);
    this.log.push(`Player ${player.name} joined the game as ${player.sign}`);
  }

  public printSummary(): void {
    let summaryString = `${GameStatusDescription[this.status]}\nMoves:\n`;
    this.log.forEach((entry) => (summaryString += `${entry}\n`));
    console.log(summaryString);
  }

  public nextMove(row: number, column: number): boolean {
    if (this.isGameOver) {
      return false;
    }

    const res = this.board.playTurn(row, column, Sign[this.turn.sign]);
    if (res) {
      this.log.push(`player ${this.turn.name} set in [${row},${column}]`);
      if (this.checkGameOver()) {
        this.log.push(
          `Game Over, ${
            this.players.filter((player) => player.sign === this.turn.sign)[0]
              .name
          } Won`
        );
      }
      const nextTurnIndex =
        (this.players.indexOf(this.turn) + 1) % this.players.length;
      this.turn = this.players[nextTurnIndex];
    }

    return res;
  }

  private checkGameOver(): boolean {
    if (this.isGameOver) {
      return true;
    }

    const board = this.board.getBoardCopy();

    //rows
    if (
      board.filter((row) => row.every((sign) => sign === this.turn.sign)).length
    ) {
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
      while (board[i] && board[i][i] === this.turn.sign) { ++i; }
      while (board[j] && board[j][board[j].length - 1 - j] === this.turn.sign) { ++j; }

      if (i === board.length || j === board.length) {
          this.isGameOver = true;
      } 

      if (this.isGameOver) {
          this.status = GameStatus.Completed;
      }
    return this.isGameOver;
  }
}
