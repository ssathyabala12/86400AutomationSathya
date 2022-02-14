using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomation.Tests
{
    public class TestExpectations
    {
        public TestExpectations()
        {
            Validations = new List<Func<IRestResponse, string>>();
        }
        public List<Func<IRestResponse, string>> Validations { get; }
        public string Validate(IRestResponse response)
        {
            if (response == null) return "Response should not be null!";

            var errorMessages = new List<string>();

            foreach (var check in Validations)
            {
                var error = check.Invoke(response);

                if (error != null) errorMessages.Add(error);
            }

            return errorMessages.Count > 0 ? string.Join(Environment.NewLine, errorMessages) : null;
        }
    }
}
