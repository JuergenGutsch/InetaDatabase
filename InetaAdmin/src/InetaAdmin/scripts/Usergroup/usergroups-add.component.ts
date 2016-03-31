import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Usergroup} from './usergroup';
import {UsergroupService} from './usergroup.service';

@Component({
    selector: 'usergroups-add',
    templateUrl: 'app/usergroup/usergroups-add.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [UsergroupService, HTTP_PROVIDERS]
})
export class UsergroupsAddComponent implements OnInit {
    @Input() usergroup: Usergroup = new Usergroup();

    constructor(private _usergroupService: UsergroupService) { }
    

    ngOnInit() {
        
    }
}
