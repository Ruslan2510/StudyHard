import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.css']
})
export class TimerComponent {
    hours: string = '01';
    minutes: string = '40';
    seconds: string = '00';
    timer: any;

    @Input() timerStarted: boolean = false;
    @Output() finishEvent = new EventEmitter();
  constructor() { }

    ngOnInit(): void {
    }

    ngOnChanges(changes: any) {
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
}
