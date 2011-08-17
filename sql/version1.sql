
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_ActiveTestCases_ActiveTestPlans]') AND parent_object_id = OBJECT_ID('ActiveTestCases'))
alter table ActiveTestCases  drop constraint FK_ActiveTestCases_ActiveTestPlans


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_ActiveTestCases_TestCases]') AND parent_object_id = OBJECT_ID('ActiveTestCases'))
alter table ActiveTestCases  drop constraint FK_ActiveTestCases_TestCases


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Builds_ActiveTestPlans]') AND parent_object_id = OBJECT_ID('ActiveTestPlans'))
alter table ActiveTestPlans  drop constraint FK_Builds_ActiveTestPlans


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_ActiveTestPlans_TestPlans]') AND parent_object_id = OBJECT_ID('ActiveTestPlans'))
alter table ActiveTestPlans  drop constraint FK_ActiveTestPlans_TestPlans


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_ActiveTestSteps_ActiveTestCases]') AND parent_object_id = OBJECT_ID('ActiveTestSteps'))
alter table ActiveTestSteps  drop constraint FK_ActiveTestSteps_ActiveTestCases


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_ActiveTestSteps_TestSteps]') AND parent_object_id = OBJECT_ID('ActiveTestSteps'))
alter table ActiveTestSteps  drop constraint FK_ActiveTestSteps_TestSteps


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Releases_Builds]') AND parent_object_id = OBJECT_ID('Builds'))
alter table Builds  drop constraint FK_Releases_Builds


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Builds_Products]') AND parent_object_id = OBJECT_ID('Builds'))
alter table Builds  drop constraint FK_Builds_Products


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_TestCases_TestPlans]') AND parent_object_id = OBJECT_ID('TestCases'))
alter table TestCases  drop constraint FK_TestCases_TestPlans


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_TestCases_TestComponents]') AND parent_object_id = OBJECT_ID('TestCases'))
alter table TestCases  drop constraint FK_TestCases_TestComponents


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_TestComponents_Products]') AND parent_object_id = OBJECT_ID('TestComponents'))
alter table TestComponents  drop constraint FK_TestComponents_Products


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_TestPlans_Features]') AND parent_object_id = OBJECT_ID('TestPlans'))
alter table TestPlans  drop constraint FK_TestPlans_Features


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_TestSteps_TestCases]') AND parent_object_id = OBJECT_ID('TestSteps'))
alter table TestSteps  drop constraint FK_TestSteps_TestCases


    if exists (select * from dbo.sysobjects where id = object_id(N'ActiveTestCases') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ActiveTestCases

    if exists (select * from dbo.sysobjects where id = object_id(N'ActiveTestPlans') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ActiveTestPlans

    if exists (select * from dbo.sysobjects where id = object_id(N'ActiveTestSteps') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ActiveTestSteps

    if exists (select * from dbo.sysobjects where id = object_id(N'Builds') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Builds

    if exists (select * from dbo.sysobjects where id = object_id(N'Features') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Features

    if exists (select * from dbo.sysobjects where id = object_id(N'Products') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Products

    if exists (select * from dbo.sysobjects where id = object_id(N'Releases') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Releases

    if exists (select * from dbo.sysobjects where id = object_id(N'TestCases') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TestCases

    if exists (select * from dbo.sysobjects where id = object_id(N'TestComponents') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TestComponents

    if exists (select * from dbo.sysobjects where id = object_id(N'TestPlans') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TestPlans

    if exists (select * from dbo.sysobjects where id = object_id(N'TestSteps') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TestSteps

    create table ActiveTestCases (
        ActiveTestCaseID INT IDENTITY NOT NULL,
       ActiveTestPlanID INT null,
       TestCaseID INT null,
       primary key (ActiveTestCaseID)
    )

    create table ActiveTestPlans (
        ActiveTestPlanID INT IDENTITY NOT NULL,
       BuildID INT null,
       TestPlanID INT null,
       primary key (ActiveTestPlanID)
    )

    create table ActiveTestSteps (
        ActiveTestStepID INT IDENTITY NOT NULL,
       RequestTicketNumber NVARCHAR(255) null,
       Status INT null,
       ActiveTestCaseID INT null,
       TestID INT null,
       primary key (ActiveTestStepID)
    )

    create table Builds (
        BuildID INT IDENTITY NOT NULL,
       BuildNumber NVARCHAR(255) null,
       Status INT null,
       ReleaseID INT null,
       ProductID INT null,
       primary key (BuildID)
    )

    create table Features (
        FeatureID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       primary key (FeatureID)
    )

    create table Products (
        ProductID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       primary key (ProductID)
    )

    create table Releases (
        ReleaseID INT IDENTITY NOT NULL,
       ReleaseDate DATETIME null,
       ReleaseTicketNumber NVARCHAR(255) null,
       primary key (ReleaseID)
    )

    create table TestCases (
        TestCaseID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       TestPlanID INT null,
       TestComponentID INT null,
       primary key (TestCaseID)
    )

    create table TestComponents (
        TestComponentID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       ProductID INT null,
       primary key (TestComponentID)
    )

    create table TestPlans (
        TestPlanID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       FeatureID INT null,
       primary key (TestPlanID)
    )

    create table TestSteps (
        TestStepID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       TestCaseID INT null,
       primary key (TestStepID)
    )

    alter table ActiveTestCases 
        add constraint FK_ActiveTestCases_ActiveTestPlans 
        foreign key (ActiveTestPlanID) 
        references ActiveTestPlans

    alter table ActiveTestCases 
        add constraint FK_ActiveTestCases_TestCases 
        foreign key (TestCaseID) 
        references TestCases

    alter table ActiveTestPlans 
        add constraint FK_Builds_ActiveTestPlans 
        foreign key (BuildID) 
        references Builds

    alter table ActiveTestPlans 
        add constraint FK_ActiveTestPlans_TestPlans 
        foreign key (TestPlanID) 
        references TestPlans

    alter table ActiveTestSteps 
        add constraint FK_ActiveTestSteps_ActiveTestCases 
        foreign key (ActiveTestCaseID) 
        references ActiveTestCases

    alter table ActiveTestSteps 
        add constraint FK_ActiveTestSteps_TestSteps 
        foreign key (TestID) 
        references TestSteps

    alter table Builds 
        add constraint FK_Releases_Builds 
        foreign key (ReleaseID) 
        references Releases

    alter table Builds 
        add constraint FK_Builds_Products 
        foreign key (ProductID) 
        references Products

    alter table TestCases 
        add constraint FK_TestCases_TestPlans 
        foreign key (TestPlanID) 
        references TestPlans

    alter table TestCases 
        add constraint FK_TestCases_TestComponents 
        foreign key (TestComponentID) 
        references TestComponents

    alter table TestComponents 
        add constraint FK_TestComponents_Products 
        foreign key (ProductID) 
        references Products

    alter table TestPlans 
        add constraint FK_TestPlans_Features 
        foreign key (FeatureID) 
        references Features

    alter table TestSteps 
        add constraint FK_TestSteps_TestCases 
        foreign key (TestCaseID) 
        references TestCases
