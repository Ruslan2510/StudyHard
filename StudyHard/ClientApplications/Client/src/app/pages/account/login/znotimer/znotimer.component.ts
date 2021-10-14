import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'znotimer',
    templateUrl: './znotimer.component.html',
    styleUrls: ['./znotimer.component.css']
})
export class ZnoTimerComponent {
    days: string = '01';
    hours: string = '01';
    minutes: string = '40';
    seconds: string = '00';
    timer: any;
    constructor() { }

    ngOnInit(): void {
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
}
