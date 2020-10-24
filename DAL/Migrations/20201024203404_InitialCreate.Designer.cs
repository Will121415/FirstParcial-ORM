﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(FirstParcialContext))]
    [Migration("20201024203404_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Person", b =>
                {
                    b.Property<string>("Identification")
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("IdSupport")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Surnames")
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Identification");

                    b.HasIndex("IdSupport");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Entity.Support", b =>
                {
                    b.Property<string>("IdSupport")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Modality")
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("IdSupport");

                    b.ToTable("Support");
                });

            modelBuilder.Entity("Entity.Person", b =>
                {
                    b.HasOne("Entity.Support", "Support")
                        .WithMany()
                        .HasForeignKey("IdSupport");
                });
#pragma warning restore 612, 618
        }
    }
}
