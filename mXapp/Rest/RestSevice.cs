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
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static mXapp.Resources.Activities.LogIn;

namespace mXapp.Rest
{
    public class RestSevice : IRestService<Vendor>
    {
       
        string url = "http://192.168.1.11:52123/api/";
        //""http://192.168.1.11:52123/api/Vendors/";

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Vendor SaveVendorRegistrationAsync(Vendor vendor)
        {
            string json = JsonConvert.SerializeObject(vendor);
            string result;
            url = url + "Vendors/";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "Post";
            byte[] bytes = UTF8Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            using (var resp = request.GetResponse())
            {
                result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                //  result = JObject.Parse(results);
            }
            Vendor v = new Vendor();
            v = JsonConvert.DeserializeObject<Vendor>(result);
            return v;


        }

       
        public string Invoke(string json, string uri, string verb )
        {   
            
            url = url + uri;
           // url = "http://192.168.1.11:52123/api/Vendors/PostByName";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = verb;
            string result;
            byte[] bytes = UTF8Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;
            //GetByName http://192.168.1.11:52123/api/vendors/PostByName/
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            using (var resp = request.GetResponse())
            {
                result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                //  result = JObject.Parse(results);
            }

            return result;
        }

       

        
        public string GetById(string ur)
        {
            url = url + ur;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "Get";
            string result;
         
            //GetByName http://192.168.1.11:52123/api/vendors/PutByName/
            
            using (var resp = request.GetResponse())
            {
                result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                //  result = JObject.Parse(results);
            }

            return result;
        }

        public Vendor LogIn(Vendor t)
        {
            throw new NotImplementedException();
        }

         public Product LogIn(LoginDTO dto) {
            
            return null;
        }



        
    }
}