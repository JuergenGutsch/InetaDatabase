import {Injectable, Component}     from 'angular2/core';
import {Http, Response, HTTP_PROVIDERS, Headers, RequestOptions} from 'angular2/http';
import {Observable}     from 'rxjs/Observable';

import {Speaker} from './speaker';

@Component({
    providers: [Http]
})
@Injectable()
export class SpeakerService {

    constructor(private _http: Http) { }

    private _speakersUrl: string = '/api/speakers/';

    getSpeakers() {
        let data: Observable<Speaker[]> = this._http.get(this._speakersUrl)
            .map(res => <Speaker[]>res.json())
            .catch(this.handleError);

        return data;
    }

    getSpeaker(id: string) {
        let data: Observable<Speaker> = this._http.get(this._speakersUrl + id)
            .map(res => <Speaker>res.json())
            .catch(this.handleError);

        return data;
    }

    saveSpeaker(speaker: Speaker) {

        let body = JSON.stringify(speaker);
        console.info(body);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let temp = this._http.post(this._speakersUrl, body, options)
            .map(res => console.info(res))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}