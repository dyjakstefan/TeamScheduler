﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamScheduler.Infrastructure.EfContext;

namespace TeamScheduler.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20181126100657_UpdateForeignKeys")]
    partial class UpdateForeignKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeamScheduler.Core.Entities.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayOfWeek");

                    b.Property<bool>("IsAccepted");

                    b.Property<int?>("ScheduleId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hours");

                    b.Property<bool>("IsPartTime");

                    b.Property<int?>("TeamId");

                    b.Property<int>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EndAt");

                    b.Property<bool>("IsAccepted");

                    b.Property<DateTime>("StartAt");

                    b.Property<int?>("TeamId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DayId");

                    b.Property<DateTime>("End");

                    b.Property<bool>("IsAccepted");

                    b.Property<int?>("MemberId");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("MemberId");

                    b.ToTable("UnitsOfWork");
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Role");

                    b.Property<string>("Salt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.Day", b =>
                {
                    b.HasOne("TeamScheduler.Core.Entities.Schedule", "Schedule")
                        .WithMany("Days")
                        .HasForeignKey("ScheduleId");
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.Member", b =>
                {
                    b.HasOne("TeamScheduler.Core.Entities.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId");

                    b.HasOne("TeamScheduler.Core.Entities.User", "User")
                        .WithMany("Members")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.Schedule", b =>
                {
                    b.HasOne("TeamScheduler.Core.Entities.Team", "Team")
                        .WithMany("Schedules")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("TeamScheduler.Core.Entities.Task", b =>
                {
                    b.HasOne("TeamScheduler.Core.Entities.Day", "Day")
                        .WithMany("UnitsOfWorks")
                        .HasForeignKey("DayId");

                    b.HasOne("TeamScheduler.Core.Entities.Member", "Member")
                        .WithMany("UnitsOfWork")
                        .HasForeignKey("MemberId");
                });
#pragma warning restore 612, 618
        }
    }
}
