using Xamarin.Forms;
using System.Collections.Generic;
using System;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
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




            var plotView = new PlotView();

            // Set our view from the "main" layout resource
            //SetContentView (Resource.Layout.Main);
            var modelP1 = new PlotModel { Title = "work Time analyze by Name" };
            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 1.8, AngleSpan = 360, StartAngle = 0 };

            seriesP1.Slices.Add(new PieSlice("Manual Tesitng", 10) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            seriesP1.Slices.Add(new PieSlice("Automation Testing", 26) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Bug handing", 5) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Communicate", 6) { IsExploded = true });
            seriesP1.Slices.Add(new PieSlice("Imprvoement", 8) { IsExploded = true });

            modelP1.Series.Add(seriesP1);
            plotView.Model = modelP1;
        
            this.AddContentView(plotView, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));



        }







    }


}
