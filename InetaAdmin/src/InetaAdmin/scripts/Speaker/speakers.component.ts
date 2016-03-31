import {Component, OnInit} from 'angular2/core';
import {ROUTER_DIRECTIVES, RouteConfig} from 'angular2/router';

import {SpeakersListComponent} from './speakers-list.component';
import {SpeakersDetailComponent} from './speakers-detail.component';
import {SpeakersEditComponent} from './speakers-edit.component';
import {SpeakersAddComponent} from './speakers-add.component';

@Component({
    selector: 'speakers',
    template: `
    <router-outlet></router-outlet>
    `,
    directives: [
        ROUTER_DIRECTIVES
    ]
})
@RouteConfig([
    { path: '/', name: 'SpeakersList', component: SpeakersListComponent, useAsDefault: true },
    { path: '/:id', name: 'Speaker', component: SpeakersDetailComponent },
    { path: '/Add', name: 'NewSpeaker', component: SpeakersAddComponent },
    { path: '/Edit/:id', name: 'EditSpeaker', component: SpeakersEditComponent }
])
export class SpeakersComponent { }
