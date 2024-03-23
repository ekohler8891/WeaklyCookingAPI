﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeaklyCookingAPI.Data;

#nullable disable

namespace WeaklyCookingAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeaklyCookingAPI.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<string>("Catagory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("recipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("recipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("WeaklyCookingAPI.Models.Instruction", b =>
                {
                    b.Property<int?>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("InstructionId"));

                    b.Property<string>("InstructionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("InstructionId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Instruction");
                });

            modelBuilder.Entity("WeaklyCookingAPI.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CookTime")
                        .HasColumnType("int");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrepTime")
                        .HasColumnType("int");

                    b.Property<double>("Servings")
                        .HasColumnType("float");

                    b.Property<int>("TotalCalories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("WeaklyCookingAPI.Models.Ingredient", b =>
                {
                    b.HasOne("WeaklyCookingAPI.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("recipeId");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("WeaklyCookingAPI.Models.Instruction", b =>
                {
                    b.HasOne("WeaklyCookingAPI.Models.Recipe", null)
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("WeaklyCookingAPI.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}
