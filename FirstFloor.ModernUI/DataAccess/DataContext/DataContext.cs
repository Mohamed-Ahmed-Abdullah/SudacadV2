﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities;

namespace DataAccess.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new DbInitializer());
            Database.Connection.ConnectionString = @"Server=(LocalDB)\v11.0;Database=Sudacad;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=180";
        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<IdentityType> IdentityTypes { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<TraineeSudatel> TraineesSudatel { get; set; }
        public DbSet<TraineeOrganizations> TraineesOrganizations { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<TraineeType> TraineeTypes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCource> TeacherCources { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<BatchOrganization> BatchOrganizations { get; set; }
        public DbSet<BatchTrainee> BatchTrainees { get; set; }

        //Accounting tables

    }
}