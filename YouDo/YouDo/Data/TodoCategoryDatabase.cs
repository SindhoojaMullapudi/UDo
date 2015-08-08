using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YouDo.Models;
//this page has methods (the ones under model only has the properties for now
namespace YouDo.Data
{
    public class TodoCategoryDatabase
    {
        SQLiteConnection database;
        


        public TodoCategoryDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<TodoCategory>();
            //constructor --> telling the database to create actual list
        }
        public void SaveCategory(TodoCategory category)
        {
            if (category.Id != 0)
            {
                database.Update(category);
            }
            else
            {
                database.Insert(category);
            }
        }

        public IEnumerable<TodoCategory> GetCategories()
        //I = the interface
        {
            return (from i in database.Table<TodoCategory>() select i).ToList();

        }

        public IEnumerable<string> GetCategoryNames()
        //I = the interface
        {
            return (from i in database.Table<TodoCategory>() select i.Name).ToList();

        }

    }


}
