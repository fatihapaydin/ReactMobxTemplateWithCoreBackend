﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VeriErisim.Context;

namespace VeriErisim.Migrations
{
    [DbContext(typeof(OkulContext))]
    [Migration("20180103052516_ilk")]
    partial class ilk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Varliklar.Bolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Butce")
                        .HasColumnType("money");

                    b.Property<bool>("IsAktif");

                    b.Property<bool>("IsSilinmis");

                    b.Property<string>("Kod")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Bolumler");
                });
#pragma warning restore 612, 618
        }
    }
}