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
    public class UsersController : ControllerBase
               
    {
        CloudStorageAccount storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
        "quickcashstorage",
        "wuiAR929Q062VTEX+UYDXmN31XaxAEQLnvvIa9NVIoNYGqSXXT1ZXC1WHHdWqhP3LLvo+5aM7xZvZykQgtMHmw=="), true);
        //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        //CloudConfigurationManager.GetSetting("wuiAR929Q062VTEX+UYDXmN31XaxAEQLnvvIa9NVIoNYGqSXXT1ZXC1WHHdWqhP3LLvo+5aM7xZvZykQgtMHmw=="));

        //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        //    ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);



        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<UserEntity>> Get()
        {

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("users");

            TableQuery<UserEntity> query =
                 new TableQuery<UserEntity>()
                 .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "user"));

            List<UserEntity> users = new List<UserEntity>();
            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<UserEntity> resultSegment = await table.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach (UserEntity user in resultSegment.Results)
                {
                    users.Add(user);
                }
            } while (token != null);

            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserEntity> Get(string userName)
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("users");

            TableOperation retrieveOperation = TableOperation.Retrieve<UserEntity>("user", userName);
            TableResult result = await table.ExecuteAsync(retrieveOperation);

            return result.Result as UserEntity;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<UserEntity> Post([FromBody] UserEntity value)
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("users");

            //UserEntity user1 = new UserEntity("user");
            value.PartitionKey = "user";
            TableOperation insertOperation = TableOperation.Insert(value);
            TableResult result = await table.ExecuteAsync(insertOperation);

            return result.Result as UserEntity;
        }

        // PUT: api/Users/5
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
