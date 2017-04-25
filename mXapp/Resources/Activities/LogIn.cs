using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using mXapp.Models;
using Newtonsoft.Json;
using mXapp.Rest;
using mXapp.Helpers;

namespace mXapp.Resources.Activities
{
    
    [Activity(Label = "LogIn")]
    public class LogIn : Activity
    {
        static string email;
        static string password;
        private IRestService<Vendor> irs = new RestSevice();
        MakeSingletonHelper helper = new MakeSingletonHelper();
        public class LoginDTO
        {
           public string email;
           public string password;
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LogIn);

            var ùserNameTextBox = FindViewById<EditText>(Resource.Id.textUserName);
            var userNameTextView = FindViewById<TextView>(Resource.Id.textUserName);
            var passwordTextBox = FindViewById<EditText>(Resource.Id.textPassword);
            var passwordTextView = FindViewById<TextView>(Resource.Id.textPassword);
            var displayUserNameText = FindViewById<TextView>(Resource.Id.textDisplay);
            var forgottenPassword = FindViewById<TextView>(Resource.Id.textPassword);
            var logInButton = FindViewById<Button>(Resource.Id.logIn);
            var textDisplayMessage = FindViewById<TextView>(Resource.Id.textDisplayMessage);
            var forgotPass = FindViewById<Button>(Resource.Id.forgotPass);
            logInButton.Clickable = true;
            ùserNameTextBox.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                displayUserNameText.Text = e.Text.ToString();
                email = e.Text.ToString();
            };

            passwordTextBox.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                displayUserNameText.Text = e.Text.ToString();
                password = e.Text.ToString();
            };

            if (userNameTextView.Text != null && passwordTextBox.Text != null)
            {
                logInButton.Enabled = true;

            }

            forgotPass.Click += (sender, e) =>
            {
                StartActivity(typeof(ForgottenPassword));
            };

            logInButton.Click += (sender, e) =>
            {   
                if(email != null && email != null)
                {
                    logInButton.Clickable = false;
                    Thread t1 = new Thread(new ThreadStart(logIn));
                    t1.Start();
                    t1.Join();
                 
                }

                
                else textDisplayMessage.Text = "That combination does not match, please try again or click on forgotten your password";

            };
            
        }
        
        void logIn()
        {
            
            string uri = "vendors/PostByName/";
            string verb = "Post";
            LoginDTO li = new LoginDTO();
            li.password = password;
            li.email = email;
            string json = JsonConvert.SerializeObject(li);
            string v = irs.Invoke(json, uri, verb );
            //Change to async method later
            Thread.Sleep(1000);
            Vendor vendor = JsonConvert.DeserializeObject<Vendor>(v);
            SingletonVendor sv = SingletonVendor.Instance;
            
            vendor = helper.MakeSingletonVendor(vendor);
            StartActivity(typeof(MainActivity));       
        }

    }
}
//var intent = new Intent(this, typeof(ViewTypes));
//intent.PutExtra("UserName", email);
//StartActivity(intent);

//myProgressBar.Visibility = ViewStates.Gone;