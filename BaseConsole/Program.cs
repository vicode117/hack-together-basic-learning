using System.Text.Json;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var scopes = new[] { "User.Read" };
var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
{
    ClientId = "",
};
Console.WriteLine($"{interactiveBrowserCredentialOptions.RedirectUri}");
var tokenCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);
Console.WriteLine($"after{interactiveBrowserCredentialOptions.RedirectUri}");


var graphClient = new GraphServiceClient(tokenCredential, scopes);

var me = await graphClient.Me.GetAsync();
var jsonStr = JsonSerializer.Serialize(me);

Console.WriteLine($"Hello {me?.DisplayName}!");
Console.WriteLine($"user object: {jsonStr}!");