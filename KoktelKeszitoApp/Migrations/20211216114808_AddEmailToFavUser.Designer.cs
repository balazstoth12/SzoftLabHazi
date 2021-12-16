﻿// <auto-generated />
using System;
using KoktelKeszitoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KoktelKeszitoApp.Migrations
{
    [DbContext(typeof(CocktailContextDb))]
    [Migration("20211216114808_AddEmailToFavUser")]
    partial class AddEmailToFavUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KoktelKeszitoApp.Models.Cocktail", b =>
                {
                    b.Property<int>("CocktailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CocktailName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("MadeByUserId")
                        .HasColumnType("int");

                    b.Property<string>("MadeDate")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CocktailId");

                    b.HasIndex("MadeByUserId");

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.CocktailIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CocktailId")
                        .HasColumnType("int");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CocktailIngredients");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.FavouriteUser", b =>
                {
                    b.Property<int>("FavouriteUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FavouriteUserId");

                    b.ToTable("FavouriteUser");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.UserCocktail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CocktailId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCocktails");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.UserFavouriteUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FavouriteUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FavouriteUserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFavouriteUsers");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.Cocktail", b =>
                {
                    b.HasOne("KoktelKeszitoApp.Models.User", "MadeBy")
                        .WithMany()
                        .HasForeignKey("MadeByUserId");

                    b.Navigation("MadeBy");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.CocktailIngredient", b =>
                {
                    b.HasOne("KoktelKeszitoApp.Models.Cocktail", "Cocktail")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KoktelKeszitoApp.Models.Ingredient", "Ingredient")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("IngredientId");

                    b.Navigation("Cocktail");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.UserCocktail", b =>
                {
                    b.HasOne("KoktelKeszitoApp.Models.Cocktail", "Cocktail")
                        .WithMany("UserCocktails")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KoktelKeszitoApp.Models.User", "User")
                        .WithMany("UserCocktails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cocktail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.UserFavouriteUser", b =>
                {
                    b.HasOne("KoktelKeszitoApp.Models.FavouriteUser", "FavouriteUser")
                        .WithMany("UserFavouriteUsers")
                        .HasForeignKey("FavouriteUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KoktelKeszitoApp.Models.User", "User")
                        .WithMany("UserFavouriteUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FavouriteUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.Cocktail", b =>
                {
                    b.Navigation("CocktailIngredients");

                    b.Navigation("UserCocktails");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.FavouriteUser", b =>
                {
                    b.Navigation("UserFavouriteUsers");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.Ingredient", b =>
                {
                    b.Navigation("CocktailIngredients");
                });

            modelBuilder.Entity("KoktelKeszitoApp.Models.User", b =>
                {
                    b.Navigation("UserCocktails");

                    b.Navigation("UserFavouriteUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
