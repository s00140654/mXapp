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
using mXapp.Helpers;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "Price List")]
    public class VendorsMenu : Activity
    {
        MakeSingletonHelper sh = new MakeSingletonHelper();
       // private object menuItems;
        private List<Product> basketList = new List<Product>();
       // private List<Product> items = new List<Product>();
        CustomerOrder order = new CustomerOrder();
        // double orderTotal;
       // Vendor vendor = new Vendor();
        SingletonSession ss = SingletonSession.Instance;
        SingletonVendor sv = SingletonVendor.Instance;
        SingletonOrder so = SingletonOrder.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VendorMenu);


            var totalText = FindViewById<TextView>(Resource.Id.DisplayTotal);    
            var checkOutButton = FindViewById<Button>(Resource.Id.buttonCheckout);
            var displayVendorDetails = FindViewById<TextView>(Resource.Id.displayVendorDetails);
            //if(ss != null) { vendor = JsonConvert.DeserializeObject<Vendor>(Intent.GetStringExtra("selected") ?? "Data not available");           
            // order.Vendor = vendor;
            if (so != null && so.Products != null)
            {
                basketList = so.Products.ToList();
                totalText.Text = Convert.ToString(calcbasket());
            }
            displayVendorDetails.Text = String.Format("Vendor Details\n Name : {0}\n Address : {1} "
                 , sv.Name, sv.AddressLine1);

           
            List<Product> products = new List<Product>();
            products.Select(x => x.ID).Distinct();
            foreach (Product p in sv.Menu.Products) { products.Add(p); }     
            VendorsMenu menu = new VendorsMenu();
            
            var data = new string[products.Count()];
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            for (int i = 0; i <= data.Count() - 1; i++)
            {
               data[i] = products[i].productName + " : " + System.Environment.NewLine + "€"+ products[i].productPrice + " + ";
            }


            checkOutButton.Click += (sender, e) => {
                order.Total = calcbasket();
                order.VendorId = sv.ID;
                order.Products = basketList.ToList();

              Intent intent = new Intent(this, typeof(Checkout));
             // intent.PutExtra("selected", JsonConvert.SerializeObject(order));
                sh.makeSingletonOrder(order);
                StartActivity(intent);
            };
            listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, data);
            listView.FastScrollEnabled = true;
            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                String selected = (String)(listView.GetItemAtPosition(position.Position));
                int idx = selected.IndexOf(" :");
                selected = selected.Substring(0, idx).Trim();           
                Product selectedProduct = new Product();
                products = products.Distinct().ToList();
                foreach (Product se in products)
                {
                    if (se.productName == selected)
                    basketList.Add(se);              
                }
                totalText.Text = Convert.ToString(calcbasket());
            };
        }

        private double  calcbasket()
        {
            double tot = 0;
            foreach (Product p in basketList){tot = tot + p.productPrice; }
            return tot;
        }

        public override void OnBackPressed()
        {
            so.Products = null;
            so = null;
            sv = null;
           
            StartActivity(typeof(ViewTypes));
        }
    }


}
//string selectedEvent = Intent.GetStringExtra("selectedEvent") ?? "Data not available";
// Product pr = ps.Where(p => p.productName.ToString() == selected);
// int x = ss.vendorID;
//    var displayUserName = FindViewById<TextView>(Resource.Id.editTextUserName);
//displayUserName.Text = "You are logged in as Gerry";
//      orderTotal = (orderTotal + se.productPrice);   
//    totalText.Text = "OrderTotal: " + orderTotal.ToString();
// var products = MockData.products.Where(v => v.VendorType == vendor.Type);
//products = vendor.Menu.Products;
//var menuItemList = new List<MenuItem>();
// menu.menuItems = menuItemList          
//foreach (Product p in products) {
//    var menuItem = new Product();
//    menuItem.product = p;
//    menuItemList.Add(menuItem);
//}

//  List<Product> ps = products.ToList();

//foreach (Product p in basketList) {
// //   Product M = new Product();
//    //   M.product = p;
//    order.Products.Add(p);
//    }
// order.Products = items;
