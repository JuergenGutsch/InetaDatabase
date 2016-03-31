import {Component, OnInit} from 'angular2/core';
import {ROUTER_DIRECTIVES, RouteConfig} from 'angular2/router';

import {NewsletterListComponent} from './newsletters-list.component';
import {NewsletterDetailComponent} from './newsletters-detail.component';
import {NewsletterEditComponent} from './newsletters-edit.component';
import {NewsletterAddComponent} from './newsletters-add.component';

@Component({
    selector: 'newsletters',
    template: `
    <router-outlet></router-outlet>
    `,
    directives: [
        ROUTER_DIRECTIVES
    ]
})
@RouteConfig([
    { path: '/', name: 'NewslettersList', component: NewsletterListComponent, useAsDefault: true },
    { path: '/:id', name: 'Newsletter', component: NewsletterDetailComponent },
    { path: '/Add', name: 'NewNewsletter', component: NewsletterAddComponent },
    { path: '/Edit/:id', name: 'EditNewsletter', component: NewsletterEditComponent }
])
export class NewsletterComponent { }
