﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovTicket.Data;

#nullable disable

namespace MovTicket.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovTicket.Models.Entities.Customer", b =>
                {
                    b.Property<int>("c_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("c_id"));

                    b.Property<string>("c_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("c_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("c_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("c_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("c_subscription")
                        .HasColumnType("bit");

                    b.HasKey("c_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MovTicket.Models.Entities.Movie", b =>
                {
                    b.Property<int>("m_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("m_id"));

                    b.Property<string>("m_genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("m_releaseDate")
                        .HasColumnType("date");

                    b.Property<string>("m_room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("m_showTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("m_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("m_id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovTicket.Models.Entities.Ticket", b =>
                {
                    b.Property<int>("t_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("t_id"));

                    b.Property<int>("Customerc_id")
                        .HasColumnType("int");

                    b.Property<int>("Moviem_id")
                        .HasColumnType("int");

                    b.Property<int>("c_id")
                        .HasColumnType("int");

                    b.Property<int>("m_id")
                        .HasColumnType("int");

                    b.Property<string>("t_seat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("t_id");

                    b.HasIndex("Customerc_id");

                    b.HasIndex("Moviem_id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MovTicket.Models.Entities.Ticket", b =>
                {
                    b.HasOne("MovTicket.Models.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customerc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovTicket.Models.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("Moviem_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
