using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampusMolndal.MockDB_Live.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Moq;
using System.Data;
using CampusMolndal.MockDB_Live.Models;

namespace CampusMolndal.MockDB_Live.Facades.Tests;

[TestClass()]
public class SQLiteFacadeTestsMoq
{
    ISQLDatabasFacade sut = null;
    List<Produkt> mockData = new List<Produkt>();
    Mock<ISQLDatabasFacade> mock;

    [TestInitialize]
    public void Setup()
    {
        //mock = new SQLiteConnection("Data Source=:memory:");
        //mock.Open();

        mock = new Mock<ISQLDatabasFacade>();
        mock.Setup(x => x.GetData()).Returns(mockData.ToArray());
        mock.Setup(x => x.Insert(It.IsAny<Produkt>())).Callback<Produkt>(x => mockData.Add(x));
        sut = mock.Object;
    }


    [TestMethod()]
    public void InsertTest()
    {
        Produkt produkt = new Produkt() { Name = "Test", Description = "Test" };
        int mockdataCount = mockData.Count;
        sut.Insert(produkt);

        Assert.AreEqual(mockdataCount + 1, mockData.Count);
        mock.Verify(x => x.Insert(It.IsAny<Produkt>()), Times.Once);
    }

    [TestMethod()]
    public void GetDataTest()
    {
        Produkt produkt = new Produkt() { Name = "Test", Description = "Test" };
        mockData.Add(produkt);
        Produkt[] result = sut.GetData();
        Assert.AreEqual(produkt, result[0]);
        mock.Verify(x => x.GetData(), Times.Once);

    }
}