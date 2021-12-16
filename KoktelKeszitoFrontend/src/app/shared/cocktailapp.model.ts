import { type } from "os"

export class Cocktail {
    CocktailId : number=0;
    CocktailName: string='';
    MadeBy: string='';
    MadeDate: string='';
    Description:string='';
    CocktailUser!: Array<User>;
    CocktailIngredients!:Array<Ingredient>;
}

export class Ingredient  {
    Id: number=0;
    Name: string='';
    Quantity:string='';
    IngredientCocktail!:Array<Cocktail>;
}

export class User  {
    UserId:number=0;
    Username: string='';
    Password:string='';
    Email:string='';
    UserCcoktail!:Array<Cocktail>;
    UserFavouriteUser!:Array<FavouriteUser>;
}

export class FavouriteUser  {
    FavouriteUserId: number=0;
    Username: string='';
    Password:string='';
    Email:string='';
    FavouriteUserUser!:Array<User>;
}
