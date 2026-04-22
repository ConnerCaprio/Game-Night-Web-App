import { Component, inject, OnInit, ChangeDetectorRef } from '@angular/core';
import { GameService } from './../Services/game-service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { GameWithPieces } from '../shared/models/game-with-pieces-model';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-game-details',
  imports: [CommonModule, RouterLink],
  templateUrl: './game-details.html',
  styleUrl: './game-details.css',
})
export class GameDetails implements OnInit {
  
  private gameService = inject(GameService);
  private cdr = inject(ChangeDetectorRef);
  game?: GameWithPieces;
  currentSuggestion = '';
  rulesOpen = false;
  activeCategory = '';
  private pieceOrder = ['Ace', 'Nine-Truth', 'Nine-Dare', 'Ten', 'Jack', 'Queen', 'King'];


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

  objectKeys(obj: object): string[] {
    return Object.keys(obj).sort((a, b) => {
      return this.pieceOrder.indexOf(a) - this.pieceOrder.indexOf(b);
    });
  }

  selectCategory(category: string) {
    this.activeCategory = category;
    this.displaySuggestionFromCategory(category);
  }
}
