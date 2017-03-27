﻿using Promact.Trappist.DomainModel.DbContext;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Promact.Trappist.Repository.Tests;
using System.Linq;
using Promact.Trappist.DomainModel.Models.Test;

using Xunit;
using System.Threading.Tasks;

namespace Promact.Trappist.Test.Tests
{
    [Collection("Register Dependency")]
    public class TestsRepositoryTest
    {
        private readonly Bootstrap _bootstrap;
        private readonly ITestsRepository _testRepository;
        private readonly TrappistDbContext _trappistDbContext;

        public TestsRepositoryTest(Bootstrap bootstrap)
        {
            _bootstrap = bootstrap;
            //resolve dependency to be used in tests
            _trappistDbContext = _bootstrap.ServiceProvider.GetService<TrappistDbContext>();
            _testRepository = _bootstrap.ServiceProvider.GetService<ITestsRepository>();
            ClearDatabase.ClearDatabaseAndSeed(_trappistDbContext);

        }
        /// <summary>
        /// Test Case For Not Empty Test Model
        /// </summary>
        [Fact]
        public async Task GetAllTest()
        {
            AddTest();
            var list = await _testRepository.GetAllTestsAsync();
            Assert.NotNull(list);
            Assert.Equal(3, list.Count);
        }
        /// <summary>
        /// Test Case For Emtpty Test Model
        /// </summary>
        [Fact]
        public async Task GetAllTestEmpty()
        {
            var list = await _testRepository.GetAllTestsAsync();
            Assert.Equal(0, list.Count);
        }
        public void AddTests()
        {
            _trappistDbContext.Test.Add(new DomainModel.Models.Test.Test() { TestName = "BBIT 123" });
            _trappistDbContext.Test.Add(new DomainModel.Models.Test.Test() { TestName = "MCKV 123" });
            _trappistDbContext.Test.Add(new DomainModel.Models.Test.Test() { TestName = "CU 123" });
            _trappistDbContext.SaveChanges();
        }
        /// <summary>
        /// Test Case for adding a new test
        /// </summary>
        [Fact]
        private void AddTest()
        {
            var test = CreateTests();
            _testRepository.CreateTest(test);
            Assert.True(_trappistDbContext.Test.Count() == 1);
        }
        /// <summary>
        /// Test  Case to create a new test when the test name given is unique
        /// </summary>
        [Fact]
        public async void UniqueNameTest()
        {
            var test = CreateTests();
            _testRepository.CreateTest(test);
            Response response = new Response();
            var name = "nameOfTest";
            var newTest = CreateTests();
            response = await _testRepository.IsTestNameUnique(name);
            Assert.True(response.ResponseValue);
        }
        /// <summary>
        /// Test Case to check when test name is not unique, new test is not added .
        /// </summary>
        [Fact]
        public async void IsNotUniqueNameTest()
        {
            var test = CreateTests();
             _testRepository.CreateTest(test);
            Response response = new Response();
            var name = "Test name";
            response = await _testRepository.IsTestNameUnique(name);
            Assert.False(response.ResponseValue);
        }
        /// <summary>
        /// Test Case for random link creation
        /// </summary>
        [Fact]
        public void RandomLinkStringTest()
        {
            var test = CreateTests();
            _testRepository.CreateTest(test);
            _testRepository.RandomLinkString(test, 10);
            Assert.True(_trappistDbContext.Test.Count() == 1);
        }
        private DomainModel.Models.Test.Test CreateTests()
        {
            var test = new DomainModel.Models.Test.Test
            {
                TestName = "test name",
            };
            return test;
        }
    }
}