﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiloradMarkovic_DeltaDrive_Delta.Infrastructure;

#nullable disable

namespace MiloradMarkovic_DeltaDrive_Delta.Migrations
{
    [DbContext(typeof(DriveDatabaseContext))]
    partial class DriveDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.HistoryPreviewItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsArrived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("History", (string)null);
                });

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Passengers", (string)null);
                });

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengersId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassengersId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rates", (string)null);
                });

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriversFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriversLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBooked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<double>("PricePerKM")
                        .HasColumnType("float");

                    b.Property<double>("StartPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.HistoryPreviewItem", b =>
                {
                    b.HasOne("MiloradMarkovic_DeltaDrive_Delta.Models.Passenger", "Passenger")
                        .WithMany("HistoryPreviews")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiloradMarkovic_DeltaDrive_Delta.Models.Vehicle", "Vehicle")
                        .WithMany("HistoryPreviews")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MiloradMarkovic_DeltaDrive_Delta.Models.HistoryPreviewItem.EndingLocation#MiloradMarkovic_DeltaDrive_Delta.Models.Location", "EndingLocation", b1 =>
                        {
                            b1.Property<int>("HistoryPreviewItemId")
                                .HasColumnType("int");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("EndLatitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("EndLongitude");

                            b1.HasKey("HistoryPreviewItemId");

                            b1.ToTable("History", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HistoryPreviewItemId");
                        });

                    b.OwnsOne("MiloradMarkovic_DeltaDrive_Delta.Models.HistoryPreviewItem.StartingLocation#MiloradMarkovic_DeltaDrive_Delta.Models.Location", "StartingLocation", b1 =>
                        {
                            b1.Property<int>("HistoryPreviewItemId")
                                .HasColumnType("int");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("StartLatitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("StartLongitude");

                            b1.HasKey("HistoryPreviewItemId");

                            b1.ToTable("History", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HistoryPreviewItemId");
                        });

                    b.Navigation("EndingLocation")
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("StartingLocation")
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.Rate", b =>
                {
                    b.HasOne("MiloradMarkovic_DeltaDrive_Delta.Models.Passenger", "Passenger")
                        .WithMany("Rates")
                        .HasForeignKey("PassengersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiloradMarkovic_DeltaDrive_Delta.Models.Vehicle", "Vehicle")
                        .WithMany("Rates")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.Vehicle", b =>
                {
                    b.OwnsOne("MiloradMarkovic_DeltaDrive_Delta.Models.Vehicle.Location#MiloradMarkovic_DeltaDrive_Delta.Models.Location", "Location", b1 =>
                        {
                            b1.Property<int>("VehicleId")
                                .HasColumnType("int");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.HasKey("VehicleId");

                            b1.ToTable("Vehicles", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("VehicleId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.Passenger", b =>
                {
                    b.Navigation("HistoryPreviews");

                    b.Navigation("Rates");
                });

            modelBuilder.Entity("MiloradMarkovic_DeltaDrive_Delta.Models.Vehicle", b =>
                {
                    b.Navigation("HistoryPreviews");

                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
