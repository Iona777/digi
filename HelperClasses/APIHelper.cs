using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Digital.Models;
using Newtonsoft.Json;


namespace Digital.ComponentHelper
{
    class APIHelper
    {

        public static Account HTTPGetRequest(string endpointURL)
        {
            //This method does not need to use the Newtonsoft.Json.JsonConvert.DeserializeObject method.
            //Instead it uses the deserialization that is built-in to the HttpClient object.
            //This makes the method more compact. It is also newer and should be used as the default approach.
            //However, it is much stricter and so a less than perfect message may cause problems. 
            //In this case use the HTTPGetRequestDeserializeUsing method which 
            //uses the Newtonsoft.Json.JsonConvert.DeserializeObject method instead of an HttpClient object

            
            HttpClient myhttpClient = new HttpClient();

            //This creates an HttpRequestMessage for the given endpointURL. 
            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, endpointURL))
            {
                //This creates an HttpResponseMessage based on the result from the request message.
                using (HttpResponseMessage responseMessage = myhttpClient.SendAsync(requestMessage).Result)
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        //Takes the output from the responseMessage, which will be as string of Json format 
                        //and maps (deserializes) it according to the specified model class, which in this case is Account.
                        //Account is specified in the Account class in Model folder
                        Account account = responseMessage.Content.ReadAsAsync<Account>().Result;
                        return account;


                    }
                    else
                    {
                        Exception e = new Exception("HttpResponseMessage was not successful. Status code = " + responseMessage.StatusCode);
                        throw e;
                    }

                }
            }
        }

        public static Account HTTPGetRequestDeserialize(string endPointURL)
        {

            //Takes the output from responseStreamReader.ReadLine(), which will be as string of Json format 
            //and map (deserialize) it according to the specified model class, which in this case is Account.
            //Account is specified in the Account class in Model folder

            //This creates a webrequest object for the given endpointURL
            WebRequest myRequest = WebRequest.Create(endPointURL);

            //This will receive the deserialized responseString
            Account responseAccount = new Account();

            //This creates a webresponse object for the given WebRequest
            using (WebResponse response = myRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader responseStreamReader = new StreamReader(responseStream);

                    string responseString = responseStreamReader.ReadLine();
                    responseAccount = JsonConvert.DeserializeObject<Account>(responseString);
                }
            }
            return responseAccount;
        }


    }
}
