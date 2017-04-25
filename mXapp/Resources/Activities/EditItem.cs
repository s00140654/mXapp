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
using mXapp.Resources.layout;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "AddEditItem")]
    public class EditItem : Activity
    {
        private IRestService<Vendor> irs = new RestSevice();
        SingletonVendor sv = SingletonVendor.Instance;
        string tempPrice;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddEditItem);
            Product product = JsonConvert.DeserializeObject<Product>(Intent.GetStringExtra("selected") ?? "Data not available");

            var text_Id = FindViewById<TextView>(Resource.Id.text_ProductId);
            var text_Product = FindViewById<TextView>(Resource.Id.text_ProductName);
            var text_Price = FindViewById<TextView>(Resource.Id.text_ProductPrice);
            var button_Submit = FindViewById<Button>(Resource.Id.button_Submit);

            string verb = "Put";

            if (product != null) {
                verb = "Put";
                text_Id.Text = product.ID.ToString();
                text_Product.Text = product.productName.ToString();
                text_Price.Text = product.productPrice.ToString(); }

            text_Product.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                product.productName = e.Text.ToString();};
            text_Price.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
               tempPrice  = (e.Text.ToString());
            };

            string uri = "/Products/" + product.ID;
           
            
            button_Submit.Click += (IntentSender, e) => {
                product.productPrice = Convert.ToDouble(tempPrice);
                string json = JsonConvert.SerializeObject(product);
                string  p = irs.Invoke(json, uri, verb);
                //  product = JsonConvert.DeserializeObject<Product>(p);
                update(product);
                StartActivity(typeof(EditMenu));
            };

            var button = FindViewById<Button>(Resource.Id.button1);
            button.Click += (sender, e) => {
                StartActivity(typeof(MainActivity));
            };


        }

        private void update(Product product)
        {
            foreach (Product p in sv.Menu.Products) {
                if(p.ID == product.ID)
                {
                    p.productPrice = product.productPrice;
                    p.productName = product.productName;
                }
            }
           
        }
    }
}