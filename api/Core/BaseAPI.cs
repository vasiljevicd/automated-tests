
using System.Runtime.InteropServices;
using api.Config;
using RestSharp;

namespace api
{
	public class BaseAPI
	{
		public RestClient client;
		public RestRequest restRequest;
		public string resource;
		public Method method;
        public string contentType;

		public BaseAPI()
		{
            this.client = new RestClient(Configuration.baseUrl);
        }



        public RestRequest CreateRequest([Optional] object body)
		{
            var request = new RestRequest(resource, method);

                request.AddHeader("Content-Type", contentType);

            if (body != null)
			{
				request.RequestFormat = DataFormat.Json;
                request.AddBody(body);
			}

            return request;

        }

        public RestRequest CreateRequestWithQueryParams(Dictionary<string, string> queryParams)
        {
            var request = new RestRequest(resource, method);
            if (contentType != "")
            {
                request.AddHeader("Content-Type", contentType);
            }

            if (queryParams != null)
            {
                foreach (var queryParam in queryParams)
                {
                    request.AddQueryParameter(queryParam.Key, queryParam.Value);
                }
            }

            return request;

        }

        public RestRequest CreateRequestUploadFile(string pathToFile)
        {
            var request = new RestRequest(resource, method);
          
             request.AddHeader("Content-Type", contentType);
             request.AddFile("file", pathToFile, "text/plain");
      
            return request;

        }
    }
}

