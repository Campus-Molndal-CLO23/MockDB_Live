namespace CampusMolndal.MockDB_Live.Facades;

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusMolndal.MockDB_Live.Models;

public class DBHelper
{
    private SQLiteConnection connection;
    public DBHelper(string databasename)
    {
        connection = new SQLiteConnection($"Data Source={databasename}.db;Version=3;UseUTF16Encoding=True;");
        connection.Open();
    }

    public void ExecuteSQL(string sql)
    {
        try
        {
            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(sql); // Ta bort innan du skickar till kunden
        }
    }

    public void Insert(Produkt produkt)
    {
        string sql= $"INSERT INTO Produkt (Name, Description) VALUES (?, ?)";
        try
        {
            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add(new SQLiteParameter("Name", produkt.Name));
            command.Parameters.Add(new SQLiteParameter("Description", produkt.Description));
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(sql); // Ta bort innan du skickar till kunden
        }
    }

    public Produkt[] GetData()
    {
        // Exekvera SQL och returnera en array med resultatet
        // Om det inte finns något resultat, returnera en tom array

        // Skapa en lista med resultatet
        var result = new List<Produkt>();

        // Skapa en command 
        var command = connection.CreateCommand();
        command.CommandText = "Select * from produkt";

        // Fyll result med resultatet
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var prod = new Produkt();
                prod.Id = reader.GetInt32(0);
                prod.Name = reader.GetString(1);
                prod.Description = reader.GetString(2);
                result.Add(prod);
            }
        }

        return result.ToArray();    
    }

    // Skapa en hel drös med CRUD metoder
    // Speciellt anpassade sökningar

}
