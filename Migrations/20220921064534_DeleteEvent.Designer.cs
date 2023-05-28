﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Model;

namespace WebApplication4.Migrations
{
    [DbContext(typeof(BookStoreDB))]
    [Migration("20220921064534_DeleteEvent")]
    partial class DeleteEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication4.Model.Author", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("WebApplication4.Model.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("authorId")
                        .HasColumnType("int");

                    b.Property<string>("bookImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("publisher_packageId")
                        .HasColumnType("int");

                    b.Property<int>("qty")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("authorId");

                    b.HasIndex("categoryId");

                    b.HasIndex("publisher_packageId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("WebApplication4.Model.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("WebApplication4.Model.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ShoppingBasketid")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ShoppingBasketid");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("WebApplication4.Model.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Basketid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_ShoppingBasketId")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<int>("totalPrice")
                        .HasColumnType("int");

                    b.Property<string>("visa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Basketid");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("WebApplication4.Model.Publisher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("publishers");
                });

            modelBuilder.Entity("WebApplication4.Model.Publisher_Package", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("publisherId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("publisherId");

                    b.ToTable("Publisher_Package");
                });

            modelBuilder.Entity("WebApplication4.Model.ShoppingBasket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("clientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("qty")
                        .HasColumnType("int");

                    b.Property<int>("totalPrice")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clientId");

                    b.ToTable("shoppingBaskets");
                });

            modelBuilder.Entity("WebApplication4.Model.ShoppingBasket_Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Iqty")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingBasketID")
                        .HasColumnType("int");

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ShoppingBasketID");

                    b.HasIndex("bookId");

                    b.ToTable("shoppingBasket_Books");
                });

            modelBuilder.Entity("WebApplication4.Model.Book", b =>
                {
                    b.HasOne("WebApplication4.Model.Author", "author")
                        .WithMany("books")
                        .HasForeignKey("authorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Model.Category", "category")
                        .WithMany("Books")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Model.Publisher_Package", "Publisher_")
                        .WithMany("Books")
                        .HasForeignKey("publisher_packageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("category");

                    b.Navigation("Publisher_");
                });

            modelBuilder.Entity("WebApplication4.Model.Client", b =>
                {
                    b.HasOne("WebApplication4.Model.ShoppingBasket", "shopping")
                        .WithMany()
                        .HasForeignKey("ShoppingBasketid");

                    b.Navigation("shopping");
                });

            modelBuilder.Entity("WebApplication4.Model.Order", b =>
                {
                    b.HasOne("WebApplication4.Model.ShoppingBasket", "Basket")
                        .WithMany()
                        .HasForeignKey("Basketid");

                    b.Navigation("Basket");
                });

            modelBuilder.Entity("WebApplication4.Model.Publisher_Package", b =>
                {
                    b.HasOne("WebApplication4.Model.Publisher", "publisher")
                        .WithMany("publisher_Packages")
                        .HasForeignKey("publisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("publisher");
                });

            modelBuilder.Entity("WebApplication4.Model.ShoppingBasket", b =>
                {
                    b.HasOne("WebApplication4.Model.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientId");

                    b.Navigation("client");
                });

            modelBuilder.Entity("WebApplication4.Model.ShoppingBasket_Book", b =>
                {
                    b.HasOne("WebApplication4.Model.ShoppingBasket", null)
                        .WithMany("BookList")
                        .HasForeignKey("ShoppingBasketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Model.Book", null)
                        .WithMany("soppingBasket_Books")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication4.Model.Author", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("WebApplication4.Model.Book", b =>
                {
                    b.Navigation("soppingBasket_Books");
                });

            modelBuilder.Entity("WebApplication4.Model.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("WebApplication4.Model.Publisher", b =>
                {
                    b.Navigation("publisher_Packages");
                });

            modelBuilder.Entity("WebApplication4.Model.Publisher_Package", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("WebApplication4.Model.ShoppingBasket", b =>
                {
                    b.Navigation("BookList");
                });
#pragma warning restore 612, 618
        }
    }
}
