import { Component, Injector, AfterViewInit, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { FilmPanelServiceProxy, FilmAndSeriesDtocs } from '../../shared/service-proxies/service-proxies';

@Component({
    templateUrl: './home.component.html',
    animations: [appModuleAnimation()]
})
export class HomeComponent extends AppComponentBase implements OnInit {

    movieSeries: FilmAndSeriesDtocs = new FilmAndSeriesDtocs();
    movieSeriesList: any[] = [];

    constructor(
        injector: Injector,
        private _filmandSeriesService: FilmPanelServiceProxy
    ) {
        super(injector);
       
    }

    ngOnInit() {
        this.getMoviesAndFlms();
    }



    getMoviesAndFlms(): void {
        this._filmandSeriesService.getMoviesAndSeries().subscribe(result => {
            this.movieSeriesList = result.map(x => ({ image: x.url, thumbImage: x.url, title: x.title }));

        });
    }
}
