using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Winsibo.sensibo
{
    
    class RestClient
    {
        const string Hosturl = "home.sensibo.com";
        const string BasePath = "/api/v2";
        const string Schemes = "https";
        const string Consumer = "application/json";
        const string Producer = "application/json; charset=utf-8";
        public readonly string _apikey = ""; //Enter you apikey here if you want to hard code it
        public RestClient(string apiKey)
        {
            _apikey = apiKey;
        }
        public Pods GetPods()
        {

            var request = (HttpWebRequest)WebRequest.Create(Schemes + "://" + Hosturl + BasePath + "/users/me/Pods?fields=id,room&apiKey=" + _apikey);
            request.Method = "GET"; //Set the request type to GET
            request.ContentType = Consumer;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = $"Request failed. Received HTTP {response.StatusCode}";
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                //Convert the json respons to Pods object
                var podList = JsonConvert.DeserializeObject<Pods>(responseValue);

                return podList;
            }
        }
        public AcStatus getpodstatus(string id)
        {

            var request = (HttpWebRequest)WebRequest.Create(Schemes + "://" + Hosturl + BasePath + "/Pods/"+ id  + "/acStates?fields=status,acState&limit=1&apiKey=" + _apikey);
            request.Method = "GET"; //Set the request type to GET
            request.ContentType = Consumer;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = $"Request failed. Received HTTP {response.StatusCode}";
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                //Convert the json respons to AcStatus object
                AcStatus acStatus = JsonConvert.DeserializeObject<AcStatus>(responseValue);

                return acStatus;
            }

        }
        public Measurements GetPodMeasurments(string id)
        {

            var request = (HttpWebRequest)WebRequest.Create(Schemes + "://" + Hosturl + BasePath + "/Pods/" + id + "/measurements?apiKey=" + _apikey);
            request.Method = "GET"; //Set the request type to GET
            request.ContentType = Consumer;

            var response = (HttpWebResponse)request.GetResponse();
            var responseValue = string.Empty;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                throw new ApplicationException(message);
            }

            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseValue = reader.ReadToEnd();
                    }
            }

            //Convert the json respons to AcStatus object
            Measurements mstatus = JsonConvert.DeserializeObject<Measurements>(responseValue);

            return mstatus;
        }
        public setResult PostPodStatus(string id, SetAcState targetstate)
        {

            var Jstate = new JsonAcState();
            Jstate.AcState = targetstate;

            string json = JsonConvert.SerializeObject(Jstate);
           
            var request = (HttpWebRequest)WebRequest.Create(Schemes + "://" + Hosturl + BasePath + "/Pods/" + id + "/acStates?apiKey=" + _apikey);
            request.Method = "POST"; //Set the request type to GET
            request.ContentType = Producer;
            

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
           
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseValue = string.Empty;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                throw new ApplicationException(message);
            }

            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseValue = reader.ReadToEnd();
                    }
            }

            //Convert the json respons to AcStatus object
            setResult mstatus = JsonConvert.DeserializeObject<setResult>(responseValue);
            return mstatus;
        }

    }
}
