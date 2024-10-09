using System;
using Amazon;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace HelloWorldGetStoreParameter;

static class Program
{
    static void Main(string[] args)
    {
        var region = RegionEndpoint.USEast1;

        var ssmClient = new AmazonSimpleSystemsManagementClient(region);

        var parameterName = "connectionstring-dev";

        var request = new GetParameterRequest
        {
            Name = parameterName,
            WithDecryption = false
        };

        var response = ssmClient.GetParameterAsync(request)
            .GetAwaiter()
            .GetResult();

        var result = response.Parameter.Value;
        Console.WriteLine($"Value is {result}");
    
    }
}
