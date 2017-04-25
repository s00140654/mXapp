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
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using mXapp.Models;
using mXapp.Data;
using mXapp.Rest;
using mXapp.Helpers;

namespace mXapp.Resources.Activities
{
    [Activity(Label = "ViewVendors")]
    public class ViewVendors : Activity
    {
        MakeSingletonHelper helper = new MakeSingletonHelper();
        //MakeSingletonHelper sh = new MakeSingletonHelper();
        SingletonVendor sv = SingletonVendor.Instance;
        SingletonOrder so = SingletonOrder.Instance;

        private IRestService<Vendor> irs = new RestSevice();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewVendors);
            sv = null;
            so = null;

       //     var displayUserNameText = FindViewById<TextView>(Resource.Id.ViewUserName);
      //      displayUserNameText.Text = "You are logged in as Gerry";

            string username = Intent.GetStringExtra("UserName") ?? "Data not available";

            string vendorType = Intent.GetStringExtra("selected") ?? "Data not available";
            List<Vendor> editedList = new List<Vendor>();
            List<Vendor> items = new List<Vendor>();

            string uri = "vendors/";

            string json = irs.GetById(uri);
            items = JsonConvert.DeserializeObject<List<Vendor>>(json);

            foreach (Vendor v in items)
            {
                string c = Convert.ToString(v.Type);
                if (c == vendorType)
                    editedList.Add(v);

                editedList.Count();
            }
            var data = new string[editedList.Count];
            var listView = FindViewById<ListView>(Resource.Id.listView1);

            

            for (int i = 0; i <= data.Count() - 1; i++)
            {
                data[i] = editedList[i].Name.ToString() + " : " + System.Environment.NewLine + editedList[i].AddressLine1.ToString();
            }
            

            listView.Adapter = new ArrayAdapter(this, Resource.Xml.listViewTemplate, data);
            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs position)
            {
                string selectedVendorName = (string)(listView.GetItemAtPosition(position.Position));
                Vendor selectedVendor = new Vendor();
                //List<Competitors> eventCompetitors = new List<Competitors>();

                //selectedSportsEvent.competitors = eventCompetitors;


                int idx = selectedVendorName.IndexOf(" :");

                selectedVendorName = selectedVendorName.Substring(0, idx).Trim();


                foreach (Vendor se in editedList)
                {
                    if (se.Name == selectedVendorName)selectedVendor  = se;
                    uri = uri + selectedVendor.ID;
                    string vjson = irs.GetById(uri);
                    selectedVendor = JsonConvert.DeserializeObject<Vendor>(vjson);


                }
                Intent intent = new Intent(this, typeof(VendorsMenu));
                intent.PutExtra("selected", JsonConvert.SerializeObject(selectedVendor));

               StartActivity(intent);

                helper.MakeSingletonVendor(selectedVendor);
               // StartActivity(typeof(ViewTypes));

            };
        }

       
    }
}

   
