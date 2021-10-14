var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, Output, EventEmitter } from '@angular/core';
let TimerComponent = class TimerComponent {
    constructor() {
        this.hours = '01';
        this.minutes = '40';
        this.seconds = '00';
        this.timerStarted = false;
        this.finishEvent = new EventEmitter();
    }
    ngOnInit() {
    }
    ngOnChanges(changes) {
        if (changes.hasOwnProperty('timerStarted')) {
            changes.timerStarted.currentValue
                ? this.startTimer()
                : this.stopTimer();
        }
    }
    startTimer() {
        let countDate = Date.now();
        countDate += 100 * 60 * 1000;
        let countDate2 = new Date(countDate);
        const countDownDate = countDate2.getTime();
        let timer = setInterval(() => {
            const now = new Date().getTime();
            const distance = countDownDate - now;
            const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            const seconds = Math.floor((distance % (1000 * 60)) / 1000);
            const minsFormatted = minutes.toString();
            const secsFormatted = seconds.toString();
            this.hours = `0${hours.toString()}`;
            this.minutes = minutes < 10 ? `0${minsFormatted}` : minsFormatted;
            this.seconds = seconds < 10 ? `0${secsFormatted}` : secsFormatted;
            if (distance < 0) {
                clearInterval(timer);
                this.finishEvent.next();
            }
            this.timer = timer;
        }, 1000);
    }
    stopTimer() {
        clearInterval(this.timer);
    }
};
__decorate([
    Input(),
    __metadata("design:type", Boolean)
], TimerComponent.prototype, "timerStarted", void 0);
__decorate([
    Output(),
    __metadata("design:type", Object)
], TimerComponent.prototype, "finishEvent", void 0);
TimerComponent = __decorate([
    Component({
        selector: 'timer',
        templateUrl: './timer.component.html',
        styleUrls: ['./timer.component.css']
    }),
    __metadata("design:paramtypes", [])
], TimerComponent);
export { TimerComponent };
//# sourceMappingURL=timer.component.js.map