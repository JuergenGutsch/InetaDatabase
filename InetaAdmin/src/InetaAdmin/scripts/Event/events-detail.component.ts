import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Event} from './event';
import {EventService} from './event.service';

@Component({
    selector: 'event',
    templateUrl: 'app/event/events-detail.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [EventService, HTTP_PROVIDERS]
})
export class EventsDetailComponent implements OnInit {
    event: Event = new Event();

    constructor(
        private _eventService: EventService,
        private _routeParams: RouteParams,
        private _router: Router) { }

    ngOnInit() {
        if (!this.event.Id) {
            let id = this._routeParams.get('id');
            this._eventService.getEvent(id)
                .subscribe((event: Event) => this._setEvent(event));
        }
    }
    private _gotoEvent() {
        let route = ['Speakers', { id: this.event ? this.event.Id : null }]
        this._router.navigate(route);
    }

    private _setEvent(event: Event) {
        if (event) {
            this.event = event;
        } else {
            this._gotoEvent();
        }
    }
}
