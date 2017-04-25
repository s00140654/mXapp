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

namespace mXapp.Helpers
{
    class MakeSingletonHelper
    {
        public Vendor MakeSingletonVendor(Vendor vendor) {
            Session S = vendor.Session;
           
            SingletonSession singletonSession = SingletonSession.Instance;
            singletonSession.IsValid = true;
            singletonSession.TimeIssued = vendor.Session.TimeIssued;
            singletonSession.IsValid = vendor.Session.IsValid;
            singletonSession.token = vendor.Session.token;
            singletonSession.vendorID = vendor.Session.vendorID;

            SingletonVendor singletonVendor = SingletonVendor.Instance;
            singletonVendor.AddressLine1 = vendor.AddressLine1;
            singletonVendor.AddressLine2 = vendor.AddressLine2;
            singletonVendor.AddressLine3 = vendor.AddressLine3;
            singletonVendor.Country = vendor.Country;
            singletonVendor.customerOrders = vendor.customerOrders;
            singletonVendor.Email = vendor.Email;
            singletonVendor.ID = vendor.ID;
            singletonVendor.Name = vendor.Name;
            singletonVendor.Password = vendor.Password;
            singletonVendor.TownCity = vendor.TownCity;
            singletonVendor.VendorType = vendor.Type;

            SingletonMenu sm = SingletonMenu.Instance;
            sm.ID = vendor.Menu.ID;
            sm.VendorID = vendor.Menu.VendorID;
            var lp = new List<Product>();
    
            foreach(Product p in vendor.Menu.Products) {
                Product sp = new Product();
                sp.ID = p.ID;
                sp.MenuId = p.MenuId;
                sp.productName = p.productName;
                sp.productPrice = p.productPrice;
                lp.Add(sp);
                }
            sm.Products = lp;
            singletonVendor.Menu = sm;

            return vendor;
        }

        public CustomerOrder makeSingletonOrder(CustomerOrder order) {
            SingletonOrder O = SingletonOrder.Instance;
            O.CustomerDetails = order.CustomerDetails;
            O.DateTime = order.DateTime;
            O.ID = order.ID;
            O.Message = order.Message;
            O.Status = order.Status;
            O.Total = order.Total;
            O.VendorId = order.VendorId;
            O.Products = order.Products;
           // O.OrderItems = order.OrderItems;

            return order;
        } 
    }
}