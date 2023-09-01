﻿// <auto-generated />
using System;
using HaliaExamAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HaliaExamAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230830215301_CorrectFieldsNameUserCaseStatus")]
    partial class CorrectFieldsNameUserCaseStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HaliaExamAPI.Models.AssignedCase", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("caseid")
                        .HasColumnType("integer");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int>("userid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("caseid");

                    b.HasIndex("userid");

                    b.ToTable("assignedcases");
                });

            modelBuilder.Entity("HaliaExamAPI.Models.Case", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("finishDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("status")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("id");

                    b.ToTable("cases");
                });

            modelBuilder.Entity("HaliaExamAPI.Models.CaseStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("actioneduserid")
                        .HasColumnType("integer");

                    b.Property<int>("caseid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("statusdescription")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("actioneduserid");

                    b.HasIndex("caseid");

                    b.ToTable("casesstatus");
                });

            modelBuilder.Entity("HaliaExamAPI.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("phone")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("HaliaExamAPI.Models.AssignedCase", b =>
                {
                    b.HasOne("HaliaExamAPI.Models.Case", "Case")
                        .WithMany()
                        .HasForeignKey("caseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HaliaExamAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HaliaExamAPI.Models.CaseStatus", b =>
                {
                    b.HasOne("HaliaExamAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("actioneduserid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HaliaExamAPI.Models.Case", "Case")
                        .WithMany()
                        .HasForeignKey("caseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
