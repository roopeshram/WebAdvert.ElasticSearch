using System;
using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Nest;
using Newtonsoft.Json;
using AdvertApi.Models.Messages;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace WebAdvert.ElasticSearch
{
    
    public class SearchWorker
    {
        private readonly IElasticClient _client;

        public SearchWorker():this(ElasticSearchHelper.GetInstance(Configurationhelper.Instance))
        {

        }

        public SearchWorker(IElasticClient client)
        {
            _client = client;
        }
        public async Task Function(SNSEvent snsevent,ILambdaContext context)
        {
            foreach(var record in snsevent.Records)
            {
                context.Logger.LogLine(record.Sns.Message);
                var message = JsonConvert.DeserializeObject<AdvertConfirmedMessage>(record.Sns.Message);
                var advertdocument = MappingHelper.Map(message);
                await _client.IndexDocumentAsync(advertdocument);
            }
        }
    }
}
