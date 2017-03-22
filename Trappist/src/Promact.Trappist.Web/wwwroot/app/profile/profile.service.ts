﻿import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { ApplicationUser } from "../profile/profile.model";
import { ChangePasswordModel } from "./password.model";

@Injectable()
export class ProfileService {
    private profileApiUrl = "api/profile";
    editUser: ApplicationUser = new ApplicationUser;
    user: ApplicationUser = new ApplicationUser;

    constructor(public httpService: HttpService) { }

    /**
    * get details of the user
    */
    getUserDetails() {
        return this.httpService.get(this.profileApiUrl);
    }

    /**
    * get details of the user and display them in the profile edit page so that the user can edit the details
    */
    editUserDetails() {
        return this.httpService.get(this.profileApiUrl);
    }

    /**
    * update the  details of the user
    */
    updateUserDetails(editUser: ApplicationUser) {
        return this.httpService.put(this.profileApiUrl, editUser);
    }

    /**
     * Update user Password 
     * @param userPassword
     */
    updateUserPassword(userPassword: ChangePasswordModel) {
        return this.httpService.put(this.profileApiUrl + "/password", userPassword);
    }
}
