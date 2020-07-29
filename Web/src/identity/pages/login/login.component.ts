import { LoginInputModel } from './../../models/inputs/login.input.model';
import { Apollo } from 'apollo-angular';
import gql from "graphql-tag";

import { Component } from '@angular/core';
import { IdentityService } from 'src/identity/services/identity.service';
import { LoginOutputModel } from 'src/identity/models/outputs/login.output.model';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    loginInput: LoginInputModel = new LoginInputModel();
    loginOutput: LoginOutputModel = new LoginOutputModel();
    constructor(private service: IdentityService) {

    }
    onLogin() {
        this.service.login(this.loginInput).subscribe(
            result => {
                this.loginOutput = result;
                localStorage.setItem("user", JSON.stringify(this.loginOutput));
            },
            (error) => {
                console.log(error);
            }
        );

    }
}