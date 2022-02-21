// See https://aka.ms/new-console-template for more information

using System.Text.Json.Nodes;
using IdentityModel.Client;

Console.WriteLine("Hello, World!");

var client = new HttpClient();
var discovery = await client.GetDiscoveryDocumentAsync("https://localhost:5001");

if (discovery.IsError)
{
    Console.WriteLine($"Error while retrieving discovery document : {discovery.Error}");
    return;
}

var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
{
    Address = discovery.TokenEndpoint,
    ClientId = "myClient",
    ClientSecret = "mySecret",
    Scope = "myApi",
});

if (tokenResponse.IsError)
{
    Console.WriteLine($"Error while retrieving token : {tokenResponse.Error}");
    return;
}

Console.WriteLine(tokenResponse.Json);

var myApiHttpClient = new HttpClient();
myApiHttpClient.SetBearerToken(tokenResponse.AccessToken);

var myApiResponse = await myApiHttpClient.GetAsync("https://localhost:6001/mySecure");
if (myApiResponse.IsSuccessStatusCode)
{
    var content = await myApiResponse.Content.ReadAsStringAsync();
    Console.WriteLine(JsonArray.Parse(content));
}
else
{
    Console.WriteLine(myApiResponse.StatusCode);
}