import {Injectable, Component}     from 'angular2/core';
import {Http, Response, HTTP_PROVIDERS} from 'angular2/http';
import {Observable}     from 'rxjs/Observable';

import {Newsletter} from './newsletter';

@Component({
    providers: [Http]
})
@Injectable()
export class NewsletterService {

    constructor(private _http: Http) { }

    private _newslettersUrl: string = '/api/newsletters/';

    getNewsletters() {
        let data: Observable<Newsletter[]> = this._http.get(this._newslettersUrl)
            .map(res => <Newsletter[]>res.json())
            .catch(this.handleError);

        return data;
    }

    getNewsletter(id: string) {
        return this.getNewsletters()
            .map(newsletters => newsletters.find(newsletter => newsletter.Id == id));
    }

    private handleError(error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}