using System;
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
                    EntryDate = table.Column<DateTime>(nullable: false),
                    PlayerName = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreEntries", x => x.Id);
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
                    { 1, "What is the punishment for playing Postal 2 in New Zealand?" },
                    { 28, "Ellen McLain, the voice of GLaDOS in the Portal game series, is married to the voice actor for which Team Fortress 2 character?" },
                    { 29, "Which one of these was not a member of the Fiendish Five in the game Sly Cooper and the Thievius Raccoonus?" },
                    { 30, "What was the first weapon pack for \"PAYDAY 2\"?" },
                    { 31, "In \"Paper Mario: The Thousand Year Door\", what is Hooktail's weakness?" },
                    { 32, "How much did the indie game \"Cave Story\" cost when it was first released in 2004?" },
                    { 33, "In which \"Call of Duty\" game are the \"Apothicons\" introduced in the Zombies mode?" },
                    { 34, "In the \"Call Of Duty: Zombies\" map \"Origins\", how many steps are there to upgrade a Staff?" },
                    { 35, "Who developed the 2016 farming RPG \"Stardew Valley\"?" },
                    { 36, "What animal is featured in \"Bloons TD Battles\"?" },
                    { 37, "In \"Call of Duty: Zombies\", what group does Doctor Maxis work for?" },
                    { 38, "In what year was Pokémon Diamond &amp; Pearl released in Japan?" },
                    { 39, "In Telltale Games' \"The Walking Dead: Season One\" what is the name of Clementine's father?" },
                    { 40, "What was the original release date of Grand Theft Auto V?" },
                    { 41, "What is the only Generation III Pokemon whose name begins with the letter I?" },
                    { 42, "In Left 4 Dead, which campaign has the protagonists going through a subway in order to reach a hospital for evacuation?" },
                    { 43, "Which of these characters is NOT a boss in Crash Bash?" },
                    { 44, "What character is NOT apart of the Grand Theft Auto series?" },
                    { 45, "In \"Kingdom Hearts\", what is the name of Sora's home world?" },
                    { 46, "In \"PUBATTLEGROUNDS\" what is the name of the Military Base island?" },
                    { 47, "In the MMO RPG \"Realm of the Mad God\", what class is known for having the highest possible defense?" },
                    { 48, "Which one of these characters was first introduced in Sonic Boom: Rise of Lyric?" },
                    { 27, "In what year were screenshots added to Steam?" },
                    { 26, "What is the item required to summon the boss Duke Fishron in the game Terraria?" },
                    { 25, "Which of the following is not a real Pokémon?" },
                    { 24, "In the game \"Persona 4\", what is the canonical name of the protagonist?" },
                    { 2, "Which company developed the video game \"Borderlands\"?" },
                    { 3, "How many Chaos Emeralds can you collect in the first Sonic The Hedgehog?" },
                    { 4, "Which character is from \"Splatoon\"?" },
                    { 5, "How many Star Spirits do you rescue in the Nintendo 64 video game \"Paper Mario\"?" },
                    { 6, "What is the original name of Final Fantasy XV?" },
                    { 7, "In Portal 2, the iconic character GLaDOS is turned into:" },
                    { 8, "Which one of the following actors did not voice a character in \"Saints Row: The Third\"?" },
                    { 9, "What was the name of the Secret Organization in the Hotline Miami series? " },
                    { 10, "In which order do you need to hit some Deku Scrubs to open the first boss door in \"Ocarina of Time\"?" },
                    { 11, "Which of the following Pokémon games released first?" },
                    { 49, "In Touhou 12: Undefined Fantastic Object, which of these was not a playable character?" },
                    { 12, "In the Portal series, Aperture Science was founded under what name in the early 1940s?" },
                    { 14, "In World of Warcraft lore, who was first to have the title \"The Ashbringer\"?" },
                    { 15, "In the game \"Cave Story,\" what is the character Balrog's catchphrase?" },
                    { 16, "Which of the following characters were considered for inclusion in Super Smash Bros. Melee?" },
                    { 17, "The creator of the Touhou Project series is:" },
                    { 18, "Who was the main antagonist of Max Payne 3 (2012)?" },
                    { 19, "In Cook, Serve, Delicious!, which food is NOT included in the game?" },
                    { 20, "In Touhou: Embodiment of Scarlet Devil, what song plays during Flandre Scarlet's boss fight?" },
                    { 21, "Which horror movie had a sequel in the form of a video game released in August 20, 2002?" },
                    { 22, "When was Final Fantasy XV released?" },
                    { 23, "In WarioWare: Smooth Moves, which one of these is NOT a Form?" },
                    { 13, "In which Mario game did the Mega Mushroom make its debut?" },
                    { 50, "In the 2000 video game \"Crimson Skies,\" what was the name of the protagonists' zeppelin?" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 11, true, 1, "10 years in prison and a fine of $50,000" },
                    { 324, false, 32, "$15 USD" },
                    { 331, true, 33, "Call Of Duty: Black Ops III" },
                    { 332, false, 33, "Call Of Duty: Black Ops" },
                    { 333, false, 33, "Call Of Duty: World At War" },
                    { 334, false, 33, "Call Of Duty: Black Ops II" },
                    { 341, true, 34, "4" },
                    { 342, false, 34, "7" },
                    { 343, false, 34, "5" },
                    { 344, false, 34, "3" },
                    { 351, true, 35, "Eric Barone" },
                    { 352, false, 35, "Daisuke Amaya" },
                    { 353, false, 35, "Jasper Byrne" },
                    { 354, false, 35, "Lucas Pope" },
                    { 361, true, 36, "Monkeys" },
                    { 362, false, 36, "Alligators" },
                    { 363, false, 36, "Pigeons" },
                    { 364, false, 36, "Lizards" },
                    { 371, true, 37, "Group 935" },
                    { 372, false, 37, "Group Reanimate" },
                    { 373, false, 37, "Group Rezurrection" },
                    { 374, false, 37, "Division 9" },
                    { 323, false, 32, "$10 USD" },
                    { 381, true, 38, "2006" },
                    { 322, false, 32, "$5 USD" },
                    { 314, false, 31, "The Hammer" },
                    { 263, false, 26, "King Grasshopper" },
                    { 264, false, 26, "Slug" },
                    { 271, true, 27, "2011" },
                    { 272, false, 27, "2010" },
                    { 273, false, 27, "2008" },
                    { 274, false, 27, "2009" },
                    { 281, true, 28, "Sniper" },
                    { 282, false, 28, "Heavy" },
                    { 283, false, 28, "Soldier" },
                    { 284, false, 28, "Scout" },
                    { 291, true, 29, "Dimitri Lousteau" },
                    { 292, false, 29, "Mz. Ruby" },
                    { 293, false, 29, "Muggshot" },
                    { 294, false, 29, "Clockwerk" },
                    { 301, true, 30, "The Gage Weapon Pack #1" },
                    { 302, false, 30, "The Overkill Pack" },
                    { 303, false, 30, "The Gage Chivalry Pack" },
                    { 304, false, 30, "The Gage Historical Pack" },
                    { 311, true, 31, "The Sound of Crickets" },
                    { 312, false, 31, "Attacks from Koopas" },
                    { 313, false, 31, "The \"Ice Storm\" Item" },
                    { 321, true, 32, "$0 USD" },
                    { 262, false, 26, "Suspicious Looking Fish" },
                    { 382, false, 38, "2009" },
                    { 384, false, 38, "2008" },
                    { 452, false, 45, "Agrabah" },
                    { 453, false, 45, "Land of Departure" },
                    { 454, false, 45, "Disney Town" },
                    { 461, true, 46, "Sosnovka" },
                    { 462, false, 46, "Novorepnoye" },
                    { 463, false, 46, "Mylta" },
                    { 464, false, 46, "Yasnaya" },
                    { 471, true, 47, "The Knight" },
                    { 472, false, 47, "The Wizard" },
                    { 473, false, 47, "The Archer" },
                    { 474, false, 47, "The Warrior" },
                    { 481, true, 48, "Sticks the Badger" },
                    { 482, false, 48, "Mighty the Armadillo" },
                    { 483, false, 48, "Espio the Chameleon" },
                    { 484, false, 48, "Rouge the Bat" },
                    { 491, true, 49, "Izayoi Sakuya" },
                    { 492, false, 49, "Hakurei Reimu" },
                    { 493, false, 49, "Kirisame Marisa" },
                    { 494, false, 49, "Kochiya Sanae" },
                    { 501, true, 50, "Pandora" },
                    { 502, false, 50, "Helios" },
                    { 451, true, 45, "Destiny Islands" },
                    { 383, false, 38, "2007" },
                    { 444, false, 44, "Lester Crest" },
                    { 442, false, 44, "Packie McReary" },
                    { 391, true, 39, "Ed" },
                    { 392, false, 39, "Charles" },
                    { 393, false, 39, "Lee" },
                    { 394, false, 39, "Walter" },
                    { 401, true, 40, "September 17, 2013" },
                    { 402, false, 40, "August 17, 2013" },
                    { 403, false, 40, "April 14, 2015" },
                    { 404, false, 40, "November 18, 2014" },
                    { 411, true, 41, "Illumise" },
                    { 412, false, 41, "Infernape" },
                    { 413, false, 41, "Ivysaur" },
                    { 414, false, 41, "Igglybuff" },
                    { 421, true, 42, "No Mercy" },
                    { 422, false, 42, "Subway Sprint" },
                    { 423, false, 42, "Hospital Havoc" },
                    { 424, false, 42, "Blood Harvest" },
                    { 431, true, 43, "Ripper Roo" },
                    { 432, false, 43, "Papu Papu" },
                    { 433, false, 43, "Komodo brothers" },
                    { 434, false, 43, "Nitros Oxide" },
                    { 441, true, 44, "Michael Cardenas" },
                    { 443, false, 44, "Tommy Vercetti" },
                    { 261, true, 26, "Truffle Worm" },
                    { 254, false, 25, "Araquanid" },
                    { 253, false, 25, "Mandibuzz" },
                    { 73, false, 7, "A lemon" },
                    { 74, false, 7, "An apple" },
                    { 81, true, 8, "Ron Jeremy" },
                    { 82, false, 8, "Sasha Grey" },
                    { 83, false, 8, "Burt Reynolds" },
                    { 84, false, 8, "Hulk Hogan" },
                    { 91, true, 9, "50 Blessings" },
                    { 92, false, 9, "American Blessings" },
                    { 93, false, 9, "50 Saints" },
                    { 94, false, 9, "USSR's Blessings" },
                    { 101, true, 10, "2, 3, 1" },
                    { 102, false, 10, "1, 2, 3" },
                    { 103, false, 10, "1, 3, 2" },
                    { 104, false, 10, "2, 1, 3" },
                    { 111, true, 11, "Pokémon Crystal" },
                    { 112, false, 11, "Pokémon Platinum" },
                    { 113, false, 11, "Pokémon FireRed" },
                    { 114, false, 11, "Pokémon Black" },
                    { 121, true, 12, "Aperture Fixtures" },
                    { 122, false, 12, "Aperture Lavatories" },
                    { 123, false, 12, "Aperture Science Innovators" },
                    { 72, false, 7, "A tomato" },
                    { 124, false, 12, "Wheatley Laboratories" },
                    { 71, true, 7, "A potato" },
                    { 63, false, 6, "Final Fantasy XVI" },
                    { 12, false, 1, "Fine of $5,000" },
                    { 13, false, 1, "Nothing" },
                    { 14, false, 1, "15 years in prison and a fine of $10,000" },
                    { 21, true, 2, "Gearbox Software" },
                    { 22, false, 2, "2K Games" },
                    { 23, false, 2, "Activision" },
                    { 24, false, 2, "Rockstar Games" },
                    { 31, true, 3, "Six" },
                    { 32, false, 3, "Seven" },
                    { 33, false, 3, "Five" },
                    { 34, false, 3, "Eight" },
                    { 41, true, 4, "Marie" },
                    { 42, false, 4, "Cyrus" },
                    { 43, false, 4, "Palutena" },
                    { 44, false, 4, "Shulk" },
                    { 51, true, 5, "7" },
                    { 52, false, 5, "5" },
                    { 53, false, 5, "10" },
                    { 54, false, 5, "12" },
                    { 61, true, 6, "Final Fantasy Versus XIII" },
                    { 62, false, 6, "Final Fantasy: Reborn" },
                    { 64, false, 6, "Final Fantasy XIII-3" },
                    { 131, true, 13, "Mario Party 4" },
                    { 132, false, 13, "New Super Mario Bros." },
                    { 133, false, 13, "Mario Kart Wii" },
                    { 202, false, 20, "Septette for the Dead Princess" },
                    { 203, false, 20, "Flowering Night" },
                    { 204, false, 20, "Pierrot of the Star-Spangled Banner" },
                    { 211, true, 21, "The Thing" },
                    { 212, false, 21, "The Evil Dead" },
                    { 213, false, 21, "Saw" },
                    { 214, false, 21, "Alien" },
                    { 221, true, 22, "November 29th, 2016" },
                    { 222, false, 22, "October 25th, 2016" },
                    { 223, false, 22, "December 31th, 2016" },
                    { 224, false, 22, "November 30th, 2016" },
                    { 231, true, 23, "The Hotshot" },
                    { 232, false, 23, "The Discard" },
                    { 233, false, 23, "The Elephant" },
                    { 234, false, 23, "The Mohawk" },
                    { 241, true, 24, "Yu Narukami" },
                    { 242, false, 24, "Chino Mashido" },
                    { 243, false, 24, "Tunki Sunada" },
                    { 244, false, 24, "Masaki Narinaka" },
                    { 251, true, 25, "Luminid" },
                    { 252, false, 25, "Dragalge" },
                    { 201, true, 20, "U.N. Owen Was Her" },
                    { 194, false, 19, "Lasagna" },
                    { 193, false, 19, "Hamburger" },
                    { 192, false, 19, "Shish Kabob" },
                    { 134, false, 13, "Super Mario 3D World" },
                    { 141, true, 14, "Alexandros Mograine" },
                    { 142, false, 14, "Tirion Fordring" },
                    { 143, false, 14, "Arthas Menethil" },
                    { 144, false, 14, "Uther the Lightbringer" },
                    { 151, true, 15, "Huzzah!" },
                    { 152, false, 15, "Yes!" },
                    { 153, false, 15, "Whoa there!" },
                    { 154, false, 15, "Nyeh heh heh!" },
                    { 161, true, 16, "Lucas" },
                    { 503, false, 50, "Icarus" },
                    { 162, false, 16, "Mega Man" },
                    { 164, false, 16, "Diddy Kong" },
                    { 171, true, 17, "ZUN" },
                    { 172, false, 17, "SUN" },
                    { 173, false, 17, "RUN" },
                    { 174, false, 17, "PUN" },
                    { 181, true, 18, "Victor Branco" },
                    { 182, false, 18, "&Aacute;lvaro Neves" },
                    { 183, false, 18, "Armando Becker" },
                    { 184, false, 18, "Milo Rego" },
                    { 191, true, 19, "Pie" },
                    { 163, false, 16, "Meta Knight" },
                    { 504, false, 50, "Orion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");
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
