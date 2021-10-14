var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
let ZnoTimerComponent = class ZnoTimerComponent {
    constructor() {
        this.days = '01';
        this.hours = '01';
        this.minutes = '40';
        this.seconds = '00';
    }
    ngOnInit() {
        this.startTimer();
    }
    startTimer() {
        let countDate2 = new Date("May 11, 2022 10:00:00").getTime();
        const countDownDate = countDate2;
        let timer = setInterval(() => {
            const now = new Date().getTime();
            const distance = countDownDate - now;
            const days = Math.floor(distance / (1000 * 60 * 60 * 24));
            const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            const seconds = Math.floor((distance % (1000 * 60)) / 1000);
            const minsFormatted = minutes.toString();
            const secsFormatted = seconds.toString();
            this.days = `${days.toString()}`;
            this.hours = `${hours.toString()}`;
            this.minutes = minutes < 10 ? `0${minsFormatted}` : minsFormatted;
            this.seconds = seconds < 10 ? `0${secsFormatted}` : secsFormatted;
            if (distance < 0) {
                clearInterval(timer);
            }
            this.timer = timer;
        }, 1000);
    }
    stopTimer() {
        clearInterval(this.timer);
    }
};
ZnoTimerComponent = __decorate([
    Component({
        selector: 'znotimer',
        templateUrl: './znotimer.component.html',
        styleUrls: ['./znotimer.component.css']
    }),
    __metadata("design:paramtypes", [])
], ZnoTimerComponent);
export { ZnoTimerComponent };
//# sourceMappingURL=znotimer.component.js.map