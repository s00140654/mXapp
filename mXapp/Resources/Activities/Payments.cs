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
using mXapp.Rest;
using mXapp.Models;
using Newtonsoft.Json;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "Payments")]
    public class Payments : Activity
    {
        
        SingletonOrder so = SingletonOrder.Instance;
        private IRestService<Vendor> irs = new RestSevice();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Checkout);
            var textFName = FindViewById<EditText>(Resource.Id.textFName);
            var textLName = FindViewById<EditText>(Resource.Id.textLName);
            var textExp = FindViewById<EditText>(Resource.Id.textExpiry);
            var textCVV = FindViewById<EditText>(Resource.Id.textCVV);
            var textAdd1 = FindViewById<EditText>(Resource.Id.textAdd1);
            var textAdd2 = FindViewById<EditText>(Resource.Id.textAdd2);
            var textAdd3 = FindViewById<EditText>(Resource.Id.textAdd3);
            var buyButton = FindViewById<Button>(Resource.Id.buttonBuy);
            var message = FindViewById<TextView>(Resource.Id.textMessage);
            var textCard = FindViewById<TextView>(Resource.Id.textCardnumber);
            CustomerOrder order = new CustomerOrder();

            textExp.Text = "06/19";
            textCVV.Text = "487";
            textAdd1.Text = "1 Main St";
            textAdd2.Text = "Maugherboy";
            textAdd3.Text = "Sligo";
            textCard.Text = "4319449845678985";

            textFName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                order.CustomerDetails.customerFirstName = e.Text.ToString();
            };
            textLName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
              order.CustomerDetails.customerSecondName = e.Text.ToString();
            };
            CustomerDetail cd = new CustomerDetail();
            order.Status = OrderStatus.Submitted;
            order.VendorId = so.VendorId;
            order.Total = so.Total;
            order.Products = so.Products;
            order.VendorId = so.VendorId;
            cd.customerFirstName = "John";
            cd.customerSecondName = "Doe";
            cd.customerAdressLine1 = "1 Main Street";
            cd.customerAdressLine2 = "Maugheraboy";
            cd.customerTown = "Sligo";
            order.CustomerDetails = cd;
            
            buyButton.Click += (sender, e) => {
                string json = JsonConvert.SerializeObject(order);
                string verb = "Post";
                string uri = "customerorders";
                json = irs.Invoke(json, uri, verb);
                order = JsonConvert.DeserializeObject<CustomerOrder>(json);

              
                message.Visibility = ViewStates.Visible;
                if (order != null) { message.Text = String.Format("Your payment of {0} has been accepted and your order has been placed", order.Total); }
                else message.Text = String.Format("Boo Hoo Hoo,  your order has not been placed");
                textFName.Visibility = ViewStates.Invisible;
                textLName.Visibility = ViewStates.Invisible;
                textExp.Visibility = ViewStates.Invisible;
                textCVV.Visibility = ViewStates.Invisible;
                textAdd1.Visibility = ViewStates.Invisible;
                textAdd2.Visibility = ViewStates.Invisible;
                textAdd3.Visibility = ViewStates.Invisible;
                textCard.Visibility = ViewStates.Invisible;
                buyButton.Visibility = ViewStates.Invisible;

            };

        }

        public override void OnBackPressed()
        {
           
            StartActivity(typeof(Checkout));
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }
    }
}