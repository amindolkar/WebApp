import { Component, OnInit, Input } from '@angular/core';
import { ViewCell } from 'ng2-smart-table';
import { Router } from '@angular/router';
import { Button } from 'protractor';
import { UserService } from '../user.service';


@Component({
  selector: 'button-view',
  template: '<button type="button" (click)="DeleteUserRecord()" title="Delete" class="btn btn btn-danger"><i class="fa fa-trash"></i>Delete</button>'
})

export class DeleteButtonComponent implements ViewCell, OnInit {
  @Input() value: any;
  @Input() rowData: any;
  public rendervalue: string;
  public status: any;

  constructor(private router: Router, private user: UserService) { }

  ngOnInit() {
    this.rendervalue = this.rowData.value;
    this.status = this.rowData.status;
  }

  DeleteUserRecord() {
    this.user.DeleteUser(this.rendervalue).subscribe((data): any => {
      if (data) {
        alert("Deleted Successfully");

      }
    });

  }
}


