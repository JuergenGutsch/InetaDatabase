import {Injectable, Component}     from 'angular2/core';
import {Http, Response, HTTP_PROVIDERS} from 'angular2/http';
import {Observable} from 'rxjs/Observable';

import {Usergroup} from './usergroup';

@Component({
    providers: [Http]
})
@Injectable()
export class UsergroupService {

    constructor(private _http: Http) { }

    private _usergroupsUrl: string = '/api/usergroups/';

    getUsergroups() {
        let data: Observable<Usergroup[]> = this._http.get(this._usergroupsUrl)
            .map(res =>  <Usergroup[]>res.json())
            .catch(this.handleError);
        
        return data;
    }

    getUsergroup(id: string) {
        return this.getUsergroups()
            .map(usergroups => usergroups.find(usergroup => usergroup.Id == id));
    }

    private handleError(error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}