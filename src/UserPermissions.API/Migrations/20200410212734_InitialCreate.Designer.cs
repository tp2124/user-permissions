﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserPermissions.API.Data;

namespace UserPermissions.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200410212734_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("UserPermissions.API.Models.PermissionFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PermissionFeatures");
                });

            modelBuilder.Entity("UserPermissions.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PermissionFeatureId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PermissionFeatureId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserPermissions.API.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PermissionFeatureId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PermissionFeatureId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("UserPermissions.API.Models.User", b =>
                {
                    b.HasOne("UserPermissions.API.Models.PermissionFeature", null)
                        .WithMany("PermittedUsers")
                        .HasForeignKey("PermissionFeatureId");

                    b.HasOne("UserPermissions.API.Models.UserGroup", null)
                        .WithMany("IncludedUsers")
                        .HasForeignKey("UserGroupId");
                });

            modelBuilder.Entity("UserPermissions.API.Models.UserGroup", b =>
                {
                    b.HasOne("UserPermissions.API.Models.PermissionFeature", null)
                        .WithMany("PermittedUserGroups")
                        .HasForeignKey("PermissionFeatureId");

                    b.HasOne("UserPermissions.API.Models.UserGroup", null)
                        .WithMany("IncludedUserGroups")
                        .HasForeignKey("UserGroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
