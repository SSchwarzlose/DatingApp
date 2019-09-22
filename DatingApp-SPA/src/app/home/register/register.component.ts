import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {AuthService} from '../../_services/auth.service';
import {AlertifyService} from '../../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() model: any = {};
  @Output() registerMode = new EventEmitter<boolean>();
  constructor(public authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('registration successfull');
      this.registerMode.emit(false);
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.registerMode.emit(false);
  }

}