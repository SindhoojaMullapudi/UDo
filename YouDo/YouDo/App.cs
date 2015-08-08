using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using YouDo.Data;
using YouDo.Views;

namespace YouDo
{
    public class App : Application
    {
        static TodoItemDatabase database;
        static TodoCategoryDatabase categoryDatabase;
        public App()
        {
            var mainNav = new NavigationPage(new MainPage());
            MainPage = mainNav;
        }

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase();
                }
                return database;
            }
        }

        public static TodoCategoryDatabase CategoryDatabase
        {
            get
            {
                if (categoryDatabase == null)
                {
                    categoryDatabase = new TodoCategoryDatabase();
                }
                return categoryDatabase;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
