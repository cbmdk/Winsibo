using System;

namespace Winsibo.sensibo
{
       
    public class Api
    {
        //==========================================================================================//
        //This API wrapper is provided to enable anyone to integrate the senibo API into their own
        //application.
        //
        // By Duncan E Grant
        //==========================================================================================//
        private string apiKey = "";

        /// <summary>
        /// Initiate the connection to the sensibo web API
        /// </summary>
        public Api(string apikey)
        {
            try
            {
                // Check we have all the nessesary parameters to initiate the connection.
                if (apikey.Equals("")) {
                    throw new ArgumentNullException("apikey", "please initate with an apikey");
                }
                apiKey = apikey;
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0} parameter exception", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} general exception", e);
            }
        }

        public Pods getPods()
        {
            var sclient = new RestClient(apiKey);
            return sclient.GetPods();
        }

        public AcStatus GetPodStatus(string id)
        {
            var sclient = new RestClient(apiKey);
            return sclient.getpodstatus(id);
        }

        public Measurements GetPodMeasurments(string id)
        {
            var sclient = new RestClient(apiKey);
            return sclient.GetPodMeasurments(id);
        }
        public setResult SetStatus(string id,SetAcState state)
        {
            RestClient sclient = new RestClient(apiKey);
            return sclient.PostPodStatus(id,state);
        }


    }

}
