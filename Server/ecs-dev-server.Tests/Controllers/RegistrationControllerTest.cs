using System;
using Xunit;
using Moq;
using ecs_dev_server.Services;
using ecs_dev_server.Models;
using ecs_dev_server.DTOs;

namespace ecs_dev_server.Tests
{
    // The Class we are testing is the outer class.
    public class RegistrationControllerTest
    {
        // Methods are inner classes
        public class SayHelloMethod
        {
            // The cases are the void methods with Arrange, Act, Assert
            [Fact]
            public void ReturnsStringHello()
            {
                // Arrange

                // Act

                // Assert
            }

        }

        public class SendSSOInfoMethod
        {
            [Fact]
            public void ConvertDTOToJson()
            {
                SSOAccountRegistrationDTO sSOAccountDTO = new SSOAccountRegistrationDTO();
                var x = JsonConverterService.SerializeObject(sSOAccountDTO);
                
            }

            [Fact]
            public void RequestToSSOController()
            {

            }

            [Fact]
            public void SaveRegisteredUserToDatabase()
            {
                // Test code
            }

            [Fact]
            public void ReturnHttpStatusCode()
            {
                // Test code
            }
        }

        public class ReceiveSSOInfoMethod
        {

        }

    }
}
