using RestSharp;

namespace ApiTestingDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        Console.WriteLine("--- Request Started ---");
    }

    [Test]
    public void TestSingleUser()
    {
        var client = new RestClient("https://reqres.in/");
        var request = new RestRequest("/api/users/2");
        var response = client.Get(request);

        Console.WriteLine($"Body GET METHOD: {response.Content}");

        int reponseStatusCode = (int)response.StatusCode;
        Assert.That(reponseStatusCode == 200);
        Assert.IsNotNull(response.Content);
    }

    [Test]
    public void TestUpdate()
    {
        var client = new RestClient("https://reqres.in/");
        var request = new RestRequest("/api/users/2");
        request.AddBody(new
        {
            name = "morpheus",
            job = "zion resident"
        });
        var response = client.Put(request);

        Console.WriteLine($"Body PUT METHOD: {response.Content}");

        int reponseStatusCode = (int)response.StatusCode;
        Assert.That(reponseStatusCode == 200);
        Assert.IsNotNull(response.Content);
    }

    [Test]
    public void TestRegisterSuccessful()
    {
        var client = new RestClient("https://reqres.in/");
        var request = new RestRequest("/api/register");
        request.AddBody(new
        {
            email = "eve.holt@reqres.in",
            password = "pistol"
        });
        var response = client.Post(request);

        Console.WriteLine($"Body POST METHOD: {response.Content}");
        Console.WriteLine("Register Successful");

        int reponseStatusCode = (int)response.StatusCode;
        Assert.That(reponseStatusCode == 200);
        Assert.IsNotNull(response.Content);
    }

    [Test]
    public void TestLoginSuccessful()
    {
        var client = new RestClient("https://reqres.in/");
        var request = new RestRequest("/api/login");
        request.AddBody(new
        {
            email = "eve.holt@reqres.in",
            password = "cityslicka"
        });
        var response = client.Post(request);

        Console.WriteLine($"Body POST METHOD: {response.Content}");
        Console.WriteLine("Login Successful");

        int reponseStatusCode = (int)response.StatusCode;
        Assert.That(reponseStatusCode == 200);
        Assert.IsNotNull(response.Content);
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("--- Request Finished ---");
    }
}