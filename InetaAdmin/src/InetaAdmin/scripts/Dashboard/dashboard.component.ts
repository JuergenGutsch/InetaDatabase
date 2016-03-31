import {Component, OnInit} from 'angular2/core';
import {ROUTER_PROVIDERS, ROUTER_DIRECTIVES, RouteConfig} from 'angular2/router';

@Component({
    selector: 'dashboard',
    templateUrl: 'app/dashboard/dashboard.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ]
})
export class Dashboard implements OnInit {


    ngOnInit() {

    }
}
