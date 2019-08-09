﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tesisCdagAsobiguaApi.Persistence.Contexts;

namespace tesisCdagAsobiguaApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190723161132_AddXyzShotPositionColumn")]
    partial class AddXyzShotPositionColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("tesisCdagAsobiguaApi.Domain.Models.Login", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("PlayerId");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<long>("TrainerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("tesisCdagAsobiguaApi.Domain.Models.Shot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BackstrokePause");

                    b.Property<double>("Finesse");

                    b.Property<double>("Finish");

                    b.Property<double>("FollowThrough");

                    b.Property<double>("Jab");

                    b.Property<long>("PlayerId");

                    b.Property<double>("ShotInterval");

                    b.Property<double>("Straightness");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<double>("TipSteer");

                    b.Property<long>("TrainerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Shots");
                });

            modelBuilder.Entity("tesisCdagAsobiguaApi.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("binary(64)");

                    b.Property<byte>("UserType");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("tesisCdagAsobiguaApi.Domain.Models.XyzShot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ShotId");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<double>("X");

                    b.Property<byte>("XyzShotPosition");

                    b.Property<double>("Y");

                    b.Property<double>("Z");

                    b.HasKey("Id");

                    b.HasIndex("ShotId");

                    b.ToTable("XyzShots");
                });

            modelBuilder.Entity("tesisCdagAsobiguaApi.Domain.Models.Login", b =>
                {
                    b.HasOne("tesisCdagAsobiguaApi.Domain.Models.User", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tesisCdagAsobiguaApi.Domain.Models.User", "Trainer")
                        .WithMany("Logins")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tesisCdagAsobiguaApi.Domain.Models.Shot", b =>
                {
                    b.HasOne("tesisCdagAsobiguaApi.Domain.Models.User", "Player")
                        .WithMany("Shots")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("tesisCdagAsobiguaApi.Domain.Models.User", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("tesisCdagAsobiguaApi.Domain.Models.XyzShot", b =>
                {
                    b.HasOne("tesisCdagAsobiguaApi.Domain.Models.Shot", "Shot")
                        .WithMany("XyzShots")
                        .HasForeignKey("ShotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
