


using Android.App;
using Android.Widget;
using Android.OS;


using Android.Net.Http;
using System.Net;

using System.Net.Http;
using System.IO;
using Android.Graphics;
using System.Json;
using Android.Util;
using Android.Text.Format;



/*...*/
using System.Threading.Tasks;
using Android.Content;


using System.Collections.Generic;




namespace App1
{
    public class activity2 : Activity
    {

    }



    [Activity(Label = "App1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;


        
        TextView txtv1;
        TextView txtv2;
        TextView tx1;
        TextView tx2;
        TextView tx3;
        TextView tx4;
        TextView tx5;
        TextView tx6;
        TextView tx7;
        TextView tx8;
        TextView tx9;
        TextView tx10;
        TextView tx11;
        TextView tx12;


        Button b2;
        ImageView view1;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);


            tx1 = FindViewById<TextView>(Resource.Id.editText1);
            tx2 = FindViewById<TextView>(Resource.Id.editText2);
            tx3 = FindViewById<TextView>(Resource.Id.editText3);
            tx4 = FindViewById<TextView>(Resource.Id.editText4);
            tx5 = FindViewById<TextView>(Resource.Id.editText5);
            tx6 = FindViewById<TextView>(Resource.Id.editText6);
            tx7 = FindViewById<TextView>(Resource.Id.editText7);
            tx8 = FindViewById<TextView>(Resource.Id.editText8);

            tx5.Text = "helo";


            // Get the latitude and longitude entered by the user and create a query.
            string url_btc = "https://api.coinmarketcap.com/v1/ticker/bitcoin/";
            string url_eth = "https://api.coinmarketcap.com/v1/ticker/ethereum/";
            string url_ltc = "https://api.coinmarketcap.com/v1/ticker/litecoin/";
            string url_xem = "https://api.coinmarketcap.com/v1/ticker/nem/";
            string url_bch   = "https://api.coinmarketcap.com/v1/ticker/bitcoin-cash/";
            string url_monero = "https://api.coinmarketcap.com/v1/ticker/monero/";
            string url_iota = "https://api.coinmarketcap.com/v1/ticker/iota/";

            JsonValue json = FetchWeatherAsync(url_btc);

            
            button.Click += delegate {

                JsonValue json1 = FetchWeatherAsync(url_btc);
                tx1.Text = "btc:" + json[0]["price_usd"].ToString();

                json1 = FetchWeatherAsync(url_eth);
                tx2.Text = "eth: " + json1[0]["price_usd"].ToString();


                json1 = FetchWeatherAsync(url_eth);
                tx3.Text = "ltc : " + json1[0]["price_usd"].ToString();


                json1 = FetchWeatherAsync(url_eth);
                tx4.Text = "nem : " + json1[0]["price_usd"].ToString();

                json1 = FetchWeatherAsync(url_bch);
                tx5.Text = "bch : " + json1[0]["price_usd"].ToString();

                json1 = FetchWeatherAsync(url_monero);
                tx6.Text = "monero : " + json1[0]["price_usd"].ToString();

                json1 = FetchWeatherAsync(url_iota);
                tx7.Text = "iota : " + json1[0]["price_usd"].ToString();



            };
        }



        private JsonValue FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            System.Net.HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create((url));

            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response =  request.GetResponseAsync().Result)
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = JsonObject.Load(stream);
                    //!! Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }
    }
}