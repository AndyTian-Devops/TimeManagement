using Xamarin.Forms;
using System.Collections.Generic;
using System;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
namespace Todo
{
   public  class TodoListReportCS : ContentPage
    {
        public TodoListReportCS()
        {
            Title = "Report";

            var todoItemAdd = new ToolbarItem
            {
                Text = "+",
                Icon = Device.OnPlatform(null, "plus.png", "plus.png")
            };
            todoItemAdd.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new TodoItemPageCS
                {
                    BindingContext = new TodoItem()
                });
            };
            ToolbarItems.Add(todoItemAdd);


            var todoListDisplay = new ToolbarItem
            {
                Text = "List"
            };
            todoListDisplay.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };


        }


        private  List<Todo> getDemodate()
        {
            Todo todo1 = new Todo();
            todo1.type = "work";
            todo1.name = "Run anlaysis";
            todo1.time = 3;
            todo1.date = DateTime.Now.AddDays(-3);

            Todo todo2 = new Todo();
            todo2.type = "work";
            todo2.name = "Manual testing";
            todo2.time = 5;
            todo2.date = DateTime.Now.AddDays(-3);

            Todo todo3 = new Todo();
            todo3.type = "Life";
            todo3.name = "cookie";
            todo3.time = 2;
            todo3.date = DateTime.Now.AddDays(-3);


            List<Todo> todoList = new List<Todo>();
            todoList.Add(todo1);
            todoList.Add(todo2);
            todoList.Add(todo3);

            return todoList;

        }

        class Todo
        {
           public DateTime date { get; set; }
           public string type { get; set; }
            public string name { get; set; }
            public int time { get; set; }
        }
       



    }


    public class MainViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        public MainViewModel()
        {
            // Create the plot model
            var tmp = new PlotModel { Title = "Simple example", Subtitle = "using OxyPlot" };

            // Create two line series (markers are hidden by default)
            var series1 = new LineSeries { Title = "Series 1", MarkerType = MarkerType.Circle };
            series1.Points.Add(new DataPoint(0, 0));
            series1.Points.Add(new DataPoint(10, 18));
            series1.Points.Add(new DataPoint(20, 12));
            series1.Points.Add(new DataPoint(30, 8));
            series1.Points.Add(new DataPoint(40, 15));

            var series2 = new LineSeries { Title = "Series 2", MarkerType = MarkerType.Square };
            series2.Points.Add(new DataPoint(0, 4));
            series2.Points.Add(new DataPoint(10, 12));
            series2.Points.Add(new DataPoint(20, 16));
            series2.Points.Add(new DataPoint(30, 25));
            series2.Points.Add(new DataPoint(40, 5));

            // Add the series to the plot model
            tmp.Series.Add(series1);
            tmp.Series.Add(series2);

            // Axes are created automatically if they are not defined

            // Set the Model property, the INotifyPropertyChanged event will make the WPF Plot control update its content
            this.Model = tmp;
        }

        /// <summary>
        /// Gets the plot model.
        /// </summary>
        public PlotModel Model { get; private set; }
    }
}
