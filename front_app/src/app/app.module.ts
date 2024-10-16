import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TableComponent } from './components/feature/table/table.component';
import { EditFeatureComponent } from './components/feature/edit/edit.component';
import { EditComponent } from './components/interfaces/edit/edit.component';
import { DashboardComponent } from './components/interfaces/dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddTicketInterfaceComponent } from './components/interfaces/add-ticket-interface/add-ticket-interface.component';
import { AddTicketFeatureComponent } from './components/feature/add-ticket-feature/add-ticket-feature.component';
import { ModalComponent } from './components/feature/modal/modal.component';
import { ToastComponent } from './components/feature/toast/toast.component';

@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    EditComponent,
    EditFeatureComponent,
    DashboardComponent,
    AddTicketInterfaceComponent,
    AddTicketFeatureComponent,
    ModalComponent,
    ToastComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
