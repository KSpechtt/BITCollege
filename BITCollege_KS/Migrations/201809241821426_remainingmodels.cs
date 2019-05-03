namespace BITCollege_KS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remainingmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCards",
                c => new
                    {
                        StudentCardId = c.Int(nullable: false, identity: true),
                        CardNumber = c.Long(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCardId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.NextStudentNumbers",
                c => new
                    {
                        NextStudentNumberId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextStudentNumberId);
            
            CreateTable(
                "dbo.NextAuditCourses",
                c => new
                    {
                        NextAuditCourseId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextAuditCourseId);
            
            CreateTable(
                "dbo.NextMasteryCourses",
                c => new
                    {
                        NextMasteryCourseId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextMasteryCourseId);
            
            CreateTable(
                "dbo.NextGradedCourses",
                c => new
                    {
                        NextGradedCourseId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextGradedCourseId);
            
            CreateTable(
                "dbo.NextRegistrationNumbers",
                c => new
                    {
                        NextRegistrationNumberId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.NextRegistrationNumberId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.StudentCards", new[] { "StudentId" });
            DropForeignKey("dbo.StudentCards", "StudentId", "dbo.Students");
            DropTable("dbo.NextRegistrationNumbers");
            DropTable("dbo.NextGradedCourses");
            DropTable("dbo.NextMasteryCourses");
            DropTable("dbo.NextAuditCourses");
            DropTable("dbo.NextStudentNumbers");
            DropTable("dbo.StudentCards");
        }
    }
}
