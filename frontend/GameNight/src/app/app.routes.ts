import { Routes } from '@angular/router';
import { GameDetails } from './GameDetails/game-details';
import { Home } from './home/home';

export const routes: Routes = [
    {
        path: 'game/:name',
        title: 'Game Details',
        component: GameDetails,
    },
    {
        path: '',
        title: 'GameNight',
        component: Home
    }
];
