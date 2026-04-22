export interface Game {
  name: string;
  rules: string;
  dateAdded: string;
  minPlayers: number;
  maxPlayers: number;
  playTimeMinutes: number;
  pieces: { [key: string]: string[] };
  sluggedName: string;
}