﻿// <auto-generated />
using System;
using LembreMeServer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LembreMeServer.Infra.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20200922183824_VarcharSize")]
    partial class VarcharSize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LembreMeServer.Domain.Entities.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("LembreMeServer.Domain.Entities.Task", b =>
                {
                    b.OwnsOne("LembreMeServer.Domain.Entities.Location", "Location", b1 =>
                        {
                            b1.Property<long>("TaskId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("FederativeUnit")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("Neighborhood")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.Property<int?>("Number")
                                .HasColumnType("int");

                            b1.Property<string>("Street")
                                .HasColumnType("varchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("TaskId");

                            b1.ToTable("Locations");

                            b1.WithOwner()
                                .HasForeignKey("TaskId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
