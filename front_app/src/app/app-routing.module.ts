import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/interfaces/dashboard/dashboard.component';
import { EditComponent } from './components/interfaces/edit/edit.component';
import { AddTicketInterfaceComponent } from './components/interfaces/add-ticket-interface/add-ticket-interface.component';

const routes: Routes = [
  { path: 'tickets', component: DashboardComponent },
  { path: 'ticket/create', component: AddTicketInterfaceComponent },
  { path: 'ticket/:id', component: EditComponent },
  { path: '**', redirectTo: 'tickets', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
