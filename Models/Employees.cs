using System.Text.Json.Serialization;

namespace AzureAPICRUD.Models;

public class Employees
{
    [JsonPropertyName("id")]
    public int Id
    {
        get;
        set;
    }

    [JsonPropertyName("code")]
    public string Code
    {
        get;
        set;
    }

    [JsonPropertyName("fullName")]
    public string FullName
    {
        get;
        set;
    }

    [JsonPropertyName("dateOfBirth")]
    public DateTime DateOfBirth
    {
        get;
        set;
    }

    public string Address
    {
        get;
        set;
    }
    public string City
    {
        get;
        set;
    }
    public string State
    {
        get;
        set;
    }
    public string PostalCode
    {
        get;
        set;
    }
    public string Country
    {
        get;
        set;
    }
    public string PhoneNo
    {
        get;
        set;
    }
    public string EmailId
    {
        get;
        set;
    }
    public DateTime JoiningDate
    {
        get;
        set;
    }
}
