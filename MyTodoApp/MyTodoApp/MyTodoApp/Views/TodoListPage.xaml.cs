using MyTodoApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTodoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ((App)App.Current).ResumeAtTodoId = 1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
        private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }

    
}