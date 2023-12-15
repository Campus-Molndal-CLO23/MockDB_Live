using CampusMolndal.MockDB_Live.Models;

namespace CampusMolndal.MockDB_Live.Facades;
public interface ISQLDatabasFacade
{
    Produkt[] GetData();
    void Insert(Produkt produkt);
}