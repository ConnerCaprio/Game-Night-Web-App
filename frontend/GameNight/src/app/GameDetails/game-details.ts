import { Component, inject, OnInit, ChangeDetectorRef } from '@angular/core';
import { GameService } from './../Services/game-service';
import { ActivatedRoute } from '@angular/router';
import { GameWithPieces } from '../shared/models/game-with-pieces-model';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-game-details',
  imports: [CommonModule],
  templateUrl: './game-details.html',
  styleUrl: './game-details.css',
})
export class GameDetails implements OnInit {
  
  private gameService = inject(GameService);
  private cdr = inject(ChangeDetectorRef);
  game?: GameWithPieces;
  currentSuggestion = '';

  constructor(private route: ActivatedRoute) {
  }

    ngOnInit(): void {
    const name = this.route.snapshot.paramMap.get('name');

    if (name) {
      this.gameService.getGameByName(name).subscribe({
        next: (game) => {
          console.log(game);
          this.game = game;
          this.cdr.markForCheck();
        },
        error: (err) => console.error(err)
      });
    }
  }

  displaySuggestionFromCategory(category: string) {
    if (!this.game?.pieces) return;

    const suggestions = this.game.pieces[category];

    if (!suggestions || suggestions.length === 0) return;

    const randomIndex = Math.floor(Math.random() * suggestions.length);
    this.currentSuggestion = suggestions[randomIndex];
  }

  clearSuggestion() {
    this.currentSuggestion = '';
  }
}
