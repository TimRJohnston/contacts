import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ContactService } from '../../services/contactservice.service'
@Component({
    selector: 'fetchcontact',
    templateUrl: './fetchcontact.component.html'
})
export class FetchContactComponent {
    public contactList: ContactData[];
    constructor(public http: Http, private _router: Router, private _contactService: ContactService) {
        this.getContacts();
    }
    getContacts() {        
        this._contactService.getContacts().subscribe(
            data => this.contactList = data            
        )
        
    }
    delete(ID) {
        var ans = confirm("Delete contact?");
        if (ans) {
            this._contactService.deleteContact(ID).subscribe((data) => {
                this.getContacts();
            }, error => console.error(error))
        }
    }
}
interface ContactData {
    id: number;
    name: string;
    number: string;    
}