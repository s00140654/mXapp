using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Threading;
using mXapp.Resources.Activities;
using Android.Content;
using System;
using mXapp.Resources.layout;
using mXapp.Models;
using System.Collections.Generic;

namespace mXapp
{
    [Activity(Label = "mXapp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        static string username;
        private SingletonSession session = SingletonSession.Instance;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            var values = new List <string> {
            "Register", "Shop", "Quit", "Login", "My Cart"
            };

            if(session.IsValid == true)
            {
                
                values.Add("Order Status");
                values.Add("Edit Menu");
                values.Add("My account");
                values.Remove("Login");
                values.Add("Add Menu Items");

            }

            string[] terms = values.ToArray();
            listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, values);
            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                String selectedType = (String)(listView.GetItemAtPosition(position.Position));
                

                switch (selectedType)
                {
                    case "Login":
                        StartActivity(typeof(LogIn));
                        break;
                    case "Register":
                        StartActivity(typeof(Register));
                        break;
                    case "Shop":
                        StartActivity(typeof(ViewTypes));
                        break;
                    case "Quit":
                        Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                        break;
                    case "My Account":
                        StartActivity(typeof(Register));
                        break;
                    case "My Cart":
                        StartActivity(typeof(Cart));
                        break;
                    case "Order Status":
                        StartActivity(typeof(OrderStatus));
                        break;
                    case "Add Menu Items":
                        StartActivity(typeof(AddMenuItems));
                        break;
                        
                    case "Edit Menu":
                   StartActivity(typeof(EditMenu));
                        break;
                }
               

            };

            

        }
        


        // Set our view from the "main" layout resource
        // SetContentView (Resource.Layout.Main);
    }
}


