import { LoginOutputModel } from './../models/outputs/login.output.model';
import { LoginInputModel } from './../models/inputs/login.input.model';
import { Injectable } from "@angular/core";
import { Apollo } from 'apollo-angular';
import gql from "graphql-tag";
import { LoginMutation } from '../mutations/login.mutation';
import { map } from 'rxjs/operators';


@Injectable()
export class IdentityService {
    constructor(
        private readonly apollo: Apollo,
        private readonly loginMutation: LoginMutation) {

    }

    public login(input: LoginInputModel) {
        return this.loginMutation.mutate(input).pipe(map(
            (res) => {
                let result = new LoginOutputModel();
                result = res.data?.user.login;
                return result;
            }
        ));
    }
}