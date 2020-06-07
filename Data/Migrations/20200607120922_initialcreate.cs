using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizzer.Data.Migrations
{
    public partial class initialcreate : Migration
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
                    QuizPlayerId = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreEntries", x => new { x.QuizPlayerId, x.Id });
                    table.ForeignKey(
                        name: "FK_ScoreEntries_AspNetUsers_QuizPlayerId",
                        column: x => x.QuizPlayerId,
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
                    { 1, "When was the first Call of Duty title released?" },
                    { 109, "In the \"Harry Potter\" novels, what must a Hogwarts student do to enter the Ravenclaw Common Room?" },
                    { 113, "How many sides does a heptagon have?" },
                    { 117, "Which car manufacturer created the \"Aventador\"?" },
                    { 121, "Who won the 2015 College Football Playoff (CFP) National Championship? " },
                    { 125, "What is the largest country in the world?" },
                    { 129, "Which of these characters wasn't a villian in Club Penguin?" },
                    { 133, "Which slogan did the fast food company, McDonald's, use before their \"I'm Lovin' It\" slogan?" },
                    { 137, "Which actors made up the trio in \"The Good, the Bad, and the Ugly\"? " },
                    { 141, "What was the callsign of Commander William Adama in Battlestar Galactica (2004)?" },
                    { 145, "Which character in the \"Animal Crossing\" series uses the phrase \"zip zoom\" when talking to the player?" },
                    { 149, "On which aircraft carrier did the Doolitte Raid launch from on April 18, 1942 during World War II?" },
                    { 153, "Which company's original slogan was \"Don't be evil\"?" },
                    { 157, "What round is a classic AK-47 chambered in?" },
                    { 161, "\"Doctor Jones\", \"Turn Back Time\" and \"Barbie Girl\" were UK number ones for which Eurodance group?" },
                    { 165, "Which Shakespeare play features the stage direction \"Enter a messenger, with two heads and a hand\"?" },
                    { 169, "What is the sum of all the tiles in a standard box of Scrabble?" },
                    { 173, "Which U.S. President was in office when the Gulf War began?" },
                    { 177, "In what sport does Fanny Chmelar compete for Germany?" },
                    { 181, "What was Bon Iver's debut album released in 2007?" },
                    { 185, "The teapot often seen in many 3D modeling applications is called what?" },
                    { 189, "What is the name of the adventurer you meet at the mines in Stardew Valley?" },
                    { 105, "\"Doctor Who\" star David Tennant performed in a rendition of which Shakespearean play?" },
                    { 101, "How many trophies are there in \"Super Smash Bros. for Nintendo 3DS\"?" },
                    { 97, "What do the letters of the fast food chain KFC stand for?" },
                    { 93, "Who is the lead singer of Bastille?" },
                    { 5, "Electronic music producer Kygo's popularity skyrocketed after a certain remix. Which song did he remix?" },
                    { 9, "What French artist/band is known for playing on the midi instrument \"Launchpad\"?" },
                    { 13, "In the \"Harry Potter\" series, what is Headmaster Dumbledore's full name?" },
                    { 17, "Which nation hosted the FIFA World Cup in 2006?" },
                    { 21, "The World Health Organization headquarters is located in which European country?" },
                    { 25, "What year did the Battle of Agincourt take place?" },
                    { 29, "Who is the founder of Team Fortress 2's fictional company \"Mann Co\"?" },
                    { 33, "Which movie of film director Stanley Kubrick is known to be an adaptation of a Stephen King novel?" },
                    { 37, "Capcom's survival horror title Dead Rising, canonically starts on what day of September 2006?" },
                    { 41, "Which of these songs is NOT included in the Suicide Squad OST?" },
                    { 193, "When was \"Luigi's Mansion 3\" released?" },
                    { 45, "Which of these African countries list \"Spanish\" as an official language?" },
                    { 53, "In an orchestra, what is the lowest member of the brass family?" },
                    { 57, "Who in Pulp Fiction says \"No, they got the metric system there, they wouldn't know what the fuck a Quarter Pounder is.\"" },
                    { 61, "According to the American rapper Nelly, what should you do when its hot in here?" },
                    { 65, "What's the name of the halloween-related Sims 4 Stuff Pack released September 29th, 2015?" },
                    { 69, "Which of the following is NOT a god in Norse Mythology." },
                    { 73, "What is the name of Poland in Polish?" },
                    { 77, "How many calories are in a 355 ml can of Pepsi Cola?" },
                    { 81, "Which of the following United States Presidents served the shortest term in office?" },
                    { 85, "Which of the following is not a real Pok&eacute;mon?" },
                    { 89, ".rs is the top-level domain for what country?" },
                    { 49, "Which company did Bethesda purchase the Fallout Series from?" },
                    { 197, "What does the computer software acronym JVM stand for?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 2, true, 1, "October 29, 2003" },
                    { 129, false, 125, "United States" },
                    { 130, true, 129, "The Director" },
                    { 131, false, 129, "Herbert P. Bear" },
                    { 132, false, 129, "Tusk" },
                    { 133, false, 129, "Ultimate Proto-Bot 10000" },
                    { 134, true, 133, "We Love to See You Smile" },
                    { 135, false, 133, "Why Pay More!?" },
                    { 136, false, 133, "Have It Your Way" },
                    { 137, false, 133, "Making People Happy Through Food" },
                    { 138, true, 137, "Clint Eastwood, Eli Wallach, and Lee Van Cleef" },
                    { 139, false, 137, "Sergio Leone, Ennio Morricone, and Tonino Delli Colli" },
                    { 140, false, 137, "Yul Brynner, Steve McQueen, and Charles Bronson" },
                    { 141, false, 137, "Aldo Giuffr&egrave;, Mario Brega, and Luigi Pistilli" },
                    { 142, true, 141, "Husker" },
                    { 143, false, 141, "Starbuck" },
                    { 144, false, 141, "Apollo" },
                    { 145, false, 141, "Crashdown" },
                    { 146, true, 145, "Scoot" },
                    { 147, false, 145, "Drake" },
                    { 148, false, 145, "Bill" },
                    { 149, false, 145, "Mallary" },
                    { 128, false, 125, "China" },
                    { 150, true, 149, "USS Hornet" },
                    { 127, false, 125, "Canada" },
                    { 125, false, 121, "Wisconsin Badgers" },
                    { 104, false, 101, "716" },
                    { 105, false, 101, "1155" },
                    { 106, true, 105, "Hamlet" },
                    { 107, false, 105, "The Tempest" },
                    { 108, false, 105, "Othello" },
                    { 109, false, 105, "The Taming of the Shrew" },
                    { 110, true, 109, "Answer a riddle" },
                    { 111, false, 109, "Rhythmically tap barrels with a wand" },
                    { 112, false, 109, "Speak a password" },
                    { 113, false, 109, "Knock in sequence" },
                    { 114, true, 113, "7" },
                    { 115, false, 113, "8" },
                    { 116, false, 113, "6" },
                    { 117, false, 113, "5" },
                    { 118, true, 117, "Lamborghini" },
                    { 119, false, 117, "Ferrari" },
                    { 120, false, 117, "Pagani" },
                    { 121, false, 117, "Bugatti" },
                    { 122, true, 121, "Ohio State Buckeyes" },
                    { 123, false, 121, "Alabama Crimson Tide" },
                    { 124, false, 121, "Clemson Tigers" },
                    { 126, true, 125, "Russia" },
                    { 103, false, 101, "1360" },
                    { 151, false, 149, "USS Enterprise" },
                    { 153, false, 149, "USS Saratoga" },
                    { 179, false, 177, "Swimming" },
                    { 180, false, 177, "Showjumping" },
                    { 181, false, 177, "Gymnastics" },
                    { 182, true, 181, "For Emma, Forever Ago" },
                    { 183, false, 181, "Bon Iver, Bon Iver" },
                    { 184, false, 181, "22, A Million" },
                    { 185, false, 181, "Blood Bank EP" },
                    { 186, true, 185, "Utah Teapot" },
                    { 187, false, 185, "Pixar Teapot" },
                    { 188, false, 185, "3D Teapot" },
                    { 189, false, 185, "Tennessee Teapot" },
                    { 190, true, 189, "Marlon" },
                    { 191, false, 189, "Marnie" },
                    { 192, false, 189, "Morris" },
                    { 193, false, 189, "Marvin" },
                    { 194, true, 193, "October 31st, 2019" },
                    { 195, false, 193, "January 13th, 2019" },
                    { 196, false, 193, "September 6th, 2018" },
                    { 197, false, 193, "October 1st, 2019" },
                    { 198, true, 197, "Java Virtual Machine" },
                    { 199, false, 197, "Java Vendor Machine" },
                    { 178, true, 177, "Skiing" },
                    { 152, false, 149, "USS Lexington" },
                    { 177, false, 173, "Ronald Regan" },
                    { 175, false, 173, "Richard Nixon" },
                    { 154, true, 153, "Google" },
                    { 155, false, 153, "Apple" },
                    { 156, false, 153, "Yahoo" },
                    { 157, false, 153, "Microsoft" },
                    { 158, true, 157, "7.62x39mm" },
                    { 159, false, 157, "7.62x51mm" },
                    { 160, false, 157, "5.56x45mm" },
                    { 161, false, 157, "5.45x39mm" },
                    { 162, true, 161, "Aqua" },
                    { 163, false, 161, "Vengaboys" },
                    { 164, false, 161, "Eiffel 65" },
                    { 165, false, 161, "Sash!" },
                    { 166, true, 165, "Titus Andronicus" },
                    { 167, false, 165, "Othello" },
                    { 168, false, 165, "Macbeth" },
                    { 169, false, 165, "King Lear" },
                    { 170, true, 169, "187" },
                    { 171, false, 169, "207" },
                    { 172, false, 169, "197" },
                    { 173, false, 169, "177" },
                    { 174, true, 173, "George H. W. Bush" },
                    { 176, false, 173, "George W. Bush " },
                    { 102, true, 101, "685" },
                    { 101, false, 97, "Kiwi Food Cut" },
                    { 100, false, 97, "Kibbled Freaky Cow" },
                    { 28, false, 25, "1401" },
                    { 29, false, 25, "1422" },
                    { 30, true, 29, "Zepheniah Mann" },
                    { 31, false, 29, "Cave Johnson" },
                    { 32, false, 29, "Wallace Breem" },
                    { 33, false, 29, "Saxton Hale" },
                    { 34, true, 33, "The Shining" },
                    { 35, false, 33, "2001: A Space Odyssey" },
                    { 36, false, 33, " Dr. Strangelove " },
                    { 37, false, 33, "Eyes Wide Shut" },
                    { 38, true, 37, "September 19th" },
                    { 39, false, 37, "September 21st" },
                    { 40, false, 37, "September 30th" },
                    { 41, false, 37, "September 14th" },
                    { 42, true, 41, "Skies on Fire - AC/DC" },
                    { 43, false, 41, "Heathens - Twenty One Pilots" },
                    { 44, false, 41, "Without Me - Eminem" },
                    { 45, false, 41, "Fortunate Son - Creedence Clearwater Revival" },
                    { 46, true, 45, "Equatorial Guinea" },
                    { 47, false, 45, "Guinea" },
                    { 48, false, 45, "Cameroon" },
                    { 27, false, 25, "1463" },
                    { 49, false, 45, "Angola" },
                    { 26, true, 25, "1415" },
                    { 24, false, 21, "France" },
                    { 3, false, 1, "December 1, 2003" },
                    { 4, false, 1, "November 14, 2002" },
                    { 5, false, 1, "July 18, 2004" },
                    { 6, true, 5, "Ed Sheeran - I See Fire" },
                    { 7, false, 5, "Marvin Gaye - Sexual Healing" },
                    { 8, false, 5, "Coldplay - Midnight" },
                    { 9, false, 5, "a-ha - Take On Me" },
                    { 10, true, 9, "Madeon" },
                    { 11, false, 9, "Daft Punk " },
                    { 12, false, 9, "Disclosure" },
                    { 13, false, 9, "David Guetta" },
                    { 14, true, 13, "Albus Percival Wulfric Brian Dumbledore" },
                    { 15, false, 13, "Albus Valum Jetta Mobius Dumbledore" },
                    { 16, false, 13, "Albus James Lunae Otto Dumbledore" },
                    { 17, false, 13, "Albus Valencium Horatio Kul Dumbledore" },
                    { 18, true, 17, "Germany" },
                    { 19, false, 17, "United Kingdom" },
                    { 20, false, 17, "Brazil" },
                    { 21, false, 17, "South Africa" },
                    { 22, true, 21, "Switzerland" },
                    { 23, false, 21, "United Kingdom" },
                    { 25, false, 21, "Belgium" },
                    { 50, true, 49, "Interplay Entertainment " },
                    { 51, false, 49, "Capcom" },
                    { 52, false, 49, "Blizzard Entertainment" },
                    { 79, false, 77, "200" },
                    { 80, false, 77, "100" },
                    { 81, false, 77, "155" },
                    { 82, true, 81, "William Henry Harrison" },
                    { 83, false, 81, "Zachary Taylor" },
                    { 84, false, 81, "James A. Garfield" },
                    { 85, false, 81, "Warren G. Harding" },
                    { 86, true, 85, "Luminid" },
                    { 87, false, 85, "Dragalge" },
                    { 88, false, 85, "Mandibuzz" },
                    { 89, false, 85, "Araquanid" },
                    { 90, true, 89, "Serbia" },
                    { 91, false, 89, "Romania" },
                    { 92, false, 89, "Russia" },
                    { 93, false, 89, "Rwanda" },
                    { 94, true, 93, "Dan Smith" },
                    { 95, false, 93, "Will Farquarson" },
                    { 96, false, 93, "Kyle Simmons" },
                    { 97, false, 93, "Chris Wood" },
                    { 98, true, 97, "Kentucky Fried Chicken" },
                    { 99, false, 97, "Kentucky Fresh Cheese" },
                    { 78, true, 77, "150" },
                    { 77, false, 73, "P&oacute;land" },
                    { 76, false, 73, "Polszka" },
                    { 75, false, 73, "Pupcia" },
                    { 53, false, 49, "Nintendo" },
                    { 54, true, 53, "Tuba" },
                    { 55, false, 53, "Trombone" },
                    { 56, false, 53, "Contrabass" },
                    { 57, false, 53, "Bassoon" },
                    { 58, true, 57, "Vincent Vega" },
                    { 59, false, 57, "Jules Winnfield" },
                    { 60, false, 57, "Jimmie Dimmick" },
                    { 61, false, 57, "Butch Coolidge" },
                    { 62, true, 61, "Take off all your clothes" },
                    { 200, false, 197, "Java Visual Machine" },
                    { 63, false, 61, "Take a cool shower" },
                    { 65, false, 61, "Go skinny dipping" },
                    { 66, true, 65, "Spooky Stuff" },
                    { 67, false, 65, "Ghosts n' Ghouls" },
                    { 68, false, 65, "Nerving Nights" },
                    { 69, false, 65, "Fearful Frights" },
                    { 70, true, 69, "Jens" },
                    { 71, false, 69, "Loki" },
                    { 72, false, 69, "Tyr" },
                    { 73, false, 69, "Snotra" },
                    { 74, true, 73, "Polska" },
                    { 64, false, 61, "Drink some water" },
                    { 201, false, 197, "Just Virtual Machine" }
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
