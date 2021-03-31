import { FilmPanelTemplatePage } from './app.po';

describe('FilmPanel App', function() {
  let page: FilmPanelTemplatePage;

  beforeEach(() => {
    page = new FilmPanelTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
