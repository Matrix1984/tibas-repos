import { Component, OnDestroy } from '@angular/core';
import { SubSink } from 'subsink';
import { GitHubRepo } from '../_models/github/github-repo.type';
import { FavouritesService } from '../_services/favourites.services';
import { GitHubReposService } from '../_services/github.service';

@Component({
  selector: 'app-github-search',
  templateUrl: './github-search.component.html',
  styleUrls: ['./github-search.component.scss'],
})
export class GithubSearchComponent implements OnDestroy {

  githubrepos: GitHubRepo[] = [];

  repoSearchInput: string = '';

  private subs = new SubSink();

  loading: boolean = false;

  errorMessage: string = '';

  constructor(
    private githubService: GitHubReposService,
    private favouritesService: FavouritesService
  ) {}

  searchReposByName() {
    this.errorMessage = '';
    if (this.repoSearchInput) {
      this.loading = true;
      this.subs.sink = this.githubService
        .getRepos(this.repoSearchInput)
        .subscribe({
          next: (data) => {
            this.githubrepos = data;
          },
          error: (err) => {
            console.error(err);
          },
          complete: () => {
            this.loading = false;
          },
        });
    } else {
      this.errorMessage = 'The form field cant be empty.';
    }
  }

  favouriteRepo(repo: GitHubRepo) {
    this.subs.sink = this.favouritesService.create(repo).subscribe({
      next: (data) => {
        console.log(data);
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
