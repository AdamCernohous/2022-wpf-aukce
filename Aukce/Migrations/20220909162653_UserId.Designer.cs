﻿// <auto-generated />
using System;
using Aukce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aukce.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220909162653_UserId")]
    partial class UserId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("Aukce.Model.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LastBuyerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LastBuyerId");

                    b.HasIndex("UserId");

                    b.ToTable("Auctions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "Drahý obraz!",
                            LastBuyerId = 1,
                            Price = 69,
                            Title = "Mona Lisa"
                        });
                });

            modelBuilder.Entity("Aukce.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "adacern019@pslib.cz",
                            Password = "1234",
                            Username = "adamcernohous"
                        });
                });

            modelBuilder.Entity("Aukce.Model.Auction", b =>
                {
                    b.HasOne("Aukce.Model.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aukce.Model.User", "LastBuyer")
                        .WithMany()
                        .HasForeignKey("LastBuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aukce.Model.User", null)
                        .WithMany("Auctions")
                        .HasForeignKey("UserId");

                    b.Navigation("Author");

                    b.Navigation("LastBuyer");
                });

            modelBuilder.Entity("Aukce.Model.User", b =>
                {
                    b.Navigation("Auctions");
                });
#pragma warning restore 612, 618
        }
    }
}
