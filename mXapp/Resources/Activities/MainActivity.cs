﻿using Android.App;
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
        
        private SingletonSession ss = SingletonSession.Instance;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            var listView = FindViewById<ListView>(Resource.Id.listView1_main);
            var values = new List<string>();
            values =checkStaus(values);
            

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
                    case "Log Out":
                        logout();
                        
                        // Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                        break;
                    case "My Account":
                        StartActivity(typeof(Register));
                        break;
                    case "My Cart":
                        StartActivity(typeof(Cart));
                        break;
                    case "Order Status":
                        StartActivity(typeof(Status));
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

        private void logout()
        {     
            ss.IsValid = false;
            ss.token = null;
            ss.vendorID =0;
            SingletonVendor sv = SingletonVendor.Instance;
            sv.Menu = null;
            sv = null;
            StartActivity(typeof(MainActivity));
        }

        private List<string> checkStaus(List<string> values)
        {
            
            if (ss.IsValid == true) { values = createLogInValues(values); }
            else values = createLoggedOutValues(values);
            return values;
            
        }

        private List<string> createLoggedOutValues(List<string> values)
        {
            values.Add("Login");
            values.Add("Shop");
            values.Add("Register");
            values.Add("My Cart");
            return values;
        }

        private List<string> createLogInValues(List<string> values)
        {         
                values.Add("Order Status");
                values.Add("Edit Menu");
                values.Add("My account");
                values.Add("Add Menu Items");
                values.Add("Log Out");
                return values;
        }





        // Set our view from the "main" layout resource
        // SetContentView (Resource.Layout.Main);
    }
}


