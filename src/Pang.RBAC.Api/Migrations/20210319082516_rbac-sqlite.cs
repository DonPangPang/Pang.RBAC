using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pang.RBAC.Api.Migrations
{
    public partial class rbacsqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FunctionOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    InterceptUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageElement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageElement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    IsSuper = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionFileResourceAss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileResourceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionFileResourceAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionFileResourceAss_FileResource_FileResourceId",
                        column: x => x.FileResourceId,
                        principalTable: "FileResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionFileResourceAss_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionFunctionOperationAss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FunctionOperationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionFunctionOperationAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionFunctionOperationAss_FunctionOperation_FunctionOperationId",
                        column: x => x.FunctionOperationId,
                        principalTable: "FunctionOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionFunctionOperationAss_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionMenuAss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MenuId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMenuAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionMenuAss_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionMenuAss_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPageElementAss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PageElementId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPageElementAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionPageElementAss_PageElement_PageElementId",
                        column: x => x.PageElementId,
                        principalTable: "PageElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionPageElementAss_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserUserGroupAss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserGroupAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUserGroupAss_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserGroupAss_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionAss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissionAss_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionAss_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUserGroupAss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUserGroupAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleUserGroupAss_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUserGroupAss_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleAss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleAss_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleAss_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name", "UserGroupId" },
                values: new object[] { new Guid("4fa85f64-5717-4562-f3fc-2c963f66afa6"), "admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "IsSuper", "Password", "Username" },
                values: new object[] { new Guid("3fa85f64-5717-4562-f3fc-2c963f66afa6"), true, "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionFileResourceAss_FileResourceId",
                table: "PermissionFileResourceAss",
                column: "FileResourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionFileResourceAss_PermissionId",
                table: "PermissionFileResourceAss",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionFunctionOperationAss_FunctionOperationId",
                table: "PermissionFunctionOperationAss",
                column: "FunctionOperationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionFunctionOperationAss_PermissionId",
                table: "PermissionFunctionOperationAss",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMenuAss_MenuId",
                table: "PermissionMenuAss",
                column: "MenuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMenuAss_PermissionId",
                table: "PermissionMenuAss",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPageElementAss_PageElementId",
                table: "PermissionPageElementAss",
                column: "PageElementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPageElementAss_PermissionId",
                table: "PermissionPageElementAss",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserGroupId",
                table: "Role",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionAss_PermissionId",
                table: "RolePermissionAss",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionAss_RoleId",
                table: "RolePermissionAss",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserGroupAss_RoleId",
                table: "RoleUserGroupAss",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserGroupAss_UserGroupId",
                table: "RoleUserGroupAss",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAss_RoleId",
                table: "UserRoleAss",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAss_UserId",
                table: "UserRoleAss",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserGroupAss_UserGroupId",
                table: "UserUserGroupAss",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserGroupAss_UserId",
                table: "UserUserGroupAss",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionFileResourceAss");

            migrationBuilder.DropTable(
                name: "PermissionFunctionOperationAss");

            migrationBuilder.DropTable(
                name: "PermissionMenuAss");

            migrationBuilder.DropTable(
                name: "PermissionPageElementAss");

            migrationBuilder.DropTable(
                name: "RolePermissionAss");

            migrationBuilder.DropTable(
                name: "RoleUserGroupAss");

            migrationBuilder.DropTable(
                name: "UserRoleAss");

            migrationBuilder.DropTable(
                name: "UserUserGroupAss");

            migrationBuilder.DropTable(
                name: "FileResource");

            migrationBuilder.DropTable(
                name: "FunctionOperation");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "PageElement");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserGroup");
        }
    }
}
