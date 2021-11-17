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

            modelBuilder.Entity("HansAfriqueApi.Entities.FileData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("MimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Partid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Partid");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.OrderAggregate.AddressEnt", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AddressEnt");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.OrderAggregate.DeliveryMethod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DeliveryMethods");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.OrderAggregate.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuyerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeliveryMethodid")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("ShipToAddressid")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("DeliveryMethodid");

                    b.HasIndex("ShipToAddressid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItemOrderedid")
                        .HasColumnType("int");

                    b.Property<int?>("Orderid")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ItemOrderedid");

                    b.HasIndex("Orderid");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.OrderAggregate.ProductItemOrdered", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductItemId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductItemOrdered");
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

            modelBuilder.Entity("HansAfriqueApi.Entities.Picture", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IsMain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Brandid")
                        .HasColumnType("int");

                    b.Property<int?>("Partid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Brandid");

                    b.HasIndex("Partid");

                    b.ToTable("Product");
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

            modelBuilder.Entity("HansAfriqueApi.Entities.FileData", b =>
                {
                    b.HasOne("HansAfriqueApi.Entities.Part", "Part")
                        .WithMany("Photo")
                        .HasForeignKey("Partid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.OrderAggregate.Order", b =>
                {
                    b.HasOne("HansAfriqueApi.Entities.OrderAggregate.DeliveryMethod", "DeliveryMethod")
                        .WithMany()
                        .HasForeignKey("DeliveryMethodid");

                    b.HasOne("HansAfriqueApi.Entities.OrderAggregate.AddressEnt", "ShipToAddress")
                        .WithMany()
                        .HasForeignKey("ShipToAddressid");

                    b.Navigation("DeliveryMethod");

                    b.Navigation("ShipToAddress");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("HansAfriqueApi.Entities.OrderAggregate.ProductItemOrdered", "ItemOrdered")
                        .WithMany()
                        .HasForeignKey("ItemOrderedid");

                    b.HasOne("HansAfriqueApi.Entities.OrderAggregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("Orderid");

                    b.Navigation("ItemOrdered");
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

            modelBuilder.Entity("HansAfriqueApi.Entities.Picture", b =>
                {
                    b.HasOne("HansAfriqueApi.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.Product", b =>
                {
                    b.HasOne("HansAfriqueApi.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("Brandid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HansAfriqueApi.Entities.Part", "Part")
                        .WithMany()
                        .HasForeignKey("Partid");

                    b.Navigation("Brand");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.OrderAggregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("HansAfriqueApi.Entities.Part", b =>
                {
                    b.Navigation("Photo");
                });
#pragma warning restore 612, 618
        }
    }
}
