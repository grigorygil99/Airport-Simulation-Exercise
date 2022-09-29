import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdvancedDashboardComponent } from './advanced-dashboard/advanced-dashboard.component';
import { NormalDashboardComponent } from './normal-dashboard/normal-dashboard.component';

const routes: Routes = [

	{
		path: '',
		children: [
		
			{
				path : '',
				component : NormalDashboardComponent,
        outlet: 'normalDashboard'
			},
			{
				path : '',
				component : AdvancedDashboardComponent,
        outlet: 'advancedDashboard'
			},	
		]
	}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
