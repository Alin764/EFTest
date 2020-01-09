using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MyConsoleAppTest
{
    [TestClass]
    public class AppUnitTest
    {
        public ServiceCollection Services { get; private set; }
        public ServiceProvider ServiceProvider { get; protected set; }

        [TestInitialize]
        public void Initialize()
        {
           Services = new ServiceCollection();

           Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"), 
               ServiceLifetime.Scoped, 
               ServiceLifetime.Scoped);

            ServiceProvider = Services.BuildServiceProvider();
        }

        [TestMethod]
        public void TestMethod1()
        {
            using (var dbContext = ServiceProvider.GetService<AppDbContext>())
            {
                dbContext.Person.Add(new Person { Id = 0, Name = "test1" });
                dbContext.SaveChanges();
                Assert.IsTrue(dbContext.Person.Count() == 1);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using (var dbContext = ServiceProvider.GetService<AppDbContext>())
            {
                dbContext.Person.Add(new Person { Id = 0, Name = "test2" });
                dbContext.SaveChanges();
                Assert.IsTrue(dbContext.Person.Count() == 1);
            }
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            ServiceProvider.Dispose();
            ServiceProvider = null;
        }
    }
}
