import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Event} from './event';
import {EventService} from './event.service';

@Component({
    selector: 'events-add',
    templateUrl: 'app/event/events-add.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [EventService, HTTP_PROVIDERS]
})
export class EventsAddComponent implements OnInit {
    @Input() event: Event = new Event();

    constructor(private _speakerService: EventService) { }
    

    ngOnInit() {
        
    }
}
