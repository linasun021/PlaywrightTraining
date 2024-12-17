using APITestProject.Models.APIS;
using APITestProject.Models.DTOS.ResponseDTO;
using BoDi;
using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using System;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace APITestProject.StepDefinitions
{
    [Binding]
    public class PetStepDefinitions : BaseSteps
    {
        private IAPIResponse aPIResponse;
        public PetStepDefinitions(IObjectContainer objectContainer) : base(objectContainer) { }


        [Given(@"I set base url")]
        public void GivenISetBaseUrl()
        {
            
        }

        [When(@"I send request to get pet by status (.*)")]
        public void WhenISendRequestToGetPetByStatus(string petStatus)
        {
            aPIResponse = new PetAPI(apiRestquestContext).GetPetByStatus(petStatus);
        }

        [Then(@"Response status should be (.*)")]
        public void ThenResponseStatusShouldBe(int statusCode)
        {
            aPIResponse.Status.Should().Be(statusCode);
        }

        [Then(@"(.*) should be include")]
        public void ThenShouldBeInclude(string petName)
        {
            var jsonResponse = aPIResponse.JsonAsync().Result.ToString();
            List<PetDto> pets = JsonSerializer.Deserialize<List<PetDto>>(jsonResponse)!;
            pets.FirstOrDefault(pet => pet.Name == petName).Should().NotBeNull();
        }
    }
}
