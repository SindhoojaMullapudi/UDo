using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YouDo.Models;

namespace YouDo.Views
{
    
    public class TodoItemPage: ContentPage

    {
        public TodoItemPage()
        {
            this.SetBinding(ContentPage.TitleProperty, "Todo");
            NavigationPage.SetHasNavigationBar(this, true);

            //task name
            var nameLabel = new Label { Text = "Name" };
            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            //Notes
            var notesLabel = new Label { Text = "Notes" };
            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            //Category
            var categoryLabel = new Label { Text = "Category" };
            var categoryPicker = new Picker
            {
                Title = "Category",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            foreach (var category in App.CategoryDatabase.GetCategories())
            {
                categoryPicker.Items.Add(category.Name);
            }
            categoryPicker.SetBinding(Picker.SelectedIndexProperty, "CategoryId");

            //var categoryPicker = new BindablePicker
            //{
            //    Title = "Category",
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    ItemsSource = App.CategoryDatabase.GetCategoryNames()
            //};
            //categoryPicker.SetBinding(BindablePicker.SelectedItemProperty, "Category");

            //Due date
            var dueDateLabel = new Label { Text = "Due Date" };
            var dueDatePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            dueDatePicker.SetBinding(DatePicker.DateProperty, "DueDate");

            //Reminder Date
            var reminderDateLabel = new Label { Text = " Set Reminder" };
            var reminderDatePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            reminderDatePicker.SetBinding(DatePicker.DateProperty, "ReminderDate");

            //Done
            var doneLabel = new Label { Text = "Done" };
            var doneEntry = new Switch();
            doneEntry.SetBinding(Switch.IsToggledProperty, "Done");

            //Save
            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) =>
            {
                var todoItem = (TodoItem)BindingContext;
                App.Database.SaveItem(todoItem);
                this.Navigation.PopAsync();
            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children = {
                    nameLabel, nameEntry,
                    notesLabel, notesEntry,
                    categoryLabel, categoryPicker,
                    dueDateLabel, dueDatePicker,
                    reminderDateLabel, reminderDatePicker,
                    doneLabel, doneEntry,
                    saveButton
                }
            };
        }


        public LayoutOptions VerticalOptions { get; set; }
    }
}
