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
using mXapp.Resources.Activities;
using mXapp.Models;
using mXapp.Rest;
using Newtonsoft.Json;


namespace mXapp.Resources.layout
{
    [Activity(Label = "Edit_Menu")]
    public class EditMenu : Activity
    {
    //    Product vendor = new Product();
        string uri;
        VendorMenu  menu = new VendorMenu();
        List<MenuItem> menuItems = new List<MenuItem>();
        Product product = new Product();
        
        SingletonSession session = SingletonSession.Instance;
        private IRestService<Vendor> irs = new RestSevice();
        protected override void OnCreate(Bundle savedInstanceState)
        {            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditMenu);
            var button = FindViewById<Button>(Resource.Id.button1);
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            uri = "/Vendors/" + session.vendorID;
            string v = irs.GetById(uri);
            //   menu.VendorID = session.vendorID;
           
           List<Product> products = new List<Product>();

            Vendor vendor = JsonConvert.DeserializeObject<Vendor>(v);

            var productss = from p in vendor.Menu.Products
                          select p;
            foreach (Product p in vendor.Menu.Products) { products.Add(p);}

            var data = new string[products.Count];
            
            for (int i = 0; i <= data.Count() - 1; i++)
            {
                data[i] =    products[i].productName.ToString()+" : " + System.Environment.NewLine
                      + "€" + products[i].productPrice.ToString();
            }
            listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, data);

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                string selected = (string)(listView.GetItemAtPosition(position.Position));
                Product selectedProduct = new Product();            
                int idx = selected.IndexOf(" :");
                selected = selected.Substring(0, idx).Trim();

                foreach (Product se in products)
                {
                    if (se.productName == selected) selectedProduct = se;
                }
                Intent intent = new Intent(this, typeof(EditItem));
                intent.PutExtra("selected", JsonConvert.SerializeObject(selectedProduct));

                StartActivity(intent);
            };       
            button.Click += (sender, e) => {
                StartActivity(typeof(MainActivity));
            };         
        }
    }
}
// menuItem.product = product;
//menu.menuItems = menuItems;
//vendor.vendorMenu = menu;
//menu.menuItems = menuItems;
//     vs =  JsonConvert.DeserializeObject<List<Product>>(v);
// vs = JsonConvert.DeserializeObject<List<Vendor>>(v);
//       menuItems = (JsonConvert.DeserializeObject(v));
//     menu = JsonConvert.DeserializeObject<VendorMenu>(v);

//dynamic vv = JsonConvert.DeserializeObject<List<MenuItem>>(v);
//tv.setFocusable(true);
//tv.setEnabled(true);
//tv.setClickable(true);
//tv.setFocusableInTouchMode(true);
