using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using AzureAPICRUD.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureAPICRUD;

public class Employee
{
    private readonly ILogger _logger;

    public Employee(ILoggerFactory loggerFactory)
    {
       
        _logger = loggerFactory.CreateLogger<Employee>();
    }

    [Function("GetEmployees")]
    public async Task<List<Employees>> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetEmployees")] HttpRequestData req)
    {
        var _employee = new List<Employees>();
        try
        {
            string connectionString = ConfigurationReader.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"Select * from Employees";
                SqlCommand command = new SqlCommand(query, connection);
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Employees employee = new Employees()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Code = Convert.ToString(reader["Code"]),
                        FullName = Convert.ToString(reader["FullName"]),
                        DateOfBirth = Convert.ToDateTime(reader["DOB"]),
                        Address = Convert.ToString(reader["Address"]),
                        City = Convert.ToString(reader["City"]),
                        State = Convert.ToString(reader["State"]),
                        Country = Convert.ToString(reader["Country"]),
                        PostalCode = Convert.ToString(reader["PostalCode"]),
                        EmailId = Convert.ToString(reader["EmailId"]),
                        PhoneNo = Convert.ToString(reader["PhoneNo"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"])
                    };
                    _employee.Add(employee);
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
        }

        return _employee;
    }


}
