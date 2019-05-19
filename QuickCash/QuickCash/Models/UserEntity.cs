using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

public class UserEntity : TableEntity
{
    public UserEntity(string userName)
    {
        this.PartitionKey = "user";
        this.RowKey = userName;
    }

    public UserEntity() { }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}
