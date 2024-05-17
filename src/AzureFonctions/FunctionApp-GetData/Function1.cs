using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using TimHanewich.OData;
using System.Threading.Tasks;

namespace FunctionApp_GetData
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Odate/{table}")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            HttpRequestMessageFeature util = new HttpRequestMessageFeature(req.HttpContext);
            HttpRequestMessage reqmsg = util.HttpRequestMessage;

            ODataOperation op = ODataOperation.Parse(reqmsg);

            if (op.Operation == DataOperation.Create)
            {
                string sqlcmd = op.ToSql(); //Creates the "INSERT INTO ..." SQL query
                using SqlConnection sqlcon = new SqlConnection("");
                await sqlcon.OpenAsync();
                using SqlCommand cmd = new SqlCommand(sqlcmd, sqlcon);

                //Execute (upload)
                await cmd.ExecuteNonQueryAsync();

                //Close the connection
                sqlcon.Close();

                //Respond w/ 201 CREATED (success)
                return new StatusCodeResult((int)HttpStatusCode.Created);
            }

            //Return bad request if it was not a create operation
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }
    }
}
