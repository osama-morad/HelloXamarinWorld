﻿using HelloXamarinWorld.Model;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                postListView.ItemsSource = Post.GetAllPosts();
                //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                //{
                //    conn.CreateTable<Post>();
                //    var experiences = conn.Table<Post>().ToList();
                //    postListView.ItemsSource = experiences;
                //}
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