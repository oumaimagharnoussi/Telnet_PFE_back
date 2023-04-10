﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ticketback.Context;

#nullable disable

namespace Ticketback.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230314103612_pass1")]
    partial class pass1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ticketback.Models.Activities", b =>
                {
                    b.Property<int>("activityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("activityId"));

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("activityId");

                    b.ToTable("Activites");
                });

            modelBuilder.Entity("Ticketback.Models.Etat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Etats");
                });

            modelBuilder.Entity("Ticketback.Models.Groups", b =>
                {
                    b.Property<int>("groupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("groupId"));

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("groupId");

                    b.ToTable("Groupss");
                });

            modelBuilder.Entity("Ticketback.Models.Site", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Ticketback.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<int?>("ActivitiesactivityId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupsgroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ResetPasswordExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qualification")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.HasIndex("ActivitiesactivityId");

                    b.HasIndex("GroupsgroupId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Ticketback.Models.User", b =>
                {
                    b.HasOne("Ticketback.Models.Activities", "Activities")
                        .WithMany("Users")
                        .HasForeignKey("ActivitiesactivityId");

                    b.HasOne("Ticketback.Models.Groups", "Groups")
                        .WithMany("Users")
                        .HasForeignKey("GroupsgroupId");

                    b.Navigation("Activities");

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Ticketback.Models.Activities", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Ticketback.Models.Groups", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}