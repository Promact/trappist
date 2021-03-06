﻿import { Component, OnInit } from '@angular/core';
import { Test } from '../tests.model';
import { MdDialogRef, MdSnackBar } from '@angular/material';
import { TestService } from '../tests.service';
import { Router } from '@angular/router';
import { MockRouteService } from '../../questions/questions-single-multiple-answer/mock-route.service';


@Component({
    moduleId: module.id,
    selector: 'delete-test-dialog',
    templateUrl: 'delete-test-dialog.html'
})

export class DeleteTestDialogComponent {
    testToDelete: Test;
    testArray: Test[] = new Array<Test>();
    response: any;
    isDeleteAllowed: boolean;
    errorMessage: string;
    successMessage: string;

    constructor(private testService: TestService, public dialog: MdDialogRef<any>, public snackBar: MdSnackBar, private router:Router, private mockRouteService: MockRouteService) {
        this.errorMessage = 'Something went wrong.Please try again later.';
        this.successMessage = 'The selected test is deleted.';
    }

    /**
     * Delete the test from the test dashboard page
     */
    deleteTest() {
        let url = this.mockRouteService.getCurrentUrl(this.router);
        this.testService.deleteTest(this.testToDelete.id).subscribe((response) => {
            this.testArray.splice(this.testArray.indexOf(this.testToDelete), 1);
            this.dialog.close();
            this.snackBar.open(this.successMessage, 'Dismiss', {
                duration: 3000,
            });
            if (url === '/tests/' + this.testToDelete.id + '/view')
                this.router.navigate(['/tests']);
        },
            err => {
                this.snackBar.open(this.errorMessage, 'Dismiss', {
                    duration: 3000,
                });
            });
    }

}
