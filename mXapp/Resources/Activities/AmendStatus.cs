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
using mXapp.Rest;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "AmendStatus")]
    public class AmendStatus : Activity
    {
        private IRestService<Vendor> irs = new RestSevice();
        SingletonVendor sv = SingletonVendor.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CustomerOrder order = JsonConvert.DeserializeObject<CustomerOrder>(Intent.GetStringExtra("selected") ?? "Data not available");
            var products = new List<Product>();
            products = order.Products.ToList();
            var layout = new LinearLayout(this);
           
            layout.Orientation = Orientation.Vertical;
            string buttonText = "Update to ";
            var message = new TextView(this);
            var productText = new TextView(this);
            message.TextSize = 25;
            message.Text = order.CustomerDetails.customerFirstName.ToString() + "\r\n" +
                           order.CustomerDetails.customerSecondName.ToString() + "\r\n" +
                           order.CustomerDetails.customerAdressLine1.ToString() + "\r\n" +
                           order.CustomerDetails.customerPhone.ToString() + "\r\n" +
                          "Status :" +  order.Status.ToString()+ "\r\n" +
                          "Products";
            var stringProducts = new List<string>();
            if (order.Status.ToString() == "Submitted")
                buttonText = buttonText + "Accepted";
            else if (order.Status.ToString() == "InTransit")
                buttonText = buttonText + "Completed";

            var changeStatusButton = new Button(this);
            changeStatusButton.Text = buttonText;
            var backButton = new Button(this);
            backButton.Text = "Amend another?";
            backButton.Visibility = ViewStates.Invisible;

            
            string listOfProducts = null;
            layout.AddView(message);
            foreach (Product p in products)
            {
                listOfProducts = listOfProducts + p.productName.ToString() + " " + p.productPrice.ToString() + System.Environment.NewLine;     
            }
            productText.Text = listOfProducts;
            layout.AddView(productText);
            layout.AddView(changeStatusButton);
            layout.AddView(backButton);           
            SetContentView(layout);
            backButton.Click += (sender, e) =>
            {
                StartActivity(typeof(Status));
            };

            changeStatusButton.Click += (sender, e) => {
                switch (order.Status)
                {
                    case OrderStatus.Submitted:
                        order.Status = OrderStatus.Accepted;
                        break;
                    case OrderStatus.Accepted:
                        order.Status = OrderStatus.InTransit;
                        break;
                    case OrderStatus.InTransit:
                        order.Status = OrderStatus.Completed;
                        break;
                }
                string verb = "Put";
                string uri = "customerorders/" + order.ID;
                string json = JsonConvert.SerializeObject(order);
                irs.Invoke(json, uri,verb);
                message.Text = "Status of order was changed to" + buttonText;
                backButton.Visibility = ViewStates.Visible;
                changeStatusButton.Visibility = ViewStates.Invisible;
       
            };

           

        }
        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(Status));
            StartActivity(intent);
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }

    }
}