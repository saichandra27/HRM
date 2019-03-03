namespace HRM.Data.DbConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HRMDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLog",
                c => new
                    {
                        AuditLogId = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        EventDateUTC = c.DateTime(nullable: false),
                        EventType = c.Int(nullable: false),
                        TypeFullName = c.String(nullable: false, maxLength: 512),
                        RecordId = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.AuditLogId);
            
            CreateTable(
                "dbo.AuditLogDetail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PropertyName = c.String(nullable: false, maxLength: 256),
                        OriginalValue = c.String(),
                        NewValue = c.String(),
                        AuditLogId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLog", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
            CreateTable(
                "dbo.LogMetadata",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuditLogId = c.Long(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLog", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddressStree1 = c.String(),
                        AddressStree2 = c.String(),
                        ZipCode = c.String(),
                        HomeTelephone = c.String(),
                        Mobile = c.String(),
                        WorkTelephone = c.String(),
                        PersonalEmailId = c.String(),
                        OfficeEmailId = c.String(),
                        Attachments = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Createdby = c.String(),
                        Modifiedby = c.String(),
                        UserId = c.String(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        City_ID = c.Int(),
                        Country_ID = c.Int(),
                        State_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.City_ID)
                .ForeignKey("dbo.Country", t => t.Country_ID)
                .ForeignKey("dbo.State", t => t.State_ID)
                .Index(t => t.City_ID)
                .Index(t => t.Country_ID)
                .Index(t => t.State_ID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Country_ID = c.Int(),
                        State_ID = c.Int(),
                        Contact_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.Country_ID)
                .ForeignKey("dbo.State", t => t.State_ID)
                .ForeignKey("dbo.Contact", t => t.Contact_ID)
                .Index(t => t.Country_ID)
                .Index(t => t.State_ID)
                .Index(t => t.Contact_ID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        City_ID = c.Int(),
                        State_ID = c.Int(),
                        Contact_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.City_ID)
                .ForeignKey("dbo.State", t => t.State_ID)
                .ForeignKey("dbo.Contact", t => t.Contact_ID)
                .Index(t => t.City_ID)
                .Index(t => t.State_ID)
                .Index(t => t.Contact_ID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Country_ID = c.Int(),
                        City_ID = c.Int(),
                        Contact_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.Country_ID)
                .ForeignKey("dbo.City", t => t.City_ID)
                .ForeignKey("dbo.Contact", t => t.Contact_ID)
                .Index(t => t.Country_ID)
                .Index(t => t.City_ID)
                .Index(t => t.Contact_ID);
            
            CreateTable(
                "dbo.Dependent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Relationship = c.Int(nullable: false),
                        OtherRelationship = c.String(),
                        NationalIdentityNumber = c.String(),
                        DOB = c.DateTime(nullable: false),
                        OtherInformation = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Createdby = c.String(),
                        Modifiedby = c.String(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        Attachments = c.String(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.LeaveTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Createdby = c.String(),
                        Modifiedby = c.String(),
                        UserId = c.String(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        Attachments = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModuleRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(maxLength: 128),
                        ModuleId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        InUse = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ModuleRole", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ModuleRole", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.Dependent", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.State", "Contact_ID", "dbo.Contact");
            DropForeignKey("dbo.Contact", "State_ID", "dbo.State");
            DropForeignKey("dbo.Country", "Contact_ID", "dbo.Contact");
            DropForeignKey("dbo.Contact", "Country_ID", "dbo.Country");
            DropForeignKey("dbo.City", "Contact_ID", "dbo.Contact");
            DropForeignKey("dbo.Contact", "City_ID", "dbo.City");
            DropForeignKey("dbo.State", "City_ID", "dbo.City");
            DropForeignKey("dbo.City", "State_ID", "dbo.State");
            DropForeignKey("dbo.Country", "State_ID", "dbo.State");
            DropForeignKey("dbo.State", "Country_ID", "dbo.Country");
            DropForeignKey("dbo.Country", "City_ID", "dbo.City");
            DropForeignKey("dbo.City", "Country_ID", "dbo.Country");
            DropForeignKey("dbo.LogMetadata", "AuditLogId", "dbo.AuditLog");
            DropForeignKey("dbo.AuditLogDetail", "AuditLogId", "dbo.AuditLog");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ModuleRole", new[] { "ModuleId" });
            DropIndex("dbo.ModuleRole", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Dependent", new[] { "UserId_Id" });
            DropIndex("dbo.State", new[] { "Contact_ID" });
            DropIndex("dbo.State", new[] { "City_ID" });
            DropIndex("dbo.State", new[] { "Country_ID" });
            DropIndex("dbo.Country", new[] { "Contact_ID" });
            DropIndex("dbo.Country", new[] { "State_ID" });
            DropIndex("dbo.Country", new[] { "City_ID" });
            DropIndex("dbo.City", new[] { "Contact_ID" });
            DropIndex("dbo.City", new[] { "State_ID" });
            DropIndex("dbo.City", new[] { "Country_ID" });
            DropIndex("dbo.Contact", new[] { "State_ID" });
            DropIndex("dbo.Contact", new[] { "Country_ID" });
            DropIndex("dbo.Contact", new[] { "City_ID" });
            DropIndex("dbo.LogMetadata", new[] { "AuditLogId" });
            DropIndex("dbo.AuditLogDetail", new[] { "AuditLogId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ModuleRole");
            DropTable("dbo.Module");
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Dependent");
            DropTable("dbo.State");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Contact");
            DropTable("dbo.LogMetadata");
            DropTable("dbo.AuditLogDetail");
            DropTable("dbo.AuditLog");
        }
    }
}
