import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import * as signalR from "@microsoft/signalr";
import { HubConnectionState, IHttpConnectionOptions } from '@microsoft/signalr';

@Injectable({
    providedIn: 'root'
})

export class SignalRService {
    constructor(private router: Router) {
    
}
    private hubConnection: signalR.HubConnection
    private options: IHttpConnectionOptions = {   
        accessTokenFactory: () => {
            return localStorage.getItem("access_token");
        }
    };

    public startConnection = () => {
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
    }

    private logoutUser = () => {
        localStorage.removeItem("access_token");
        localStorage.removeItem("expires");
        this.router.navigate(['/']);
    }

    public sessionEvent = (url) => {
        if (this.hubConnection && this.hubConnection.state == HubConnectionState.Connected) {
            console.log(localStorage.getItem("session_id"));
            this.hubConnection.send('onactionasync', localStorage.getItem("session_id"), url)
                .then()
                .catch();
        }
    }
}