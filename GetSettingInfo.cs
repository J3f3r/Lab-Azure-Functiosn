using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace laboratorio
{
    public class GetSettingInfo
    {
        private readonly ILogger<GetSettingInfo> _logger;

        public GetSettingInfo(ILogger<GetSettingInfo> logger)
        {
            _logger = logger;
        }

        [Function("GetSettingInfo")]
        public Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        [BlobInput("jeh-dio/local.settings.json", Connection ="AzureWebJobsStorage")] string blobContent)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            _logger.LogInformation($"{blobContent}");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content.Type", "text/plain; charset-utf-8");
            return Task.FromResult(response);
        }
    }
}