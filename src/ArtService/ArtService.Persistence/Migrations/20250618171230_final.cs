using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
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
                    OwnerHandle = table.Column<string>(type: "text", nullable: false),
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
                    OwnerHandle = table.Column<string>(type: "text", nullable: false),
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
                    OwnerHandle = table.Column<string>(type: "text", nullable: false),
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
                    { new Guid("04f666f9-ae37-4db9-924c-b73c8dd63222"), "Память", 0, 1, 0, 0 },
                    { new Guid("0547db99-b0a7-4d2d-b1aa-cb47e0adbeb7"), "Исторический сеттинг", 1, 1, 0, 0 },
                    { new Guid("0642fd27-e61b-408e-bab5-1ff95376b4ac"), "Ностальгия", 0, 0, 0, 1 },
                    { new Guid("06b59235-35af-4c49-adc0-2b1cce6164f3"), "Детектив", 1, 0, 0, 1 },
                    { new Guid("09140d12-db73-4fd4-bc3b-82d62b835f00"), "Трагизм", 0, 1, 0, 0 },
                    { new Guid("11456252-5ff4-4429-91cb-b9af84059728"), "Самооценка", 0, 1, 0, 1 },
                    { new Guid("13b7606e-8d25-4a50-bb96-df5d551710cf"), "Желания", 0, 1, 0, 1 },
                    { new Guid("1501bee2-b7a5-4511-b485-a3e3291b4b52"), "Юмор", 1, 0, 0, 1 },
                    { new Guid("1979c4b3-467e-4786-830e-8351e6efa5f0"), "Дистопия", 1, 1, 1, 0 },
                    { new Guid("1a155b01-725f-48b1-9ff9-80ba0f8d8e75"), "Семья", 0, 1, 0, 1 },
                    { new Guid("1f18baad-0fee-4af5-900c-b69dabe7b578"), "Судьба", 0, 1, 0, 0 },
                    { new Guid("23af64c6-9c8a-406c-ba69-faaeace37e87"), "Страхи", 0, 1, 0, 0 },
                    { new Guid("285a1fc5-33b3-4ec4-b388-1ffe1db71968"), "Аллегория", 1, 1, 1, 0 },
                    { new Guid("2e6acf7e-8452-4a5d-a666-e90f7b956309"), "Футуризм", 1, 0, 1, 1 },
                    { new Guid("351ca117-32ca-419b-9ac7-cebf44348217"), "Любовь", 0, 0, 0, 0 },
                    { new Guid("39f88db9-8475-4d56-acf1-1b5521576e60"), "Философия", 0, 1, 0, 0 },
                    { new Guid("3ac170e2-d824-4d2f-9058-6332e7985bab"), "Минимализм", 1, 0, 0, 1 },
                    { new Guid("3cd0ee4e-1acb-4a46-8deb-e5c031271c78"), "Антигерой", 0, 0, 0, 0 },
                    { new Guid("4120dea0-9b89-4205-a3ee-ee49ea738413"), "Архаизм", 0, 1, 0, 0 },
                    { new Guid("45e995be-5db0-4b5a-8977-0c3a917f5677"), "Предательство", 1, 0, 0, 0 },
                    { new Guid("49550086-a247-4e4b-8ce0-3187da5851c5"), "Спасение мира", 1, 0, 1, 1 },
                    { new Guid("50d503b9-c066-4eca-90cc-6272a29677ba"), "Эскапизм", 1, 0, 1, 1 },
                    { new Guid("51bac7bb-8a8f-40c1-9bbf-08f3e5b9610f"), "Внутренний конфликт", 0, 1, 0, 0 },
                    { new Guid("5565288d-1a35-4a7b-a944-babb84a7dc89"), "Эмоции", 0, 1, 0, 0 },
                    { new Guid("595b89d0-91a9-42fc-a563-1a522963b7f7"), "Поколения", 1, 1, 0, 1 },
                    { new Guid("5b286ce2-9eca-4617-9957-9bb46e0b8ab5"), "Родственные связи", 0, 1, 0, 1 },
                    { new Guid("5d3d7039-ebf6-4cda-8a77-2f9286e79e15"), "Бегство", 1, 0, 1, 0 },
                    { new Guid("5ee088b1-485f-48b8-bfd1-6e8865a70834"), "Интрига", 1, 0, 1, 1 },
                    { new Guid("620afff6-ba51-493e-bf40-d970f75ce6af"), "Страх", 1, 0, 1, 0 },
                    { new Guid("6fa1759b-7042-40f3-a76a-16607a64ecbd"), "От первого лица", 0, 0, 0, 1 },
                    { new Guid("70ba8aee-7936-4753-99cd-dbbd3557c8e5"), "Трагедия", 0, 1, 0, 0 },
                    { new Guid("73c669e1-e493-41cd-8916-e84334b4598f"), "Политика", 1, 1, 0, 0 },
                    { new Guid("774777cf-d3b1-4f57-a82b-a5e3b4141fed"), "Обучение", 0, 1, 0, 0 },
                    { new Guid("78f353c8-1db6-4197-8019-6ceee2029094"), "Наставник", 0, 1, 0, 1 },
                    { new Guid("7d74091d-daa9-48b4-ad31-d9f76fdc39d1"), "Природа", 1, 0, 0, 1 },
                    { new Guid("880665ee-11b9-4049-9904-7e50988e7869"), "Альтернативная реальность", 1, 1, 1, 1 },
                    { new Guid("8864a236-c81c-404c-8ec1-f8b0334480c2"), "Критика", 1, 1, 0, 0 },
                    { new Guid("8c8b050d-19b9-4161-8f8f-4390b6a4a7e9"), "Изменения", 0, 1, 0, 1 },
                    { new Guid("8ea1a7ce-d42e-4b63-88e2-f85f511207b2"), "Городская среда", 1, 1, 0, 1 },
                    { new Guid("8ea2c763-59ae-47d9-9c2f-4f849ca53ab3"), "Рост героя", 0, 1, 0, 1 },
                    { new Guid("93e0d194-aeea-4b42-a4c9-7ec4467e8f97"), "Инопланетная цивилизация", 1, 0, 1, 1 },
                    { new Guid("9e48ad14-80ea-4171-a008-1058b33d5eba"), "Обращение", 0, 0, 0, 1 },
                    { new Guid("9f48ab41-9fc7-45d5-8954-c83680af739d"), "Ненадёжный рассказчик", 0, 1, 1, 0 },
                    { new Guid("a459b7fd-5ab5-4a28-865a-dd7b0c6e6e97"), "Одиночество", 0, 1, 0, 0 },
                    { new Guid("a7e386a7-6166-49ac-b1fa-8e741c658197"), "Смерть", 0, 1, 0, 0 },
                    { new Guid("b1beefb8-05d7-4a0f-955e-82d4e450c47d"), "Метастиль", 1, 1, 1, 1 },
                    { new Guid("b34b5675-46b8-499a-a871-416a91770c81"), "Сатира", 1, 1, 0, 1 },
                    { new Guid("b3c76e42-f4a6-4cec-92f3-9d99f282eb8e"), "Утопия", 1, 1, 1, 1 },
                    { new Guid("b538fae6-1352-44e3-9498-11b6cfb20937"), "Добро и зло", 1, 0, 1, 0 },
                    { new Guid("b62e615c-6f13-4a18-9e7f-1e5bfb9f8a98"), "Романтика", 0, 0, 0, 1 },
                    { new Guid("bb62e645-a594-4453-8b89-5fb80ab544af"), "Нелинейность", 1, 1, 1, 0 },
                    { new Guid("beba16e9-5f93-4262-9058-7edb921c28a0"), "Человеческая природа", 0, 1, 0, 0 },
                    { new Guid("c99a13e6-9e83-4f75-b745-9aa52dd9c39f"), "Символизм", 0, 1, 0, 0 },
                    { new Guid("ca81e2ef-1ac1-47e8-9d03-fa96ead05e8f"), "Отчуждение", 0, 1, 0, 0 },
                    { new Guid("ca8bf2a4-273c-4b3e-8eb3-582b63458591"), "Вызов нормам", 1, 1, 0, 0 },
                    { new Guid("d1df6498-7f5c-4d22-bd4e-5158915357cb"), "Свобода", 0, 1, 0, 1 },
                    { new Guid("d634d36d-1e0b-41f9-aaaf-937f9bbcf4c7"), "Тревожность", 0, 1, 0, 0 },
                    { new Guid("d74bf627-2a8c-48cc-a0b8-4e4922b1f88b"), "Поиск смысла", 0, 1, 0, 0 },
                    { new Guid("e0b1c46e-7b9d-4041-92ed-e61de8d96ac6"), "Моральный выбор", 0, 1, 0, 0 },
                    { new Guid("ecc49ae5-8f19-41e6-89cb-4afb89f5f4c1"), "Приключения", 1, 0, 1, 1 },
                    { new Guid("ef39729d-9c31-4837-9a5c-bde676674c62"), "Открытый финал", 1, 1, 1, 0 },
                    { new Guid("ef682a22-d914-409d-bc03-6bdbd99e54a2"), "Общество", 1, 1, 0, 0 },
                    { new Guid("f2b3a1fb-368d-4a56-909e-a79efea0fc82"), "Письма", 1, 0, 0, 1 },
                    { new Guid("f37fb922-9024-47c2-97bc-203c100c1700"), "Постапокалипсис", 1, 0, 1, 0 },
                    { new Guid("f40c61c2-266f-4da1-9b43-b1f200aa5a41"), "Надежда", 0, 0, 0, 1 },
                    { new Guid("f4850343-5876-465a-9f89-cfb31e8441dc"), "Система магии", 1, 0, 1, 1 },
                    { new Guid("f7edec87-5105-46a7-acd1-a6965b2d4205"), "Осознание", 0, 1, 0, 1 },
                    { new Guid("fb3f8bf5-3d46-48a1-b8f4-9413987c3e2f"), "Психология", 0, 1, 0, 0 },
                    { new Guid("fc779dc6-db6c-48cb-af75-5d7341a84e69"), "Интерактивность", 1, 0, 1, 1 },
                    { new Guid("fe91a7a9-ec7d-48e6-8aa4-36ed621b03f4"), "Рефлексия", 0, 1, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_VolumeId_Order",
                table: "Chapters",
                columns: new[] { "VolumeId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OwnerHandle",
                table: "Comments",
                column: "OwnerHandle");

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
                name: "IX_Reviews_OwnerHandle",
                table: "Reviews",
                column: "OwnerHandle");

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
                name: "IX_Works_OwnerHandle",
                table: "Works",
                column: "OwnerHandle");

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
