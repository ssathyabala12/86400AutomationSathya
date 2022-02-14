using ApiAutomation.Extensions;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using ApiAutomation.Extensions;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Serialization.Json;

namespace ApiAutomation.Tests
{
    public class EndpointTest
    {
        #region Constructors

        public class TestPostEndPoint
        {
            private string authenticationHeader = ConfigurationManager.AppSettings["PetById.Endpoint"];

            [TestCase("1")]
            [TestCase( "2" )]
            public void FindPetById(string petId)
            {
              
                RestClient client = new RestClient(authenticationHeader);
               
                RestRequest request = new RestRequest(petId, Method.POST);

                IRestResponse response = client.Execute(request);
               
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
              

            }
            [TestCase("2", "teste")]
            public void UpdatePetNameById(string petId, string expectedName)
            {               
                RestClient client = new RestClient(authenticationHeader);

                RestRequest getRequest = new RestRequest(petId, Method.GET);
                IRestResponse getResponse = client.Execute(getRequest);
                PetDataResponce petDataResponce = new JsonSerializer().Deserialize<PetDataResponce>(getResponse);

                
                Assert.That(petDataResponce.Name, Is.EqualTo(expectedName));
            }
            #endregion
     }  }
 }
