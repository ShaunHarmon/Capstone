using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;


namespace QuickCash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        CloudStorageAccount storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
        "quickcashstorage",
        "wuiAR929Q062VTEX+UYDXmN31XaxAEQLnvvIa9NVIoNYGqSXXT1ZXC1WHHdWqhP3LLvo+5aM7xZvZykQgtMHmw=="), true);


        // GET: api/Jobs
        [HttpGet]
        public async Task<IEnumerable<JobEntity>> Get()
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("jobs");

            TableQuery<JobEntity> query =
                 new TableQuery<JobEntity>()
                 .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "job"));

            List<JobEntity> jobs = new List<JobEntity>();
            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<JobEntity> resultSegment = await table.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach (JobEntity job in resultSegment.Results)
                {
                    jobs.Add(job);
                }
            } while (token != null);

            return jobs;
        }

      

        // POST: api/Jobs
        [HttpPost]
        public async Task<JobEntity> Post([FromBody] JobEntity value)
        {
            

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("jobs");
            
            
            value.PartitionKey = "job";
            TableOperation insertOperation = TableOperation.Insert(value);
            TableResult result = await table.ExecuteAsync(insertOperation);

            return result.Result as JobEntity;
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
