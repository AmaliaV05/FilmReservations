import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PreloadAllModules, RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { FilmsListComponent } from './films/films-list/films-list.component';
import { ReservationsListComponent } from './reservations/reservations-list/reservations-list.component'
import { FilmAddComponent } from './films/film-add/film-add.component';
import { FilmsListViewComponent } from './films/film-view/film-view.component';
import { FilmPageComponent } from './films/film-view/film-page.component';
import { FilmsService } from './films/films.service';
import { EditFilmPage } from './films/film-edit/film-edit.component';
import { ReservationsService } from './reservations/reservations.service';
import { FilterPipe } from './films/film-filter/film-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FilmsListComponent,
    ReservationsListComponent,
    FilmAddComponent,
    FilmsListViewComponent,
    FilmPageComponent,
    EditFilmPage,
    FilterPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'films', component: FilmsListComponent, canActivate: [AuthorizeGuard] },
      { path: 'films/add', component: FilmAddComponent, canActivate: [AuthorizeGuard] },
      { path: 'films/:id', component: EditFilmPage, canActivate: [AuthorizeGuard] },
      { path: 'explore', component: FilmsListViewComponent },
      { path: 'film-with-comments/:id/:title', component: FilmPageComponent },
      { path: 'reservations', component: ReservationsListComponent, canActivate: [AuthorizeGuard] }

    ], { preloadingStrategy: PreloadAllModules, relativeLinkResolution: 'legacy' }),
    ReactiveFormsModule,
    PaginationModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    FilmsService,
    ReservationsService
  ],
  exports: [
    PaginationModule, RouterModule, ModalModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
