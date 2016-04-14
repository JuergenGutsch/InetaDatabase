import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Speaker} from './speaker';
import {SpeakerService} from './speaker.service';

@Component({
    selector: 'speakers-edit',
    templateUrl: 'app/speaker/speakers-edit.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [SpeakerService, HTTP_PROVIDERS]
})
export class SpeakersEditComponent implements OnInit {
    @Input() speaker: Speaker = new Speaker();

    constructor(
        private _speakerService: SpeakerService,
        private _routeParams: RouteParams,
        private _router: Router) { }

    ngOnInit() {
        if (!this.speaker.Id) {
            let id = this._routeParams.get('id');
            this._speakerService.getSpeaker(id)
                .subscribe((speaker: Speaker) => this.speaker = speaker);
        }
    }

    public saveSpeaker(speaker: Speaker) {
        this._speakerService.saveSpeaker(speaker);
    }
}
