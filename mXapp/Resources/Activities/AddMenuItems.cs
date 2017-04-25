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
    [Activity(Label = "Add Menu Items")]
    public class AddMenuItems : Activity
    {
        string tempPrice;
        private IRestService<Vendor> irs = new RestSevice();
        SingletonVendor sv = SingletonVendor.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            var layout = new LinearLayout(this);
            var product = new Product();
            
            layout.Orientation = Orientation.Vertical;

            EditText enterProductName = new EditText(this);
            enterProductName.Text = "Enter Product Name";
            enterProductName.TextSize = 25;
            
            
            var enterProductPrice = new EditText(this);
            enterProductPrice.Text = "Enter Product Price";
            enterProductPrice.TextSize = 25;

            var message = new TextView(this);
            message.TextSize = 15;

            

            var addButton = new Button(this);
            addButton.Text = "Add to Menu";


            var reviewButton = new Button(this);
            reviewButton.Text = "Edit Existing Items";

            layout.AddView(enterProductName);
            layout.AddView(enterProductPrice);
            layout.AddView(message);
            layout.AddView(addButton);
            SetContentView(layout);

            
            enterProductName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                product.productName = e.Text.ToString();
            };
            enterProductPrice.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                tempPrice = e.Text.ToString();
            };

           
            product.MenuId = sv.Menu.ID;
            string verb = "Post";
            string uri = "/Products/";
            addButton.Click += (sender, e) =>
            {
                product.productPrice = Convert.ToDouble(tempPrice);
                string json = JsonConvert.SerializeObject(product);
                string p = irs.Invoke(json, uri, verb);
                if (product != null)
                {
                    product = JsonConvert.DeserializeObject<Product>(p);
                    update(product);           
                    message.Text = (product.productName + ": was added sucessfully, add another or edit existing");
                    enterProductName.Text = "Enter Product Name";
                    enterProductPrice.Text = "Enter Product Price";
                    layout.AddView(reviewButton);

                }

            };


            reviewButton.Click += (sender, e) => {
                StartActivity(typeof(layout.EditMenu));
            };
            //var button = FindViewById<Button>(Resource.Id.button1);
            //button.Click += (sender, e) => {
            //    StartActivity(typeof(MainActivity));
            //};


        }

        private void update(Product product)
        {   

            sv.Menu.Products.Add(product);
           

        }
    }
}