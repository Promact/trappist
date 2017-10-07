﻿import { Component, Injectable, OnInit } from '@angular/core';
import { CategoryService } from '../categories.service';
import { MdDialogRef, MdSnackBar } from '@angular/material';
import { Category } from '../category.model';

@Injectable()
@Component({
    moduleId: module.id,
    selector: 'update-category-dialog',
    templateUrl: 'update-category-dialog.html'
})

export class UpdateCategoryDialogComponent implements OnInit {
    private response: any;
    private successMessage: string;

    isCategoryNameExist: boolean;
    errorMessage: string;
    category: Category;
    responseObject: Category;
    isButtonClicked: boolean;

    constructor(private categoryService: CategoryService, private dialogRef: MdDialogRef<UpdateCategoryDialogComponent>, public snackBar: MdSnackBar) {
        this.isCategoryNameExist = false;
        this.successMessage = 'Category name updated successfully.';
        this.isButtonClicked = false;;
    }

    ngOnInit() {
        this.selectTextArea();
    }

    /**
     * Open snackbar
     */
    openSnackBar(message: string) {
        let snackBarRef = this.snackBar.open(message, '', {
            duration: 3000,
        });
    }

    /**
     *Method to update Category 
     * @param category: Category object
     */
    updateCategory(category: Category) {
        this.isButtonClicked = true;
        category.categoryName = category.categoryName.trim();
        if (category.categoryName) {
            this.categoryService.updateCategory(category.id, category).subscribe(
                result => {
                    this.responseObject = result;
                    this.dialogRef.close(this.responseObject);
                    this.openSnackBar(this.successMessage);
                },
                err => {
                    this.isCategoryNameExist = true;
                    this.response = (err.json());
                    this.errorMessage = this.response['error'][0];
                    this.isButtonClicked = false;
                });
        }
    }

    /**
     *Method to toggle error message
     */
    changeErrorMessage() {
        this.isCategoryNameExist = false;
    }

    /**
     * Method to call updateCategory() method when enter key will be pressed
     * @param category:Category object
     */
    onEnter(category: Category) {
        if (!this.isButtonClicked && category.categoryName) {
            this.updateCategory(category);
        }
    }

    /**
     * Selects the text area present in the dialog when the dialog gets opened
     */
    selectTextArea() {
        let textArea: any = document.getElementById('categoryName');
        setTimeout(() => {
            textArea.select();
        }, 500);
    }
}