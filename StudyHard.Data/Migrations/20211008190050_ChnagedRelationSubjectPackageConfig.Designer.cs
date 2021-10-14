﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyHard.Data;

namespace StudyHard.Data.Migrations
{
    [DbContext(typeof(StudyHardApplicationContext))]
    [Migration("20211008190050_ChnagedRelationSubjectPackageConfig")]
    partial class ChnagedRelationSubjectPackageConfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudyHard.Data.Entity.Blog.BlogSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePublicationUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PreviewText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SEODescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SEOKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("BlogSections");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Category.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Exam.ExamResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Result")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ExamResults");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Package.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Package.PackageConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TasksAvaliable")
                        .HasColumnType("bit");

                    b.Property<bool>("TheoryAvaliable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("SubjectId")
                        .IsUnique();

                    b.ToTable("PackageConfigurations");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Package.UserPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("TransactionId")
                        .IsUnique()
                        .HasFilter("[TransactionId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("UserPackages");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Payment.LiqpayTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("LiqpayTransactions");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Subject.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Task.QuestionWithVariants.Answers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Task.QuestionWithVariants.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Task.TaskList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TaskType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TaskLists");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Theory.Theory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Theories");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Theory.TheoryNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TheoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TheoryId");

                    b.HasIndex("UserId");

                    b.ToTable("TheoryNotes");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelegramUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.Property<Guid?>("UniversityId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.UserSession", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastLoginDateUTC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Blog.BlogSection", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.File", "File")
                        .WithMany("BlogSections")
                        .HasForeignKey("ImageId");

                    b.Navigation("File");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Category.Category", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.Subject.Subject", "Subject")
                        .WithMany("Categories")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Exam.ExamResult", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.Subject.Subject", "Subject")
                        .WithMany("ExamResults")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyHard.Data.Entity.User", "User")
                        .WithMany("ExamResults")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Package.PackageConfiguration", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.Package.Package", "Package")
                        .WithMany("PackageConfigurations")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyHard.Data.Entity.Subject.Subject", "Subject")
                        .WithOne("PackageConfiguration")
                        .HasForeignKey("StudyHard.Data.Entity.Package.PackageConfiguration", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Package.UserPackage", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.Package.Package", "Package")
                        .WithMany("UserPackages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyHard.Data.Entity.Payment.LiqpayTransaction", "LiqpayTransaction")
                        .WithOne("UserPackage")
                        .HasForeignKey("StudyHard.Data.Entity.Package.UserPackage", "TransactionId");

                    b.HasOne("StudyHard.Data.Entity.User", "User")
                        .WithMany("UserPackages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiqpayTransaction");

                    b.Navigation("Package");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Task.QuestionWithVariants.Answers", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.Task.QuestionWithVariants.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Task.TaskList", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.Category.Category", "Category")
                        .WithMany("TaskLists")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Theory.Theory", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.Category.Category", "Category")
                        .WithMany("Theories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Theory.TheoryNote", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.Theory.Theory", "Theory")
                        .WithMany("TheoryNotes")
                        .HasForeignKey("TheoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyHard.Data.Entity.User", "User")
                        .WithMany("TheoryNotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.User", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.University", "University")
                        .WithMany("User")
                        .HasForeignKey("UniversityId1");

                    b.Navigation("University");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.UserSession", b =>
                {
                    b.HasOne("StudyHard.Data.Entity.User", "User")
                        .WithOne("UserSession")
                        .HasForeignKey("StudyHard.Data.Entity.UserSession", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Category.Category", b =>
                {
                    b.Navigation("TaskLists");

                    b.Navigation("Theories");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.File", b =>
                {
                    b.Navigation("BlogSections");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Package.Package", b =>
                {
                    b.Navigation("PackageConfigurations");

                    b.Navigation("UserPackages");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Payment.LiqpayTransaction", b =>
                {
                    b.Navigation("UserPackage");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Subject.Subject", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("ExamResults");

                    b.Navigation("PackageConfiguration");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Task.QuestionWithVariants.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.Theory.Theory", b =>
                {
                    b.Navigation("TheoryNotes");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.University", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("StudyHard.Data.Entity.User", b =>
                {
                    b.Navigation("ExamResults");

                    b.Navigation("TheoryNotes");

                    b.Navigation("UserPackages");

                    b.Navigation("UserSession");
                });
#pragma warning restore 612, 618
        }
    }
}