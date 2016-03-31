import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Usergroup} from './usergroup';
import {UsergroupService} from './usergroup.service';

@Component({
    selector: 'usergroups-detail',
    templateUrl: 'app/usergroup/usergroups-detail.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [UsergroupService, HTTP_PROVIDERS]
})
export class UsergroupsDetailComponent implements OnInit {
    @Input() usergroup: Usergroup = new Usergroup();

    constructor(
        private _usergroupService: UsergroupService,
        private _routeParams: RouteParams,
        private _router: Router) { }

    ngOnInit() {
        if (!this.usergroup.Id) {
            let id = this._routeParams.get('id');
            this._usergroupService.getUsergroup(id)
                .subscribe((usergroup: Usergroup) => this._setUsergroup(usergroup));
        }
    }
    private _gotoUsergroup() {
        let route = ['Usergroup', { id: this.usergroup ? this.usergroup.Id : null }]
        this._router.navigate(route);
    }

    private _setUsergroup(usergroup: Usergroup) {
        if (usergroup) {
            this.usergroup = usergroup;
        } else {
            this._gotoUsergroup();
        }
    }
}
