export enum Sign {
  x = "x",
  o = "o",
  EMPTY = " ",
}

export class Board {
  private items: Sign[][] = [];
  private maxWidth: number;
  private maxHeight: number;

  constructor(width: number, height: number) {
    this.maxWidth = width;
    this.maxHeight = height;
    for (let i = 0; i < height; ++i) {
      this.items.push(Array(width).fill(Sign.EMPTY));
    }
  }

  public playTurn(row: number, column: number, sign: Sign): boolean {
    if (
      row < 0 ||
      column < 0 ||
      row >= this.maxHeight ||
      column >= this.maxWidth ||
      this.items[row][column] !== Sign.EMPTY
    ) {
      return false;
    }

    this.items[row][column] = sign;
    return true;
  }

  public getBoardCopy(): Sign[][] {
    return JSON.parse(JSON.stringify(this.items));
  }

  public print(): void {
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
