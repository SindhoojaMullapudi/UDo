using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YouDo.Models;
//inheritance = automatically get all features of the class
// using = in order to make the page successful we need selections from the classes 
namespace YouDo.Views
{
    //This class is no longer needed - since it is moved to TaskListPage.Xaml
    class TodoListPage:ContentPage 
        //":" TodoListpage inherits from ContentPage--> makes your life easier
        // TodoListPage = derived class
        // ContentPage = base class
    {
        ListView listView;

        public TodoListPage()
        {
            Title = "You do";

            listView = new ListView();
            listView.ItemTemplate = new DataTemplate(typeof(ToDoItemCell));
            listView.ItemSelected += (sender, e) =>
            {
                var todoItem = (TodoItem)e.SelectedItem; 
                var todoPage = new TodoItemPage();
                todoPage.BindingContext = todoItem;

                Navigation.PushAsync(todoPage);
            };

            var layout = new StackLayout();
            layout.Children.Add(listView);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;

            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.Android)
            {
                tbi = new ToolbarItem("+", "plus", () =>{
                    var todoItem = new TodoItem();
                    var todoPage = new TodoItemPage();
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                },0,0);
                    
            }

            ToolbarItems.Add(tbi);
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Database.GetItems();
        }

        
      
   }
}
