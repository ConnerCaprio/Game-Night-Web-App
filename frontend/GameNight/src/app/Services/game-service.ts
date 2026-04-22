import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { response } from 'express';
import { GetGamesResponse } from '../shared/models/getGamesResponseModel';
import { Game } from '../shared/models/game-model';
import { GameWithPieces } from '../shared/models/game-with-pieces-model';


@Injectable({
  providedIn: 'root',
})
export class GameService {
  private http = inject(HttpClient);

  private getGamesApiUrl = 'https://localhost:7064/GetGames';

   getGames(): Observable<Game[]> {
  return this.http.get<GetGamesResponse>(this.getGamesApiUrl).pipe(
    map((response: GetGamesResponse) =>
      response.gamesWithPieces.map((game: Game) => ({
        ...game,
        sluggedName: game.sluggedName || game.name
          .toLowerCase()
          .split(/\s+/)
          .map(word => word.charAt(0).toUpperCase() + word.slice(1))
          .join('')
      }))
    )
  );
}

  getGameByName(gameName: string): Observable<GameWithPieces> {
    const url = `${this.getGamesApiUrl}/${encodeURIComponent(gameName)}`;

    return this.http.get<GameWithPieces>(url);
  }
}
