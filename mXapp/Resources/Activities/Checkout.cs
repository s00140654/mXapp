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
using Newtonsoft.Json;
using mXapp.Helpers;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "Checkout")]
    public class Checkout : Activity
    {
        SingletonOrder so = SingletonOrder.Instance;
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Payment);
           
            CustomerOrder order = new CustomerOrder();
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            var textTotal = FindViewById<TextView>(Resource.Id.textToal);
            var paymentButton = FindViewById<Button>(Resource.Id.buttonPayment);
          //  order = JsonConvert.DeserializeObject<CustomerOrder>(Intent.GetStringExtra("selected") ?? "Data not available");
            

          //  var orderItems = so.OrderItems;
            var data = new string[so.Products.Count()];
            for (int i = 0; i <= data.Count() - 1; i++)
            {
                data[i] = so.Products[i].productName + " : " + "€" +
                    so.Products[i].productPrice+ " - ";
            }
            so.Total = 0;
            foreach (Product mi in so.Products) {

                so.Total = so.Total + mi.productPrice;
            }

            textTotal.Text ="Total Cost: €"+ so.Total.ToString();

            listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, data);
            listView.FastScrollEnabled = true;

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                String selected = (String)(listView.GetItemAtPosition(position.Position));
                int idx = selected.IndexOf(" :");
          
                selected = selected.Substring(0, idx).Trim();
                MenuItem selectedProduct = new MenuItem();

                //foreach (MenuItem mi in order.OrderItems)
                //{
                //    if (mi.product.productName == selected)
                      

                //}

                for (int i = 0; i <= so.Products.Count() - 1; i++) {
                    if (so.Products[i].productName == selected) {
                        so.Products.Remove(so.Products[i]);
                        StartActivity(typeof(Checkout));
                    }
                }


               // totalText.Text = Convert.ToString(calcbasket());
            };

            paymentButton.Click+= (sender, e) =>
            {
                StartActivity(typeof(Payments));
            };


            //order.orderItems[0].

            //  foreach(Product p in object.)
        }

        public override void OnBackPressed()
        {
            StartActivity(typeof(VendorsMenu));
        }
    }
}