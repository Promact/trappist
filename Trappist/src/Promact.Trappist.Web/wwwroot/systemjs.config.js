﻿/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        baseURL: '/',
        defaultJSExtensions: true,
        paths: {
            // paths serve as alias
            'npm:': 'node_modules/'
        },
        meta: {

            'npm:tinymce/plugins/advlist/plugin.js': { format: 'global' },
            'npm:tinymce/plugins/autoresize/plugin.js': { format: 'global' },
            'npm:tinymce/plugins/code/plugin.js': { format: 'global' },
            'npm:tinymce/plugins/link/plugin.js': { format: 'global' },
            'npm:tinymce/plugins/lists/plugin.js': { format: 'global' },
            'npm:tinymce/plugins/paste/plugin.js': { format: 'global' },
            'npm:tinymce/plugins/table/plugin.js': { format: 'global' },
            'npm:tinymce/themes/modern/theme.js': { format: 'global' }
        },


        // map tells the System loader where to look for things
        map: {
            // angular bundles
            '@angular/animations': 'npm:@angular/animations/bundles/animations.umd.js',
            '@angular/animations/browser': 'npm:@angular/animations/bundles/animations-browser.umd.js',
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser/animations': 'npm:@angular/platform-browser/bundles/platform-browser-animations.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            '@angular/material': 'npm:@angular/material/bundles/material.umd.js',
            // other libraries
            'rxjs': 'npm:rxjs',
            'rxjs/operators':'npm:rxjs/operators',
            'angular2-wizard-fix': 'npm:angular2-wizard-fix/dist/',
            'angular-in-memory-web-api': 'npm:angular-in-memory-web-api/bundles/in-memory-web-api.umd.js',
            'clipboard': 'npm:clipboard/dist/clipboard.js',
            'ngx-clipboard': 'npm:ngx-clipboard',
            'md2': 'npm:md2/bundles/md2.umd.js',
            'ng2-ckeditor': 'npm:ng2-ckeditor',
            'angular2-infinite-scroll': 'npm:angular2-infinite-scroll',
            'angular2-tinymce': 'npm:angular2-tinymce/dist',
            'tinymce': 'npm:tinymce',
            'ngx-popover': 'npm:ngx-popover',
            'chart.js': 'npm:chart.js',
            'ng2-charts': 'npm:ng2-charts',
            '@angular/cdk': 'npm:@angular/cdk/bundles/cdk.umd.js',
            'ng2-ace-editor': 'npm:ng2-ace-editor',
            'brace': 'npm:brace',
            'w3c-blob': 'npm:w3c-blob',
            'buffer': 'npm:buffer',
            'ieee754': 'npm:ieee754',
            'base64-js': 'npm:base64-js',
            'ace-builds': 'npm:ace-builds/src-min',
            'exceljs/dist/exceljs.min': 'npm:exceljs/dist/exceljs.min.js',
            '@aspnet/signalr-client': 'npm:@aspnet/signalr-client/dist/browser/signalr-client-1.0.0-alpha2-final.min.js',
            'screenfull': 'npm:screenfull/dist/screenfull.js'

        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            rxjs: {
                defaultExtension: 'js'
            },
            'rxjs/operators': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'angular2-wizard-fix': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'ngx-clipboard': {
                main: 'dist/bundles/ngxClipboard.umd.js'
            },
            'clipboard': {
                defaultExtension: 'js'
            },
            'ng2-ckeditor': {
                'main': 'lib/index.js',
                'defaultExtension': 'js'
            },
            'angular2-infinite-scroll': {
                main: 'src/index.js',
                defaultExtension: 'js'
            },
            'ng2-charts': {
                'main': 'index.js',
                'defaultExtension': 'js'
            },
            'angular2-tinymce': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'tinymce': { defaultExtension: 'js' },
            'chart.js': {
                main: 'dist/Chart.bundle.min.js',
                defaultExtension: 'js'
            },
            'ngx-popover': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'ng2-ace-editor': {
                main: 'ng2-ace-editor.js',
                defaultExtension: 'js'
            },
            'brace': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'w3c-blob': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'buffer': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'ieee754': {
                main: 'index.js',
                deafultExtension: 'js'
            },
            'base64-js': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'ace-builds': {
                main: 'ace.js',
                defaultExtension: 'js'
            },
            '.': {
                defaultExtension: 'js'
            }
        }
    });
})(this);