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
using mXapp.Rest;
using Newtonsoft.Json;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "Order Status")]
    public class Status : Activity
    {
      
        private IRestService<Vendor> irs = new RestSevice();
        SingletonVendor sv = SingletonVendor.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Status);

            if(SingletonVendor.Instance == null) { StartActivity(typeof(MainActivity));}

            List<CustomerOrder> orderList = new List<CustomerOrder>();
            var listView = FindViewById<ListView>(Resource.Id.listView1_status);
         
            var selected = new CustomerOrder();
            string uri = "customerorders?customerid=" + SingletonVendor.Instance.ID;
            string json = irs.GetById(uri) ;
            orderList = JsonConvert.DeserializeObject<List<CustomerOrder>>(json);
            orderList.RemoveAll(o => o.CustomerDetails == null);
            orderList = orderList.Where(o => o.Status != OrderStatus.Completed).ToList();
            orderList = orderList.Where(o => o.VendorId == sv.ID).ToList();
            orderList = orderList.Where(p => p.DateTime.HasValue).OrderBy(p => p.DateTime.Value).ToList();
            orderList.RemoveAll(o => o.CustomerDetails == null);
            //for(int i = 0; i <= orderList.Count-1; i++)
            //{
            //    if (orderList[i].CustomerDetails == null) { orderList.Remove(orderList[i]); }
            //}
            var data = new string[orderList.Count];
            for (int i = 0; i <= orderList.Count - 1; i++) {
                    if (orderList[i].CustomerDetails != null && orderList[i].CustomerDetails.ID != 0 && orderList[i].CustomerDetails.customerAdressLine1.ToString() != null)
                data[i] = orderList[i].CustomerDetails.ID.ToString() + " : "+ String.Format("{0:d/M/yy HH:mm}", orderList[i].DateTime)+ System.Environment.NewLine
                        + orderList[i].CustomerDetails.customerAdressLine1.ToString() + System.Environment.NewLine
                        + orderList[i].Status.ToString();
                    
            }

            var data1 = data.ToList();
     //       foreach(string s in data1) { if (s == null) data1.Remove(s); }

            data1.RemoveAll(i => i == null);

            listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, data1);
            
            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                string selectedOrder = (string)(listView.GetItemAtPosition(position.Position));
                var order = new CustomerOrder();
                int idx = selectedOrder.IndexOf(" :");
                selectedOrder = selectedOrder.Substring(0, idx).Trim();


                foreach (CustomerOrder se in orderList)
                {
                    if (se.ID.ToString() == selectedOrder)
                        order = se;
                }
                Intent intent = new Intent(this, typeof(AmendStatus));
                intent.PutExtra("selected", JsonConvert.SerializeObject(order));

                StartActivity(intent);


            };

        }

        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }
    }
}