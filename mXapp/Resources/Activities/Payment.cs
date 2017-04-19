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

namespace mXapp.Resources.Activities
{
    [Activity(Label = "Checkout")]
    public class Payment : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Payment);
            // Create your application here
            CustomerOrder order = new CustomerOrder();
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            var textTotal = FindViewById<TextView>(Resource.Id.textToal);
            var paymentButton = FindViewById<Button>(Resource.Id.buttonPayment);
            order = JsonConvert.DeserializeObject<CustomerOrder>(Intent.GetStringExtra("selected") ?? "Data not available");
            var data = new string[order.OrderItems.Count()];
            for (int i = 0; i <= data.Count() - 1; i++)
            {
                data[i] = " - " + order.OrderItems[i].product.productName + " " + "€" +
                    order.OrderItems[i].product.productPrice;

            }
            order.Total = 0;
            foreach (MenuItem mi in order.OrderItems) {

                order.Total = order.Total + mi.product.productPrice;
            }

            textTotal.Text ="Total Cost: €"+  order.Total.ToString();

            listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, data);
            listView.FastScrollEnabled = true;

            paymentButton.Click+= (sender, e) =>
            {
                StartActivity(typeof(Checkout));
            };
            //order.orderItems[0].

            //  foreach(Product p in object.)
        }
    }
}