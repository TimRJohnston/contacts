import { Injectable, Inject } from '@angular/core'
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw';  
@Injectable()  
export class ContactService {  
    myAppUrl: string = "";  
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {  
        this.myAppUrl = baseUrl;  
    }  
    getContacts() {  
        return this._http.get(this.myAppUrl + 'api/Contact/Index')  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    }  
    getContactById(id: number) {  
        return this._http.get(this.myAppUrl + "api/Contact/Details/" + id)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler)  
    }  
    saveContact(contact) {       
        return this._http.post(this.myAppUrl + 'api/Contact/Create', contact)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler) 
    }  
    updateContact(contact) {  
        return this._http.put(this.myAppUrl + 'api/Contact/Edit', contact)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    }  
    deleteContact(id) {  
        return this._http.delete(this.myAppUrl + "api/Contact/Delete/" + id)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    }  
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }  
}