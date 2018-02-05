namespace ecs_dev_server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ECSContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Points = c.Int(nullable: false),
                        AccountStatus = c.Int(nullable: false),
                        SuspensionTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.InterestTag",
                c => new
                    {
                        TagName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TagName);
            
            CreateTable(
                "dbo.SecurityQuestion",
                c => new
                    {
                        SecurityQuestions = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SecurityQuestions);
            
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        TypeName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TypeName);
            
            CreateTable(
                "dbo.SweepStakeEntry",
                c => new
                    {
                        PurchaseDateTime = c.DateTime(nullable: false),
                        cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseDateTime);
            
            CreateTable(
                "dbo.SweepStakes",
                c => new
                    {
                        SweepStakesID = c.Int(nullable: false, identity: true),
                        OpenDateTime = c.DateTime(nullable: false),
                        ClosedDateTime = c.DateTime(nullable: false),
                        Prize = c.String(),
                        UsernameWinner = c.String(),
                    })
                .PrimaryKey(t => t.SweepStakesID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.ZipLocation",
                c => new
                    {
                        ZipCode = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        State = c.String(),
                        Latitude = c.Int(nullable: false),
                        Longitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZipCode);
            
            CreateTable(
                "dbo.InterestTagAccount",
                c => new
                    {
                        InterestTag_TagName = c.String(nullable: false, maxLength: 128),
                        Account_UserName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.InterestTag_TagName, t.Account_UserName })
                .ForeignKey("dbo.InterestTag", t => t.InterestTag_TagName, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Account_UserName, cascadeDelete: true)
                .Index(t => t.InterestTag_TagName)
                .Index(t => t.Account_UserName);
            
            CreateTable(
                "dbo.SecurityQuestionAccount",
                c => new
                    {
                        SecurityQuestion_SecurityQuestions = c.String(nullable: false, maxLength: 128),
                        Account_UserName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SecurityQuestion_SecurityQuestions, t.Account_UserName })
                .ForeignKey("dbo.SecurityQuestion", t => t.SecurityQuestion_SecurityQuestions, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Account_UserName, cascadeDelete: true)
                .Index(t => t.SecurityQuestion_SecurityQuestions)
                .Index(t => t.Account_UserName);
            
            CreateTable(
                "dbo.ZipLocationUser",
                c => new
                    {
                        ZipLocation_ZipCode = c.Int(nullable: false),
                        User_Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ZipLocation_ZipCode, t.User_Email })
                .ForeignKey("dbo.ZipLocation", t => t.ZipLocation_ZipCode, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Email, cascadeDelete: true)
                .Index(t => t.ZipLocation_ZipCode)
                .Index(t => t.User_Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZipLocationUser", "User_Email", "dbo.User");
            DropForeignKey("dbo.ZipLocationUser", "ZipLocation_ZipCode", "dbo.ZipLocation");
            DropForeignKey("dbo.SecurityQuestionAccount", "Account_UserName", "dbo.Account");
            DropForeignKey("dbo.SecurityQuestionAccount", "SecurityQuestion_SecurityQuestions", "dbo.SecurityQuestion");
            DropForeignKey("dbo.InterestTagAccount", "Account_UserName", "dbo.Account");
            DropForeignKey("dbo.InterestTagAccount", "InterestTag_TagName", "dbo.InterestTag");
            DropIndex("dbo.ZipLocationUser", new[] { "User_Email" });
            DropIndex("dbo.ZipLocationUser", new[] { "ZipLocation_ZipCode" });
            DropIndex("dbo.SecurityQuestionAccount", new[] { "Account_UserName" });
            DropIndex("dbo.SecurityQuestionAccount", new[] { "SecurityQuestion_SecurityQuestions" });
            DropIndex("dbo.InterestTagAccount", new[] { "Account_UserName" });
            DropIndex("dbo.InterestTagAccount", new[] { "InterestTag_TagName" });
            DropTable("dbo.ZipLocationUser");
            DropTable("dbo.SecurityQuestionAccount");
            DropTable("dbo.InterestTagAccount");
            DropTable("dbo.ZipLocation");
            DropTable("dbo.User");
            DropTable("dbo.SweepStakes");
            DropTable("dbo.SweepStakeEntry");
            DropTable("dbo.AccountType");
            DropTable("dbo.SecurityQuestion");
            DropTable("dbo.InterestTag");
            DropTable("dbo.Account");
        }
    }
}
