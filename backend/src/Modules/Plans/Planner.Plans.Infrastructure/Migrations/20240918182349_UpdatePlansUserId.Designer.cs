﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Planner.Plans.Infrastructure;

#nullable disable

namespace Planner.Plans.Infrastructure.Migrations
{
    [DbContext(typeof(PlansDbContext))]
    [Migration("20240918182349_UpdatePlansUserId")]
    partial class UpdatePlansUserId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("plans")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Planner.Plans.Domain.Plans.Entities.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_plans");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_plans_user_id");

                    b.ToTable("plans", "plans");
                });

            modelBuilder.Entity("Planner.Plans.Domain.Plans.Entities.PlanReminder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid")
                        .HasColumnName("plan_id");

                    b.Property<DateTimeOffset>("RemindAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("remind_at");

                    b.HasKey("Id")
                        .HasName("pk_plan_reminders");

                    b.HasIndex("PlanId")
                        .HasDatabaseName("ix_plan_reminders_plan_id");

                    b.ToTable("plan_reminders", "plans");
                });

            modelBuilder.Entity("Planner.Plans.Domain.Plans.Entities.PlanReminder", b =>
                {
                    b.HasOne("Planner.Plans.Domain.Plans.Entities.Plan", null)
                        .WithMany("Reminders")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_plan_reminders_plans_plan_id");
                });

            modelBuilder.Entity("Planner.Plans.Domain.Plans.Entities.Plan", b =>
                {
                    b.Navigation("Reminders");
                });
#pragma warning restore 612, 618
        }
    }
}