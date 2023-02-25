using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbyOnContainers.ProductDataManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    AttrTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    DescrProductId = table.Column<Guid>(name: "Descr_ProductId", type: "uuid", nullable: true),
                    DescrDetailId = table.Column<Guid>(type: "uuid", nullable: true),
                    DescrTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttrType_Attrs",
                        column: x => x.AttrTypeId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescrType_DescrValues",
                        column: x => x.DescrTypeId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescrValue_Descrs",
                        column: x => x.DescrDetailId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attr_products",
                        column: x => x.ProductId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_category_categories",
                        column: x => x.ParentId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_descr_products",
                        column: x => x.DescrProductId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_categories",
                        column: x => x.CategoryId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryAttrTypes",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttrTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAttrTypes", x => new { x.CategoryId, x.AttrTypeId });
                    table.ForeignKey(
                        name: "FK_AttrType_CategoryAttrTypes",
                        column: x => x.AttrTypeId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_CategoryAttrTypes",
                        column: x => x.CategoryId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDescrTypes",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescrTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDescrTypes", x => new { x.CategoryId, x.DescrTypeId });
                    table.ForeignKey(
                        name: "FK_Category_CategoryDescrTypes",
                        column: x => x.CategoryId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescrType_CategoryDescrTypes",
                        column: x => x.DescrTypeId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttrTypes_AttrTypeId",
                table: "CategoryAttrTypes",
                column: "AttrTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDescrTypes_DescrTypeId",
                table: "CategoryDescrTypes",
                column: "DescrTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_AttrTypeId",
                table: "Entity",
                column: "AttrTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_CategoryId",
                table: "Entity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_Descr_ProductId",
                table: "Entity",
                column: "Descr_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_DescrDetailId",
                table: "Entity",
                column: "DescrDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_DescrTypeId",
                table: "Entity",
                column: "DescrTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ParentId",
                table: "Entity",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ProductId",
                table: "Entity",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryAttrTypes");

            migrationBuilder.DropTable(
                name: "CategoryDescrTypes");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
