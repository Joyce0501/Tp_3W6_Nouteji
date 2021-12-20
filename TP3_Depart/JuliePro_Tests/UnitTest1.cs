using JuliePro.Controllers;
using JuliePro_DataAccess.Data;
using JuliePro_DataAccess.Repository;
using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace JuliePro_Tests
{
  public class Tests
  {
        private DbContextOptions<JulieProDbContext> options;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public Tests(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [SetUp]
        public void Setup()
    {
            options = new DbContextOptionsBuilder<JulieProDbContext>()
          .UseInMemoryDatabase(databaseName: "JuliePro_MasterTP3").Options;

    }

    [Test]
    public void DeleteToIndex()
    {

            // Teste si ca delete ensuite retourne a la vue index

            //Trainer untrainer = new Trainer();

            //using (var context = new JulieProDbContext(options))
            //{
            //var repository = new TrainerRepository(context);
            //repository.Remove(untrainer);
            //    Assert.AreEqual(0, repository.GetAll().Count());
            //}

            using (var context = new JulieProDbContext(options))
            {
                context.Database.EnsureDeleted();
                UnitOfWork unitofwork = new UnitOfWork(context);

                TrainerController controller = new TrainerController(unitofwork, _webHostEnvironment);

                //ViewResult result = controller.Index() as ViewResult;

                //Assert.AreEqual("Index", result.ViewName);

                var repository = new TrainerRepository(context);

                repository.Remove(unitofwork.Trainer.FirstOrDefault());

                dynamic result = controller.Index();

                Assert.AreEqual("Index", result.ViewName);



            }

    }
  }
}
