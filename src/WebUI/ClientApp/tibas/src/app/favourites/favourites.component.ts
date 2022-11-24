import { Component, OnDestroy, OnInit } from '@angular/core';
import { SubSink } from 'subsink';
import { Favourite } from '../_models/favourite/favourite.type';
import { FavouritesService } from '../_services/favourites.services';

@Component({
  selector: 'app-favourites',
  templateUrl: './favourites.component.html',
  styleUrls: ['./favourites.component.scss'],
})
export class FavouritesComponent implements OnInit, OnDestroy {
  private subs = new SubSink();

  favourites: Favourite[] = [];

  loading: boolean = false;

  constructor(private favouritesService: FavouritesService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.loading = true;
    this.subs.sink = this.favouritesService.getFavourites().subscribe({
      next: (data) => {
        this.favourites = data.favourites;
      },
      error: (err) => {
        console.error(err);
      },
      complete: () => {
        this.loading = false;
      },
    });
  }

  unfavouriteRepo(fav: Favourite) {
    this.subs.sink = this.favouritesService.delete(fav.id).subscribe({
      next: () => {
        this.favourites = this.favourites.filter((x) => x.id != fav.id);
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }
}
