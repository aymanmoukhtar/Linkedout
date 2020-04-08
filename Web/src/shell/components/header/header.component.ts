import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
    routes = [];
    isVisible = false;

    constructor(private readonly _router: Router) { }

    ngOnInit() {
        this._router
            .events
            .pipe(filter(e => e instanceof NavigationEnd))
            .subscribe(() => {
                this.isVisible = !this._router.url.includes('identity');
                this.routes = [
                    { path: ['feed'], isActive: this._router.url === '/feed', icon: 'home', label: 'Feed' },
                    { path: ['people'], isActive: this._router.url === '/people', icon: 'people', label: 'People' },
                    { path: ['messaging'], isActive: this._router.url === '/messaging', icon: 'message', label: 'Messaging' },
                    { path: ['notifications'], isActive: this._router.url === '/notifications', icon: 'notifications', label: 'People' }
                ];
            });
    }
}