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
    [Activity(Label = "RegisterAsVendor")]
    public class Register : Activity
    {
        public bool registered = false;
       private IRestService<Vendor> irs = new RestSevice();
        Vendor vendor = new Vendor();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerVendorType);
            var email = FindViewById<EditText>(Resource.Id.textEmail);
            var name = FindViewById<EditText>(Resource.Id.textCompanyName);
            var password = FindViewById<EditText>(Resource.Id.textEnterPassword);
            var repeatPassword = FindViewById<EditText>(Resource.Id.textRepeatPassword);
            var add1 = FindViewById<EditText>(Resource.Id.textAdd1);
            var add2 = FindViewById<EditText>(Resource.Id.textAdd2);
            var add3 = FindViewById<EditText>(Resource.Id.textAdd3);
            var townCity = FindViewById<EditText>(Resource.Id.textTownCity);
            var phone = FindViewById<EditText>(Resource.Id.textPhone);
            var message = FindViewById<TextView>(Resource.Id.textMessage);

            Button submit = FindViewById<Button>(Resource.Id.buttonSubmit);
            // Create your application here

            var items = new List<string>();
            foreach (VendorType enums in Enum.GetValues(typeof(VendorType)))
            {
                string s = enums.ToString();
                items.Add(s);
            }
            var adapter = new ArrayAdapter<string>(this, Resource.Xml.listViewTemplate, items);
            spinner.Adapter = adapter;
            //    //    Toast.MakeText(this, "Passwords must be the same", ToastLength.Short).Show();

           
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            name.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => { vendor.Name = e.Text.ToString(); };
            password.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => { vendor.Password = e.Text.ToString(); };
            add1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => { vendor.AddressLine1 = e.Text.ToString(); };
            add2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => { vendor.AddressLine2 = add2.Text; };
            add3.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => { vendor.AddressLine3 = add3.Text; };
            townCity.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => { vendor.TownCity = townCity.Text; };
            phone.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => { vendor.Phone = phone.Text; };

            submit.Click += (sender, e) =>
            {
                Vendor v = new Vendor();
                    string json = JsonConvert.SerializeObject(vendor);
                  v = irs.SaveVendorRegistrationAsync(vendor);
                    
                    if (v != null)
                    {
                    spinner.Visibility = ViewStates.Invisible;
                        name.Visibility = ViewStates.Invisible;
                        password.Visibility = ViewStates.Invisible;
                        add1.Visibility = ViewStates.Invisible;
                        add2.Visibility = ViewStates.Invisible;
                        add3.Visibility = ViewStates.Invisible;
                        townCity.Visibility = ViewStates.Invisible;
                        phone.Visibility = ViewStates.Invisible;
                        email.Visibility = ViewStates.Invisible;
                        repeatPassword.Visibility = ViewStates.Invisible;
                        registered = true;
                       

                    }
                    if(registered == true){
                    message.Visibility = ViewStates.Visible;
                    message.Text = "You have been sucessfully registered";
                    submit.Text = "Continue to your menu";

                    StartActivity(typeof(EditMenu));
                }
                
                else {
                    message.Text = "Registration unsucessful please try again";
                    submit.Text = "Continue to your menu";
                    StartActivity(typeof(Register));
                }
                };
            
        }



    private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
    {
        Spinner spinner = (Spinner)sender;
        string s = spinner.GetItemAtPosition(e.Position).ToString();
        vendor.Type = (VendorType)Enum.Parse(typeof(VendorType), s);
    }



    


    }
}