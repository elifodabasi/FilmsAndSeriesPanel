import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuggestFilmsOrSeriesDialogComponent } from './suggest-films-or-series-dialog.component';

describe('SuggestFilmsOrSeriesDialogComponent', () => {
  let component: SuggestFilmsOrSeriesDialogComponent;
  let fixture: ComponentFixture<SuggestFilmsOrSeriesDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuggestFilmsOrSeriesDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuggestFilmsOrSeriesDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
