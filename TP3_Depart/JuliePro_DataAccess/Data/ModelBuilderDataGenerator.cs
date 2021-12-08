using JuliePro_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Data
{
  public static class ModelBuilderDataGenerator
  {
    public static void GenerateData(this ModelBuilder builder)
    {
      #region Données pour Speciality
      builder.Entity<Speciality>().HasData(new Speciality() { Id = 1, Name = "Perte de poids" });
      builder.Entity<Speciality>().HasData(new Speciality() { Id = 2, Name = "Course" });
      builder.Entity<Speciality>().HasData(new Speciality() { Id = 3, Name = "Althérophilie" });
      builder.Entity<Speciality>().HasData(new Speciality() { Id = 4, Name = "Réhabilitation" });
      #endregion

      #region Données pour Trainer
      builder.Entity<Trainer>().HasData(new Trainer() { Id = 1, FirstName = "Chrysal", LastName = "Lappierre", Email = "Chrystal.lapierre@juliepro.ca", Speciality_Id = 1, Photo = "8624af64-2685-459a-a1cc-816c0695d760.png", Active = true });
      builder.Entity<Trainer>().HasData(new Trainer() { Id = 2, FirstName = "Félix", LastName = "Trudeau", Email = "Felix.trudeau@juliePro.ca", Speciality_Id = 2, Photo = "a202bae3-e6bb-40f0-84cf-e4b11627ba1c.png", Active = true });
      builder.Entity<Trainer>().HasData(new Trainer() { Id = 3, FirstName = "François", LastName = "Saint-John", Email = "Frank.StJohn@juliepro.ca", Speciality_Id = 1, Photo = "aedd9532-1395-42a2-8ae6-56f0e2ab49b5.png", Active = false });
      builder.Entity<Trainer>().HasData(new Trainer() { Id = 4, FirstName = "Jean-Claude", LastName = "Bastien", Email = "JC.Bastien@juliepro.ca", Speciality_Id = 4, Photo = "d7bcc6d9-0599-42aa-8305-3c1ae5a4505c.png", Active = true });
      builder.Entity<Trainer>().HasData(new Trainer() { Id = 5, FirstName = "Jin Lee", LastName = "Godette", Email = "JinLee.godette@juliepro.ca", Speciality_Id = 3, Photo = "E3Rcc6d9-0599-42aa-8305-3c1ae5a4512v.png", Active = true });
      builder.Entity<Trainer>().HasData(new Trainer() { Id = 6, FirstName = "Karine", LastName = "Lachance", Email = "Karine.Lachance@juliepro.ca", Speciality_Id = 2, Photo = "b333bae3-e6bb-40f0-84cf-e4b11627ba1c.png", Active = true });
      builder.Entity<Trainer>().HasData(new Trainer() { Id = 7, FirstName = "Ramone", LastName = "Esteban", Email = "Ramone.Esteban@juliepro.ca", Speciality_Id = 3, Photo = "waqd9532-1395-42a2-8ae6-56f0e2ab49e9.png", Active = false });
      #endregion

      #region Données pour Training
      builder.Entity<Training>().HasData(new Training() { Id = 1, Name = "Step", Category = "Cardio" });
      builder.Entity<Training>().HasData(new Training() { Id = 2, Name = "Yoga", Category = "Étirement" });
      builder.Entity<Training>().HasData(new Training() { Id = 3, Name = "CrossFit", Category = "Musculaire" });
      builder.Entity<Training>().HasData(new Training() { Id = 4, Name = "Course", Category = "Cardio" });
      builder.Entity<Training>().HasData(new Training() { Id = 5, Name = "Zumba", Category = "Cardio" });
      builder.Entity<Training>().HasData(new Training() { Id = 6, Name = "Spinning", Category = "Musculaire" });
      builder.Entity<Training>().HasData(new Training() { Id = 7, Name = "Taichi", Category = "Étirement" });
      #endregion

      #region Données pour Customer
      builder.Entity<Customer>().HasData(new Customer() { Id = 1, FirstName = "Arthur", LastName = "Laroche", Email = "arthurLaroche@gmail.com", BirthDate = new DateTime(1965, 10, 04, 00, 00, 00), Photo = "", Trainer_Id = 3});
      #endregion

      #region Données pour Objective
      builder.Entity<Objective>().HasData(new Objective() { Id = 1, Name = "", LostWeight = 5, DistanceKm = 0, AchievedDate = new DateTime(2021, 09, 01, 00, 00, 00), Customer_Id =1 });
      builder.Entity<Objective>().HasData(new Objective() { Id = 2, Name = "", LostWeight = 5, DistanceKm = 0, AchievedDate = new DateTime(2021, 10, 01, 00, 00, 00), Customer_Id = 1 });
      builder.Entity<Objective>().HasData(new Objective() { Id = 3, Name = "", LostWeight = 5, DistanceKm = 0, Customer_Id = 1 });

      #endregion

      #region Données pour Equipment
      builder.Entity<Equipment>().HasData(new Equipment() { Id = 1, @Name = "Vélo" });
      builder.Entity<Equipment>().HasData(new Equipment() { Id = 2, @Name = "Ensemble dumbels" });
      builder.Entity<Equipment>().HasData(new Equipment() { Id = 3, @Name = "Tapis" });
      builder.Entity<Equipment>().HasData(new Equipment() { Id = 4, @Name = "Step" });
      builder.Entity<Equipment>().HasData(new Equipment() { Id = 5, @Name = "Ensemble barre altère" });
      builder.Entity<Equipment>().HasData(new Equipment() { Id = 6, @Name = "Bloc yoga" });
      builder.Entity<Equipment>().HasData(new Equipment() { Id = 7, @Name = "Elastiques" });
      builder.Entity<Equipment>().HasData(new Equipment() { Id = 8, @Name = "Ballon d'exercice" });
      #endregion

      #region Données pour TrainingEquipment
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 1, Equipment_Id = 4 });
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 1, Equipment_Id = 7 });
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 2, Equipment_Id = 3 });
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 2, Equipment_Id = 6 });
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 3, Equipment_Id = 2 });
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 3, Equipment_Id = 5 });
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 3, Equipment_Id = 4 });
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 6, Equipment_Id = 1 });
      builder.Entity<TrainingEquipment>().HasData(new TrainingEquipment() { Training_Id = 2, Equipment_Id = 8 });
      #endregion

      #region Données pour ScheduledSession
      //builder.Entity<ScheduledSession>().HasData(new ScheduledSession() { Id = 1, Description = "", Date = new DateTime(2021, 11, 04, 19, 00, 00), DurationMin = 60, WithTrainer = false, Complete = false, CustomerId = 1, TrainingId = 1 });
      #endregion


      #region Données pour Certification
      //builder.Entity<Certification>().HasData(new Certification() { Id = 1, Title = "Niveau Bronze" });
      //builder.Entity<Certification>().HasData(new Certification() { Id = 2, Title = "Niveau Argent" });
      //builder.Entity<Certification>().HasData(new Certification() { Id = 3, Title = "Niveau Or" });
      //builder.Entity<Certification>().HasData(new Certification() { Id = 4, Title = "Niveau Élite" });
      #endregion

      #region Données pour Category
      builder.Entity<Category>().HasData(new Category() { Id = 1, CategoryName = "Compétition" });
      builder.Entity<Category>().HasData(new Category() { Id = 2, CategoryName = "Certification" });
      builder.Entity<Category>().HasData(new Category() { Id = 3, CategoryName = "Levée de fonds" });
      #endregion

      #region Données pour Event
      builder.Entity<CalendarEvent>().HasData(new CalendarEvent() { Id = 1, Description = "Niveau Bronze", Date = new DateTime(2021, 11, 20, 00, 00, 00), Category_Id = 2 });
      builder.Entity<CalendarEvent>().HasData(new CalendarEvent() { Id = 2, Description = "Cross Fit  Bahamas", Date = new DateTime(2022, 01, 28, 00, 00, 00), Category_Id = 1 });
      builder.Entity<CalendarEvent>().HasData(new CalendarEvent() { Id = 3, Description = "Zumba-Thon", Date = new DateTime(2022, 02, 03, 00, 00, 00), Category_Id = 3 });
      builder.Entity<CalendarEvent>().HasData(new CalendarEvent() { Id = 4, Description = "Trialthon", Date = new DateTime(2022, 01, 08, 00, 00, 00), Category_Id = 1 });
      builder.Entity<CalendarEvent>().HasData(new CalendarEvent() { Id = 5, Description = "Niveau Argent", Date = new DateTime(2021, 12, 26, 00, 00, 00), Category_Id = 2 });
      #endregion

    }
  }
}

