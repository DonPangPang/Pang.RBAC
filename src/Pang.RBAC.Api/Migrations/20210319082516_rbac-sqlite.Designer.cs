﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pang.RBAC.Api.Data;

namespace Pang.RBAC.Api.Migrations
{
    [DbContext(typeof(PangDbContext))]
    [Migration("20210319082516_rbac-sqlite")]
    partial class rbacsqlite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Pang.RBAC.Api.Entities.FileResource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FileResource");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.FunctionOperation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("InterceptUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FunctionOperation");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PageElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PageElement");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PermissionFileResourceAss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FileResourceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FileResourceId")
                        .IsUnique();

                    b.HasIndex("PermissionId");

                    b.ToTable("PermissionFileResourceAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PermissionFunctionOperationAss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FunctionOperationId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FunctionOperationId")
                        .IsUnique();

                    b.HasIndex("PermissionId");

                    b.ToTable("PermissionFunctionOperationAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PermissionMenuAss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MenuId")
                        .IsUnique();

                    b.HasIndex("PermissionId");

                    b.ToTable("PermissionMenuAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PermissionPageElementAss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PageElementId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PageElementId")
                        .IsUnique();

                    b.HasIndex("PermissionId");

                    b.ToTable("PermissionPageElementAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserGroupId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fa85f64-5717-4562-f3fc-2c963f66afa6"),
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.RolePermissionAss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissionAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.RoleUserGroupAss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserGroupId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("RoleUserGroupAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSuper")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3fa85f64-5717-4562-f3fc-2c963f66afa6"),
                            IsSuper = true,
                            Password = "admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.UserGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.UserRoleAss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoleAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.UserUserGroupAss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserGroupId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserUserGroupAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PermissionFileResourceAss", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.FileResource", "FileResource")
                        .WithOne("PermissionFileResourceAss")
                        .HasForeignKey("Pang.RBAC.Api.Entities.PermissionFileResourceAss", "FileResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pang.RBAC.Api.Entities.Permission", "Permission")
                        .WithMany("permissionFileResourceAsses")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileResource");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PermissionFunctionOperationAss", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.FunctionOperation", "FunctionOperation")
                        .WithOne("PermissionFunctionOperationAss")
                        .HasForeignKey("Pang.RBAC.Api.Entities.PermissionFunctionOperationAss", "FunctionOperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pang.RBAC.Api.Entities.Permission", "Permission")
                        .WithMany("PermissionFunctionOperationAsses")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FunctionOperation");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PermissionMenuAss", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.Menu", "Menu")
                        .WithOne("PermissionMenuAss")
                        .HasForeignKey("Pang.RBAC.Api.Entities.PermissionMenuAss", "MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pang.RBAC.Api.Entities.Permission", "Permission")
                        .WithMany("PermissionMenuAsses")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PermissionPageElementAss", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.PageElement", "PageElement")
                        .WithOne("PermissionPageElementAss")
                        .HasForeignKey("Pang.RBAC.Api.Entities.PermissionPageElementAss", "PageElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pang.RBAC.Api.Entities.Permission", "Permission")
                        .WithMany("PermissionPageElementAsses")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PageElement");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.Role", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.UserGroup", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupId");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.RolePermissionAss", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.Permission", "Permission")
                        .WithMany("RolePermissionAsses")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pang.RBAC.Api.Entities.Role", "Role")
                        .WithMany("RolePermissionAsses")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.RoleUserGroupAss", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pang.RBAC.Api.Entities.UserGroup", "UserGroup")
                        .WithMany("RoleUserGroupAsses")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.UserRoleAss", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.Role", "Role")
                        .WithMany("UserRoleAsses")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pang.RBAC.Api.Entities.User", "User")
                        .WithMany("UserRoleAsses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.UserUserGroupAss", b =>
                {
                    b.HasOne("Pang.RBAC.Api.Entities.UserGroup", "UserGroup")
                        .WithMany("UserUserGroupAsses")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pang.RBAC.Api.Entities.User", "User")
                        .WithOne("UserUserGroupAss")
                        .HasForeignKey("Pang.RBAC.Api.Entities.UserUserGroupAss", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.FileResource", b =>
                {
                    b.Navigation("PermissionFileResourceAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.FunctionOperation", b =>
                {
                    b.Navigation("PermissionFunctionOperationAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.Menu", b =>
                {
                    b.Navigation("PermissionMenuAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.PageElement", b =>
                {
                    b.Navigation("PermissionPageElementAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.Permission", b =>
                {
                    b.Navigation("permissionFileResourceAsses");

                    b.Navigation("PermissionFunctionOperationAsses");

                    b.Navigation("PermissionMenuAsses");

                    b.Navigation("PermissionPageElementAsses");

                    b.Navigation("RolePermissionAsses");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.Role", b =>
                {
                    b.Navigation("RolePermissionAsses");

                    b.Navigation("UserRoleAsses");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.User", b =>
                {
                    b.Navigation("UserRoleAsses");

                    b.Navigation("UserUserGroupAss");
                });

            modelBuilder.Entity("Pang.RBAC.Api.Entities.UserGroup", b =>
                {
                    b.Navigation("RoleUserGroupAsses");

                    b.Navigation("UserUserGroupAsses");
                });
#pragma warning restore 612, 618
        }
    }
}