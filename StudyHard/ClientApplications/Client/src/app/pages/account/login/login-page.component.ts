import { Component, ElementRef, ViewChild } from '@angular/core';
import { Auth } from 'src/app/services/Auth';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { Login } from 'src/app/models/login.model';
import { Window } from 'src/app/services/Window';
import { NgZone } from '@angular/core'; 
import { Router } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: './login-page.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginPageComponent {
    constructor(
        private fb: FormBuilder,
        private router: Router,
        private auth: Auth,
        private windowRef: Window,
        private ngZone: NgZone) {        
    }
    @ViewChild('script', { static: true }) script: ElementRef;

    //TODO move to environments
    idDevelopment: boolean = false;
    loginForm = this.fb.group({
        email:['', Validators.required],
        password:['', Validators.required]
    });

    isLoading: boolean = false;

    login() {
        const loginData: Login = this.loginForm.value;
        this.isLoading = true;
        this.auth.login(loginData, this.hideLoader.bind(this));
    }

    hideLoader() {
        this.isLoading = false;
    }

    convertToScript() {
        const element = this.script.nativeElement;
        const script = document.createElement('script');
        script.src = 'https://telegram.org/js/telegram-widget.js?5';
        var url = this.windowRef.current.location.href;
        if (url.includes("devpravoplatform")) {
            script.setAttribute('data-telegram-login', "PravoDevBot");
        }
        else {
            script.setAttribute('data-telegram-login', "pravozno_bot");
        }
        script.setAttribute('data-size', 'large');
        // Callback function in global scope
        script.setAttribute('data-onauth', 'loginWithTelegram(user)');
        script.setAttribute('data-request-access', 'write');
        element.parentElement.replaceChild(script, element);
    }

    ngOnInit() {
        window['angularComponentReference'] =
        {
            component: this,
            zone: this.ngZone,
            navigateAfterLogin: () => this.navigateAfterLogin(),
        }; 
        var url = this.windowRef.current.location.href;
        this.idDevelopment = url.includes("localhost")
        //if (this.auth.isTokenExist()) {
        //    this.windowRef.current.location.href = '/platform/user';
        //}
    }
    ngAfterViewInit() {
        this.convertToScript();
    }

    navigateAfterLogin() {
        this.router.navigate(['/platform/user']);
    }
}