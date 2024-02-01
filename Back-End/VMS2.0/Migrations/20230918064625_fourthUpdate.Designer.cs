﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VMS2._0.Data;

#nullable disable

namespace VMS2._0.Migrations
{
    [DbContext(typeof(VMSDbContext))]
    [Migration("20230918064625_fourthUpdate")]
    partial class fourthUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VMS2._0.Models.Notification", b =>
                {
                    b.Property<string>("NotificationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NotificationGenerated")
                        .HasColumnType("datetime2");

                    b.Property<string>("NotificationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NotificationID");

                    b.HasIndex("VisitID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("VMS2._0.Models.SecondaryInfo", b =>
                {
                    b.Property<string>("SecondaryInfoID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AlternateContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlternateEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlternateEmergencyContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SecondaryInfoID");

                    b.HasIndex("VisitorID");

                    b.ToTable("SecondaryInfos");
                });

            modelBuilder.Entity("VMS2._0.Models.URLManagement", b =>
                {
                    b.Property<string>("URLID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GenerateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("URLStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("URLID");

                    b.HasIndex("VisitID");

                    b.ToTable("URLManagements");
                });

            modelBuilder.Entity("VMS2._0.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VMS2._0.Models.Visit", b =>
                {
                    b.Property<string>("VisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedArrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedDepart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentVisitID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("VisitID");

                    b.HasIndex("VisitorID");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("VMS2._0.Models.Visitor", b =>
                {
                    b.Property<string>("VisitorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("VisitorAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitorNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitorID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("VMS2._0.Models.Notification", b =>
                {
                    b.HasOne("VMS2._0.Models.Visit", "Visit")
                        .WithMany()
                        .HasForeignKey("VisitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("VMS2._0.Models.SecondaryInfo", b =>
                {
                    b.HasOne("VMS2._0.Models.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("VMS2._0.Models.URLManagement", b =>
                {
                    b.HasOne("VMS2._0.Models.Visit", "Visit")
                        .WithMany()
                        .HasForeignKey("VisitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("VMS2._0.Models.Visit", b =>
                {
                    b.HasOne("VMS2._0.Models.Visitor", "Visitor")
                        .WithMany("Visits")
                        .HasForeignKey("VisitorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("VMS2._0.Models.Visitor", b =>
                {
                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
