import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validator, Validators } from '@angular/forms';
import { UserService } from '../userService/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './user.component.html',
})
export class UserComponent {

  userForm: FormGroup;
  FirstName: FormControl;
  LastName: FormControl;
  City: FormControl;
  PhoneNumber: FormControl;
  userData: any;

  constructor(
    public fb: FormBuilder, private user: UserService, private toastr: ToastrService

  ) { this.getAllUsers(); }

  ngOnInit() {
    this.userForm = new FormGroup({
      FirstName: new FormControl('', Validators.required),
      LastName: new FormControl('', Validators.required),
      City: new FormControl('', Validators.required),
      PhoneNumber: new FormControl('', [Validators.pattern("^[0-9]*$"),
      Validators.minLength(10)])
    });

  }


  submitForm(obj: any) {

    this.user.SaveUser(obj).subscribe((res): any => {
      if (res) {
        this.toastr.success("User Saved Successfully.")

        this.getAllUsers();
      }
      this.userForm.reset();
    });

  }

  getAllUsers() {
    this.user.getAllUsers().subscribe((res): any => {
      if (res) {
        this.userData = res;

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

    this.user.DeleteUser(event.data.userId).subscribe((data): any => {

      this.toastr.success("User Deleted Successfully.")

    });
    event.confirm.resolve();
  }

  onUserUpdate(event) {
    this.user.EditUser(event.newData).subscribe((data): any => {

      this.toastr.success("User Updated Successfully.")
      this.getAllUsers();

    });

  }
}
