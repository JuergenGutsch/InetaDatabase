import {Injectable, Component}     from 'angular2/core';
import {Http, Response, HTTP_PROVIDERS} from 'angular2/http';
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
        return this.getSpeakers()
            .map(speakers => speakers.find(speaker => speaker.Id == id));
    }

    private handleError(error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}