import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/enviroment';
import { GitHubRepo } from '../_models/github/github-repo.type';

@Injectable({ providedIn: 'root' })
export class GitHubReposService {

    private _requestUrl:string='';

    constructor(private http: HttpClient)
    {
        this._requestUrl=`${environment.apiUrl}/GitHub`;
    }

    getRepos(searchInput:string): Observable<any>{

      let reposistories:GitHubRepo[]=[];

      return this.http.get<any>(this._requestUrl+"?searchName="+searchInput)
      .pipe(map(repos => {

          const repItemLength=repos.items.length;

          for(let i:number=0; i<repItemLength; i++){
            reposistories.push({
              gitHubId: repos.items[i].id,
              gitHubName:  repos.items[i].name,
              gitOwnerName:  repos.items[i].full_name,
              description:  repos.items[i].description
            });
           }

        return reposistories;
    }));;
    }
}
