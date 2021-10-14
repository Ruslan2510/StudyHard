import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { Window } from '../../src/app/services/Window';
import { Auth } from '../../src/app/services/Auth';
import { SignalRService } from './services/SignalRServicets';
import { HttpClient } from '@angular/common/http';

declare let gtag: Function;

@Component({
    selector: 'app',
    templateUrl: './app.component.html'
})

export class AppComponent {
    constructor(public router: Router,
        private windowRef: Window,
        private http: HttpClient,
        private auth: Auth,
        private signalR: SignalRService) {
        this.router.events.subscribe(event => {
            this.windowRef.current.Site.getInstance().initComponents();
            if (event instanceof NavigationEnd) {                
                this.checkHttps();
                this.signalRAction();
            }
        })
    }

    ngOnInit() {
        this.signalR.startConnection();
    }

    signalRAction() {
        if (this.auth.isTokenExist()) {
            this.signalR.sessionEvent(this.router.url);
        }
    }

    checkHttps() {
        var needRedirect = false;
        var newUrl = window.location.href;
        if (window.location.href.includes("www.")) {
            newUrl = window.location.href.replace('www.', '')
            needRedirect = true;
        }

        if (needRedirect) {
            window.location.href = newUrl;
        }
    }
}