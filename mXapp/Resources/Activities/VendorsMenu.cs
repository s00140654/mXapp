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
using mXapp.Data;
using Newtonsoft.Json;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "Price List")]
    public class VendorsMenu : Activity
    {
        private object menuItems;
        private List<Product> basketList = new List<Product>();
        private List<MenuItem> orderItems = new List<MenuItem>();
        CustomerOrder order = new CustomerOrder();
        double orderTotal;

       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VendorMenu);
            var totalText = FindViewById<TextView>(Resource.Id.DisplayTotal);

            Vendor vendor = new Vendor();
            //string selectedEvent = Intent.GetStringExtra("selectedEvent") ?? "Data not available";
            SingletonSession ss = SingletonSession.Instance;
           // int x = ss.vendorID;
        //    var displayUserName = FindViewById<TextView>(Resource.Id.editTextUserName);
            var checkOutButton = FindViewById<Button>(Resource.Id.buttonCheckout);
            //displayUserName.Text = "You are logged in as Gerry";

            vendor = JsonConvert.DeserializeObject<Vendor>(Intent.GetStringExtra("selected") ?? "Data not available");
           // order.Vendor = vendor;

            var displayVendorDetails = FindViewById<TextView>(Resource.Id.displayVendorDetails);

            displayVendorDetails.Text = String.Format("Vendor Details\n Name : {0}\n Address : {1} "
                 , vendor.Name, vendor.AddressLine1);

            var products = MockData.products.Where(v => v.VendorType == vendor.VendorType);
            
            VendorsMenu menu = new VendorsMenu();
            var menuItemList = new List<MenuItem>();
            menu.menuItems = menuItemList;
            

            foreach (Product p in products) {
                var menuItem = new MenuItem();
                menuItem.product = p;
                menuItemList.Add(menuItem);

            }

           List<Product> ps = products.ToList();
            var data = new string[products.Count()];
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            for (int i = 0; i <= data.Count() - 1; i++)
            {
               data[i] = ps[i].productName + " : " + System.Environment.NewLine + "€"+ ps[i].productPrice + " + ";
            }


            checkOutButton.Click += (sender, e) => {
                order.Total = orderTotal;
                foreach (Product p in basketList) {
                    MenuItem M = new MenuItem();
                    M.product = p;
                    orderItems.Add(M);
                    }
                order.OrderItems = orderItems;
               
                Intent intent = new Intent(this, typeof(Payment));
                intent.PutExtra("selected", JsonConvert.SerializeObject(order));

                StartActivity(intent);

            };


            listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, data);
            listView.FastScrollEnabled = true;
            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                String selected = (String)(listView.GetItemAtPosition(position.Position));
                int idx = selected.IndexOf(" :");
                selected = selected.Substring(0, idx).Trim();

                // Product pr = ps.Where(p => p.productName.ToString() == selected);
                Product selectedProduct = new Product();
                
                foreach (Product se in ps)
                {
                    if (se.productName == selected)
                    basketList.Add(se);
                    orderTotal = (orderTotal + se.productPrice);
                 
                }

                totalText.Text = "OrderTotal: " + orderTotal.ToString();

            };

            

        }
        
    }
}