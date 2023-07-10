using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuestBook.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Body", "CreatedAt" },
                values: new object[,]
                {
                    { 1, "Marilyn Orn", "Et consequatur non facilis omnis id quae corporis suscipit rerum. Rerum minus qui officia ipsam et. Minima aut eum dolorem magni a cumque non. Animi perspiciatis praesentium. Voluptatum sunt aperiam qui distinctio voluptatem est aspernatur laborum. Delectus commodi omnis accusantium voluptatem sit quo.", new DateTime(2023, 7, 10, 16, 45, 9, 817, DateTimeKind.Local).AddTicks(9279) },
                    { 2, "Maggie Hoeger", "Itaque sunt commodi dolores libero porro ut molestias ea ratione.\nId nisi expedita ipsam quam sint adipisci dolore ut et.\nDelectus et recusandae animi.", new DateTime(2023, 7, 10, 1, 7, 34, 923, DateTimeKind.Local).AddTicks(3873) },
                    { 3, "Olga Beer", "Soluta et doloribus ducimus facere aut fugiat quisquam officia.", new DateTime(2023, 7, 9, 21, 28, 47, 818, DateTimeKind.Local).AddTicks(8648) },
                    { 4, "Rafael Morar", "Blanditiis ea corporis laboriosam minima omnis qui.\nNumquam sed veniam et consequatur consequatur.", new DateTime(2023, 7, 9, 23, 9, 15, 479, DateTimeKind.Local).AddTicks(7569) },
                    { 5, "Vivian Ziemann", "Distinctio autem quis.\nNecessitatibus voluptatum ipsum perferendis aperiam architecto eos sit.", new DateTime(2023, 7, 10, 16, 7, 49, 194, DateTimeKind.Local).AddTicks(7883) },
                    { 6, "Larry Runte", "Aliquam exercitationem corporis harum dolores in rerum veritatis repellendus.\nItaque reiciendis quis nemo aspernatur rerum illo in.\nRerum voluptas quos.\nMaiores consequatur molestiae consectetur sit sit et soluta.", new DateTime(2023, 7, 10, 13, 15, 37, 652, DateTimeKind.Local).AddTicks(2069) },
                    { 7, "Mathew Aufderhar", "Consequatur culpa sint qui laudantium perspiciatis numquam ducimus et.\nOmnis sed et ut nisi sapiente fuga consequuntur.\nLaudantium quaerat a consequuntur.\nDoloremque ut voluptatum quia quod est quos a hic.\nId eveniet officia et.", new DateTime(2023, 7, 10, 19, 38, 1, 403, DateTimeKind.Local).AddTicks(8769) },
                    { 8, "Mathew Fritsch", "Sequi distinctio et excepturi ut.", new DateTime(2023, 7, 10, 14, 47, 30, 579, DateTimeKind.Local).AddTicks(4338) },
                    { 9, "Dale Huel", "Numquam nulla ex perferendis qui tenetur non beatae voluptate.\nVeniam id molestias et velit pariatur placeat aspernatur.\nSimilique sed repellat accusamus eos.\nEum soluta porro labore iste ducimus velit molestiae beatae.\nDoloremque atque porro enim tempore quo ipsa rerum.", new DateTime(2023, 7, 9, 23, 2, 19, 438, DateTimeKind.Local).AddTicks(1146) },
                    { 10, "Gary Stark", "Aspernatur doloribus tenetur autem illum et incidunt excepturi sint.", new DateTime(2023, 7, 10, 10, 56, 32, 347, DateTimeKind.Local).AddTicks(4735) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Author", "Body", "CreatedAt", "PostId" },
                values: new object[,]
                {
                    { 1, "Courtney Parisian", "Quia accusantium consequatur.\nSapiente dolorum ducimus ab voluptatem voluptas autem quia.\nIure eius iusto soluta ducimus sapiente.\nRepudiandae quia omnis reiciendis.", new DateTime(2023, 7, 9, 22, 15, 37, 181, DateTimeKind.Local).AddTicks(8688), 5 },
                    { 2, "Elsie Hahn", "Ullam ullam et natus quo et rerum molestiae.\nSit quibusdam ratione atque quae autem quia omnis nemo.\nQuibusdam quia omnis rerum maxime libero qui consequuntur sequi.\nBlanditiis vel et eos occaecati exercitationem iste consequatur illo.\nPerspiciatis rerum a", new DateTime(2023, 7, 10, 7, 37, 30, 524, DateTimeKind.Local).AddTicks(461), 4 },
                    { 3, "Darrel Wyman", "Et reiciendis eaque.", new DateTime(2023, 7, 10, 6, 46, 11, 265, DateTimeKind.Local).AddTicks(4219), 4 },
                    { 4, "Mattie Hackett", "Eveniet sit vel. Sunt magni nostrum et ex. Reprehenderit nihil maxime qui doloribus sequi provident. Possimus pariatur tempore unde magni ipsam cum. Ducimus odit atque omnis sequi aut. Ut officia perspiciatis reprehenderit dolor.", new DateTime(2023, 7, 10, 17, 55, 22, 51, DateTimeKind.Local).AddTicks(5608), 1 },
                    { 5, "Maggie Mills", "Quis quaerat nihil sequi mollitia modi. Molestias asperiores voluptate qui nihil. Provident ut laudantium soluta consequatur quo delectus.", new DateTime(2023, 7, 10, 6, 19, 31, 894, DateTimeKind.Local).AddTicks(4197), 1 },
                    { 6, "Virgil Wilderman", "Molestiae velit totam aliquam unde odit itaque sequi. Quis saepe fugit dolorem quia. Non voluptas nostrum dolores et omnis illo. Voluptas natus nihil doloribus eos voluptatem et facere omnis.", new DateTime(2023, 7, 10, 1, 44, 27, 819, DateTimeKind.Local).AddTicks(4838), 8 },
                    { 7, "Kevin Howell", "Dolorem non libero natus pariatur sed suscipit.", new DateTime(2023, 7, 10, 9, 7, 35, 9, DateTimeKind.Local).AddTicks(258), 7 },
                    { 8, "Sonja Gibson", "recusandae", new DateTime(2023, 7, 10, 0, 36, 50, 690, DateTimeKind.Local).AddTicks(3286), 5 },
                    { 9, "Kristen Altenwerth", "Asperiores ea aliquam voluptatem et omnis adipisci voluptate at.\nAt consectetur sed cumque ut.\nDeleniti ex natus exercitationem eveniet repellat earum et dolores sint.", new DateTime(2023, 7, 10, 2, 43, 44, 826, DateTimeKind.Local).AddTicks(5643), 1 },
                    { 10, "Kendra Tromp", "Fuga sunt non est dolorem. Aliquid enim voluptatem a iusto temporibus sunt velit. Reiciendis expedita totam et asperiores nihil rem quaerat architecto. Labore et blanditiis sit suscipit at dignissimos quis incidunt eveniet.", new DateTime(2023, 7, 10, 20, 9, 9, 220, DateTimeKind.Local).AddTicks(4859), 1 },
                    { 11, "Rogelio Parisian", "Quia dolorum qui dignissimos vel.\nSuscipit dolores ipsa.\nVoluptatem non illo.", new DateTime(2023, 7, 10, 15, 17, 58, 882, DateTimeKind.Local).AddTicks(9012), 10 },
                    { 12, "Damon Doyle", "Dolor consequuntur dolore.\nQuibusdam nihil rerum quibusdam voluptate enim voluptatem et.\nVoluptate culpa et consequatur saepe est.\nOmnis quas iusto adipisci.", new DateTime(2023, 7, 10, 10, 45, 50, 489, DateTimeKind.Local).AddTicks(1491), 4 },
                    { 13, "Milton Grimes", "Placeat veritatis optio culpa reiciendis maxime rerum qui deleniti.\nAutem iusto quam unde harum.", new DateTime(2023, 7, 9, 20, 54, 46, 926, DateTimeKind.Local).AddTicks(7743), 7 },
                    { 14, "Reginald Fritsch", "Suscipit temporibus eligendi consequatur nobis delectus expedita.\nDoloremque ut aut voluptatem eos incidunt aut sunt.", new DateTime(2023, 7, 9, 23, 15, 13, 343, DateTimeKind.Local).AddTicks(6382), 1 },
                    { 15, "Sabrina Larson", "Cupiditate dicta delectus sunt dolorum dolor dolorum labore. Id inventore modi. Architecto quia qui aut. Eaque est debitis culpa ex asperiores dolorem. Accusamus voluptate soluta dolores facere quis. Repellendus facilis vel excepturi.", new DateTime(2023, 7, 10, 10, 51, 47, 274, DateTimeKind.Local).AddTicks(4495), 9 },
                    { 16, "Kristina Jacobi", "Incidunt dolorem commodi est id in eos laboriosam repellat occaecati.", new DateTime(2023, 7, 10, 15, 10, 15, 328, DateTimeKind.Local).AddTicks(216), 9 },
                    { 17, "Andres Ratke", "aut", new DateTime(2023, 7, 10, 12, 1, 53, 671, DateTimeKind.Local).AddTicks(6491), 3 },
                    { 18, "Bruce Dach", "optio", new DateTime(2023, 7, 10, 0, 8, 42, 862, DateTimeKind.Local).AddTicks(9250), 7 },
                    { 19, "Ana Kshlerin", "commodi", new DateTime(2023, 7, 10, 7, 53, 36, 231, DateTimeKind.Local).AddTicks(6867), 1 },
                    { 20, "Fernando Reynolds", "Facere a est velit.\nQuis aut et et sed excepturi.", new DateTime(2023, 7, 10, 15, 41, 46, 291, DateTimeKind.Local).AddTicks(1884), 9 },
                    { 21, "Ervin Jacobs", "Ut aperiam nihil dolores culpa accusamus eveniet minus.", new DateTime(2023, 7, 10, 1, 53, 56, 535, DateTimeKind.Local).AddTicks(4187), 1 },
                    { 22, "Nathaniel Hane", "sit", new DateTime(2023, 7, 10, 16, 39, 12, 442, DateTimeKind.Local).AddTicks(5779), 2 },
                    { 23, "Lamar Roob", "Quibusdam ipsum et iusto culpa nesciunt repudiandae unde et explicabo.\nEst sed voluptatum velit veritatis corrupti omnis mollitia eos.\nRepellendus rerum vero corporis sit tempora.", new DateTime(2023, 7, 9, 23, 38, 16, 65, DateTimeKind.Local).AddTicks(8302), 4 },
                    { 24, "Phillip Volkman", "Molestiae tempora ullam.", new DateTime(2023, 7, 10, 11, 37, 3, 977, DateTimeKind.Local).AddTicks(7592), 9 },
                    { 25, "Saul Kreiger", "Nam qui ut aut omnis commodi.", new DateTime(2023, 7, 10, 1, 19, 34, 740, DateTimeKind.Local).AddTicks(4209), 9 },
                    { 26, "Patricia Weimann", "Quae sequi quis ut.", new DateTime(2023, 7, 10, 12, 25, 55, 667, DateTimeKind.Local).AddTicks(7230), 6 },
                    { 27, "Lonnie Hermann", "esse", new DateTime(2023, 7, 9, 23, 29, 15, 209, DateTimeKind.Local).AddTicks(8619), 9 },
                    { 28, "Christy Nader", "Et ab quis possimus et velit cumque aut id.\nLaudantium ipsa vel impedit voluptates facere non accusantium.\nVoluptas non aut voluptas et porro rem.\nQuibusdam sit at ut omnis veritatis sunt temporibus.", new DateTime(2023, 7, 10, 14, 6, 57, 840, DateTimeKind.Local).AddTicks(360), 8 },
                    { 29, "Lance Schiller", "molestiae", new DateTime(2023, 7, 10, 13, 34, 39, 951, DateTimeKind.Local).AddTicks(7997), 8 },
                    { 30, "Ernestine Erdman", "Nihil odio fugit doloremque illum modi.", new DateTime(2023, 7, 10, 14, 30, 19, 310, DateTimeKind.Local).AddTicks(7281), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
