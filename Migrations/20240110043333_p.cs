using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USBDProperty.Migrations
{
    public partial class p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ClientContacts",
            //    columns: table => new
            //    {
            //        ClientContactId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ContactDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ClientContacts", x => x.ClientContactId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Countries",
            //    columns: table => new
            //    {
            //        CountryID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Countries", x => x.CountryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DevelopersorAgent",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        ContactNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        PostedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DevelopersorAgent", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Notices",
            //    columns: table => new
            //    {
            //        NoticeID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Notices", x => x.NoticeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PrivacyPolicy",
            //    columns: table => new
            //    {
            //        PpId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PrivacyPolicy", x => x.PpId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PropertyFeatures",
            //    columns: table => new
            //    {
            //        PropertyFeatureId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PropertyFeatureName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        FeatureDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PropertyFeatures", x => x.PropertyFeatureId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PropertyTypes",
            //    columns: table => new
            //    {
            //        PropertyTypeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PropertyTypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        ParentPropertyTypeId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PropertyTypes", x => x.PropertyTypeId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SocialIcons",
            //    columns: table => new
            //    {
            //        IconId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SocialIcons", x => x.IconId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TermsConditions",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TermsConditions", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TransactionTypes",
            //    columns: table => new
            //    {
            //        TransactionTypeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TransactionTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TransactionTypes", x => x.TransactionTypeId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Divisions",
            //    columns: table => new
            //    {
            //        DivisionID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DivisionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        CountryId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Divisions", x => x.DivisionID);
            //        table.ForeignKey(
            //            name: "FK_Divisions_Countries_CountryId",
            //            column: x => x.CountryId,
            //            principalTable: "Countries",
            //            principalColumn: "CountryID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProjectsInfo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ProjectName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        LocationMap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        AgentID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProjectsInfo", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProjectsInfo_DevelopersorAgent_AgentID",
            //            column: x => x.AgentID,
            //            principalTable: "DevelopersorAgent",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Citys",
            //    columns: table => new
            //    {
            //        CityId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        DivisionId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Citys", x => x.CityId);
            //        table.ForeignKey(
            //            name: "FK_Citys_Divisions_DivisionId",
            //            column: x => x.DivisionId,
            //            principalTable: "Divisions",
            //            principalColumn: "DivisionID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProjectImageGallery",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ImagePath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        ProjectID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProjectImageGallery", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProjectImageGallery_ProjectsInfo_ProjectID",
            //            column: x => x.ProjectID,
            //            principalTable: "ProjectsInfo",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Areas",
            //    columns: table => new
            //    {
            //        AreaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AreaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        CityId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Areas", x => x.AreaId);
            //        table.ForeignKey(
            //            name: "FK_Areas_Citys_CityId",
            //            column: x => x.CityId,
            //            principalTable: "Citys",
            //            principalColumn: "CityId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PropertyDetails",
            //    columns: table => new
            //    {
            //        PropertyInfoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PropertyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        ConstructionStatus = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        PropertySize = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        NumberOfBedrooms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        NumberOfBaths = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        NumberOfBalconies = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        NumberOfGarages = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        TotalFloor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        FloorAvailableNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Furnishing = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Facing = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        LandArea = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Price = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Measurement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Comments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        PropertyCondition = table.Column<int>(type: "int", nullable: false),
            //        HandOverDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        PropertyTypeId = table.Column<int>(type: "int", nullable: false),
            //        ProjectId = table.Column<int>(type: "int", nullable: false),
            //        AreaId = table.Column<int>(type: "int", nullable: false),
            //        PropertyFor = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PropertyDetails", x => x.PropertyInfoId);
            //        table.ForeignKey(
            //            name: "FK_PropertyDetails_Areas_AreaId",
            //            column: x => x.AreaId,
            //            principalTable: "Areas",
            //            principalColumn: "AreaId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PropertyDetails_ProjectsInfo_ProjectId",
            //            column: x => x.ProjectId,
            //            principalTable: "ProjectsInfo",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PropertyDetails_PropertyTypes_PropertyTypeId",
            //            column: x => x.PropertyTypeId,
            //            principalTable: "PropertyTypes",
            //            principalColumn: "PropertyTypeId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FloorPlans",
            //    columns: table => new
            //    {
            //        FloorPlanId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FloorPlanName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PropertyInfoID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FloorPlans", x => x.FloorPlanId);
            //        table.ForeignKey(
            //            name: "FK_FloorPlans_PropertyDetails_PropertyInfoID",
            //            column: x => x.PropertyInfoID,
            //            principalTable: "PropertyDetails",
            //            principalColumn: "PropertyInfoId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PropertyImages",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MultiImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        propertyInfoId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PropertyImages", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_PropertyImages_PropertyDetails_propertyInfoId",
            //            column: x => x.propertyInfoId,
            //            principalTable: "PropertyDetails",
            //            principalColumn: "PropertyInfoId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PropertyWithFeatures",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PropertyId = table.Column<int>(type: "int", nullable: false),
            //        FeatureId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PropertyWithFeatures", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_PropertyWithFeatures_PropertyDetails_PropertyId",
            //            column: x => x.PropertyId,
            //            principalTable: "PropertyDetails",
            //            principalColumn: "PropertyInfoId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PropertyWithFeatures_PropertyFeatures_FeatureId",
            //            column: x => x.FeatureId,
            //            principalTable: "PropertyFeatures",
            //            principalColumn: "PropertyFeatureId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Areas_CityId",
            //    table: "Areas",
            //    column: "CityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Citys_DivisionId",
            //    table: "Citys",
            //    column: "DivisionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Divisions_CountryId",
            //    table: "Divisions",
            //    column: "CountryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FloorPlans_PropertyInfoID",
            //    table: "FloorPlans",
            //    column: "PropertyInfoID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProjectImageGallery_ProjectID",
            //    table: "ProjectImageGallery",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProjectsInfo_AgentID",
            //    table: "ProjectsInfo",
            //    column: "AgentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PropertyDetails_AreaId",
            //    table: "PropertyDetails",
            //    column: "AreaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PropertyDetails_ProjectId",
            //    table: "PropertyDetails",
            //    column: "ProjectId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PropertyDetails_PropertyTypeId",
            //    table: "PropertyDetails",
            //    column: "PropertyTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PropertyImages_propertyInfoId",
            //    table: "PropertyImages",
            //    column: "propertyInfoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PropertyWithFeatures_FeatureId",
            //    table: "PropertyWithFeatures",
            //    column: "FeatureId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PropertyWithFeatures_PropertyId",
            //    table: "PropertyWithFeatures",
            //    column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "ClientContacts");

            //migrationBuilder.DropTable(
            //    name: "FloorPlans");

            //migrationBuilder.DropTable(
            //    name: "Notices");

            //migrationBuilder.DropTable(
            //    name: "PrivacyPolicy");

            //migrationBuilder.DropTable(
            //    name: "ProjectImageGallery");

            //migrationBuilder.DropTable(
            //    name: "PropertyImages");

            //migrationBuilder.DropTable(
            //    name: "PropertyWithFeatures");

            //migrationBuilder.DropTable(
            //    name: "SocialIcons");

            //migrationBuilder.DropTable(
            //    name: "TermsConditions");

            //migrationBuilder.DropTable(
            //    name: "TransactionTypes");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "PropertyDetails");

            //migrationBuilder.DropTable(
            //    name: "PropertyFeatures");

            //migrationBuilder.DropTable(
            //    name: "Areas");

            //migrationBuilder.DropTable(
            //    name: "ProjectsInfo");

            //migrationBuilder.DropTable(
            //    name: "PropertyTypes");

            //migrationBuilder.DropTable(
            //    name: "Citys");

            //migrationBuilder.DropTable(
            //    name: "DevelopersorAgent");

            //migrationBuilder.DropTable(
            //    name: "Divisions");

            //migrationBuilder.DropTable(
            //    name: "Countries");
        }
    }
}
