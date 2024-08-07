﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Planner.Challenges.Infrastructure;

#nullable disable

namespace Planner.Challenges.Infrastructure.Migrations
{
    [DbContext(typeof(ChallengesDbContext))]
    [Migration("20240806200917_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("challenges")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Planner.Challenges.Domain.ChallengeMessages.Entities.ChallengeMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ChallengeId")
                        .HasColumnType("uuid")
                        .HasColumnName("challenge_id");

                    b.Property<int>("MessageId")
                        .HasColumnType("integer")
                        .HasColumnName("message_id");

                    b.Property<DateTimeOffset>("SentAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sent_at");

                    b.HasKey("Id")
                        .HasName("pk_challenge_messages");

                    b.HasIndex("ChallengeId")
                        .HasDatabaseName("ix_challenge_messages_challenge_id");

                    b.HasIndex("MessageId")
                        .IsUnique()
                        .HasDatabaseName("ix_challenge_messages_message_id");

                    b.ToTable("challenge_messages", "challenges");
                });

            modelBuilder.Entity("Planner.Challenges.Domain.Challenges.Entities.Challenge", b =>
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

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_challenges");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_challenges_user_id");

                    b.ToTable("challenges", "challenges");
                });

            modelBuilder.Entity("Planner.Challenges.Domain.ChallengeMessages.Entities.ChallengeMessage", b =>
                {
                    b.HasOne("Planner.Challenges.Domain.Challenges.Entities.Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_challenge_messages_challenges_challenge_id");

                    b.Navigation("Challenge");
                });
#pragma warning restore 612, 618
        }
    }
}
