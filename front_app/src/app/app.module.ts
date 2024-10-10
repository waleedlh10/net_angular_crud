import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TableComponent } from './components/feature/table/table.component';
import { EditComponent } from './components/feature/edit/edit.component';
import { DashboardComponent } from './components/interfaces/dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    EditComponent,
    DashboardComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
