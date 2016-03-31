import {Component, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {ROUTER_DIRECTIVES} from 'angular2/router';

import {Usergroup} from './usergroup';
import {UsergroupService} from './usergroup.service';

@Component({
    selector: 'usergroups-list',
    templateUrl: 'app/usergroup/usergroups-list.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [UsergroupService, HTTP_PROVIDERS]
})
export class UsergroupsListComponent implements OnInit {

    constructor(private _usergroupService: UsergroupService) { }

    usergroups: Usergroup[];
    errorMessage: any;

    ngOnInit() {
        this._usergroupService.getUsergroups()
            .subscribe(
                usergroups => this.usergroups = usergroups,
                error => this.errorMessage = <any>error);
    }
}
