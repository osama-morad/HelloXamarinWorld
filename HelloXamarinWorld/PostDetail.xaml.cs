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
    public partial class PostDetail : ContentPage
    {
        Post selectedPost;
        public PostDetail(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
        }

        private void updatePost_Clicked(object sender, EventArgs e)
        {
            this.selectedPost.Experience = experienceEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(this.selectedPost);
                if (rows > 0)
                    DisplayAlert("Success", "Travel Experience succesfullt updated", "OK");
                else
                    DisplayAlert("Failure", "Travel Experience failed to be updated", "OK");
            }
        }

        private void deletePost_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(this.selectedPost);
                if (rows > 0)
                    DisplayAlert("Success", "Travel Experience succesfullt deleted", "OK");
                else
                    DisplayAlert("Failure", "Travel Experience failed to be deleted", "OK");
            }
        }
    }
}