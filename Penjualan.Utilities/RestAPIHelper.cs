using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Net.Http.Headers;

namespace Penjualan.Utilities
{

    public class ApiUrl
    {
        public static string OrganizationUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlOrganization}/Organization/";
        public static string EmployeeUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlEmployee}/Employee/";
        public static string TimeUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlTime}/Time/";
        public static string RecruitmentUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlRecruitment}/Recruitment/";
        public static string CareerUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlCareer}/Career/";
        public static string LearningUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlLearning}/Learning/";
        public static string PayrollUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlPayroll}/Payroll/";
        public static string PerformanceUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlPerformance}/Performance/";
        public static string ReimbursementUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlReimbursement}/Reimbursement/";
        public static string CompetencyUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlCompetency}/Competency/";
        public static string LoanAdministrationUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlLoanAdministration}/LoanAdministration/";
        public static string SecurityUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlSecurity}/Security/";
        public static string SysAdminUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlSysAdmin}/SysAdmin/";
        public static string WorkflowUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlWorkflow}/Workflow/";
        public static string PenjualanUrl => $"{DataConfiguration.Configuration.AppConfiguration.ApiServerUrlPenjualan}/Product/";

    }

    public class Route
    {
        public static readonly string Get = "/Get";
        public static readonly string GetDetail = "/GetDetail";
        public static readonly string Add = "/Add";
        public static readonly string Edit = "/Edit";
        public static readonly string Delete = "/Delete";
        public static readonly string Validate = "/Validate";
        public static readonly string MaxSequenceLevel = "/MaxSequenceLevel";
        public static readonly string MaxSequenceGrade = "/MaxSequenceGrade";

        //public static Task Hi(Task a,string b)
        //{

        //    return a;
        //}

    }

    public class DataConfiguration
    {
        public static Configuration Configuration
        {
            get
            {
                string json = System.IO.File.ReadAllText("appsettings.json");
                var data = JsonConvert.DeserializeObject<Configuration>(json);
                return data;
            }
        }
    }

    public class Configuration
    {
        public AppConfiguration AppConfiguration { get; set; }
    }

    public class AppConfiguration
    {
        public string ApiServerUrlSecurity { get; set; }
        public string ApiServerUrlSysAdmin { get; set; }
        public string ApiServerUrlOrganization { get; set; }
        public string ApiServerUrlEmployee { get; set; }
        public string ApiServerUrlTime { get; set; }
        public string ApiServerUrlRecruitment { get; set; }
        public string ApiServerUrlCareer { get; set; }
        public string ApiServerUrlLearning { get; set; }
        public string ApiServerUrlPayroll { get; set; }
        public string ApiServerUrlPerformance { get; set; }
        public string ApiServerUrlReimbursement { get; set; }
        public string ApiServerUrlCompetency { get; set; }
        public string ApiServerUrlLoanAdministration { get; set; }
        public string ApiServerUrlWorkflow { get; set; }
        public string ApiServerUrlPenjualan { get; set; }
    }

    public class RestAPIHelper<T>
    {
        //public static T Submit(string jsonBody, Method httpMethod, string endpoint, HttpRequest httpRequest)
        //{

        //    var requests = new RestRequest(httpMethod);
        //    requests.AddHeader("Content-Type", "application/json");
        //    requests.AddHeader("Authorization", string.Format("Bearer " + ""));

        //    if (!string.IsNullOrEmpty(jsonBody))
        //    {
        //        requests.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
        //    }
        //    var client = new RestClient(endpoint);
        //    IRestResponse response = client.Execute(requests);

        //    var result = JsonConvert.DeserializeObject<T>(response.Content);

        //    return result;
        //}

        //public static T Submit(string jsonBody, Method httpMethod, string endpoint)
        //{
        //    var requests = new RestRequest(httpMethod);
        //    requests.AddHeader("Content-Type", "application/json");
        //    requests.AddParameter("Authorization", string.Format("Bearer " + ""), ParameterType.HttpHeader);


        //    if (!string.IsNullOrEmpty(jsonBody))
        //    {
        //        requests.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
        //    }

        //    var client = new RestClient(endpoint);
        //    IRestResponse response = client.Execute(requests);

        //    var result = JsonConvert.DeserializeObject<T>(response.Content);
        //    return result;
        //}

        public static T Submit(string jsonBody, Method httpMethod, string endpoint)
        {
            var requests = new RestRequest(httpMethod);
            requests.AddHeader("Content-Type", "application/json");
            requests.AddParameter("Authorization", string.Format("Bearer " + ""), ParameterType.HttpHeader);


            if (!string.IsNullOrEmpty(jsonBody))
            {
                requests.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            }

            var client = new RestClient(endpoint);
            IRestResponse response = client.Execute(requests);

            var result = JsonConvert.DeserializeObject<T>(response.Content);
            //var result = response.Content;
            return result;
        }
    }

    
}

