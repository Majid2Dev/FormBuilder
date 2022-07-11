﻿// <auto-generated />
using System;
using FormBuilder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormBuilder.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FormBuilder.Models.Field", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<long>("FormId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("VocabularieId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("VocabularieId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("FormBuilder.Models.Form", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("FormStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("FormBuilder.Models.Response", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("FieldId")
                        .HasColumnType("bigint");

                    b.Property<long>("FormId")
                        .HasColumnType("bigint");

                    b.Property<string>("Resonses")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("FormId");

                    b.ToTable("Response");
                });

            modelBuilder.Entity("FormBuilder.Models.Term", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("OrderBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VocabularieId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VocabularieId");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("FormBuilder.Models.Vocabularie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Vocabularies");
                });

            modelBuilder.Entity("FormBuilder.Models.Field", b =>
                {
                    b.HasOne("FormBuilder.Models.Form", "Form")
                        .WithMany("Fields")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormBuilder.Models.Vocabularie", "Vocabularie")
                        .WithMany()
                        .HasForeignKey("VocabularieId");

                    b.Navigation("Form");

                    b.Navigation("Vocabularie");
                });

            modelBuilder.Entity("FormBuilder.Models.Response", b =>
                {
                    b.HasOne("FormBuilder.Models.Field", "Field")
                        .WithMany("Responses")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormBuilder.Models.Form", "Form")
                        .WithMany("Responses")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("FormBuilder.Models.Term", b =>
                {
                    b.HasOne("FormBuilder.Models.Vocabularie", "Vocabularie")
                        .WithMany("Terms")
                        .HasForeignKey("VocabularieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vocabularie");
                });

            modelBuilder.Entity("FormBuilder.Models.Field", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("FormBuilder.Models.Form", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Responses");
                });

            modelBuilder.Entity("FormBuilder.Models.Vocabularie", b =>
                {
                    b.Navigation("Terms");
                });
#pragma warning restore 612, 618
        }
    }
}
