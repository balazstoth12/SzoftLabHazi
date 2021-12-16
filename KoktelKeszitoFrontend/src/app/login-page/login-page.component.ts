import { Component, OnInit } from '@angular/core';
import { User } from '../shared/cocktailapp.model';
import { CocktailappService } from 'src/app/shared/cocktailapp.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-page',
  templateUrl: 'login-page.component.html',
  styles: [
  ]
})
export class LoginPageComponent implements OnInit {

  constructor(public service: User) { }

    ngOnInit(): void {

    }

}