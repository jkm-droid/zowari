﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ActivityId");

                    b.Property<string>("ActivityBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Domain.Entities.BookMark", b =>
                {
                    b.Property<Guid>("BookMarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("BookMarkId");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TopicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("BookMarkId");

                    b.HasIndex("MessageId");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("BookMarks");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("CategoryId");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ForumId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("CommentId");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("CountryId");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Iso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Iso3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NiceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumCode")
                        .HasColumnType("integer");

                    b.Property<int>("PhoneCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Entities.ForumList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ForumId");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ForumLists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1404dde0-45cc-4438-9fd8-03e0ed5d6d16"),
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 3, 0, 0, 0)),
                            Description = "Hello world forum",
                            LastModifiedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3293), new TimeSpan(0, 3, 0, 0, 0)),
                            Title = "Hello"
                        },
                        new
                        {
                            Id = new Guid("620c985b-dcd8-499b-91f7-32ee5498822e"),
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3321), new TimeSpan(0, 3, 0, 0, 0)),
                            Description = "World politics forum",
                            LastModifiedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3322), new TimeSpan(0, 3, 0, 0, 0)),
                            Title = "World politics"
                        },
                        new
                        {
                            Id = new Guid("f390a27d-dbd5-4254-9001-ec0848854d4d"),
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 3, 0, 0, 0)),
                            Description = "Nature forum",
                            LastModifiedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3338), new TimeSpan(0, 3, 0, 0, 0)),
                            Title = "Nature"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"),
                            ConcurrencyStamp = "4fb63c0e-8b51-4e7e-a52e-2a29fced51f1",
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2853), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Visitor role description",
                            LastModifiedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Visitor",
                            NormalizedName = "VISITOR"
                        },
                        new
                        {
                            Id = new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"),
                            ConcurrencyStamp = "5a5989b8-bf29-4177-92fd-eda87767e410",
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2896), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Administrator role description",
                            LastModifiedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2896), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "SuperAdministrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"),
                            ConcurrencyStamp = "f6012a1f-4da9-443e-ac3b-ff1daf960fa0",
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2918), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Basic role description",
                            LastModifiedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2918), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "BasicUser",
                            NormalizedName = "BASICUSER"
                        },
                        new
                        {
                            Id = new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"),
                            ConcurrencyStamp = "b5a2bbfd-7a22-471f-a326-80d5884abc97",
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2936), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Administrator role description",
                            LastModifiedOn = new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2936), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("text");

                    b.Property<int?>("Rating")
                        .HasColumnType("integer");

                    b.Property<int?>("Score")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("LikeId");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("MessageId");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.Entities.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("TagId");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Domain.Entities.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("TopicId");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TagTopic", b =>
                {
                    b.Property<Guid>("TagsTagId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TopicsId")
                        .HasColumnType("uuid");

                    b.HasKey("TagsTagId", "TopicsId");

                    b.HasIndex("TopicsId");

                    b.ToTable("TagTopic");
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.Property<Guid>("RoleId1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uuid");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("Domain.Entities.BookMark", b =>
                {
                    b.HasOne("Domain.Entities.Message", null)
                        .WithMany("BookMarks")
                        .HasForeignKey("MessageId");

                    b.HasOne("Domain.Entities.Topic", null)
                        .WithMany("BookMarks")
                        .HasForeignKey("TopicId");

                    b.HasOne("Domain.Entities.Identity.User", "User")
                        .WithMany("BookMarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.HasOne("Domain.Entities.ForumList", "ForumList")
                        .WithMany("Categories")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ForumList");
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Entities.Message", "Message")
                        .WithMany("Comments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Domain.Entities.Like", b =>
                {
                    b.HasOne("Domain.Entities.Message", "Message")
                        .WithMany("Likes")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.HasOne("Domain.Entities.Topic", "Topic")
                        .WithMany("Messages")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Domain.Entities.Topic", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Topics")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TagTopic", b =>
                {
                    b.HasOne("Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Domain.Entities.ForumList", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Identity.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.Identity.User", b =>
                {
                    b.Navigation("BookMarks");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.Navigation("BookMarks");

                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Domain.Entities.Topic", b =>
                {
                    b.Navigation("BookMarks");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
