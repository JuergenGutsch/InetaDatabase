import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Speaker} from './speaker';
import {SpeakerService} from './speaker.service';

@Component({
    selector: 'speaker-add',
    templateUrl: 'app/speaker/speakers-add.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [SpeakerService, HTTP_PROVIDERS]
})
export class SpeakersAddComponent implements OnInit {
    @Input() speaker: Speaker = new Speaker();

    constructor(private _speakerService: SpeakerService) { }
    

    ngOnInit() {
        
    }
}
