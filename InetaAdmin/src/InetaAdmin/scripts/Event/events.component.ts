import {Component, OnInit} from 'angular2/core';
import {ROUTER_DIRECTIVES, RouteConfig} from 'angular2/router';

import {EventsListComponent} from './events-list.component';
import {EventsDetailComponent} from './events-detail.component';
import {EventsEditComponent} from './events-edit.component';
import {EventsAddComponent} from './events-add.component';

@Component({
    selector: 'events',
    template: `
    <router-outlet></router-outlet>
    `,
    directives: [
        ROUTER_DIRECTIVES
    ]
})
@RouteConfig([
    { path: '/', name: 'EventsList', component: EventsListComponent, useAsDefault: true },
    { path: '/:id', name: 'Event', component: EventsDetailComponent },
    { path: '/Add', name: 'NewEvent', component: EventsAddComponent },
    { path: '/Edit/:id', name: 'EditEvent', component: EventsEditComponent }
])
export class EventsComponent { }
