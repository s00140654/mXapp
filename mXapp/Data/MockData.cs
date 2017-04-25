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

namespace mXapp.Data
{
    class MockData
    {
     public static  List<CustomerDetail> customers = new List<CustomerDetail>
            {
                new CustomerDetail {ID = 1 , customerFirstName = "Tom" , customerSecondName = "Lee" , customerAdressLine1 = "1 Main St", customerTown = "Sligo", customerEmail = "Tom@gb.com", customerPhone ="0876097874"},
                 new CustomerDetail {ID = 2, customerFirstName = "Tommy" , customerSecondName = "Fee" , customerAdressLine1 = "11 Main St", customerTown = "Sligo", customerEmail = "Tom1@gb.com", customerPhone ="0876094574"},
                  new CustomerDetail {ID = 3, customerFirstName = "Jom" , customerSecondName = "Snee" , customerAdressLine1 = "110 Main St", customerTown = "Sligo", customerEmail = "Tom2@gb.com", customerPhone ="0876015874"},
                   new CustomerDetail {ID = 4, customerFirstName = "Mom" , customerSecondName = "Leahy" , customerAdressLine1 = "1A Main St", customerTown = "Sligo", customerEmail = "Tom2@gb.com", customerPhone ="0876041474"},
                   new CustomerDetail {ID = 1,customerFirstName = "Mammy" , customerSecondName = "Leahy" , customerAdressLine1 = "1A Main St",customerAdressLine2 = "Blah", customerTown = "Sligo",customerCounty = "Sligo", eircode = "1250", customerEmail = "Tom2@gb.com", customerPhone ="0876041474"}
            };


    public static List<Vendor> vendors = new List<Vendor> {
              new Vendor {ID = 1, Name = "Boneys Coal", AddressLine1 = "1 Sligo Retail Park",TownCity = "Sligo" ,Type = VendorType.Fuel },
               new Vendor {ID = 1, Name = "Coal + Turf", AddressLine1 = "2 Sligo Retail Park",TownCity = "Sligo" ,Type = VendorType.Fuel },
                new Vendor {ID = 1, Name = "Sligo Fuel", AddressLine1 = "11 Collooney Retail Park",TownCity = "Sligo" ,Type = VendorType.Fuel },
                 new Vendor {ID = 1, Name = "Hot Stuff Fuel", AddressLine1 = "1 Ceveragh Park",TownCity = "Sligo" ,Type = VendorType.Fuel },
              new Vendor {ID= 2, Name = "Beer Co", AddressLine1 = "2 Sligo Retail Park",TownCity = "Sligo" ,Type = VendorType.Offsales },
              new Vendor {ID = 3, Name = "Food Co", AddressLine1 = "3 Sligo Retail Park",TownCity = "Sligo" ,Type = VendorType.Food },
              new Vendor {ID = 4, Name = "Cocktail Bar", AddressLine1 = "Rockwood Parade",TownCity = "Sligo" ,Type = VendorType.TableService },
            };
       


     //public static List<OrderItem> products = new List<OrderItem>
     //       {
     //           new OrderItem {ID = 1 , productName = "Slack 40 KG", productPrice = 19.99, VendorType= VendorType.Fuel },
     //            new OrderItem {ID = 2, productName = "Coal 40 KG", productPrice = 19.99, VendorType = VendorType.Fuel },
     //             new OrderItem {ID = 3,productName = "Chicken Curry", productPrice = 9.99, VendorType = VendorType.Food },
     //              new OrderItem {ID = 4, productName = "Sirloin Steak 40 KG", productPrice = 29.99, VendorType = VendorType.TableService },
     //               new OrderItem {ID = 5,productName = "24 Cans of Carlsberg", productPrice = 29.99, VendorType = VendorType.Offsales },
     //                new OrderItem {ID = 6, productName = "Fries", productPrice = 2.55, VendorType = VendorType.Food },
     //                   new OrderItem {ID = 7, productName = "Vodaka Screwdriver", productPrice = 7.55, VendorType = VendorType.TableService },
     //                      new OrderItem { ID = 8, productName = "6 pk of Stella Artois", productPrice = 2.55, VendorType = VendorType.Offsales },
     //                      new OrderItem {ID = 9, productName = "Onion Rings", productPrice = 2.55, VendorType =VendorType.Food },
     //                      new OrderItem {ID = 10,productName = "Martini", productPrice = 8.55, VendorType= VendorType.TableService }

     //       };

        //var menuItems = new List<MenuItem> {
        //    new MenuItem { VendorMenuID = 1, quantity = 1 },
        //    new MenuItem { VendorMenuID = 1, quantity = 1 },
        //    new MenuItem { VendorMenuID  = 3, quantity = 1 },
        //    new MenuItem { VendorMenuID = 4 , quantity = 1 },
        //    new MenuItem { VendorMenuID  = 2, quantity = 1 },
        //    new MenuItem { VendorMenuID = 3 , quantity = 1},
        //    new MenuItem { VendorMenuID  = 1, quantity = 1 },
        //    new MenuItem { VendorMenuID  = 1, quantity = 1 },
        //};
        //menuItems.ForEach(m => context.MenuItms.Add(m));
        //context.SaveChanges();

        //var vendorMenus = new List<VendorMenu>
        //{
        //   new VendorMenu  {ID = 1,VendorID = 1 },
        //   new  VendorMenu  {ID = 2,VendorID = 2 },
        //   new VendorMenu  {ID = 3,VendorID = 3 },
        //   new VendorMenu  {ID = 4,VendorID = 4 }

        //};
        //    vendorMenus.ForEach(m => context.VendorMenus.Add(m));

     //public static  List<CustomerOrder> orders = new List<CustomerOrder>
     //       {
     //           new CustomerOrder {  Status = OrderStatus.Completed, Message = "message", OrderItems =
     //           new List<MenuItem> {new MenuItem {product = new OrderItem { ID = 1, productName = "Slack 40 KG ", productPrice = 19.99 }, quantity = 1, VendorMenuID = 1 } } },
     //           new CustomerOrder { Status = OrderStatus.InTransit, OrderItems =
     //          new List<MenuItem> {new MenuItem {product = new OrderItem { ID = 3, productName = "Chicked curry ", productPrice = 9.99 }, quantity = 1, VendorMenuID = 3 } } },
     //           new CustomerOrder { Status = OrderStatus.InTransit, OrderItems =
     //         new List<MenuItem> {new MenuItem {product = new OrderItem { ID = 1, productName = "Martini ", productPrice = 9.99, }, quantity = 1, VendorMenuID = 4 } } },
     //           new CustomerOrder { Status = OrderStatus.Accepted, OrderItems =
     //         new List<MenuItem> {new MenuItem {product = new OrderItem { ID = 1, productName = "6 Pk Guinness ", productPrice = 19.99,  }, quantity = 1, VendorMenuID = 2 } } },
     //       };
        

    }

}