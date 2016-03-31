import {Component} from 'angular2/core';
import {ROUTER_PROVIDERS, ROUTER_DIRECTIVES, RouteConfig} from 'angular2/router';

import {Dashboard} from './Dashboard/dashboard.component';
import {SpeakersComponent} from './Speaker/speakers.component';
import {UsergroupsComponent} from './Usergroup/usergroups.component';
import {EventsComponent} from './Event/events.component';
import {NewsletterComponent} from './Newsletter/newsletters.component';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [
        ROUTER_PROVIDERS
    ]
})
@RouteConfig([
    { path: '/Dashboard', name: 'Dashboard', component: Dashboard, useAsDefault: true },
    { path: '/Speakers/...', name: 'Speakers', component: SpeakersComponent },
    { path: '/Usergroups/...', name: 'Usergroups', component: UsergroupsComponent },
    { path: '/Events/...', name: 'Events', component: EventsComponent },
    { path: '/Newsletter/...', name: 'Newsletter', component: NewsletterComponent },
])
export class AppComponent {

}