using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YouDo.Views
{
    class ToDoItemCell: ViewCell 
    {
        public ToDoItemCell()
        {
            var label = new Label { YAlign = TextAlignment.Center };
            label.SetBinding(Label.TextProperty, "Name");

            var tick = new Image { Source = FileImageSource.FromFile("check.png") };
            tick.SetBinding(Image.IsVisibleProperty, "Done");

            var layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 0, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { label, tick }
            };
            View = layout;
        }

        protected override void OnBindingContextChanged()
        {
            View.BindingContext = BindingContext;
            base.OnBindingContextChanged();
        }
    }
}
