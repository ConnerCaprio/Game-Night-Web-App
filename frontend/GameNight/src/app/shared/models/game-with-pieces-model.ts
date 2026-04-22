import { Game } from "./game-model";

export interface GameWithPieces extends Game {
  pieces: { [key: string]: string[] };
}