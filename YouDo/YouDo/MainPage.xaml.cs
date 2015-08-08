using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using YouDo.Views;

namespace YouDo
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Children.Add(new TaskListPage { Title = "List" });
            this.Children.Add(new TodoCategoryPage { Title = "Category" });
        }
    }
}
