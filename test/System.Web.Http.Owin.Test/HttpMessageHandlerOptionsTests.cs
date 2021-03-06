﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Hosting;
using Microsoft.TestCommon;
using Moq;
using Moq.Protected;

namespace System.Web.Http.Owin
{
    public class HttpMessageHandlerOptionsTests
    {
        [Fact]
        public void MessageHandlerGet_ReturnsSpecifiedInstance()
        {
            // Arrange
            HttpMessageHandlerOptions product = CreateProductUnderTest();

            using (HttpMessageHandler expectedMessageHandler = CreateDummyMessageHandler())
            {
                product.MessageHandler = expectedMessageHandler;

                // Act
                HttpMessageHandler messageHandler = product.MessageHandler;

                // Assert
                Assert.Same(expectedMessageHandler, messageHandler);
            }
        }

        [Fact]
        public void BufferPolicySelectorGet_ReturnsSpecifiedInstance()
        {
            // Arrange
            HttpMessageHandlerOptions product = CreateProductUnderTest();
            IHostBufferPolicySelector expectedBufferPolicySelector = CreateDummyBufferPolicy();
            product.BufferPolicySelector = expectedBufferPolicySelector;

            // Act
            IHostBufferPolicySelector bufferPolicy = product.BufferPolicySelector;

            // Assert
            Assert.Same(expectedBufferPolicySelector, bufferPolicy);
        }

        [Fact]
        public void ExceptionLoggerGet_ReturnsSpecifiedInstance()
        {
            // Arrange
            HttpMessageHandlerOptions product = CreateProductUnderTest();
            IExceptionLogger expectedExceptionLogger = CreateDummyExceptionLogger();
            product.ExceptionLogger = expectedExceptionLogger;

            // Act
            IExceptionLogger exceptionLogger = product.ExceptionLogger;

            // Assert
            Assert.Same(expectedExceptionLogger, exceptionLogger);
        }

        [Fact]
        public void ExceptionHandlerGet_ReturnsSpecifiedInstance()
        {
            // Arrange
            HttpMessageHandlerOptions product = CreateProductUnderTest();
            IExceptionHandler expectedExceptionHandler = CreateDummyExceptionHandler();
            product.ExceptionHandler = expectedExceptionHandler;

            // Act
            IExceptionHandler exceptionHandler = product.ExceptionHandler;

            // Assert
            Assert.Same(expectedExceptionHandler, exceptionHandler);
        }

        private static IHostBufferPolicySelector CreateDummyBufferPolicy()
        {
            return new Mock<IHostBufferPolicySelector>(MockBehavior.Strict).Object;
        }

        private static IExceptionHandler CreateDummyExceptionHandler()
        {
            return new Mock<IExceptionHandler>(MockBehavior.Strict).Object;
        }

        private static IExceptionLogger CreateDummyExceptionLogger()
        {
            return new Mock<IExceptionLogger>(MockBehavior.Strict).Object;
        }

        private static HttpMessageHandler CreateDummyMessageHandler()
        {
            Mock<HttpMessageHandler> mock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mock.Protected().Setup("Dispose", ItExpr.IsAny<bool>());
            return mock.Object;
        }

        private static HttpMessageHandlerOptions CreateProductUnderTest()
        {
            return new HttpMessageHandlerOptions();
        }
    }
}
