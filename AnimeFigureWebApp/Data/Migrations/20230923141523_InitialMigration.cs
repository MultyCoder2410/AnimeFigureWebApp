using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeFigureWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalValue = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionId);
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    OriginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.OriginId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Collectors",
                columns: table => new
                {
                    CollectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectors", x => x.CollectorId);
                    table.ForeignKey(
                        name: "FK_Collectors_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                });

            migrationBuilder.CreateTable(
                name: "Figures",
                columns: table => new
                {
                    AnimeFigureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    CollectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Figures", x => x.AnimeFigureId);
                    table.ForeignKey(
                        name: "FK_Figures_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_Figures_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Figures_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId");
                    table.ForeignKey(
                        name: "FK_Figures_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId");
                });

            migrationBuilder.CreateTable(
                name: "CollectionCollector",
                columns: table => new
                {
                    CollectionsCollectionId = table.Column<int>(type: "int", nullable: false),
                    CollectorsCollectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionCollector", x => new { x.CollectionsCollectionId, x.CollectorsCollectorId });
                    table.ForeignKey(
                        name: "FK_CollectionCollector_Collections_CollectionsCollectionId",
                        column: x => x.CollectionsCollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionCollector_Collectors_CollectorsCollectorId",
                        column: x => x.CollectorsCollectorId,
                        principalTable: "Collectors",
                        principalColumn: "CollectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeFigureCategory",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    FiguresAnimeFigureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeFigureCategory", x => new { x.CategoriesCategoryId, x.FiguresAnimeFigureId });
                    table.ForeignKey(
                        name: "FK_AnimeFigureCategory_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeFigureCategory_Figures_FiguresAnimeFigureId",
                        column: x => x.FiguresAnimeFigureId,
                        principalTable: "Figures",
                        principalColumn: "AnimeFigureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeFigureOrigin",
                columns: table => new
                {
                    FiguresAnimeFigureId = table.Column<int>(type: "int", nullable: false),
                    OriginsOriginId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeFigureOrigin", x => new { x.FiguresAnimeFigureId, x.OriginsOriginId });
                    table.ForeignKey(
                        name: "FK_AnimeFigureOrigin_Figures_FiguresAnimeFigureId",
                        column: x => x.FiguresAnimeFigureId,
                        principalTable: "Figures",
                        principalColumn: "AnimeFigureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeFigureOrigin_Origins_OriginsOriginId",
                        column: x => x.OriginsOriginId,
                        principalTable: "Origins",
                        principalColumn: "OriginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerCollectorId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FigureAnimeFigureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Collectors_OwnerCollectorId",
                        column: x => x.OwnerCollectorId,
                        principalTable: "Collectors",
                        principalColumn: "CollectorId");
                    table.ForeignKey(
                        name: "FK_Reviews_Figures_FigureAnimeFigureId",
                        column: x => x.FigureAnimeFigureId,
                        principalTable: "Figures",
                        principalColumn: "AnimeFigureId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeFigureCategory_FiguresAnimeFigureId",
                table: "AnimeFigureCategory",
                column: "FiguresAnimeFigureId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeFigureOrigin_OriginsOriginId",
                table: "AnimeFigureOrigin",
                column: "OriginsOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCollector_CollectorsCollectorId",
                table: "CollectionCollector",
                column: "CollectorsCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Collectors_AdminId",
                table: "Collectors",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Figures_AdminId",
                table: "Figures",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Figures_BrandId",
                table: "Figures",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Figures_CollectionId",
                table: "Figures",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Figures_TypeId",
                table: "Figures",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FigureAnimeFigureId",
                table: "Reviews",
                column: "FigureAnimeFigureId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OwnerCollectorId",
                table: "Reviews",
                column: "OwnerCollectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeFigureCategory");

            migrationBuilder.DropTable(
                name: "AnimeFigureOrigin");

            migrationBuilder.DropTable(
                name: "CollectionCollector");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Origins");

            migrationBuilder.DropTable(
                name: "Collectors");

            migrationBuilder.DropTable(
                name: "Figures");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
