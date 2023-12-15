using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampusMolndal.MockDB_Live.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CampusMolndal.MockDB_Live.Models;

namespace CampusMolndal.MockDB_Live.Facades.Tests;

[TestClass()]
public class SQLiteFacadeTestsRealDB
{
    static readonly string dbName = Guid.NewGuid().ToString();
    string dbFolder = @"c:\Databaser";
    SQLiteFacade sut = null;

    [TestInitialize]
    public void Init()
    {
        string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //dbFolder = System.IO.Path.Combine(myDocumentsPath, "Databaser");

        // temporary override
        dbFolder = @"c:\Databaser";

        System.IO.Directory.CreateDirectory(dbFolder);

        sut = new SQLiteFacade(System.IO.Path.Combine(dbFolder, dbName));

    }

    [TestCleanup]
    public void Cleanup()
    {
        File.Delete(System.IO.Path.Combine(dbFolder, dbName));
        // Ta bort databasen
    }

    [TestMethod()]
    public void ExecuteSQLTest()
    {
        // Lista alla tabeller
        Produkt[] result = sut.GetData();

        Assert.IsTrue(result.Length>0);
    }

    [TestMethod()]
    public void InsertTest()
    {
        // Arrange
        var produkt = new Produkt { Name = "Kaffe", Description = "Bryggt kaffe" };

        // Act
        sut.Insert(produkt);

        // Assert
        // TODO: Fixa detta, den kraschar
        Produkt[] result = sut.GetData();
        Assert.IsTrue(result.Length > 0);
    }
}