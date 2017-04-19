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
    [Activity(Label = "Forgotten Password")]
    public class ForgottenPassword : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FogottenPassword);
            var submitPasswordRequest = FindViewById<Button>(Resource.Id.submitPasswordRequest);
            var textRequestPassword = FindViewById<TextView>(Resource.Id.textRequestPassword);
            var textSubmitPasswordRequest = FindViewById<EditText>(Resource.Id.textSubmitPasswordRequest);

            submitPasswordRequest.Click += (sender, e)=>{
                textRequestPassword.Text = "Your new password has been sent to your email address";
                textSubmitPasswordRequest.Text = "";
            };
            // Create your application here
        }
    }
}