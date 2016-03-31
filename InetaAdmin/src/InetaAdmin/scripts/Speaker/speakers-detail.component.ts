import {Component, Input, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {RouteParams, Router, ROUTER_DIRECTIVES } from 'angular2/router';

import {Speaker}           from './speaker';
import {SpeakerService}           from './speaker.service';

@Component({
    selector: 'speaker',
    templateUrl: 'app/speaker/speakers-detail.template.html',
    directives: [
        ROUTER_DIRECTIVES
    ],
    providers: [SpeakerService, HTTP_PROVIDERS]
})
export class SpeakersDetailComponent implements OnInit {
    speaker: Speaker = new Speaker();

    constructor(
        private _speakerService: SpeakerService,
        private _routeParams: RouteParams,
        private _router: Router) { }

    ngOnInit() {
        if (!this.speaker.Id) {
            let id = this._routeParams.get('id');
            this._speakerService.getSpeaker(id)
                .subscribe((speaker: Speaker) => this._setSpeaker(speaker));
        }
    }
    private _gotoSpeaker() {
        let route = ['Speakers', { id: this.speaker ? this.speaker.Id : null }]
        this._router.navigate(route);
    }

    private _setSpeaker(speaker: Speaker) {
        if (speaker) {
            this.speaker = speaker;
        } else {
            this._gotoSpeaker();
        }
    }
}
