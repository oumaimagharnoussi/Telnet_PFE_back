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
    [Migration("20230504101749_relation_site_ticket")]
    partial class relation_site_ticket
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ticketback.Models.Activitie", b =>
                {
                    b.Property<int>("activityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("activityId"));

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("activityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Ticketback.Models.Commentaire", b =>
                {
                    b.Property<int>("commentaireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentaireId"));

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticketId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("commentaireId");

                    b.HasIndex("ticketId");

                    b.HasIndex("userId");

                    b.ToTable("Commentaires", (string)null);
                });

            modelBuilder.Entity("Ticketback.Models.Etat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Etats");
                });

            modelBuilder.Entity("Ticketback.Models.Groupe", b =>
                {
                    b.Property<int>("groupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("groupId"));

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("groupId");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("Ticketback.Models.Telnet", b =>
                {
                    b.Property<int>("telnetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("telnetId"));

                    b.Property<string>("libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("telnetId");

                    b.ToTable("Telnet");
                });

            modelBuilder.Entity("Ticketback.Models.Ticket", b =>
                {
                    b.Property<int>("ticketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ticketId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("File")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Priorite")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<float>("dayNumber")
                        .HasColumnType("real");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("etatId")
                        .HasColumnType("int");

                    b.Property<int>("halfDay")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("telnetId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("ticketId");

                    b.HasIndex("etatId");

                    b.HasIndex("id");

                    b.HasIndex("telnetId");

                    b.HasIndex("userId");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Ticketback.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<DateTime>("ResetPasswordExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("activityId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qualification")
                        .HasColumnType("int");

                    b.Property<int>("telnetId")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.HasIndex("activityId");

                    b.HasIndex("groupId");

                    b.HasIndex("telnetId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Ticketback.Models.WorkFromHomeRequest", b =>
                {
                    b.Property<int>("workHomeRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("workHomeRequestId"));

                    b.Property<int>("dayNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("halfDay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("motive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("state")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("userFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("userNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("workHomeRequestId");

                    b.HasIndex("userId", "startDate", "endDate")
                        .IsUnique();

                    b.ToTable("WorkFromHomeRequests");
                });

            modelBuilder.Entity("Ticketback.Models.Commentaire", b =>
                {
                    b.HasOne("Ticketback.Models.Ticket", "Ticket")
                        .WithMany("Commentaire")
                        .HasForeignKey("ticketId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ticketback.Models.User", "User")
                        .WithMany("Commentaire")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ticketback.Models.Ticket", b =>
                {
                    b.HasOne("Ticketback.Models.Etat", null)
                        .WithMany("Ticket")
                        .HasForeignKey("etatId");

                    b.HasOne("Ticketback.Models.Etat", "Etat")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ticketback.Models.Telnet", "Telnet")
                        .WithMany("Ticket")
                        .HasForeignKey("telnetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ticketback.Models.User", "User")
                        .WithMany("Ticket")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Etat");

                    b.Navigation("Telnet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ticketback.Models.User", b =>
                {
                    b.HasOne("Ticketback.Models.Activitie", "Activitie")
                        .WithMany("Users")
                        .HasForeignKey("activityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ticketback.Models.Groupe", "Groupe")
                        .WithMany("Users")
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ticketback.Models.Telnet", "Telnet")
                        .WithMany("Users")
                        .HasForeignKey("telnetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activitie");

                    b.Navigation("Groupe");

                    b.Navigation("Telnet");
                });

            modelBuilder.Entity("Ticketback.Models.WorkFromHomeRequest", b =>
                {
                    b.HasOne("Ticketback.Models.User", "User")
                        .WithMany("WorkFromHomeRequests")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_WorkFromHomeRequests_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ticketback.Models.Activitie", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Ticketback.Models.Etat", b =>
                {
                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Ticketback.Models.Groupe", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Ticketback.Models.Telnet", b =>
                {
                    b.Navigation("Ticket");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Ticketback.Models.Ticket", b =>
                {
                    b.Navigation("Commentaire");
                });

            modelBuilder.Entity("Ticketback.Models.User", b =>
                {
                    b.Navigation("Commentaire");

                    b.Navigation("Ticket");

                    b.Navigation("WorkFromHomeRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
