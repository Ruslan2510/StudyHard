var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { TopNavigationComponent } from 'src/app/shared/top-navigation/top-navigation.component';
import { LeftSidebarComponent } from 'src/app/shared/left-sidebar/left-sidebar.component';
import { LoginPageComponent } from 'src/app/pages/account/login/login-page.component';
import { ZnoTimerComponent } from 'src/app/pages/account/login/znotimer/znotimer.component';
import { UserComponent } from 'src/app/pages/account/details/user.component';
import { ProfileComponent } from 'src/app/pages/account/details/profile/profile.component';
import { PlatformTemplateComponent } from 'src/app/shared/templates/platform/platform.template.component';
import { AccountTemplateComponent } from 'src/app/shared/templates/account/account.template.component';
import { SubjectsComponent } from 'src/app/pages/account/subjects/subjects.component';
import { CategoriesComponent } from 'src/app/pages/account/categories/categories.component';
import { QuestionsComponent } from 'src/app/pages/account/questions/questions.component';
import { TheoriesComponent } from 'src/app/pages/account/theories/theories.component';
import { TheoryComponent } from './pages/account/theories/theory/theory.component';
import { NotesComponent } from './pages/account/theories/notes/notes.component';
import { LoaderComponent } from './shared/loader/loader.component';
import { PackagesComponent } from './pages/account/packages/packages.component';
import { LiqpayComponent } from 'src/app/pages/account/liqpay/liqpay.component';
import { TestResultComponent } from 'src/app/pages/account/questions/result/test-result.component';
import { TelegramResultComponent } from 'src/app/pages/account/questions/telegram result/telegram-result.component';
import { Auth } from 'src/app/services/Auth';
import { Window } from 'src/app/services/Window';
import { RouterModule } from '@angular/router';
import { AppRoutes } from './app.routes';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { QuillModule } from 'ngx-quill';
import { PravoInterceptor } from "./services/PravoInterceptor";
import { ConfigService } from "./services/ConfigService";
import { ExamComponent } from './pages/exam/exam.component';
import { TimerComponent } from './pages/exam/timer/timer.component';
import { ExamPreviewComponent } from './pages/exam/exam-preview/exam-preview.component';
import { ChartsModule } from 'ng2-charts';
import { NgxMaskModule } from 'ngx-mask';
import { SignalRService } from './services/SignalRServicets';
import { NewPostComponent } from './pages/account/details/new-post-details/new-post-details-component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { RegistrationComponent } from './pages/account/registration/registration.component';
import { AlertifyService } from './services/alertify/alertify.service';
;
import { BlogPageComponent } from './pages/account/blog/blog-page/blog-page.component';
;
import { BlogTemplateComponent } from './shared/templates/blog/blog.template.component';
;
import { AppFooterComponent } from './shared/app-footer/app-footer.component';
import { BlogHeaderComponent } from './shared/blog-header/blog-header.component';
export const configFactory = (configService) => {
    return () => configService.loadConfig();
};
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        imports: [
            BrowserModule,
            FormsModule,
            ReactiveFormsModule,
            HttpClientModule,
            QuillModule.forRoot(),
            RouterModule.forRoot(AppRoutes.appRoutes),
            ChartsModule,
            NgxMaskModule.forRoot(),
            ServiceWorkerModule.register('ngsw-worker.js', { enabled: true, registrationStrategy: "registerImmediately" })
        ],
        declarations: [
            AppComponent,
            TopNavigationComponent,
            LeftSidebarComponent,
            PlatformTemplateComponent,
            AccountTemplateComponent,
            LoginPageComponent,
            UserComponent,
            SubjectsComponent,
            CategoriesComponent,
            QuestionsComponent,
            TheoriesComponent,
            TheoryComponent,
            NotesComponent,
            PackagesComponent,
            TestResultComponent,
            LiqpayComponent,
            TelegramResultComponent,
            LoaderComponent,
            ExamComponent,
            TimerComponent,
            ExamPreviewComponent,
            ProfileComponent,
            ZnoTimerComponent,
            NewPostComponent,
            RegistrationComponent,
            BlogPageComponent,
            BlogTemplateComponent,
            AppFooterComponent,
            BlogHeaderComponent
        ],
        bootstrap: [AppComponent],
        providers: [
            HttpClient,
            Window,
            Auth,
            {
                provide: HTTP_INTERCEPTORS,
                useClass: PravoInterceptor,
                multi: true
            },
            {
                provide: APP_INITIALIZER,
                useFactory: configFactory,
                deps: [ConfigService],
                multi: true
            },
            SignalRService,
            AlertifyService
        ]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map