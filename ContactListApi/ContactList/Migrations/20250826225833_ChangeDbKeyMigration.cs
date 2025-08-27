using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ContactList.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbKeyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Category_CategoryId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_SubCategory_SubCategoryId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_Contact_CategoryId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_SubCategoryId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Contact",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryName",
                table: "Contact",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CategoryName",
                table: "Contact",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_SubCategoryName",
                table: "Contact",
                column: "SubCategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Category_CategoryName",
                table: "Contact",
                column: "CategoryName",
                principalTable: "Category",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_SubCategory_SubCategoryName",
                table: "Contact",
                column: "SubCategoryName",
                principalTable: "SubCategory",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Category_CategoryName",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_SubCategory_SubCategoryName",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_Contact_CategoryName",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_SubCategoryName",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "SubCategoryName",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubCategory",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Contact",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Contact",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Category",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CategoryId",
                table: "Contact",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_SubCategoryId",
                table: "Contact",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Category_CategoryId",
                table: "Contact",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_SubCategory_SubCategoryId",
                table: "Contact",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
