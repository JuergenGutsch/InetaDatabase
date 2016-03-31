import {Component, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {ROUTER_DIRECTIVES} from 'angular2/router';

import {Speaker}           from './speaker';
import {SpeakerService}           from './speaker.service';

@Component({
    selector: 'speakers-list',
    templateUrl: 'app/speaker/speakers-list.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [SpeakerService, HTTP_PROVIDERS]
})
export class SpeakersListComponent implements OnInit {

    constructor(private _speakerService: SpeakerService) { }

    speakers: Speaker[];
    errorMessage: any;

    ngOnInit() {
        this._speakerService.getSpeakers()
            .subscribe(
                speakers => this.speakers = speakers,
                error => this.errorMessage = <any>error);
    }
}
