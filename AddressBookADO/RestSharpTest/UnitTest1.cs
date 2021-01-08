using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTest
{
    public class EmployeePayroll
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        public IRestResponse GetEmployeePayrollList()
        {
            //arrange
            RestRequest request = new RestRequest("/EmployeePayroll", Method.GET);

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void byCallingGetApi_ReturnEmployeeList()
        {
            IRestResponse response = GetEmployeePayrollList();
            //assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<EmployeePayroll> listResponse = JsonConvert.DeserializeObject<List<EmployeePayroll>>(response.Content);
            Assert.AreEqual(14, listResponse.Count);
            foreach (EmployeePayroll e in listResponse)
            {
                System.Console.Write("id: " + e.id + "Employee Name: " + e.Name + "Salary: " + e.Salary);
            }
        }

        /// <summary>
        /// Here We adding new Employee
        /// </summary>
        [TestMethod]
        public void GivenEmployee_OnPost_ShouldReturnAddedEmployeePayroll()
        {
            RestRequest request = new RestRequest("/EmployeePayroll", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("Name", "Imran");
            jObjectbody.Add("Salary", "90000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            EmployeePayroll employee = JsonConvert.DeserializeObject<EmployeePayroll>(response.Content);
            //Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Imran", employee.Name);
            Assert.AreEqual("90000", employee.Salary);
        }
    }
}
