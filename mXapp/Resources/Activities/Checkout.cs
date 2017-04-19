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

namespace mXapp.Resources.Activities
{
    [Activity(Label = "Checkout")]
    public class Checkout : Activity
    {
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
            // Create your application here

            buyButton.Click += (sender, e) => {
                message.Visibility = ViewStates.Visible;
                message.Text = "Your payment has been accepted and your order has been accepted";
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
    }
}