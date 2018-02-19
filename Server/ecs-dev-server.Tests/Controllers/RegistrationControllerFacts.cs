using System;
using Xunit;
using Moq;

namespace ecs_dev_server.Tests
{
    // The Class we are testing is the outer class.
    public class RegistrationControllerFacts
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
                // Test code
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
