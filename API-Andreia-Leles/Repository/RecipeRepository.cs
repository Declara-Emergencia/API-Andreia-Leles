using API_Andreia_Leles.Entities;
using API_Andreia_Leles.Repository.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace API_Andreia_Leles.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private static SQLiteConnection sqliteConnection;
        private string ConnectionString { get; set; } = @"C:\Users\Public\Documents\andrelles.sqlite"; 

        public RecipeRepository()
        {
            CreateDbFile();
            CreateConnection();
            CreateRecipeDbTable();
        }

        private void CreateDbFile()
        {
            if (!File.Exists(ConnectionString))
            {
                SQLiteConnection.CreateFile(ConnectionString);
            }
        }
        private void CreateConnection()
        {
            sqliteConnection = new SQLiteConnection($"Data Source={ConnectionString}");
            sqliteConnection.Open();
        }

        private void CreateRecipeDbTable()
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS Recipes(ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, RecipeName Varchar(50))";
                cmd.ExecuteNonQuery();
            }
        }

        public List<Recipe> ConvertDataTableIntoList(DataTable dt)
        {
            List<Recipe> auxList = new();

            foreach (DataRow dr in dt.Rows)
            {
                auxList.Add
                (
                    new Recipe
                    {
                        RecipeName = dr["RecipeName"].ToString()
                    }
                );
            }

            return auxList;
        }

        public DataTable GetAll()
        {
            DataTable dt = new();

            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Recipes";
                SQLiteDataAdapter da = new(cmd.CommandText, sqliteConnection);
                da.Fill(dt);
            }

            return dt;
        }

        public bool Insert(Recipe recipe)
        {
            int dBChanges = 0;
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Recipes(RecipeName) values (@RecipeName)";
                cmd.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                dBChanges = cmd.ExecuteNonQuery();
            }

            if (dBChanges != 0)
            {
                return true;
            }

            return false;
        }
    }
}