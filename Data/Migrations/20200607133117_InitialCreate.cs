using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizzer.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    QuizPlayerId = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreEntries", x => new { x.ApplicationUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_ScoreEntries_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCorrect = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "What breed of dog was Marley in the film \"Marley &amp; Me\" (2008)?" },
                    { 28, "Which of these is not the name of a city in the Grand Theft Auto series?" },
                    { 29, "In \"The Big Bang Theory\", what is Howard Wolowitz's nickname in World of Warcraft?" },
                    { 30, "Who designed the album cover for True Romance, an album by Estelle?" },
                    { 31, "What collaborative album was released by Kanye West and Jay-Z in 2011?" },
                    { 32, "What is Canada's largest island?" },
                    { 33, "What is the second-largest city in Lithuania?" },
                    { 34, "In the 2012 film, \"The Lorax\", who is the antagonist?" },
                    { 35, "What is the name of the gang that Ponyboy is a part of in the book, The Outsiders?" },
                    { 36, "The LS2 engine is how many cubic inches?" },
                    { 37, "In \"Star Trek\", what is the Ferengi's First Rule of Acquisition?" },
                    { 38, "Which of the following countries was the first to send an object into space?" },
                    { 39, "How many aces can be shot down through the entirety of \"Ace Combat Zero: The Belkan War\"?" },
                    { 40, "What year did \"Bishoujo Senshi Sailor Moon\" air in Japan?" },
                    { 41, "Computer manufacturer Compaq was acquired for $25 billion dollars in 2002 by which company?" },
                    { 42, "In \"My Little Pony: Friendship is Magic\", which of these ponies represents the quality of honesty?" },
                    { 43, "In \"Team Fortress 2\", what is the fastest taunt kill that can be pulled off?" },
                    { 44, "Who plays \"Bruce Wayne\" in the 2008 movie \"The Dark Knight\"?" },
                    { 45, "What was the release date of \"Grand Theft Auto IV\"?" },
                    { 46, "Which sign of the zodiac comes between Virgo and Scorpio?" },
                    { 47, "Which studio animated Soul Eater?" },
                    { 48, "What film did James Cameron's Avatar dethrone as the highest-grossing film ever?" },
                    { 27, "The 2002 film \"28 Days Later\" is mainly set in which European country?" },
                    { 26, "This Marvel superhero is often called \"The man without fear\"." },
                    { 25, "In the movie \"Scream\" who is Ghost Face?" },
                    { 24, "Which one of these is not a typical European sword design?" },
                    { 2, "What is Scooby-Doo's real name?" },
                    { 3, "In the Beatrix Potter books, what type of animal is Tommy Brock?" },
                    { 4, "Which of the following created and directed the Katamari Damacy series?" },
                    { 5, "What is the most common surname Wales?" },
                    { 6, "Which internet company began life as an online bookstore called 'Cadabra'?" },
                    { 7, "Which English football club has the nickname 'The Foxes'?" },
                    { 8, "Which type of rock is created by intense heat AND pressure?" },
                    { 9, "What does GHz stand for?" },
                    { 10, "When was the programming language \"C#\" released?" },
                    { 11, "On which continent is the country of Angola located?" },
                    { 49, "Which 1994 film did Roger Ebert famously despise, saying \"I hated hated hated hated hated this movie\"." },
                    { 12, "Which of these artists do NOT originate from France?" },
                    { 14, "Which of the following films was Don Bluth both the writer, director, and producer for?" },
                    { 15, "Which of the following Arab countries does NOT have a flag containing only Pan-Arab colours?" },
                    { 16, "In most FPS video games such as Counter-Strike, shooting which part of the body does the highest damage?" },
                    { 17, "What is the name of Broadway's first \"long-run\" musical?" },
                    { 18, "If you play the Super Mario RPG and nap in a rented hotel room, you will wake up next to what familiar looking character?" },
                    { 19, "Which movie of film director Stanley Kubrick is known to be an adaptation of a Stephen King novel?" },
                    { 20, "Which band released songs suchs as \"Rio\", \"Girls on Film\", and \"The Reflex\"?" },
                    { 21, "Dee from \"It's Always Sunny in Philadelphia\" has dated all of the following guys EXCEPT" },
                    { 22, "In an orchestra, what is the lowest member of the brass family?" },
                    { 23, "What was the first movie to ever use a Wilhelm Scream?" },
                    { 13, "Which of these is NOT a playable character in the 2016 video game Overwatch?" },
                    { 50, "Located in Chile, El Teniente is the world's largest underground mine for what metal?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 11, true, 1, "Labrador Retriever" },
                    { 324, false, 32, "Newfoundland" },
                    { 331, true, 33, "Kaunas" },
                    { 332, false, 33, "Panevėžys" },
                    { 333, false, 33, "Vilnius" },
                    { 334, false, 33, "Klaipėda" },
                    { 341, true, 34, "Aloysius O'Hare" },
                    { 342, false, 34, "Ted Wiggins" },
                    { 343, false, 34, "The Once-Ler" },
                    { 344, false, 34, "Grammy Norma" },
                    { 351, true, 35, "The Greasers" },
                    { 352, false, 35, "The Outsiders" },
                    { 353, false, 35, "The Mafia" },
                    { 354, false, 35, "The Socs" },
                    { 361, true, 36, "364" },
                    { 362, false, 36, "346" },
                    { 363, false, 36, "376" },
                    { 364, false, 36, "402" },
                    { 371, true, 37, "Once you have their money, you never give it back. " },
                    { 372, false, 37, "Never place friendship above profit" },
                    { 373, false, 37, "Greed is Eternal" },
                    { 374, false, 37, "Never allow family to stand in the way of opportunity" },
                    { 323, false, 32, "Vancouver Island" },
                    { 381, true, 38, "Germany" },
                    { 322, false, 32, "Prince Edward Island" },
                    { 314, false, 31, "Unfinished Business" },
                    { 263, false, 26, "Wolverine" },
                    { 264, false, 26, "Hulk" },
                    { 271, true, 27, "United Kingdom" },
                    { 272, false, 27, "France" },
                    { 273, false, 27, "Italy" },
                    { 274, false, 27, "Germany" },
                    { 281, true, 28, "San Andreas" },
                    { 282, false, 28, "San Fierro" },
                    { 283, false, 28, "Las Venturas" },
                    { 284, false, 28, "Vice City" },
                    { 291, true, 29, "Wolowizard" },
                    { 292, false, 29, "Sheldor" },
                    { 293, false, 29, "Rajesh" },
                    { 294, false, 29, "Priya" },
                    { 301, true, 30, "Rebecca Sugar" },
                    { 302, false, 30, "Matt Burnett" },
                    { 303, false, 30, "Ian Jones Quartey" },
                    { 304, false, 30, "Ben Leven" },
                    { 311, true, 31, "Watch the Throne" },
                    { 312, false, 31, "Distant Relatives" },
                    { 313, false, 31, "What a Time to be Alive" },
                    { 321, true, 32, "Baffin Island" },
                    { 262, false, 26, "Thor" },
                    { 382, false, 38, "USA" },
                    { 384, false, 38, "China" },
                    { 452, false, 45, "May 21, 2009" },
                    { 453, false, 45, "June 22, 2010" },
                    { 454, false, 45, "July 28, 2008" },
                    { 461, true, 46, "Libra" },
                    { 462, false, 46, "Gemini" },
                    { 463, false, 46, "Taurus" },
                    { 464, false, 46, "Capricorn" },
                    { 471, true, 47, "Bones" },
                    { 472, false, 47, "Kyoto Animation" },
                    { 473, false, 47, "xebec" },
                    { 474, false, 47, "Production I.G" },
                    { 481, true, 48, "Titanic" },
                    { 482, false, 48, "Star Wars" },
                    { 483, false, 48, "Gone with the Wind" },
                    { 484, false, 48, "Jaws" },
                    { 491, true, 49, "North" },
                    { 492, false, 49, "3 Ninjas Kick Back" },
                    { 493, false, 49, "The Santa Clause" },
                    { 494, false, 49, "Richie Rich" },
                    { 501, true, 50, "Copper" },
                    { 502, false, 50, "Iron" },
                    { 451, true, 45, "April 29, 2008" },
                    { 383, false, 38, "Russia" },
                    { 444, false, 44, "Heath Ledger" },
                    { 442, false, 44, "Michael Caine" },
                    { 391, true, 39, "169" },
                    { 392, false, 39, "100" },
                    { 393, false, 39, "132" },
                    { 394, false, 39, "245" },
                    { 401, true, 40, "1992" },
                    { 402, false, 40, "1989" },
                    { 403, false, 40, "1990" },
                    { 404, false, 40, "1994" },
                    { 411, true, 41, "Hewlett-Packard" },
                    { 412, false, 41, "Toshiba" },
                    { 413, false, 41, "Asus" },
                    { 414, false, 41, "Dell" },
                    { 421, true, 42, "Applejack" },
                    { 422, false, 42, "Twilight Sparkle" },
                    { 423, false, 42, "Pinkie Pie" },
                    { 424, false, 42, "Rarity" },
                    { 431, true, 43, "Showdown" },
                    { 432, false, 43, "Hadouken" },
                    { 433, false, 43, "Organ Grinder" },
                    { 434, false, 43, "Skewer" },
                    { 441, true, 44, "Christian Bale" },
                    { 443, false, 44, "Ron Dean" },
                    { 261, true, 26, "Daredevil" },
                    { 254, false, 25, "Archie Prescott and Philip Marv" },
                    { 253, false, 25, "Sidney Prescott" },
                    { 73, false, 7, "Bradford City" },
                    { 74, false, 7, "West Bromwich Albion" },
                    { 81, true, 8, "Metamorphic" },
                    { 82, false, 8, "Sedimentary" },
                    { 83, false, 8, "Igneous" },
                    { 84, false, 8, "Diamond" },
                    { 91, true, 9, "Gigahertz" },
                    { 92, false, 9, "Gigahotz" },
                    { 93, false, 9, "Gigahetz" },
                    { 94, false, 9, "Gigahatz" },
                    { 101, true, 10, "2000" },
                    { 102, false, 10, "1998" },
                    { 103, false, 10, "1999" },
                    { 104, false, 10, "2001" },
                    { 111, true, 11, "Africa" },
                    { 112, false, 11, "South America" },
                    { 113, false, 11, "Europe" },
                    { 114, false, 11, "Asia" },
                    { 121, true, 12, "The Chemical Brothers" },
                    { 122, false, 12, "Air" },
                    { 123, false, 12, "Justice" },
                    { 72, false, 7, "Northampton Town" },
                    { 124, false, 12, "Daft Punk" },
                    { 71, true, 7, "Leicester City" },
                    { 63, false, 6, "Overstock" },
                    { 12, false, 1, "Golden Retriever" },
                    { 13, false, 1, "Dalmatian" },
                    { 14, false, 1, "Shiba Inu" },
                    { 21, true, 2, "Scoobert" },
                    { 22, false, 2, "Scooter" },
                    { 23, false, 2, "Scrappy" },
                    { 24, false, 2, "Shooby" },
                    { 31, true, 3, "Badger" },
                    { 32, false, 3, "Fox" },
                    { 33, false, 3, "Frog" },
                    { 34, false, 3, "Rabbit" },
                    { 41, true, 4, "Keita Takahashi" },
                    { 42, false, 4, "Hideki Kamiya" },
                    { 43, false, 4, "Shu Takumi" },
                    { 44, false, 4, "Shinji Mikami" },
                    { 51, true, 5, "Jones" },
                    { 52, false, 5, "Williams" },
                    { 53, false, 5, "Davies" },
                    { 54, false, 5, "Evans" },
                    { 61, true, 6, "Amazon" },
                    { 62, false, 6, "eBay" },
                    { 64, false, 6, "Shopify" },
                    { 131, true, 13, "Invoker" },
                    { 132, false, 13, "Mercy" },
                    { 133, false, 13, "Winston" },
                    { 202, false, 20, "The Cure" },
                    { 203, false, 20, "New Order" },
                    { 204, false, 20, "Depeche Mode" },
                    { 211, true, 21, "Matthew \"Rickety Cricket\" Mara" },
                    { 212, false, 21, "Colin the Thief" },
                    { 213, false, 21, "Ben the Soldier" },
                    { 214, false, 21, "Kevin Gallagher aka Lil' Kevin" },
                    { 221, true, 22, "Tuba" },
                    { 222, false, 22, "Trombone" },
                    { 223, false, 22, "Contrabass" },
                    { 224, false, 22, "Bassoon" },
                    { 231, true, 23, "Distant Drums" },
                    { 232, false, 23, "Treasure of the Sierra Madre" },
                    { 233, false, 23, "The Charge at Feather River" },
                    { 234, false, 23, "Indiana Jones" },
                    { 241, true, 24, "Scimitar" },
                    { 242, false, 24, "Falchion" },
                    { 243, false, 24, "Ulfberht" },
                    { 244, false, 24, "Flamberge" },
                    { 251, true, 25, "Billy Loomis and Stu Macher" },
                    { 252, false, 25, "Dewey Riley" },
                    { 201, true, 20, "Duran Duran" },
                    { 194, false, 19, "Eyes Wide Shut" },
                    { 193, false, 19, " Dr. Strangelove " },
                    { 192, false, 19, "2001: A Space Odyssey" },
                    { 134, false, 13, "Zenyatta" },
                    { 141, true, 14, "All Dogs Go To Heaven" },
                    { 142, false, 14, "Titan A.E." },
                    { 143, false, 14, "Anastasia" },
                    { 144, false, 14, "The Land Before Time" },
                    { 151, true, 15, "Qatar" },
                    { 152, false, 15, "Kuwait" },
                    { 153, false, 15, "United Arab Emirates" },
                    { 154, false, 15, "Jordan" },
                    { 161, true, 16, "Head" },
                    { 503, false, 50, "Nickel" },
                    { 162, false, 16, "Arm" },
                    { 164, false, 16, "Chest" },
                    { 171, true, 17, "The Elves" },
                    { 172, false, 17, "Wicked" },
                    { 173, false, 17, "Hamilton" },
                    { 174, false, 17, "The Book of Mormon" },
                    { 181, true, 18, "Link" },
                    { 182, false, 18, "Wario" },
                    { 183, false, 18, "Q*bert" },
                    { 184, false, 18, "Solid Snake" },
                    { 191, true, 19, "The Shining" },
                    { 163, false, 16, "Leg" },
                    { 504, false, 50, "Silver" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "ScoreEntries");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
