import {Injectable, Component}     from 'angular2/core';
import {Http, Response, HTTP_PROVIDERS} from 'angular2/http';
import {Observable}     from 'rxjs/Observable';

import {Event} from './event';

@Component({
    providers: [Http]
})
@Injectable()
export class EventService {

    constructor(private _http: Http) { }

    private _eventsUrl: string = '/api/events/';

    getEvents() {
        let data: Observable<Event[]> = this._http.get(this._eventsUrl)
            .map(res => <Event[]>res.json())
            .catch(this.handleError);

        return data;
    }

    getEvent(id: string) {
        return this.getEvents()
            .map(events => events.find(event => event.Id == id));
    }

    private handleError(error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}