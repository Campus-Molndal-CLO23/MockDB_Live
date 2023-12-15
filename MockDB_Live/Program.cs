// Denna kod är skapad av Marcus Medina (C) 2023 och för all framtid, Yeah!

using CampusMolndal.MockDB_Live;
using CampusMolndal.MockDB_Live.Facades;
using CampusMolndal.MockDB_Live.Models;

Console.WriteLine("Hello,");
Console.WriteLine(@"     _____       _      _ _         ");
Console.WriteLine(@"    / ____|     | |    (_) |        ");
Console.WriteLine(@"   | (___   __ _| |     _| |_ ___   ");
Console.WriteLine(@"    \___ \ / _` | |    | | __/ _ \  ");
Console.WriteLine(@"    ____) | (_| | |____| | ||  __ / ");
Console.WriteLine(@"   |_____/ \__, |______|_|\__\___|  ");
Console.WriteLine(@"              | |                   ");
Console.WriteLine(@"              |_|                   ");

// H:\users\marmed02\Documents\Databaser
// Det finns olika mappar i olike i miljöer, användarnamn skiljer sig
// c:\users\marcus\documents + "Databaser"
// Jag vet inte med med säkerhet om mappen slutar på \ eller inte
// Windows \ Linux /
string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
string dbFolder = Path.Combine(myDocumentsPath, "Databaser");

// temporary override
dbFolder = @"c:\Databaser";

Directory.CreateDirectory(dbFolder);

var db = new SQLiteFacade(Path.Combine(dbFolder, "Produkter"));

db.Insert(new Produkt { Name = "Kaffe", Description = "Bryggt kaffe" });
db.Insert(new Produkt { Name = "Te", Description = "Te med mjölk" });
db.Insert(new Produkt { Name = "Kaffe", Description = "Kaffe med mjölk" });

