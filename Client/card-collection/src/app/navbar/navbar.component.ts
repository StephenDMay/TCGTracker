import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/services/account-service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLoggedIn: boolean;

  constructor(private service : AccountService) {
    this.isLoggedIn = service.isLoggedIn();
   }

  ngOnInit(): void {
  }


  reload() {
    this.ngOnInit();
  }
}
