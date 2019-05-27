using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

public class JobEntity : TableEntity
{

    public JobEntity(string description)
    {
        this.PartitionKey = "job";
        this.RowKey = description;
    }

    public JobEntity() { }
    public string Title { get; set; }
    public string Description { get; set; }
  
    
}
