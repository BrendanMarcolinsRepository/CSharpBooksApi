using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Books.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileDescription = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: true),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Roles = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Pagecount = table.Column<int>(type: "integer", nullable: false),
                    WordsPerPage = table.Column<int>(type: "integer", nullable: false),
                    WordCount = table.Column<int>(type: "integer", nullable: false),
                    BookCover = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DifficultyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Difficulty_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BookUser_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    percentage = table.Column<int>(type: "integer", nullable: false),
                    completed = table.Column<bool>(type: "boolean", nullable: false),
                    timeleft = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progress_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Progress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06580836-f2af-42c0-b5a7-479975ef1c9d"), "Neil Stephenson" },
                    { new Guid("302afacb-becd-4dfc-9186-5c7eaa93424b"), "Dan Simmons" }
                });

            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"), "Medium" },
                    { new Guid("3b28d9bd-7f0a-4718-8bd6-06e5785ea865"), "Hard" },
                    { new Guid("abcd9987-fbac-4ba4-a15d-e12f5d15fe8f"), "Expert" },
                    { new Guid("df289bf2-06f2-477b-89ef-aa82bb905d47"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"), "Sci-Fi" },
                    { new Guid("387e14af-27b6-45ef-8d8e-29a708019073"), "History" },
                    { new Guid("a0f16189-1e04-44e9-8022-90168db7b6c3"), "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5104a982-9ee5-4cf8-b947-037a1728e427"), "Penguin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Roles", "Username" },
                values: new object[] { new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576"), "Password123!", new[] { "Writer" }, "m@gmail.com" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "BookCover", "Description", "DifficultyId", "GenreId", "Name", "Pagecount", "ProgressId", "PublisherId", "WordCount", "WordsPerPage" },
                values: new object[,]
                {
                    { new Guid("2a7ada53-e3f7-4154-8737-dfee6aff1b80"), new Guid("302afacb-becd-4dfc-9186-5c7eaa93424b"), "", "", new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"), new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"), "Hyperion", 482, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("5104a982-9ee5-4cf8-b947-037a1728e427"), 163500, 400 },
                    { new Guid("941e317b-77e5-4f7d-915f-beb98541e560"), new Guid("06580836-f2af-42c0-b5a7-479975ef1c9d"), "", "", new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"), new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"), "Cryptonomicon", 1152, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("5104a982-9ee5-4cf8-b947-037a1728e427"), 349056, 400 },
                    { new Guid("9c9e4237-bd98-4dda-8fb3-9e6ab9a75963"), new Guid("302afacb-becd-4dfc-9186-5c7eaa93424b"), "", "", new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"), new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"), "Fall of Hyperion", 544, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("5104a982-9ee5-4cf8-b947-037a1728e427"), 169059, 400 },
                    { new Guid("ad241e9a-dc28-4a30-93e2-300402631654"), new Guid("06580836-f2af-42c0-b5a7-479975ef1c9d"), "", "", new Guid("166373b8-74e9-4b99-bd3d-e7dd77b1590b"), new Guid("1ae27bf6-6b8e-4cfd-a23d-d16f232669e2"), "Snow Crash", 576, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("5104a982-9ee5-4cf8-b947-037a1728e427"), 182234, 400 }
                });

            migrationBuilder.InsertData(
                table: "BookUser",
                columns: new[] { "BooksId", "UsersId" },
                values: new object[,]
                {
                    { new Guid("2a7ada53-e3f7-4154-8737-dfee6aff1b80"), new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576") },
                    { new Guid("941e317b-77e5-4f7d-915f-beb98541e560"), new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576") },
                    { new Guid("9c9e4237-bd98-4dda-8fb3-9e6ab9a75963"), new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576") },
                    { new Guid("ad241e9a-dc28-4a30-93e2-300402631654"), new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576") }
                });

            migrationBuilder.InsertData(
                table: "Progress",
                columns: new[] { "Id", "BookId", "UserId", "completed", "percentage", "timeleft" },
                values: new object[,]
                {
                    { new Guid("8ea8c311-aaa9-4e1a-ac39-95d2bd989cc1"), new Guid("941e317b-77e5-4f7d-915f-beb98541e560"), new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576"), false, 50, 698 },
                    { new Guid("9738c657-a1f3-4e5c-8f5b-e9e8b9e5bd06"), new Guid("9c9e4237-bd98-4dda-8fb3-9e6ab9a75963"), new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576"), false, 25, 507 },
                    { new Guid("ad91f371-ce2f-432b-b001-572f493c4112"), new Guid("ad241e9a-dc28-4a30-93e2-300402631654"), new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576"), true, 100, 0 },
                    { new Guid("f4f791b9-4df7-4786-a247-4d2e69630eef"), new Guid("2a7ada53-e3f7-4154-8737-dfee6aff1b80"), new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576"), false, 75, 163 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "Name", "UserId", "rating" },
                values: new object[] { new Guid("fc859859-d1a9-495e-aac9-082b6e3f7989"), new Guid("ad241e9a-dc28-4a30-93e2-300402631654"), "This book is amazing blah blah ", "Amazing book!!!", new Guid("eac69ca4-a917-4faf-9e3e-5bff6a951576"), 5 });

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
