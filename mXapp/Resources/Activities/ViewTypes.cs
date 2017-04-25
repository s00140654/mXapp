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
using mXapp.Models;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "ViewTypes")]
    public class ViewTypes : Activity
    {
        SingletonVendor sv = SingletonVendor.Instance;
        SingletonOrder so = SingletonOrder.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewTypes);
            sv = null;
            so = null;
            string username = Intent.GetStringExtra("UserName") ?? "Data not available";
            var displayUserNameText = FindViewById<TextView>(Resource.Id.ViewUserName);
         //   displayUserNameText.Text = "You are logged in as Gerry
            var listView = FindViewById<ListView>(Resource.Id.listView1);
             Array values = Enum.GetValues(typeof(VendorType));
            
           
          listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, values);
            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                String selectedType = (String)(listView.GetItemAtPosition(position.Position));
                Intent intent = new Intent(this, typeof(ViewVendors));
                intent.PutExtra("selected", selectedType);
                StartActivity(intent);

            };

        }
        // Create your application here
    }
    }
