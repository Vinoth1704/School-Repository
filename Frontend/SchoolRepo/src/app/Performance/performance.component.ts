import { Component, OnInit } from '@angular/core';
import { ConnectionServiceService } from '../Service/connection-service.service';
import { Performance } from '../Model/Performance';

@Component({
  selector: 'app-performance',
  templateUrl: './performance.component.html',
  styleUrls: ['./performance.component.css']
})
export class PerformanceComponent implements OnInit {

  average: Performance[] = [{ schoolName: '', overAllPercentage: 0, subjects: [{ subject: '', average: 0 }], numberOfStudents:0 }];

  constructor(private connection: ConnectionServiceService) { }

  ngOnInit(): void {
    this.connection.GetAverage().subscribe({
      next: (data: any) => { console.warn(data), this.average = data }
    })
  }

}
