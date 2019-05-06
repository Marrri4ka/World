using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace World.Models
{
  public class Country // class
  {
    private string _name;
    private string _continent;
    private int _population;
    private float _lifeExpectancy;


    public Country (string name, string continent, int population, float lifeExpectancy) // constructor
    {
      _name = name;
      _continent = continent;
      _population = population;
      _lifeExpectancy= lifeExpectancy;
    }


    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetContinent()
    {
      return _continent;
    }

    public void SetContinent(string newContinent)
    {
      _continent = newContinent;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public void SetPopulation(int newPopulation)
    {
      _population = newPopulation;
    }

    public float GetLifeExpectancy()
    {
      return _lifeExpectancy;
    }

    public void SetLifeExpectancy(float newLifeExpectancy)
    {
      _lifeExpectancy = newLifeExpectancy;
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT name, continent, population, lifeExpectancy FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {

        string countryName = rdr.GetString(0);
        string countryContinent = rdr.GetString(1);
        int countryPopulation = rdr.GetInt32(2);
        float countryLifeExpectancy = 0;
        if(!rdr.IsDBNull(3))
        {
          countryLifeExpectancy = rdr.GetFloat(3);
        }
        Country newCountry = new Country (countryName,countryContinent, countryPopulation,countryLifeExpectancy);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allCountries;

    }

    public static List<Country> GetAllContinents(string userInput)
    {
      List<Country> allCountries = new List<Country>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT name, continent, population, lifeExpectancy FROM country WHERE continent = '@userInput';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {

        string countryName = rdr.GetString(0);
        string countryContinent = rdr.GetString(1);
        int countryPopulation = rdr.GetInt32(2);
        float countryLifeExpectancy = 0;
        if(!rdr.IsDBNull(3))
        {
          countryLifeExpectancy = rdr.GetFloat(3);
        }
        Country newCountry = new Country (countryName,countryContinent, countryPopulation,countryLifeExpectancy);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allCountries;

    }
  }
}
