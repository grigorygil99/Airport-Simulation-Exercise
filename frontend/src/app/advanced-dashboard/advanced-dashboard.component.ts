import { Component, OnInit } from '@angular/core';
import { AdvancedDashboardService } from './advanced-dashboard.service';
import { RequestModel } from '../models/Request';
@Component({
  selector: 'app-advanced-dashboard',
  templateUrl: './advanced-dashboard.component.html',
  styleUrls: ['./advanced-dashboard.component.css']
})
export class AdvancedDashboardComponent implements OnInit {

  requests : RequestModel[] = [];

  constructor(private advancedDashboardService : AdvancedDashboardService) { 

  }

  showRequests(){
    this.advancedDashboardService.getRequests()
      .subscribe((data : RequestModel[]) => console.log(data))

  }

  ngOnInit(): void {
    this.showRequests();
  }

}
