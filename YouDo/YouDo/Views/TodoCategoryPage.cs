using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YouDo.Models;

namespace YouDo.Views
{
    
    public class TodoCategoryPage: ContentPage

    {
        public TodoCategoryPage()
        {
            this.SetBinding(ContentPage.TitleProperty, "Udo");
            NavigationPage.SetHasNavigationBar(this, true);
            var toDoCategory = new TodoCategory();
            this.BindingContext = toDoCategory;

            //task name
            var nameLabel = new Label { Text = "Category Name" };
            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");


            //Save
            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) =>
            {
                var todoCategory = (TodoCategory)BindingContext;
                App.CategoryDatabase.SaveCategory(todoCategory);
                nameEntry.Text = "";

            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children = {
                    nameLabel, nameEntry,
                    saveButton
                }
            };
        }

    }
}
