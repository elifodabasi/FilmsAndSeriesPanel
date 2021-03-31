import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountComponent } from './account.component';
import { LoginPersonComponent } from './login - Copy/login-person.component';
import { LoginPersonService } from './login - Copy/login-person.service';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AccountComponent,
                children: [
                    { path: 'login', component: LoginComponent },
                    { path: 'login-person', component: LoginPersonComponent },
                    { path: 'register', component: RegisterComponent }
                ]
            }
        ])
    ],
    providers: [
        LoginPersonService,
    ],

    exports: [
        RouterModule
    ]
})
export class AccountRoutingModule { }
