import {Component, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {ROUTER_DIRECTIVES} from 'angular2/router';

import {Event}           from './event';
import {EventService}           from './event.service';

@Component({
    selector: 'events-list',
    templateUrl: 'app/event/events-list.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [EventService, HTTP_PROVIDERS]
})
export class EventsListComponent implements OnInit {

    constructor(private _eventService: EventService) { }

    events: Event[];
    errorMessage: any;

    ngOnInit() {
        this._eventService.getEvents()
            .subscribe(
            events => this.events = events,
                error => this.errorMessage = <any>error);
    }
}
