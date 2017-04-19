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

namespace mXapp.Models
{
    public static class OrderBool
    {
        public static bool isLoggedIn;
        public static bool IsVendor;

    }
    public enum OrderStatus
    {
        Accepted, InTransit, Completed, Unsubmitted
    }

    public enum VendorType
    {
        Fuel, Food, Offsales, TableService
    }


    public class CustomerOrder
    {
        public int ID { get; set; } //Guid may be used instead of string for all ids.

        public DateTime? DateTime { get; set; }

        public double Total { get; set; }

        public string Message { get; set; }

        public OrderStatus Status { get; set; }

        public Product Vendor { get; set; }

        public CustomerDetail CustomerDetails { get; set; }

        public IList<MenuItem> OrderItems { get; set; }

       
    }

    public class Vendor
    {

        public int ID { get; set; }

        public int CustomerOrderID { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string TownCity { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public VendorType VendorType { get; set; }

        public VendorMenu Menu { get; set; }

        public Session Session { get; set; }

        public List<CustomerOrder> customerOrders { get; set; }
    }


    public class VendorMenu
    {
        public int ID { get; set; }

        public int VendorID { get; set; }

        //   public ICollection<MenuItem> menuItems { get; set; }
        public ICollection<Product> Products { get; set; }
        public VendorMenu() { }

    }

    public class MenuItem
    {
        public int ID { get; set; }

        public int VendorMenuID { get; set; }

        public int quantity { get; set; }

        public Product product { get; set; }

        public MenuItem() { }
    }

    public class Product
    {
        public int ID { get; set; }

        // public int MenuItemID { get; set; }

        public int MenuId { get; set; }

        public string productName { get; set; }

        public double productPrice { get; set; }

        public VendorType VendorType;

        public Product() { }
    }
    public class CustomerDetail
    {
        public int ID { get; set; }

        public int CustomerOrderID { get; set; }

        public string customerFirstName { get; set; }

        public string customerSecondName { get; set; }

        public string customerAdressLine1 { get; set; }

        public string customerAdressLine2 { get; set; }

        public string customerTown { get; set; }

        public string customerCounty { get; set; }

        public string eircode { get; set; }

        public string customerEmail { get; set; }

        public string customerPhone { get; set; }

    }

    
    public sealed class SingletonSession
    {
        private static SingletonSession instance = null;
        private static readonly object padlock = new object();

        public string token { get; set; }

        public int vendorID { get; set; }

        public DateTime TimeIssued { get; set; }

        public bool IsValid { get; set; }


      //  public bool LoggedIn { get; set; }

        SingletonSession()
        {
        }


        public static SingletonSession Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonSession();
                    }
                    return instance;
                }
            }
        }
    }

    public class Session
    {

        public string token { get; set; }

        public int vendorID { get; set; }

        public DateTime TimeIssued { get; set; }

        public bool IsValid { get; set; }

        // static Session() { }


    }
    
    public sealed class SingletonCart
    {
        private static SingletonCart instance = null;
        private static readonly object padlock = new object();

       

        SingletonCart()
        {
        }


        public static SingletonCart Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonCart();
                    }
                    return instance;
                }
            }
        }
    }
    public sealed class SingletonVendor
    {
        private static SingletonVendor instance = null;
        private static readonly object padlock = new object();

        public int ID { get; set; }

        public int CustomerOrderID { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string TownCity { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public VendorType VendorType { get; set; }

        public SingletonMenu Menu { get; set; }

        public Session Session { get; set; }

        public List<CustomerOrder> customerOrders { get; set; }


        SingletonVendor()
        {
        }


        public static SingletonVendor Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonVendor();
                    }
                    return instance;
                }
            }
        }
    }


    public sealed class SingletonMenu
    {
        private static SingletonMenu instance = null;
        private static readonly object padlock = new object();
        public int ID { get; set; }

        public int VendorID { get; set; }

        //   public ICollection<MenuItem> menuItems { get; set; }
        public ICollection<Product> Products { get; set; }
        
        SingletonMenu()
        {
        }
        public static SingletonMenu Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonMenu();
                    }
                    return instance;
                }
            }
        }
    }


    public sealed class SingletonProduct
    {
        private static SingletonProduct instance = null;
        private static readonly object padlock = new object();

        public int ID { get; set; }

        // public int MenuItemID { get; set; }

        public int MenuId { get; set; }

        public string productName { get; set; }

        public double productPrice { get; set; }

        public VendorType VendorType;


        SingletonProduct()
        {
        }


        public static SingletonProduct Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonProduct();
                    }
                    return instance;
                }
            }
        }
    }
    //public static class LogInDTO
    //{
    //    public static string PassWord { get; set; }

    //    public static string Email { get; set; }

    //}

}