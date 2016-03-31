import {Component, OnInit} from 'angular2/core';
import {ROUTER_DIRECTIVES, RouteConfig} from 'angular2/router';

import {UsergroupsListComponent} from './usergroups-list.component';
import {UsergroupsDetailComponent} from './usergroups-detail.component';
import {UsergroupsEditComponent} from './usergroups-edit.component';
import {UsergroupsAddComponent} from './usergroups-add.component';

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
    { path: '/', name: 'UsergroupsList', component: UsergroupsListComponent, useAsDefault: true },
    { path: '/:id', name: 'Usergroup', component: UsergroupsDetailComponent },
    { path: '/Add', name: 'NewUsergroup', component: UsergroupsAddComponent },
    { path: '/Edit/:id', name: 'EditUsergroup', component: UsergroupsEditComponent }
])
export class UsergroupsComponent { }
