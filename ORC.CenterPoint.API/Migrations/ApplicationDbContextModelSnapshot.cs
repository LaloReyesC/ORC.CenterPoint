﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORC.CenterPoint.API.Application;

#nullable disable

namespace ORC.CenterPoint.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ORC.CenterPoint.API.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComputedColumnSql("[Name] + ' ' + [LastName] + ' ' + [MaternalSurname]");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaternalSurname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<short>("PositionId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<short>("StatusId")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("PK_Employee_Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("StatusId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("ORC.CenterPoint.API.Models.Entities.EmployeePosition", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id")
                        .HasName("PK_EmployeePosition_Id");

                    b.ToTable("EmployeePosition", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Name = "Empleado general",
                            RegistrationDate = new DateTime(2024, 10, 30, 22, 43, 52, 152, DateTimeKind.Local).AddTicks(7041)
                        });
                });

            modelBuilder.Entity("ORC.CenterPoint.API.Models.Entities.RestaurantTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AllowedDinersNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "IX_RestaurantTable_Name");

                    b.HasIndex(new[] { "RoomName" }, "IX_RestaurantTable_RoomName");

                    b.ToTable("RestaurantTable", (string)null);
                });

            modelBuilder.Entity("ORC.CenterPoint.API.Models.Entities.Status", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id")
                        .HasName("PK_Status_Id");

                    b.ToTable("Status", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Name = "Activo",
                            RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7041)
                        },
                        new
                        {
                            Id = (short)2,
                            Name = "Deshabilitado",
                            RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7053)
                        },
                        new
                        {
                            Id = (short)3,
                            Name = "Baja",
                            RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7055)
                        },
                        new
                        {
                            Id = (short)4,
                            Name = "Reincorporado",
                            RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7056)
                        },
                        new
                        {
                            Id = (short)5,
                            Name = "De vacaciones",
                            RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7057)
                        },
                        new
                        {
                            Id = (short)9999,
                            Name = "Eliminado",
                            RegistrationDate = new DateTime(2024, 10, 27, 1, 35, 32, 953, DateTimeKind.Local).AddTicks(7058)
                        });
                });

            modelBuilder.Entity("ORC.CenterPoint.API.Models.Entities.Employee", b =>
                {
                    b.HasOne("ORC.CenterPoint.API.Models.Entities.EmployeePosition", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Employee_PositionId");

                    b.HasOne("ORC.CenterPoint.API.Models.Entities.Status", "Status")
                        .WithMany("Employees")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Employee_StatusId");

                    b.Navigation("Position");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ORC.CenterPoint.API.Models.Entities.EmployeePosition", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ORC.CenterPoint.API.Models.Entities.Status", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
