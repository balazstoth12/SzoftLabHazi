import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { Cocktail, FavouriteUser, Ingredient, User } from './cocktailapp.model';
@Injectable({
    providedIn: 'root'
  })
  export class CocktailappService {
    constructor(private http: HttpClient) { }
    Cocktail: Cocktail=new Cocktail();
    User: User=new User();
    Ingredient: Ingredient=new Ingredient();
    FavouriteUser: FavouriteUser=new FavouriteUser();
  }