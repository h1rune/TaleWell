using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiteraryArchetypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ScopeType = table.Column<int>(type: "integer", nullable: false),
                    NarrativeType = table.Column<int>(type: "integer", nullable: false),
                    ToneType = table.Column<int>(type: "integer", nullable: false),
                    PurposeType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiteraryArchetypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiteraryTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ScopeType = table.Column<int>(type: "integer", nullable: false),
                    NarrativeType = table.Column<int>(type: "integer", nullable: false),
                    ToneType = table.Column<int>(type: "integer", nullable: false),
                    PurposeType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiteraryTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsFanfic = table.Column<bool>(type: "boolean", nullable: false),
                    OriginalWorkId = table.Column<Guid>(type: "uuid", nullable: true),
                    FormType = table.Column<int>(type: "integer", nullable: false),
                    LiteraryArchetypeId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_LiteraryArchetypes_LiteraryArchetypeId",
                        column: x => x.LiteraryArchetypeId,
                        principalTable: "LiteraryArchetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_Works_OriginalWorkId",
                        column: x => x.OriginalWorkId,
                        principalTable: "Works",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LiteraryTagWork",
                columns: table => new
                {
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiteraryTagWork", x => new { x.TagsId, x.WorksId });
                    table.ForeignKey(
                        name: "FK_LiteraryTagWork_LiteraryTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "LiteraryTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiteraryTagWork_Works_WorksId",
                        column: x => x.WorksId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    Mark = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    CoverKey = table.Column<string>(type: "text", nullable: true),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volumes_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    VolumeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChapterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    S3Key = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParagraphId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    IsSpoiler = table.Column<bool>(type: "boolean", nullable: false),
                    SpoilerChapterId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Chapters_SpoilerChapterId",
                        column: x => x.SpoilerChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Comments_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParagraphId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    PutAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_Paragraphs_ParagraphId",
                        column: x => x.ParagraphId,
                        principalTable: "Paragraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LiteraryArchetypes",
                columns: new[] { "Id", "Name", "NarrativeType", "PurposeType", "ScopeType", "ToneType" },
                values: new object[,]
                {
                    { "FBLE", "Трикстер", 1, 0, 1, 1 },
                    { "FBLI", "Алхимик", 1, 1, 1, 1 },
                    { "FBSE", "Герой", 1, 0, 1, 0 },
                    { "FBSI-P", "Пророк", 1, 1, 1, 0 },
                    { "FHLE", "Чародей", 0, 0, 1, 1 },
                    { "FHLI", "Визионер", 0, 1, 1, 1 },
                    { "FHSE", "Мистик", 0, 0, 1, 0 },
                    { "FHSI", "Оракул", 0, 1, 1, 0 },
                    { "RBLE", "Бард", 1, 0, 0, 1 },
                    { "RBLI", "Свидетель", 1, 1, 0, 1 },
                    { "RBSE", "Хроникёр", 1, 0, 0, 0 },
                    { "RBSI", "Судья", 1, 1, 0, 0 },
                    { "RHLE", "Арлекин", 0, 0, 0, 1 },
                    { "RHLI", "Пилигрим", 0, 1, 0, 1 },
                    { "RHSE", "Отшельник", 0, 0, 0, 0 },
                    { "RHSI", "Мудрец", 0, 1, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "LiteraryTags",
                columns: new[] { "Id", "Name", "NarrativeType", "PurposeType", "ScopeType", "ToneType" },
                values: new object[,]
                {
                    { new Guid("03a5f83c-7187-41b3-9cc3-db11210733d3"), "Метастиль", 1, 1, 1, 1 },
                    { new Guid("0614effc-9be3-4632-af7c-70cd487fd86c"), "Трагизм", 0, 1, 0, 0 },
                    { new Guid("0cb3ee49-f561-4237-af0d-7d2593bf2e00"), "Вызов нормам", 1, 1, 0, 0 },
                    { new Guid("13955ae4-a8e9-497a-ad2c-2124999143ea"), "От первого лица", 0, 0, 0, 1 },
                    { new Guid("13d4d535-3df2-4eb1-8804-59e8ea0c31c6"), "Критика", 1, 1, 0, 0 },
                    { new Guid("16277759-6195-4c8d-a40f-def5623cd90b"), "Рефлексия", 0, 1, 0, 0 },
                    { new Guid("224649db-9083-4e76-8a10-145afd78efdd"), "Интрига", 1, 0, 1, 1 },
                    { new Guid("279a76fc-7733-4a43-80f4-6a06b418a9f2"), "Родственные связи", 0, 1, 0, 1 },
                    { new Guid("2dc5ab6b-6f43-4eed-9edd-5bac31a52d17"), "Система магии", 1, 0, 1, 1 },
                    { new Guid("2dd3bcee-e678-4ff1-b7bd-38b45bf8b5a7"), "Одиночество", 0, 1, 0, 0 },
                    { new Guid("2dff17b0-0d10-44bb-9cc1-a0747dd3439f"), "Исторический сеттинг", 1, 1, 0, 0 },
                    { new Guid("30f17aeb-8970-4631-9c63-1f29c1b39f78"), "Поколения", 1, 1, 0, 1 },
                    { new Guid("33d416cf-48f2-4eaf-bd46-6f49647629f9"), "Моральный выбор", 0, 1, 0, 0 },
                    { new Guid("395299ea-8bab-4785-9e06-cd19f7878d87"), "Инопланетная цивилизация", 1, 0, 1, 1 },
                    { new Guid("42158584-39a4-4018-a835-44a3be36dd52"), "Трагедия", 0, 1, 0, 0 },
                    { new Guid("4230c8d6-6776-46fb-9280-fcfcab67d194"), "Предательство", 1, 0, 0, 0 },
                    { new Guid("45e8b8e3-0ca3-4f4b-a2d0-64d4f06f11a7"), "Утопия", 1, 1, 1, 1 },
                    { new Guid("45f1b833-8005-4538-b4a2-4448430e9707"), "Эскапизм", 1, 0, 1, 1 },
                    { new Guid("4836389e-2c76-4862-a27f-3177eb7df4d1"), "Страх", 1, 0, 1, 0 },
                    { new Guid("5a06d6b9-c24e-4f41-ad79-bcef46693816"), "Отчуждение", 0, 1, 0, 0 },
                    { new Guid("6326a2ad-168a-4dbf-9807-0780071bf9ce"), "Романтика", 0, 0, 0, 1 },
                    { new Guid("63eaa89b-d59a-4171-907a-77f092129910"), "Архаизм", 0, 1, 0, 0 },
                    { new Guid("66ed4746-bd03-44d4-a1ee-3aa69733198c"), "Альтернативная реальность", 1, 1, 1, 1 },
                    { new Guid("697ce266-b023-41fa-a25d-9c72863d8efa"), "Общество", 1, 1, 0, 0 },
                    { new Guid("6b940f12-a125-4a63-a0b8-cb5e9b317bac"), "Надежда", 0, 0, 0, 1 },
                    { new Guid("6dd0fcc1-b72d-4c64-9fc0-20f2b68a73e0"), "Дистопия", 1, 1, 1, 0 },
                    { new Guid("7aafcbcc-fd38-4044-abb5-d45b2ed7b320"), "Поиск смысла", 0, 1, 0, 0 },
                    { new Guid("7d71c4b3-18c7-4e02-b110-2fab2a1a9536"), "Философия", 0, 1, 0, 0 },
                    { new Guid("7dbe2c49-3100-4581-b08f-70b0c22565ad"), "Человеческая природа", 0, 1, 0, 0 },
                    { new Guid("8064693a-cff3-4b4c-b604-ad8dcfa039b6"), "Наставник", 0, 1, 0, 1 },
                    { new Guid("82764e64-6856-445d-81cf-6d5e8297a924"), "Ненадёжный рассказчик", 0, 1, 1, 0 },
                    { new Guid("88f023a5-3d83-45d1-a4fa-b7188ce81a6d"), "Страхи", 0, 1, 0, 0 },
                    { new Guid("8aea65ee-0997-4c1c-aa88-5f659b5843e3"), "Спасение мира", 1, 0, 1, 1 },
                    { new Guid("8bbcf0a6-841c-488b-96d5-4b66fcf95446"), "Осознание", 0, 1, 0, 1 },
                    { new Guid("8daec224-778f-41d8-a04b-77934e644d6d"), "Самооценка", 0, 1, 0, 1 },
                    { new Guid("8e64f15a-d184-423e-8fa1-451eb69039ab"), "Футуризм", 1, 0, 1, 1 },
                    { new Guid("8ef681b3-947d-444f-bf7f-477a15fa1ecf"), "Детектив", 1, 0, 0, 1 },
                    { new Guid("9315dd35-30af-4ca8-9411-1d3d54860f36"), "Обучение", 0, 1, 0, 0 },
                    { new Guid("967ef310-6c90-4e63-92b0-ac1a507b8ef9"), "Символизм", 0, 1, 0, 0 },
                    { new Guid("98f20020-ebb7-40f2-876d-8983484a52e5"), "Желания", 0, 1, 0, 1 },
                    { new Guid("9bdf3b1a-108a-4be3-b129-c8ad66e9d05b"), "Постапокалипсис", 1, 0, 1, 0 },
                    { new Guid("a104f842-dcd0-4f22-8a73-fc07802f1275"), "Тревожность", 0, 1, 0, 0 },
                    { new Guid("a20d0390-9ef2-41b6-92cd-9e272f20b2c7"), "Внутренний конфликт", 0, 1, 0, 0 },
                    { new Guid("a24432ff-5627-4252-87c6-06ca19badcf7"), "Семья", 0, 1, 0, 1 },
                    { new Guid("a8147c76-a2e2-4af1-9361-ede3d20d646b"), "Ностальгия", 0, 0, 0, 1 },
                    { new Guid("aa5b9c59-383d-4a22-86cf-92289cee9c57"), "Юмор", 1, 0, 0, 1 },
                    { new Guid("ab9e3345-7d5e-43b4-a214-3ed0d6cf094a"), "Обращение", 0, 0, 0, 1 },
                    { new Guid("ac901868-ec5c-415c-8fb2-25e2086c7f51"), "Память", 0, 1, 0, 0 },
                    { new Guid("b4a16f13-f28b-4e43-bbd6-d241217b9455"), "Психология", 0, 1, 0, 0 },
                    { new Guid("b5ed9540-25a7-4847-81a3-a16ae018163e"), "Открытый финал", 1, 1, 1, 0 },
                    { new Guid("bea81375-c96d-47e5-a85c-928c5ce114d6"), "Природа", 1, 0, 0, 1 },
                    { new Guid("c82852fd-6ddb-4bb0-98a8-e0e67fe17ecf"), "Городская среда", 1, 1, 0, 1 },
                    { new Guid("ce0476b5-1a1b-4215-90c7-cbd0e1309450"), "Смерть", 0, 1, 0, 0 },
                    { new Guid("d0d6bd7b-474d-4c35-863a-b4fbb5290d77"), "Добро и зло", 1, 0, 1, 0 },
                    { new Guid("d1589788-f740-4920-9c1d-8216309f9927"), "Политика", 1, 1, 0, 0 },
                    { new Guid("daecf81a-4b2b-45b8-ae3c-9b817e14eb41"), "Свобода", 0, 1, 0, 1 },
                    { new Guid("dd971aa7-7153-4cf2-836a-3e9e473c536b"), "Аллегория", 1, 1, 1, 0 },
                    { new Guid("de8bef6b-8d5e-4495-a8d2-7eedcd3551fe"), "Сатира", 1, 1, 0, 1 },
                    { new Guid("e45cd96e-a0f1-46c5-bc6d-3d83c9cba91c"), "Антигерой", 0, 0, 0, 0 },
                    { new Guid("e53c081a-6f7c-42f5-a523-f2a90d41e6f8"), "Нелинейность", 1, 1, 1, 0 },
                    { new Guid("ea62ce55-fe25-4993-a18b-05153b11693b"), "Судьба", 0, 1, 0, 0 },
                    { new Guid("ebd6005f-42ef-43c6-8159-d1cc7b80d1a2"), "Бегство", 1, 0, 1, 0 },
                    { new Guid("eeff65f7-c613-4fae-ae96-122c05462bc8"), "Эмоции", 0, 1, 0, 0 },
                    { new Guid("ef404207-a797-4ba5-8943-a0be3211366b"), "Любовь", 0, 0, 0, 0 },
                    { new Guid("efc99aab-4a12-495d-8a9b-764277170b7c"), "Письма", 1, 0, 0, 1 },
                    { new Guid("f4114e01-837e-4228-9a6b-2cbeab19f5ea"), "Минимализм", 1, 0, 0, 1 },
                    { new Guid("f70f2d76-0cc9-4b79-9d31-c23086aa515a"), "Интерактивность", 1, 0, 1, 1 },
                    { new Guid("fb5e1492-48a1-4bd1-a9ff-a3629e2547e6"), "Рост героя", 0, 1, 0, 1 },
                    { new Guid("ffda949c-bcb4-4668-9bc8-b0f92af5310c"), "Изменения", 0, 1, 0, 1 },
                    { new Guid("ffe13f34-dc99-45ee-9292-ba36f36bbe57"), "Приключения", 1, 0, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_VolumeId_Order",
                table: "Chapters",
                columns: new[] { "VolumeId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParagraphId",
                table: "Comments",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SpoilerChapterId",
                table: "Comments",
                column: "SpoilerChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_LiteraryArchetypes_ScopeType_NarrativeType_ToneType_Purpose~",
                table: "LiteraryArchetypes",
                columns: new[] { "ScopeType", "NarrativeType", "ToneType", "PurposeType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiteraryTags_ScopeType_NarrativeType_ToneType_PurposeType",
                table: "LiteraryTags",
                columns: new[] { "ScopeType", "NarrativeType", "ToneType", "PurposeType" });

            migrationBuilder.CreateIndex(
                name: "IX_LiteraryTagWork_WorksId",
                table: "LiteraryTagWork",
                column: "WorksId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_ChapterId_Order",
                table: "Paragraphs",
                columns: new[] { "ChapterId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ParagraphId",
                table: "Reactions",
                column: "ParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_WorkId",
                table: "Reviews",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_WorkId_Order",
                table: "Volumes",
                columns: new[] { "WorkId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_Works_LiteraryArchetypeId",
                table: "Works",
                column: "LiteraryArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_OriginalWorkId",
                table: "Works",
                column: "OriginalWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_OwnerId",
                table: "Works",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "LiteraryTagWork");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "LiteraryTags");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Volumes");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "LiteraryArchetypes");
        }
    }
}
