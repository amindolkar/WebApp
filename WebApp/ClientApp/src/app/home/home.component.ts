import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  productForm: FormGroup;
  FirstName: FormControl;
  LastName: FormControl;
  City: FormControl;
  PhoneNumber: FormControl;
  data: any;

  constructor(
    public fb: FormBuilder,
    private user: UserService
    
  ) { this.getAlUsers(); }

  ngOnInit() {
    this.productForm = new FormGroup({
      FirstName: new FormControl(),
      LastName: new FormControl(),
      City: new FormControl(),
      PhoneNumber: new FormControl()
    });
       
  }

  
  submitForm(obj:any) {

    this.user.SaveUser(obj).subscribe((data): any => {
      if (data) {
        alert("Save Successfully");
        this.getAlUsers();
      }
      this.productForm.reset();
    });

  }

  getAlUsers() {
    this.user.getAllUsers().subscribe((data): any => {
      if (data) {
        this.data = data;

      }
    });
  }

  settings = {
    actions: { add: false, edit: true, delete: true, postion: 'right' },
    mode: 'inline',
    hideSubHeader: true,   
    delete: {
      confirmDelete: true,
      deleteButtonContent: 'Delete',
      saveButtonContent: 'save',
      cancelButtonContent: 'cancel'
    },
    edit: {
      confirmSave: true,
    },
    columns: {
      firstName: {
        title: 'First Name'
      },
      lastName: {
        title: 'Last Name'
      },
      city: {
        title: 'City'
      },
      phoneNumber: {
        title: 'Phone Number'
      }
    }   
    
  };
  onUserDelete(event) {

    var that = this;
    console.log("Delete Event In Console")
    console.log(event);
    // if (window.confirm('Are you sure you want to delete?')) {
    this.user.DeleteUser(event.data.userId).subscribe((data): any => {
      if (data) {
        alert("Deleted Successfully");

      }
    });
      event.confirm.resolve();    
  }

  onUserEdit(event) {
    this.user.EditUser(event.newData).subscribe((data): any => {
      if (data) {
        alert("Updated Successfully");
        this.getAlUsers();
      }      
    });

  }
}
