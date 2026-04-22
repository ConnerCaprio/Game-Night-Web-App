import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { RouterLink } from '@angular/router';
import { GameService } from './../Services/game-service';
import { CommonModule } from '@angular/common';
import { Game } from '../shared/models/game-model';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-home',
  imports: [ CommonModule, RouterLink, MatButtonModule ],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements OnInit {
  private gameService = inject(GameService);
  private cdr = inject(ChangeDetectorRef);

  games: Game[] = [];

  ngOnInit(): void {
    this.gameService.getGames().subscribe({
      next: (games: Game[]) => {
        console.log(games);
        this.games = games;
        this.cdr.markForCheck();
      },
      error: (err) => {
        console.error('Error loading games', err);
      }
    });
  }
}
