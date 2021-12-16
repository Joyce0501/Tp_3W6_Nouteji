using JuliePro_DataAccess.Data;
using JuliePro_DataAccess.Repository;
using JuliePro_Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace JuliePro_DataAccess_Tests
{
   
    public class Tests
  {

        private DbContextOptions<JulieProDbContext> options;
        
        [SetUp]

      
        public void Setup()
    {
            options = new DbContextOptionsBuilder<JulieProDbContext>()
           .UseInMemoryDatabase(databaseName: "JuliePro_MasterTP3").Options;
     }

    [Test]
    public void TestAjoutTrainer()
    {
            //                Arrange


            //                Act

            Trainer untrainer = new Trainer();

            untrainer.Email = "Landry@google.ca";
            untrainer.FirstName = "Landry";
            untrainer.LastName = "Heyyyooo";

            using (var context = new JulieProDbContext(options))
            {
                var repository = new TrainerRepository(context);
                repository.Add(untrainer);
                repository.Save();
                Trainer trainer1 = repository.FirstOrDefault();
                Assert.AreEqual("Landry@google.ca", trainer1.Email);
                Assert.AreEqual("Landry", trainer1.FirstName);
                Assert.AreEqual("Heyyyooo", trainer1.LastName);
                //Assert.AreEqual(1, repository.GetAll().Count());
            }
         

            //                Assert

          
    }
        [Test]
        public void TestTrainerActive()
        {
            //                Arrange


            //                Act

            Trainer trainer = new Trainer();
            Trainer trainer1 = new Trainer();
            Trainer trainer2 = new Trainer();
          
            trainer.Email = "Vivien@google.ca";
            trainer.FirstName = "Vivien";
            trainer.LastName = "Heyyy";
            trainer.Active = true;
          

            trainer1.Email = "Joyce@google.ca";
            trainer1.FirstName = "Joyce";
            trainer1.LastName = "okayy";

            trainer2.Email = "Marc@google.ca";
            trainer2.FirstName = "Marc";
            trainer2.LastName = "ooouuiii";

          
            using (var context = new JulieProDbContext(options))
            {
                context.Database.EnsureDeleted();
                var repository = new TrainerRepository(context);
                repository.Add(trainer);
                repository.Add(trainer1);
                repository.Add(trainer2);
                repository.Save();
                IEnumerable<Trainer> TrainerList = repository.GetAllActive();
                Assert.AreEqual(1, TrainerList.Count());
            }


            //                Assert


        }
    }
}