namespace CampusMolndal.MockDB_Live.Facades;

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusMolndal.MockDB_Live.Models;

public class SQLiteFacade : ISQLDatabasFacade
{
    DBHelper db = null;
    public SQLiteFacade(string databasename)
    {
        db = new DBHelper(databasename);
        CreateTables();
        Seeder();
    }

    public SQLiteFacade(DBHelper helper)
    {
        DBHelper db = helper;
        CreateTables();
        Seeder();
    }

    private void Seeder()
    {
        // Lägg in en faslig massa INSERT till tabellerna här
        // Används för defaultvärder
        // Kolla först om tabellen är tom
    }

    private void CreateTables()
    {
        // Lägg till en faslig massa CREATE TABLE IF NOT EXISTS
        // Kolla först om tabellen finns
        var sql = @"CREATE TABLE IF NOT EXISTS Produkt (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT,
            Description TEXT
        )";
        db.ExecuteSQL(sql);
    }

    public void Insert(Produkt produkt)
    {
        db.Insert(produkt);
    }

    public Produkt[] GetData()
    {
        return db.GetData();
    }

    // Skapa en hel drös med CRUD metoder
    // Speciellt anpassade sökningar

}
