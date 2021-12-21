using JuliePro.Controllers;
using JuliePro_DataAccess.Data;
using JuliePro_DataAccess.Repository;
using JuliePro_DataAccess.Repository.IRepository;
using JuliePro_Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace JuliePro_Tests
{
  public class Tests
  {
        private DbContextOptions<JulieProDbContext> options;

        private Mock<IWebHostEnvironment> _webHostEnvironment;

        [SetUp]
        public void Setup()
    {
            _webHostEnvironment = new Mock<IWebHostEnvironment>();
            options = new DbContextOptionsBuilder<JulieProDbContext>()
          .UseInMemoryDatabase(databaseName: "JuliePro_MasterTP3").Options;
        }

    [Test]
    public void DeleteToIndex()
    {

            // Teste si ca delete ensuite retourne a la vue index

            Trainer untrainer = new Trainer();

            untrainer.Email = "Landry@google.ca";
            untrainer.FirstName = "Landry";
            untrainer.LastName = "Heyyyooo";

            using (var context = new JulieProDbContext(options))
            {

                context.Database.EnsureDeleted();

                UnitOfWork unitofwork = new UnitOfWork(context);

                TrainerController controller = new TrainerController(unitofwork, _webHostEnvironment.Object);

 
                var repository = new TrainerRepository(context);

                repository.Add(untrainer);

                repository.Save();

                var result = (RedirectToActionResult)controller.DeletePost(untrainer.Id);

                Assert.AreEqual("Index", result.ActionName);



            }

    }
  }
}
