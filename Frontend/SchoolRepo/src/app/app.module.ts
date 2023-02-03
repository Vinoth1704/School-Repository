import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PerformanceComponent } from './Performance/performance.component';
import { FilterMenuComponent, FilterMenuContainerComponent, GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OverallPerformanceComponent } from './overall-performance/overall-performance.component';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ListOfStudentsComponent } from './list-of-students/list-of-students.component';
import { FilterModule } from '@progress/kendo-angular-filter';



@NgModule({
  declarations: [
    AppComponent,
    PerformanceComponent,
    OverallPerformanceComponent,
    ListOfStudentsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GridModule,
    ButtonsModule,
    FilterModule,    
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
