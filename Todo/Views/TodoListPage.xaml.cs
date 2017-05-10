using System;
using System.Diagnostics;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Todo
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);

            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = e.SelectedItem as TodoItem
            });
        }
        void StartTimeCount(object sender, EventArgs e)
        {
            //Get the start button
            Button startbtn = (Button)sender;

            //Get the parent node
            var stLayout = startbtn.Parent;

            //Find the time button
            Button timebtn = stLayout.FindByName<Button>("TimeButton");
            int IniTimeCount = Convert.ToInt32(timebtn.Text);

            if (startbtn.Text == "Start" )
            {
                startbtn.Text = "Pause";
            }
            else
            {
                //Stop count down time and save the time 
                startbtn.Text = "Start";

            }
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (startbtn.Text == "Pause")
                {
                    IniTimeCount--;
                    if (IniTimeCount < 0)
                    {
                        startbtn.Text = "Start";
                        return false;
                    }
                    timebtn.Text = IniTimeCount.ToString();
                    return true;
                }
                else return false;
            });
        }
    }
}
