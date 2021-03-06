﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities;

namespace DataAccess.DataContext
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            #region Jobs
            IList<Job> jobs = new List<Job>();

            jobs.Add(new Job() {ArabicName="محاسب",EnglishName="Accountant",Notes="" });
            jobs.Add(new Job() {ArabicName="مطور نظم",EnglishName="Software Developer",Notes="" });
            jobs.Add(new Job() {ArabicName="مدير",EnglishName="Manager",Notes="" });

            foreach (var job in jobs)
                context.Jobs.Add(job);
            #endregion

            #region IdentityTypes
            IList<IdentityType> identityTypes = new List<IdentityType>();

            identityTypes.Add(new IdentityType() { ArabicName = "جواز سفر", EnglishName = "Passport", Notes = "" });
            identityTypes.Add(new IdentityType() { ArabicName = "جنسية", EnglishName = "Nationality Card", Notes = "" });
            identityTypes.Add(new IdentityType() { ArabicName = "رقم وطني", EnglishName = "National Number", Notes = "" });

            foreach (var identityType in identityTypes)
                context.IdentityTypes.Add(identityType);
            #endregion

            #region Nationalities
            IList<Nationality> nationalities = new List<Nationality>();

            nationalities.Add(new Nationality() { ArabicName = "سوداني", EnglishName = "Sudanies", Notes = "" });
            nationalities.Add(new Nationality() { ArabicName = "مصري", EnglishName = "Egyptian", Notes = "" });
            nationalities.Add(new Nationality() { ArabicName = "سعوديي", EnglishName = "Saudian", Notes = "" });

            foreach (var nationality in nationalities)
                context.Nationalities.Add(nationality);
            #endregion

            #region Divisions
            IList<Division> divisions = new List<Division>();

            divisions.Add(new Division { ArabicName = "الشؤون القانونية", EnglishName = "Legals", Notes = "" });
            divisions.Add(new Division { ArabicName = "المكتب التنفيذي", EnglishName = "General Manager Office", Notes = "" });
            divisions.Add(new Division { ArabicName = "تقنية المعلومات", EnglishName = "IT", Notes = "" });

            foreach (var division in divisions)
                context.Divisions.Add(division);
            #endregion

            #region OrganizationTypes
            var organizationTypes = new List<OrganizationType>();

            organizationTypes.Add(new OrganizationType { ArabicName = "افراد", EnglishName = "Legals", Notes = "" });
            organizationTypes.Add(new OrganizationType { ArabicName = "عاملين", EnglishName = "General Manager Office", Notes = "" });
            organizationTypes.Add(new OrganizationType { ArabicName = "وكلاء", EnglishName = "IT", Notes = "" });

            foreach (var organizationType in organizationTypes)
                context.OrganizationTypes.Add(organizationType);
            #endregion

            #region TraineeTypes
            var traineeTypes = new List<TraineeType>();

            traineeTypes.Add(new TraineeType { Id = 1, ArabicName = "فرد", EnglishName = "Individual", Notes = "" });
            traineeTypes.Add(new TraineeType { Id = 2, ArabicName = "سوداتل", EnglishName = "Sudatel", Notes = "" });
            traineeTypes.Add(new TraineeType { Id = 3, ArabicName = "جهة إعتبارية", EnglishName = "Organization", Notes = "" });

            foreach (var traineeType in traineeTypes)
                context.TraineeTypes.Add(traineeType);
            #endregion

            #region Organizations
            var organizations = new List<Organization>();

            organizations.Add(new Organization { Id = 1, ArabicName = "الراجحي", EnglishName = "Alrajihi", Notes = "" });
            organizations.Add(new Organization { Id = 2, ArabicName = "جياد", EnglishName = "Jiad", Notes = "" });
            organizations.Add(new Organization { Id = 3, ArabicName = "زين", EnglishName = "Zain", Notes = "" });

            foreach (var organization in organizations)
                context.Organizations.Add(organization);
            #endregion

            #region Courses

            var cources = new List<Course>
            {
                new Course {CourseId = 1, ArabicName = "اكسل", EnglishName = "Excel", Notes = ""},
                new Course {CourseId = 2, ArabicName = "وورد", EnglishName = "Word", Notes = ""},
                new Course {CourseId = 3, ArabicName = "شبكات", EnglishName = "Networks", Notes = ""}
            };

            foreach (var cource in cources)
                context.Courses.Add(cource);

            #endregion

            #region Rooms

            context.Rooms.AddRange(new List<Room>
            {
                new Room {Id = 1, ArabicName = "السلام", EnglishName = "Excel", Notes = ""},
                new Room {Id = 2, ArabicName = "الطابق الاول", EnglishName = "Word", Notes = ""},
                new Room {Id = 3, ArabicName = "الطابق الثاني", EnglishName = "Networks", Notes = ""}
            });

            #endregion

            #region Teachers

            context.SaveChanges();

            context.Teachers.AddRange(new List<Teacher>
            {
                new Teacher {TeacherId = 1, ArabicFirstName = "محمد", EnglishFirstName = "mohamed",Identity = new Identity
                {
                    IdentityNumber = "123",
                    IdentityType = context.IdentityTypes.First(),
                    Nationality = context.Nationalities.First(),
                    IssueDate = DateTime.Now
                }},
                new Teacher {TeacherId = 2, ArabicFirstName = "احمد", EnglishFirstName = "ahmed",Identity = new Identity
                {
                    IdentityNumber = "456",
                    IdentityType = context.IdentityTypes.First(),
                    Nationality = context.Nationalities.First(),
                    IssueDate = DateTime.Now
                }},
            });

            #endregion

            base.Seed(context);
        }
    }
}