﻿// <auto-generated />
using System;
using HansAfriqueApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HansAfriqueApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HansAfriqueApi.Entities.Brand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.Part", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Brandid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartCategoryid")
                        .HasColumnType("int");

                    b.Property<string>("PartCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartNumberid")
                        .HasColumnType("int");

                    b.Property<string>("PictureULR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Supplierid")
                        .HasColumnType("int");

                    b.Property<string>("VehicleModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vehicleid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Brandid");

                    b.HasIndex("PartCategoryid");

                    b.HasIndex("PartNumberid");

                    b.HasIndex("Supplierid");

                    b.HasIndex("Vehicleid");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.PartCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PartCategories");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.PartNumber", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PartNumbers");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.Supplier", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.Vehicle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Vehicle_Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.Part", b =>
                {
                    b.HasOne("HansAfriqueApi.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("Brandid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HansAfriqueApi.Entities.PartCategory", "PartCategory")
                        .WithMany()
                        .HasForeignKey("PartCategoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HansAfriqueApi.Entities.PartNumber", "PartNumber")
                        .WithMany()
                        .HasForeignKey("PartNumberid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HansAfriqueApi.Entities.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("Supplierid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HansAfriqueApi.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("Vehicleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("PartCategory");

                    b.Navigation("PartNumber");

                    b.Navigation("Supplier");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
