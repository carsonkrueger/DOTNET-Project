
using MyHttpClient;

var apiClient = new ApiClient("https://localhost:7221");
var endpoint1 = "Customer/2";
var responseString = await apiClient.GetDataAsync(endpoint1);
Console.WriteLine(responseString);
