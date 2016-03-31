import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Newsletter} from './newsletter';
import {NewsletterService} from './newsletter.service';

@Component({
    selector: 'newsletter-add',
    templateUrl: 'app/newsletter/newsletters-add.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [NewsletterService, HTTP_PROVIDERS]
})
export class NewsletterAddComponent implements OnInit {
    @Input() newsletter: Newsletter = new Newsletter();

    constructor(private _newsletterService: NewsletterService) { }
    

    ngOnInit() {
        
    }
}
