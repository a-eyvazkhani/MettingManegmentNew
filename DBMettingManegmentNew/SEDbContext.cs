using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLLMettingManegmentNew.Entity;

namespace DBMettingManegmentNew
{
    internal class SEDbContext : DbContext
    {
        public SEDbContext() : base("SamixConnectionString")
        {

        }
        public DbSet<EfMeeting> EfMeetings { get; set; }


        public DbSet<EfMeetingPlace> EfMeetingPlace { get; set; }
        public DbSet<EfMeetingTemplate> EfMeetingTemplate { get; set; }
        public DbSet<EfUnit> EfUnit { get; set; }
        public DbSet<EfAlerts> EfAlert { get; set; }
        public DbSet<EfPhoneNumbers> EfPhoneNumbers { get; set; }

        public DbSet<EfMeetingUserRel> EfMeetingUserRel { get; set; }

        public DbSet<EFMinute> EFMinute { get; set; }

        // public DbSet<EfAdmins> EfAdmins { get; set; }


        public DbSet<EfUser> EfUsers { get; set; }

        public DbSet<EfTask> EfTask { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfMeeting>().ToTable("Meetings", "MMS");
            modelBuilder.Entity<EfMeeting>().HasKey(X => X.ID);


            modelBuilder.Entity<EfMeetingPlace>().ToTable("MeetingPlaces", "MMS");
            modelBuilder.Entity<EfMeetingPlace>().HasKey(X => X.ID);

            modelBuilder.Entity<EfMeetingTemplate>().ToTable("MeetingTemplate", "MMS");
            modelBuilder.Entity<EfMeetingTemplate>().HasKey(X => X.ID);

            modelBuilder.Entity<EfUnit>().ToTable("Unit", "MMS");
            modelBuilder.Entity<EfUnit>().HasKey(X => X.ID);

            modelBuilder.Entity<EfAlerts>().ToTable("Alerts", "MMS");
            modelBuilder.Entity<EfAlerts>().HasKey(X => X.ID);

            modelBuilder.Entity<EfUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<EfUser>().HasKey(x => x.ID);

            modelBuilder.Entity<EfEmail>().ToTable("Emails", "dbo");
            modelBuilder.Entity<EfEmail>().HasKey(x => x.ID);
                                                           
            modelBuilder.Entity<EfPhoneNumbers>().ToTable("PhoneNumbers", "dbo");
            modelBuilder.Entity<EfPhoneNumbers>().HasKey(x => x.ID);


            modelBuilder.Entity<EfMeetingUserRel>().ToTable("MeetingUserRel", "MMS");
            modelBuilder.Entity<EfMeetingUserRel>().HasKey(x => x.ID);


            modelBuilder.Entity<EFMinute>().ToTable("Minutes", "MMS");
            modelBuilder.Entity<EFMinute>().HasKey(x => x.ID);


            modelBuilder.Entity<EfTask>().ToTable("Task", "MMS");
            modelBuilder.Entity<EfTask>().HasKey(x => x.ID);





            modelBuilder.Entity<EfMeeting>().HasRequired<EfUser>(x => x.Secretary).WithMany(x => x.SecretryMeetings).HasForeignKey(x => x.SecretaryUserId);
            modelBuilder.Entity<EfMeeting>().HasRequired<EfMeetingPlace>(x => x.Place).WithMany(x => x.Meeting).HasForeignKey(x => x.PlaceID);
            modelBuilder.Entity<EfPhoneNumbers>().HasRequired<EfUser>(x => x.User).
               WithMany(x => x.Mobiles).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<EfEmail>().HasRequired<EfUser>(x => x.User).
               WithMany(x => x.Emails).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<EfAlerts>().HasRequired<EfUser>(x => x.User).WithMany(x => x.Alerts).HasForeignKey(x => x.UserID);
            modelBuilder.Entity<EfAlerts>().HasRequired<EfMeeting>(x => x.Meeting).WithMany(x => x.Alerts).HasForeignKey(x => x.MeetingId);


            modelBuilder.Entity<EfMeetingUserRel>().HasRequired<EfMeeting>(x => x.Meeting).WithMany(x => x.RelatedUsers).HasForeignKey(x => x.MeetingId);
            modelBuilder.Entity<EfMeetingUserRel>().HasRequired<EfUser>(x => x.User).WithMany(x => x.MeetingUserRels).HasForeignKey(x => x.UserID);

            modelBuilder.Entity<EFMinute>().HasRequired<EfUser>(x => x.Registerer).WithMany(x => x.MinutRegisterer).HasForeignKey(x => x.RegistererID);

            modelBuilder.Entity<EfTask>().HasRequired<EfUnit>(x => x.Unit).WithMany(x => x.Task).HasForeignKey(x => x.UnitID);
            modelBuilder.Entity<EfTask>().HasRequired<EfMeeting>(x => x.Meetings).WithMany(x => x.Task).HasForeignKey(x => x.MeetingId);

            modelBuilder.Entity<EfTask>().HasRequired<EfUser>(x => x.MasolAnjam).WithMany(x => x.MasolAnjam).HasForeignKey(x => x.MasolAnjamID);

            modelBuilder.Entity<EfTask>().HasRequired<EfUser>(x => x.Aprove1).WithMany(x => x.Aprove1).HasForeignKey(x => x.Aprove1ID);





        }
    }
}
