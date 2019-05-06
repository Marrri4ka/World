using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace World.Models
{
  public class City // class
  {
    private int _id;
    private string _name;
    private int _population;


    public City (int id, string name, int population) // constructor
    {
      _id = id;
      _name = name;
      _population = population;
    }


    public int GetId()
    {
      return _id;
    }

    public void SetId(int newId)
    {
      _id = newId;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT id, name, population FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        int cityPopulation = rdr.GetInt32(2);
        City newCity= new City (cityId ,cityName, cityPopulation);
        allCities.Add(newCity);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allCities;

    }

    // public static void ClearAll()
    // {
    //   _instances.Clear();
    // }
    // public int GetId()
    // {
    //   return _id;
    // }

    // public static Item Find (int searchId)
    // {
    //
    //   return _instances[searchId-1];
    // }

    // public void DeleteItem ()
    // {
    //   for (int i =0; i< _instances.Count; i++)
    //   {
    //     if (_instances[i].GetId() == _id)
    //     {
    //       _instances.Remove(_instances[i]);
    //     }
    //   }
    // }




  }
}
