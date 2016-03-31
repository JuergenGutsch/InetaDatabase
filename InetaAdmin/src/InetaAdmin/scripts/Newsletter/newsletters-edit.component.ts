import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Newsletter} from './newsletter';
import {NewsletterService} from './newsletter.service';

@Component({
    selector: 'newsletters-edit',
    templateUrl: 'app/newsletter/newsletters-edit.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [NewsletterService, HTTP_PROVIDERS]
})
export class NewsletterEditComponent implements OnInit {
    @Input() newsletter: Newsletter = new Newsletter();

    constructor(
        private _newsletterService: NewsletterService,
        private _routeParams: RouteParams,
        private _router: Router) { }

    ngOnInit() {
        if (!this.newsletter.Id) {
            let id = this._routeParams.get('id');
            this._newsletterService.getNewsletter(id)
                .subscribe((newsletter: Newsletter) => this._setNewsletter(newsletter));
        }
    }
    private _gotoNewsletter() {
        let route = ['Newsletter', { id: this.newsletter ? this.newsletter.Id : null }]
        this._router.navigate(route);
    }

    private _setNewsletter(newsletter: Newsletter) {
        if (newsletter) {
            this.newsletter = newsletter;
        } else {
            this._gotoNewsletter();
        }
    }
}
