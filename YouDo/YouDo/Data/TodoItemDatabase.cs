using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YouDo.Models;
//the methods of the ToDoItem class
namespace YouDo.Data
{
    public class TodoItemDatabase
    {
        SQLiteConnection database;

        public TodoItemDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<TodoItem>();
            //constructor --> telling the database to create actual list
        }
        public void SaveItem(TodoItem item)
        {
            if (item.ID != 0)
            {
                database.Update(item);
            }
            else
            {
                database.Insert(item);
            }
        }

        public IEnumerable<TodoItem> GetItems()
        //I = the interface
        {
            return (from i in database.Table<TodoItem>() select i).ToList();

        }
    }


}
