import {Component, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {ROUTER_DIRECTIVES} from 'angular2/router';

import {Newsletter} from './newsletter';
import {NewsletterService} from './newsletter.service';

@Component({
    selector: 'newsletters-list',
    templateUrl: 'app/newsletter/newsletters-list.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [NewsletterService, HTTP_PROVIDERS]
})
export class NewsletterListComponent implements OnInit {

    constructor(private _newsletterService: NewsletterService) { }

    newsletters: Newsletter[];
    errorMessage: any;

    ngOnInit() {
        this._newsletterService.getNewsletters()
            .subscribe(
                newsletters => this.newsletters = newsletters,
                error => this.errorMessage = <any>error);
    }
}
