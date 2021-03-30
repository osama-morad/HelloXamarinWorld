using HelloXamarinWorld.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloXamarinWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    var experiences = conn.Table<Post>().ToList();
                    postListView.ItemsSource = experiences;
                }

                Need need = new Need()
                {
                    NeedType = "فلوس"
                };
                await App.MobileService.GetTable<Need>().InsertAsync(need);
            }
            catch (NullReferenceException nre)
            {

            }
            catch(Exception ex)
            {

            }
        }

        private void postListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Post selectedPost = postListView.SelectedItem as Post;
            Navigation.PushAsync(new PostDetail(selectedPost));
        }
    }
}