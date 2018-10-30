import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchContactComponent } from '../fetchcontact/fetchcontact.component';
import { ContactService } from '../../services/contactservice.service';
@Component({
    selector: 'createcontact',
    templateUrl: './AddContact.component.html'
})
export class createcontact implements OnInit {
    contactForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _contactService: ContactService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }
        this.contactForm = this._fb.group({
            id: 0,
            name: ['', [Validators.required]],
            number: ['', [Validators.required]]
        })
    }
    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this._contactService.getContactById(this.id)
                .subscribe(resp => this.contactForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
    }
    save() {
        if (!this.contactForm.valid) {
            return;
        }
        if (this.title == "Create") {
            this._contactService.saveContact(this.contactForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-contact']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._contactService.updateContact(this.contactForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-contact']);
                }, error => this.errorMessage = error)
        }
    }
    cancel() {
        this._router.navigate(['/fetch-contact']);
    }
    get name() { return this.contactForm.get('name'); }
    get number() { return this.contactForm.get('number'); }   
}