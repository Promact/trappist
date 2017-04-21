﻿import { TestOrder } from './enum-testorder';
import { Category } from '../questions/category.model';

export class Test {
    public id: number;
    public testName: string;
    public link: string;
    public startDate: Date;
    public endDate: Date;
    public duration: number;
    public warningTime: number;
    public fromIpAddress: string;
    public toIpAddress: string;
    public warningMessage: string;
    public correctMarks: string;
    public incorrectMarks: string;
    public browserTolerance: number;
    public questionOrder: TestOrder;
    public optionOrder: TestOrder;
    categoryAcList: Category[] = [];
}

