import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { FilmAndSeriesDtocs, FilmPanelServiceProxy, FilmAndSeriesDtocsPagedResultDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { VoteFilmsOrSeriesDialogComponent } from '../vote-films-or-series-dialog/vote-films-or-series-dialog.component';


class PagedTenantsRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: './films.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})
export class FilmsComponent extends PagedListingComponentBase<FilmAndSeriesDtocs> {
    filmsAndSeries: FilmAndSeriesDtocs[] = [];
    keyword = '';

    constructor(
        injector: Injector,
        private _filmAndSeriesServiceProxy: FilmPanelServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    /**
     * Filmleri getirmek için yazıldı.
     * @param request
     * @param pageNumber
     * @param finishedCallback
     */
    list(
        request: PagedTenantsRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;
        request.maxResultCount = 21;
        this._filmAndSeriesServiceProxy
            .getMovies(request.skipCount, request.maxResultCount, request.keyword)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
        )
            .subscribe((result: FilmAndSeriesDtocsPagedResultDto) => {
                this.filmsAndSeries = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    /*
     * Oy vermek için eklenen popupın açıldığı yer.
     * @param id
     */
    private showVotingComponent(id?: number): void {
        let voteComponentDialog;
        if (id === undefined || id <= 0) {
            voteComponentDialog = this._dialog.open(VoteFilmsOrSeriesDialogComponent);
        } else {
            voteComponentDialog = this._dialog.open(VoteFilmsOrSeriesDialogComponent, {
                data: id
            });
        }

        voteComponentDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }

    delete(): void {
   
    }

    


}
