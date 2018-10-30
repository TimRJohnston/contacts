import { NgModule } from '@angular/core';
import { ContactService } from './services/contactservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchContactComponent } from './components/fetchcontact/fetchcontact.component'
import { createcontact } from './components/addcontact/AddContact.component'
@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchContactComponent,
        createcontact,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-contact', component: FetchContactComponent },
            { path: 'register-contact', component: createcontact },
            { path: 'contact/edit/:id', component: createcontact },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ContactService]
})
export class AppModuleShared {
}