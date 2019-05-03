namespace BITCollege_KS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        GPAStateId = c.Int(nullable: false),
                        ProgramId = c.Int(),
                        StudentNumber = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 35),
                        LastName = c.String(nullable: false, maxLength: 35),
                        Address = c.String(nullable: false, maxLength: 35),
                        City = c.String(nullable: false, maxLength: 35),
                        Province = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        GradePointAverage = c.Double(),
                        OutstandingFees = c.Double(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.GPAStates", t => t.GPAStateId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId)
                .Index(t => t.GPAStateId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        ProgramAcronym = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProgramId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.Long(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        Grade = c.Double(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(),
                        CourseNumber = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        CreditHours = c.Double(nullable: false),
                        TuitionAmount = c.Double(nullable: false),
                        Notes = c.String(),
                        AssignmentWeight = c.Double(),
                        MidtermWeight = c.Double(),
                        FinalWeight = c.Double(),
                        MaximumAttempts = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Programs", t => t.ProgramId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.GPAStates",
                c => new
                    {
                        GPAStateId = c.Int(nullable: false, identity: true),
                        LowerLimit = c.Double(nullable: false),
                        UpperLimit = c.Double(nullable: false),
                        TuitionRateFactor = c.Double(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.GPAStateId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "ProgramId" });
            DropIndex("dbo.Registrations", new[] { "CourseId" });
            DropIndex("dbo.Registrations", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "ProgramId" });
            DropIndex("dbo.Students", new[] { "GPAStateId" });
            DropForeignKey("dbo.Courses", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Registrations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Registrations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Students", "GPAStateId", "dbo.GPAStates");
            DropTable("dbo.GPAStates");
            DropTable("dbo.Courses");
            DropTable("dbo.Registrations");
            DropTable("dbo.Programs");
            DropTable("dbo.Students");
        }
    }
}
