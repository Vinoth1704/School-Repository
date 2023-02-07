import { Component, OnInit } from '@angular/core';
import { student } from '../Model/Students';
import { ConnectionServiceService } from '../Service/connection-service.service';

@Component({
  selector: 'app-list-of-students',
  templateUrl: './list-of-students.component.html',
  styleUrls: ['./list-of-students.component.css']
})
export class ListOfStudentsComponent implements OnInit {

  studentsList: student[] = [{ rollNumber: 0, studentName: '', schoolName: '' }];

  constructor(private connection: ConnectionServiceService) { }

  ngOnInit(): void {
    this.connection.GetAllStudents().subscribe({
      next: (data: any) => { console.warn(data), this.studentsList = data }
    });
  }

}
