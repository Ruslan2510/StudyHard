import { Routes } from '@angular/router';
import { _404Component } from 'src/app/pages/404/404.component';
import { LoginPageComponent } from './pages/account/login/login-page.component';
import { AccountTemplateComponent } from './shared/templates/account/account.template.component';
import { UserComponent } from './pages/account/details/user.component';
import { SubjectsComponent } from './pages/account/subjects/subjects.component';
import { CategoriesComponent } from './pages/account/categories/categories.component';
import { QuestionsComponent } from './pages/account/questions/questions.component';
import { TheoriesComponent } from './pages/account/theories/theories.component';
import { TheoryComponent } from './pages/account/theories/theory/theory.component';
import { TestResultComponent } from './pages/account/questions/result/test-result.component';
import { LiqpayComponent } from './pages/account/liqpay/liqpay.component';
import { TelegramResultComponent } from './pages/account/questions/telegram result/telegram-result.component';
import { ExamComponent } from './pages/exam/exam.component';
import { ExamPreviewComponent } from './pages/exam/exam-preview/exam-preview.component';
import { ProfileComponent } from './pages/account/details/profile/profile.component';
import { NewPostComponent } from './pages/account/details/new-post-details/new-post-details-component';
import { RegistrationComponent } from './pages/account/registration/registration.component';
import { BlogPageComponent } from './pages/account/blog/blog-page/blog-page.component';
import { BlogTemplateComponent } from './shared/templates/blog/blog.template.component';
import { PlatformTemplateComponent } from './shared/templates/platform/platform.template.component';

export class AppRoutes {
    public static appRoutes: Routes = [
        {
            path:'',
            component: LoginPageComponent
        },
        {
            path: 'registration',
            component: RegistrationComponent
        },
        {
            path: 'platform',
            component: PlatformTemplateComponent,
            children: [
                {
                    path: 'user',
                    component: UserComponent
                },
                {
                    path: "user/profile",
                    component: ProfileComponent,
                },
                {
                    path: 'user/profile/newpost',
                    component: NewPostComponent
                },
                {
                    path: "subjects/:id",
                    component: SubjectsComponent,
                },
                {
                    path: 'categories/:id',
                    component: CategoriesComponent
                },
                {
                    path: 'exampreview/:id',
                    component: ExamPreviewComponent
                },
                {
                    path: 'exam/:id',
                    component: ExamComponent
                },
                {
                    path: ':subjectId/theories/:categoryId',
                    component: TheoriesComponent
                },
                {
                    path: ':subjectId/theory/:theoryId',
                    component: TheoryComponent,
                },
                {
                    path: ':subjectId/questions/:categoryId',
                    component: QuestionsComponent,
                },
                {
                    path: 'buy/:id',
                    component: LiqpayComponent
                },
                {
                    path: 'telegramresult/:id',
                    component: TelegramResultComponent
                },
                {
                    path: 'testresult/:id',
                    component: TestResultComponent
                }
            ]
        },
        {
            path: 'blog/:id',
            component: BlogTemplateComponent,
            children: [
                {
                    path: '**',
                    component: BlogPageComponent,
                }
            ]
        },
        {
            path: 'account',
            component: AccountTemplateComponent,
            children: [
                {
                    path: '',
                    redirectTo: 'login',
                    pathMatch: 'full'
                },
                {
                    path: 'login',
                    component: LoginPageComponent
                }
            ]  
        },
        {
            path: '404',
            component: _404Component
        },
        {
            path: '**',
            redirectTo: '/404'
        }
    ];
}