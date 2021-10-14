var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import * as signalR from "@microsoft/signalr";
import { HubConnectionState } from '@microsoft/signalr';
let SignalRService = class SignalRService {
    constructor(router) {
        this.router = router;
        this.options = {
            accessTokenFactory: () => {
                return localStorage.getItem("access_token");
            }
        };
        this.startConnection = () => {
            this.hubConnection = new signalR.HubConnectionBuilder()
                .withUrl('/session', this.options)
                .withAutomaticReconnect()
                .build();
            this.hubConnection.on('logoutUser', () => {
                this.logoutUser();
            });
            this.hubConnection
                .start()
                .then()
                .catch();
        };
        this.logoutUser = () => {
            localStorage.removeItem("access_token");
            localStorage.removeItem("expires");
            this.router.navigate(['/']);
        };
        this.sessionEvent = (url) => {
            if (this.hubConnection && this.hubConnection.state == HubConnectionState.Connected) {
                console.log(localStorage.getItem("session_id"));
                this.hubConnection.send('onactionasync', localStorage.getItem("session_id"), url)
                    .then()
                    .catch();
            }
        };
    }
};
SignalRService = __decorate([
    Injectable({
        providedIn: 'root'
    }),
    __metadata("design:paramtypes", [Router])
], SignalRService);
export { SignalRService };
//# sourceMappingURL=SignalRServicets.js.map