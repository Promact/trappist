﻿import { Component } from "@angular/core";
import { Category } from "../category.model";
import { CategoryService } from "../categories.service";
import { MdDialog } from '@angular/material';

@Component({
    moduleId: module.id,
    selector: 'add-category-dialog',
    templateUrl: "add-category-dialog.html"
})
export class AddCategoryDialogComponent {
    private category: Category = new Category();
    isNameExist: boolean = false;
    constructor(private categoryService: CategoryService, private dialog: MdDialog) {
    }

    /*
    *Add category in Cateogry Model
    */
    CategoryAdd(category: Category) {
        this.categoryService.addCategory(category).subscribe((response) => {
            this.dialog.closeAll();
        });
    }

    /* to check Whether CategoryName Exists or not
    * if categoryName Exists it will return true and button will be disabled
    */
    CheckDuplicateCategoryName(categoryName: string) {
        this.categoryService.checkDuplicateCategoryName(categoryName).subscribe((result) => {
            this.isNameExist = result;
        });
    }
}
