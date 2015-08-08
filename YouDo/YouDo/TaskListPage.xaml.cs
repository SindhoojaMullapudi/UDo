using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YouDo.Models;
using YouDo.Views;

namespace YouDo
{
    public partial class TaskListPage : ContentPage
    {
    
                ListView listView;

        public TaskListPage()
        {
            InitializeComponent();
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
            listView.ItemsSource = App.Database.GetItems();

            
        }

    }
}
