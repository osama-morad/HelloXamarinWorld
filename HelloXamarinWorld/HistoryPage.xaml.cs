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

                var allNeeds = await App.MobileService.GetTable<Needs>().ReadAsync();
                var socialStatus = await App.MobileService.GetTable<SocialStatus>().ReadAsync();

                var inNeed = await App.MobileService.GetTable<InNeed>().ReadAsync();
                var inNeedRequired = await App.MobileService.GetTable<RequiredNeed>().ReadAsync();
                var inNeedsocialStatus = await App.MobileService.GetTable<InNeedSocialStatus>().ReadAsync();
                //Needs need = new Needs()
                //{
                //    NeedType = "فلوس"
                //};
                //await App.MobileService.GetTable<Needs>().InsertAsync(need);
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