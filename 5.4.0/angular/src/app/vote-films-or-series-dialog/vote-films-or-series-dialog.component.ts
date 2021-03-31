import { Component, OnInit, Optional, Inject, Injector } from '@angular/core';
import { MatSliderChange, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AppComponentBase } from '../../shared/app-component-base';
import { FilmAndSeriesDtocs, VoteDto, FilmPanelServiceProxy } from '../../shared/service-proxies/service-proxies';

@Component({
    selector: 'app-vote-films-or-series-dialog',
    templateUrl: './vote-films-or-series-dialog.component.html',
    styleUrls: ['./vote-films-or-series-dialog.component.css']
})
export class VoteFilmsOrSeriesDialogComponent extends AppComponentBase {
    vote: number;
    filmsAndSeries: FilmAndSeriesDtocs = new FilmAndSeriesDtocs();
    filmsAndSeriesVote: VoteDto = new VoteDto();
    id: number;

    constructor(
        injector: Injector,
        private _dialogRef: MatDialogRef<VoteFilmsOrSeriesDialogComponent>,
        private _voteService: FilmPanelServiceProxy,
        @Optional() @Inject(MAT_DIALOG_DATA) private data: any
    ) {
        super(injector);
        if (data > 0) {
            this._voteService.findVoteByFilmsAndSeriesId(this.data)
                .subscribe((result: any) => {

                    this.filmsAndSeriesVote = result;
                    this.vote = this.filmsAndSeriesVote.point;
                })

        }
        console.log(data)

    }

    ngOnInit() {
    }



    voteNumber($event: MatSliderChange) {
        this.vote = $event.value;
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }

    save() {
        if (this.data > 0) {
            this.filmsAndSeriesVote.filmAndSeriesId = this.data;
            this.filmsAndSeriesVote.description = this.filmsAndSeriesVote.description;
            this.filmsAndSeriesVote.point = this.vote;

            this._voteService.updateVote(this.filmsAndSeriesVote)
                .subscribe((result: any) => {
                    this.notify.info(this.l('UpdatedSuccesfully'));
                    this.close(true);

                })

        } else {
            this.filmsAndSeriesVote.filmAndSeriesId = this.data;
            this.filmsAndSeriesVote.description = this.filmsAndSeriesVote.description;
            this.filmsAndSeriesVote.point = this.vote;

            this._voteService.addVote(this.filmsAndSeriesVote)
                .subscribe((result: any) => {
                    this.notify.info(this.l('SavedSuccessfully'));
                    this.close(true);

                })
        }
    
    }
}
