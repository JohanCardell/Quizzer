using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizzer.Data.Migrations
{
    public partial class IntitialCreate : Migration
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
                    QuizPlayerId = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreEntries_AspNetUsers_QuizPlayerId",
                        column: x => x.QuizPlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
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
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
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
                    { 1, "What is not a wind instrument?" },
                    { 28, "Toby Fox's \"Megalovania\" was first used where?" },
                    { 29, "Laserjet and inkjet printers are both examples of what type of printer?" },
                    { 30, "In what year did Clint Eastwood star as Inspector Harry Callahan in the film \"Dirty Harry\"?" },
                    { 31, "Dutch computer scientist Mark Overmars is known for creating which game development engine?" },
                    { 32, "Which was the first \"Call Of Duty: Zombies\" map to introduce the \"Wunderwaffe DG-2\"?" },
                    { 33, "In \"Gravity Falls\", how much does Waddles weigh when Mable wins him in \"The Time Traveler's Pig\"?" },
                    { 34, "Which of the following songs did Elton John perform following Princess Diane's passing?" },
                    { 35, "How many controllers could a Nintendo GameCube have plugged in at one time?" },
                    { 36, "What is the name of the ship which was only a few miles away from the RMS Titanic when it struck an iceberg on April 14, 1912?" },
                    { 37, "In \"Magic: The Gathering\", what instant card has the highest converted mana cost?" },
                    { 38, "Which of the following won the first season of American Idol in 2002?" },
                    { 39, "What is Lilo's last name from Lilo and Stitch?" },
                    { 40, "Approximately how long is a year on Uranus?" },
                    { 41, "Which NBA player won Most Valuable Player for the 1999-2000 season?" },
                    { 42, "In which English county is the city of Portsmouth?" },
                    { 43, "Which novel by John Grisham was conceived on a road trip to Florida while thinking about stolen books with his wife?" },
                    { 44, "Which former US president used \"Let's Make America Great Again\" as his campaign slogan before Donald Trump's campaign?" },
                    { 45, "In Game of Thrones what is the name of Jon Snow's sword?" },
                    { 46, "How many states are in Australia?" },
                    { 47, "What ability does Princess Sofia the First have from her amulet that allows her to breathe underwater?" },
                    { 48, "Which of these is NOT a real tectonic plate?" },
                    { 27, "In the game \"Hearthstone\", what is the best rank possible?" },
                    { 26, "The two main characters of \"No Game No Life\", Sora and Shiro, together go by what name?" },
                    { 25, "Which town was Seamus \"Sledge\" Cowden from \"Tom Clancy's Rainbow Six Siege\" born in?" },
                    { 24, "Who wrote the song \"You Know You Like It\"?" },
                    { 2, "What town was \"Springfield\" from \"The Simpsons\" originally named after?" },
                    { 3, "What does AD stand for in relation to Windows Operating Systems? " },
                    { 4, "What are the first 6 digits of the number \"Pi\"?" },
                    { 5, "What is Hermione Granger's middle name?" },
                    { 6, "On what day did Germany invade Poland?" },
                    { 7, "In the Gamecube Version of \"Resident Evil\" what text document is open on the monitor of the computer in the Visual Data Room?" },
                    { 8, "Which artist released the 2012 single \"Harlem Shake\", which was used in numerous YouTube videos in 2013?" },
                    { 9, "What did the first vending machines in the early 1880's dispense?" },
                    { 10, "What is the scientific name of the red fox?" },
                    { 11, "In which Mario game did the Mega Mushroom make its debut?" },
                    { 49, "In 2014, this new top 100 rapper who featured in \"Computers\" and \"Body Dance\" was arrested in a NYPD sting for murder." },
                    { 12, "Which company designed the \"Betamax\" video cassette format?" },
                    { 14, "Where is the world's oldest still operational space launch facility located?" },
                    { 15, "What is the oldest US state?" },
                    { 16, "Which element has the highest melting point?" },
                    { 17, "Which one of these rappers is NOT a member of the rap group Wu-Tang Clan?" },
                    { 18, "In the television show Breaking Bad, what is the street name of Walter and Jesse's notorious product?" },
                    { 19, "What is Brian May's guitar called?" },
                    { 20, "Who is the Egyptian god of reproduction and lettuce?" },
                    { 21, "What is the 100th digit of Pi?" },
                    { 22, "What is the name of New Zealand's indigenous people?" },
                    { 23, "Which show is known for the songs \"You are a Pirate\", \"Cooking by the Book\" and \"We Are Number One\"?" },
                    { 13, "Which supercar company is from Sweden?" },
                    { 50, "What does the computer software acronym JVM stand for?" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 11, true, 1, "Viola" },
                    { 324, false, 32, "Der Riese" },
                    { 331, true, 33, "15 pounds" },
                    { 332, false, 33, "20 pounds" },
                    { 333, false, 33, "10 pounds" },
                    { 334, false, 33, "30 pounds" },
                    { 341, true, 34, "Candles in the Wind" },
                    { 342, false, 34, "I Guess That's Why They Call It The Blues" },
                    { 343, false, 34, "Your Song" },
                    { 344, false, 34, "Island Girl" },
                    { 351, true, 35, "4" },
                    { 352, false, 35, "8" },
                    { 353, false, 35, "6" },
                    { 354, false, 35, "2" },
                    { 361, true, 36, "Californian" },
                    { 362, false, 36, "Carpathia" },
                    { 363, false, 36, "Cristol" },
                    { 364, false, 36, "Commerce" },
                    { 371, true, 37, "Blinkmoth Infusion" },
                    { 372, false, 37, "Vitalizing Wind" },
                    { 373, false, 37, " Chant of Vitu-Ghazi" },
                    { 374, false, 37, "Assert Authority" },
                    { 323, false, 32, "Kino Der Toten" },
                    { 381, true, 38, "Kelly Clarkson" },
                    { 322, false, 32, "Tranzit" },
                    { 314, false, 31, "Torque 2D" },
                    { 263, false, 26, "Disboard" },
                    { 264, false, 26, "Warbeasts" },
                    { 271, true, 27, "Rank 1 Legend" },
                    { 272, false, 27, "Rank 1 Elite" },
                    { 273, false, 27, "Rank 1 Master" },
                    { 274, false, 27, "Rank 1 Supreme" },
                    { 281, true, 28, "Radiation's Earthbound Halloween Hack" },
                    { 282, false, 28, "Homestuck: [S] Wake" },
                    { 283, false, 28, "Undertale" },
                    { 284, false, 28, "Mother: Cognitive Dissonance" },
                    { 291, true, 29, "Non-impact printer" },
                    { 292, false, 29, "Impact printer" },
                    { 293, false, 29, "Daisywheel printer" },
                    { 294, false, 29, "Dot matrix printer" },
                    { 301, true, 30, "1971" },
                    { 302, false, 30, "1975" },
                    { 303, false, 30, "1983" },
                    { 304, false, 30, "1969" },
                    { 311, true, 31, "Game Maker" },
                    { 312, false, 31, "Stencyl" },
                    { 313, false, 31, "Construct" },
                    { 321, true, 32, "Shi No Numa" },
                    { 262, false, 26, "Immanity" },
                    { 382, false, 38, "Justin Guarini" },
                    { 384, false, 38, "Chris Daughtry" },
                    { 452, false, 45, "Oathkeeper" },
                    { 453, false, 45, "Widow's Wail" },
                    { 454, false, 45, "Needle" },
                    { 461, true, 46, "6" },
                    { 462, false, 46, "7" },
                    { 463, false, 46, "8" },
                    { 464, false, 46, "5" },
                    { 471, true, 47, "Mermaid Transformation" },
                    { 472, false, 47, "Artificial Gills" },
                    { 473, false, 47, "Bubble Head" },
                    { 474, false, 47, "Bubble Shield" },
                    { 481, true, 48, "Atlantic Plate" },
                    { 482, false, 48, "North American Plate" },
                    { 483, false, 48, "Eurasian Plate" },
                    { 484, false, 48, "Nazca Plate" },
                    { 491, true, 49, "Bobby Shmurda" },
                    { 492, false, 49, "DJ Snake" },
                    { 493, false, 49, "Swae Lee" },
                    { 494, false, 49, "Young Thug" },
                    { 501, true, 50, "Java Virtual Machine" },
                    { 502, false, 50, "Java Vendor Machine" },
                    { 451, true, 45, "Longclaw" },
                    { 383, false, 38, "Ruben Studdard" },
                    { 444, false, 44, "Richard Nixon" },
                    { 442, false, 44, "Jimmy Carter" },
                    { 391, true, 39, "Pelekai" },
                    { 392, false, 39, "Anoaʻi" },
                    { 393, false, 39, "Kealoha" },
                    { 394, false, 39, "Kuʻulei" },
                    { 401, true, 40, "84 Earth years" },
                    { 402, false, 40, "47 Earth years" },
                    { 403, false, 40, "62 Earth years" },
                    { 404, false, 40, "109 Earth years" },
                    { 411, true, 41, "Shaquille O'Neal" },
                    { 412, false, 41, "Allen Iverson" },
                    { 413, false, 41, "Kobe Bryant" },
                    { 414, false, 41, "Paul Pierce" },
                    { 421, true, 42, "Hampshire" },
                    { 422, false, 42, "Oxfordshire" },
                    { 423, false, 42, "Buckinghamshire" },
                    { 424, false, 42, "Surrey" },
                    { 431, true, 43, "Camino Island" },
                    { 432, false, 43, "Rogue Lawyer" },
                    { 433, false, 43, "Gray Mountain" },
                    { 434, false, 43, "The Litigators" },
                    { 441, true, 44, "Ronald Reagan" },
                    { 443, false, 44, "Gerald Ford" },
                    { 261, true, 26, "Blank" },
                    { 254, false, 25, "Talmine" },
                    { 253, false, 25, "Kearvaig" },
                    { 73, false, 7, "Nothing" },
                    { 74, false, 7, "Document on B.O.Ws" },
                    { 81, true, 8, "Baauer" },
                    { 82, false, 8, "RL Grime" },
                    { 83, false, 8, "NGHTMRE" },
                    { 84, false, 8, "Flosstradamus" },
                    { 91, true, 9, "Post cards" },
                    { 92, false, 9, "Alcohol" },
                    { 93, false, 9, "Cigarettes" },
                    { 94, false, 9, "Sodas " },
                    { 101, true, 10, "Vulpes Vulpes" },
                    { 102, false, 10, "Vulpes Redus" },
                    { 103, false, 10, "Red Fox" },
                    { 104, false, 10, "Vulpes Vulpie" },
                    { 111, true, 11, "Mario Party 4" },
                    { 112, false, 11, "New Super Mario Bros." },
                    { 113, false, 11, "Mario Kart Wii" },
                    { 114, false, 11, "Super Mario 3D World" },
                    { 121, true, 12, "Sony" },
                    { 122, false, 12, "Panasonic" },
                    { 123, false, 12, "LG" },
                    { 72, false, 7, "Text Document on Herbs" },
                    { 124, false, 12, "Fujitsu" },
                    { 71, true, 7, "A GDC Document" },
                    { 63, false, 6, "June 22, 1941" },
                    { 12, false, 1, "Oboe" },
                    { 13, false, 1, "Trombone" },
                    { 14, false, 1, "Duduk" },
                    { 21, true, 2, "Springfield, Oregon" },
                    { 22, false, 2, "Springfield, Missouri" },
                    { 23, false, 2, "Springfield, Illinois" },
                    { 24, false, 2, "Springfield, Massachusetts" },
                    { 31, true, 3, "Active Directory" },
                    { 32, false, 3, "Alternative Drive" },
                    { 33, false, 3, "Automated Database" },
                    { 34, false, 3, "Active Department" },
                    { 41, true, 4, "3.14159" },
                    { 42, false, 4, "3.14169" },
                    { 43, false, 4, "3.12423" },
                    { 44, false, 4, "3.25812" },
                    { 51, true, 5, "Jean" },
                    { 52, false, 5, "Jane" },
                    { 53, false, 5, "Emma" },
                    { 54, false, 5, "Jo" },
                    { 61, true, 6, "September 1, 1939" },
                    { 62, false, 6, "December 7, 1941" },
                    { 64, false, 6, "July 7, 1937" },
                    { 131, true, 13, "Koenigsegg" },
                    { 132, false, 13, "Bugatti" },
                    { 133, false, 13, "Lamborghini" },
                    { 202, false, 20, "Menu" },
                    { 203, false, 20, "Mut" },
                    { 204, false, 20, "Meret" },
                    { 211, true, 21, "9" },
                    { 212, false, 21, "4" },
                    { 213, false, 21, "7" },
                    { 214, false, 21, "2" },
                    { 221, true, 22, "Maori" },
                    { 222, false, 22, "Vikings" },
                    { 223, false, 22, "Polynesians" },
                    { 224, false, 22, "Samoans" },
                    { 231, true, 23, "LazyTown" },
                    { 232, false, 23, "Sofia the First" },
                    { 233, false, 23, "DuckTales" },
                    { 234, false, 23, "Tom and Jerry" },
                    { 241, true, 24, "AlunaGeorge" },
                    { 242, false, 24, "DJ Snake" },
                    { 243, false, 24, "Steve Aoki" },
                    { 244, false, 24, "Major Lazer" },
                    { 251, true, 25, "John O'Groats" },
                    { 252, false, 25, "Brawl" },
                    { 201, true, 20, "Min" },
                    { 194, false, 19, "Yellow Special" },
                    { 193, false, 19, "Green Special" },
                    { 192, false, 19, "Blue Special" },
                    { 134, false, 13, "McLaren" },
                    { 141, true, 14, "Kazakhstan" },
                    { 142, false, 14, "Russia" },
                    { 143, false, 14, "Iran" },
                    { 144, false, 14, "United States" },
                    { 151, true, 15, "Delaware" },
                    { 152, false, 15, "Rhode Island" },
                    { 153, false, 15, "Maine" },
                    { 154, false, 15, "Virginia" },
                    { 161, true, 16, "Carbon" },
                    { 503, false, 50, "Java Visual Machine" },
                    { 162, false, 16, "Tungsten" },
                    { 164, false, 16, "Osmium" },
                    { 171, true, 17, "Dr.Dre" },
                    { 172, false, 17, "Ol' Dirty Bastard" },
                    { 173, false, 17, "GZA" },
                    { 174, false, 17, "Method Man" },
                    { 181, true, 18, "Blue Sky" },
                    { 182, false, 18, "Baby Blue" },
                    { 183, false, 18, "Rock Candy" },
                    { 184, false, 18, "Pure Glass" },
                    { 191, true, 19, "Red Special" },
                    { 163, false, 16, "Platinum" },
                    { 504, false, 50, "Just Virtual Machine" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreEntries_QuizPlayerId",
                table: "ScoreEntries",
                column: "QuizPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "ScoreEntries");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
