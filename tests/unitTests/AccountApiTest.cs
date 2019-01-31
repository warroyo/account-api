using Xunit;
using account_api.Controllers;
using account_api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace unitTests
{
    public class AccountApiTest
    {
        public AccountApiTest()
        {
            InitContext();
        }

        private AccountDb _accountContext;
        private IConfiguration configuration;
        public void InitContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountDb>();
            optionsBuilder.UseInMemoryDatabase();

            var context = new AccountDb(optionsBuilder.Options);
            var accounts = Enumerable.Range(1, 10)
                .Select(i => new Account { Id = i,  First = $"Bob{i}", Last = "Test", Email = "bobtest@gmail.com" });
            context.AddRange(accounts);
            int changed = context.SaveChanges();
            _accountContext = context;
        }

        [Fact]
        public void TestGetAccountById()
        {
            string expectedFirst = "Bob1";
            var controller = new AccountsController(_accountContext, configuration);
            Account result = controller.Get(1);
            Assert.Equal(expectedFirst, result.First);
        }
    }
}
