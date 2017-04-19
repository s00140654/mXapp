using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using mXapp.Models;
using static mXapp.Resources.Activities.LogIn;

namespace mXapp.Rest
{
    public interface IRestService<T> : IDisposable
    {
        Vendor SaveVendorRegistrationAsync(Vendor vendor);
        Vendor LogIn(T t);
        string Invoke(string json, string uri, string verb);
        string GetById(string  ur);

    }
}