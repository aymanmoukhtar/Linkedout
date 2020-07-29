import { LoginInputModel } from '../models/inputs/login.input.model';
import { LoginOutputModel } from '../models/outputs/login.output.model';

import { Injectable } from "@angular/core";
import { Mutation } from "apollo-angular";
import gql from "graphql-tag";

@Injectable()
export class LoginMutation extends Mutation<any, LoginInputModel> {
  document = gql`
  mutation login($password:String!,$username:String!){
  user {
      login(password:$password,username:$username){
        token,
        username
      }
  }
}
  `;
}