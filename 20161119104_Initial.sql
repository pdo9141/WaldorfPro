﻿CREATE TABLE [dbo].[Parties] (
    [Id] [bigint] NOT NULL IDENTITY,
    [PartyStatusType] [int] NOT NULL,
    [FirstName] [nvarchar](50) NOT NULL,
    [LastName] [nvarchar](50) NOT NULL,
    [EmailAddress] [nvarchar](75) NOT NULL,
    [ZipCode] [nvarchar](10) NOT NULL,
    [AnthroposophicalFoundationalStudies] [bit] NOT NULL,
    [AllowSchoolMatchWithoutApproval] [bit] NOT NULL,
    [WaldorfTranscriptFileName] [nvarchar](100),
    [AnyWaldorfAdminCertUnitsCompleted] [bit] NOT NULL,
    [BiographyFileName] [nvarchar](100),
    [PreferredName] [nvarchar](75) NOT NULL,
    [ProfileImageName] [nvarchar](100),
    [UserId] [nvarchar](128) NOT NULL,
    [DateCreated] [datetime] NOT NULL,
    [CreditCard_Id] [bigint],
    CONSTRAINT [PK_dbo.Parties] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_CreditCard_Id] ON [dbo].[Parties]([CreditCard_Id])
CREATE TABLE [dbo].[AdministratorExperiences] (
    [Id] [bigint] NOT NULL IDENTITY,
    [Institution] [nvarchar](50) NOT NULL,
    [Position] [nvarchar](50) NOT NULL,
    [StartDate] [datetime] NOT NULL,
    [EndDate] [datetime] NOT NULL,
    [ResponsibilitiesDuties] [nvarchar](1000),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.AdministratorExperiences] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[AdministratorExperiences]([PartyId])
CREATE TABLE [dbo].[ApprovedMatchPostedJobPositions] (
    [Id] [bigint] NOT NULL IDENTITY,
    [PostedJobPositionId] [bigint] NOT NULL,
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.ApprovedMatchPostedJobPositions] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[ApprovedMatchPostedJobPositions]([PartyId])
CREATE TABLE [dbo].[CompletedWaldorfTeachingCertificationTypeWrappers] (
    [Id] [bigint] NOT NULL IDENTITY,
    [PartyId] [bigint] NOT NULL,
    [WaldorfTeachingCertificationType] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CompletedWaldorfTeachingCertificationTypeWrappers] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[CompletedWaldorfTeachingCertificationTypeWrappers]([PartyId])
CREATE TABLE [dbo].[CreditCards] (
    [Id] [bigint] NOT NULL IDENTITY,
    [CreditCardStatusType] [int] NOT NULL,
    [CreditCardType] [int] NOT NULL,
    [Number] [nvarchar](300),
    [CVVNumber] [nvarchar](100),
    [ExpirationMonth] [nvarchar](100),
    [ExpirationYear] [nvarchar](100),
    [HolderFirstName] [nvarchar](500),
    [HolderMiddleName] [nvarchar](500),
    [HolderLastName] [nvarchar](500),
    CONSTRAINT [PK_dbo.CreditCards] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Evaluations] (
    [Id] [bigint] NOT NULL IDENTITY,
    [FileName] [nvarchar](100),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.Evaluations] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[Evaluations]([PartyId])
CREATE TABLE [dbo].[FavoritedPostedJobPositions] (
    [Id] [bigint] NOT NULL IDENTITY,
    [PostedJobPositionId] [bigint] NOT NULL,
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.FavoritedPostedJobPositions] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[FavoritedPostedJobPositions]([PartyId])
CREATE TABLE [dbo].[Graduates] (
    [Id] [bigint] NOT NULL IDENTITY,
    [SchoolName] [nvarchar](50) NOT NULL,
    [City] [nvarchar](50) NOT NULL,
    [State] [int] NOT NULL,
    [DegreeEmphasis] [nvarchar](100) NOT NULL,
    [TranscriptFileName] [nvarchar](100),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.Graduates] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[Graduates]([PartyId])
CREATE TABLE [dbo].[JobPositionWrappers] (
    [Id] [bigint] NOT NULL IDENTITY,
    [JobPositionType] [int] NOT NULL,
    [PartyId] [bigint] NOT NULL,
    [JobPositionTierOneCategory_Id] [bigint],
    CONSTRAINT [PK_dbo.JobPositionWrappers] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[JobPositionWrappers]([PartyId])
CREATE INDEX [IX_JobPositionTierOneCategory_Id] ON [dbo].[JobPositionWrappers]([JobPositionTierOneCategory_Id])
CREATE TABLE [dbo].[JobPositionTierOneCategories] (
    [Id] [bigint] NOT NULL IDENTITY,
    [JobPositionTierOneCategoryType] [int] NOT NULL,
    [JobPositionTierTwoCategory_Id] [bigint],
    CONSTRAINT [PK_dbo.JobPositionTierOneCategories] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_JobPositionTierTwoCategory_Id] ON [dbo].[JobPositionTierOneCategories]([JobPositionTierTwoCategory_Id])
CREATE TABLE [dbo].[JobPositionTierTwoCategories] (
    [Id] [bigint] NOT NULL IDENTITY,
    [JobPositionTierTwoCategoryType] [int] NOT NULL,
    CONSTRAINT [PK_dbo.JobPositionTierTwoCategories] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[OccupationalCertifications] (
    [Id] [bigint] NOT NULL IDENTITY,
    [Name] [nvarchar](100) NOT NULL,
    [State] [int] NOT NULL,
    [DocumentationFileName] [nvarchar](100),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.OccupationalCertifications] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[OccupationalCertifications]([PartyId])
CREATE TABLE [dbo].[PartialWaldorfTeachingCertificationTypeWrappers] (
    [Id] [bigint] NOT NULL IDENTITY,
    [PartyId] [bigint] NOT NULL,
    [WaldorfTeachingCertificationType] [int] NOT NULL,
    CONSTRAINT [PK_dbo.PartialWaldorfTeachingCertificationTypeWrappers] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[PartialWaldorfTeachingCertificationTypeWrappers]([PartyId])
CREATE TABLE [dbo].[PartyTypeWrappers] (
    [Id] [bigint] NOT NULL IDENTITY,
    [PartyType] [int] NOT NULL,
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.PartyTypeWrappers] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[PartyTypeWrappers]([PartyId])
CREATE TABLE [dbo].[RecommendationLetters] (
    [Id] [bigint] NOT NULL IDENTITY,
    [FileName] [nvarchar](100),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.RecommendationLetters] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[RecommendationLetters]([PartyId])
CREATE TABLE [dbo].[StateCredentials] (
    [Id] [bigint] NOT NULL IDENTITY,
    [Name] [nvarchar](100) NOT NULL,
    [State] [int] NOT NULL,
    [DocumentationFileName] [nvarchar](100),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.StateCredentials] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[StateCredentials]([PartyId])
CREATE TABLE [dbo].[TeachingExperiences] (
    [Id] [bigint] NOT NULL IDENTITY,
    [Institution] [nvarchar](50) NOT NULL,
    [Position] [nvarchar](50) NOT NULL,
    [StartDate] [datetime] NOT NULL,
    [EndDate] [datetime] NOT NULL,
    [ResponsibilitiesDuties] [nvarchar](1000),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.TeachingExperiences] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[TeachingExperiences]([PartyId])
CREATE TABLE [dbo].[Undergraduates] (
    [Id] [bigint] NOT NULL IDENTITY,
    [SchoolName] [nvarchar](50) NOT NULL,
    [City] [nvarchar](50) NOT NULL,
    [State] [int] NOT NULL,
    [Degree] [int] NOT NULL,
    [Major] [nvarchar](100) NOT NULL,
    [Minor] [nvarchar](100),
    [TranscriptFileName] [nvarchar](100),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.Undergraduates] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[Undergraduates]([PartyId])
CREATE TABLE [dbo].[VolunteerRelevantExperiences] (
    [Id] [bigint] NOT NULL IDENTITY,
    [Institution] [nvarchar](50) NOT NULL,
    [Position] [nvarchar](50) NOT NULL,
    [StartDate] [datetime] NOT NULL,
    [EndDate] [datetime] NOT NULL,
    [ResponsibilitiesDuties] [nvarchar](1000),
    [PartyId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.VolunteerRelevantExperiences] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PartyId] ON [dbo].[VolunteerRelevantExperiences]([PartyId])
CREATE TABLE [dbo].[PostedJobPositions] (
    [Id] [bigint] NOT NULL IDENTITY,
    [SchoolId] [int] NOT NULL,
    [PostedJobPositionStatusType] [int] NOT NULL,
    [PartyType] [int] NOT NULL,
    [EmploymentType] [int] NOT NULL,
    [Title] [nvarchar](50),
    [Description] [nvarchar](100),
    [Compensation] [decimal](18, 2) NOT NULL,
    [CompensationType] [int] NOT NULL,
    [HasBenefits] [bit] NOT NULL,
    [StartDate] [datetime] NOT NULL,
    [DateFilled] [datetime],
    [DateCreated] [datetime] NOT NULL,
    [Category_Id] [bigint],
    CONSTRAINT [PK_dbo.PostedJobPositions] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_SchoolId] ON [dbo].[PostedJobPositions]([SchoolId])
CREATE INDEX [IX_Category_Id] ON [dbo].[PostedJobPositions]([Category_Id])
CREATE TABLE [dbo].[PostedJobPositionCategories] (
    [Id] [bigint] NOT NULL IDENTITY,
    [JobPositionType] [int] NOT NULL,
    [JobPositionTierOneCategory_Id] [bigint],
    CONSTRAINT [PK_dbo.PostedJobPositionCategories] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_JobPositionTierOneCategory_Id] ON [dbo].[PostedJobPositionCategories]([JobPositionTierOneCategory_Id])
CREATE TABLE [dbo].[FavoritedParties] (
    [Id] [bigint] NOT NULL IDENTITY,
    [PartyId] [bigint] NOT NULL,
    [PostedJobPosition_Id] [bigint],
    CONSTRAINT [PK_dbo.FavoritedParties] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_PostedJobPosition_Id] ON [dbo].[FavoritedParties]([PostedJobPosition_Id])
CREATE TABLE [dbo].[Schools] (
    [Id] [int] NOT NULL IDENTITY,
    [SchoolStatusType] [int] NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [PhoneNumber] [nvarchar](20),
    [EmailAddress] [nvarchar](75),
    [WebAddress] [nvarchar](100),
    [AwsnaAccreditationLevel] [int] NOT NULL,
    [YearFounded] [smallint] NOT NULL,
    [Enrollment] [int] NOT NULL,
    [DateCreated] [datetime] NOT NULL,
    [Address_Id] [int],
    [CreditCard_Id] [bigint],
    CONSTRAINT [PK_dbo.Schools] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Address_Id] ON [dbo].[Schools]([Address_Id])
CREATE INDEX [IX_CreditCard_Id] ON [dbo].[Schools]([CreditCard_Id])
CREATE TABLE [dbo].[Addresses] (
    [Id] [int] NOT NULL IDENTITY,
    [Street] [nvarchar](50) NOT NULL,
    [Street2] [nvarchar](50),
    [City] [nvarchar](50) NOT NULL,
    [State] [int] NOT NULL,
    [ZipCode] [nvarchar](10) NOT NULL,
    [Country] [nvarchar](75),
    CONSTRAINT [PK_dbo.Addresses] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[SchoolDescriptionTypeWrappers] (
    [Id] [int] NOT NULL IDENTITY,
    [SchoolDescriptionType] [int] NOT NULL,
    [SchoolId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.SchoolDescriptionTypeWrappers] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_SchoolId] ON [dbo].[SchoolDescriptionTypeWrappers]([SchoolId])
ALTER TABLE [dbo].[Parties] ADD CONSTRAINT [FK_dbo.Parties_dbo.CreditCards_CreditCard_Id] FOREIGN KEY ([CreditCard_Id]) REFERENCES [dbo].[CreditCards] ([Id])
ALTER TABLE [dbo].[AdministratorExperiences] ADD CONSTRAINT [FK_dbo.AdministratorExperiences_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[ApprovedMatchPostedJobPositions] ADD CONSTRAINT [FK_dbo.ApprovedMatchPostedJobPositions_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[CompletedWaldorfTeachingCertificationTypeWrappers] ADD CONSTRAINT [FK_dbo.CompletedWaldorfTeachingCertificationTypeWrappers_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Evaluations] ADD CONSTRAINT [FK_dbo.Evaluations_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[FavoritedPostedJobPositions] ADD CONSTRAINT [FK_dbo.FavoritedPostedJobPositions_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Graduates] ADD CONSTRAINT [FK_dbo.Graduates_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[JobPositionWrappers] ADD CONSTRAINT [FK_dbo.JobPositionWrappers_dbo.JobPositionTierOneCategories_JobPositionTierOneCategory_Id] FOREIGN KEY ([JobPositionTierOneCategory_Id]) REFERENCES [dbo].[JobPositionTierOneCategories] ([Id])
ALTER TABLE [dbo].[JobPositionWrappers] ADD CONSTRAINT [FK_dbo.JobPositionWrappers_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[JobPositionTierOneCategories] ADD CONSTRAINT [FK_dbo.JobPositionTierOneCategories_dbo.JobPositionTierTwoCategories_JobPositionTierTwoCategory_Id] FOREIGN KEY ([JobPositionTierTwoCategory_Id]) REFERENCES [dbo].[JobPositionTierTwoCategories] ([Id])
ALTER TABLE [dbo].[OccupationalCertifications] ADD CONSTRAINT [FK_dbo.OccupationalCertifications_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PartialWaldorfTeachingCertificationTypeWrappers] ADD CONSTRAINT [FK_dbo.PartialWaldorfTeachingCertificationTypeWrappers_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PartyTypeWrappers] ADD CONSTRAINT [FK_dbo.PartyTypeWrappers_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[RecommendationLetters] ADD CONSTRAINT [FK_dbo.RecommendationLetters_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[StateCredentials] ADD CONSTRAINT [FK_dbo.StateCredentials_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[TeachingExperiences] ADD CONSTRAINT [FK_dbo.TeachingExperiences_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Undergraduates] ADD CONSTRAINT [FK_dbo.Undergraduates_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[VolunteerRelevantExperiences] ADD CONSTRAINT [FK_dbo.VolunteerRelevantExperiences_dbo.Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PostedJobPositions] ADD CONSTRAINT [FK_dbo.PostedJobPositions_dbo.PostedJobPositionCategories_Category_Id] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[PostedJobPositionCategories] ([Id])
ALTER TABLE [dbo].[PostedJobPositions] ADD CONSTRAINT [FK_dbo.PostedJobPositions_dbo.Schools_SchoolId] FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[Schools] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[PostedJobPositionCategories] ADD CONSTRAINT [FK_dbo.PostedJobPositionCategories_dbo.JobPositionTierOneCategories_JobPositionTierOneCategory_Id] FOREIGN KEY ([JobPositionTierOneCategory_Id]) REFERENCES [dbo].[JobPositionTierOneCategories] ([Id])
ALTER TABLE [dbo].[FavoritedParties] ADD CONSTRAINT [FK_dbo.FavoritedParties_dbo.PostedJobPositions_PostedJobPosition_Id] FOREIGN KEY ([PostedJobPosition_Id]) REFERENCES [dbo].[PostedJobPositions] ([Id])
ALTER TABLE [dbo].[Schools] ADD CONSTRAINT [FK_dbo.Schools_dbo.Addresses_Address_Id] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Addresses] ([Id])
ALTER TABLE [dbo].[Schools] ADD CONSTRAINT [FK_dbo.Schools_dbo.CreditCards_CreditCard_Id] FOREIGN KEY ([CreditCard_Id]) REFERENCES [dbo].[CreditCards] ([Id])
ALTER TABLE [dbo].[SchoolDescriptionTypeWrappers] ADD CONSTRAINT [FK_dbo.SchoolDescriptionTypeWrappers_dbo.Schools_SchoolId] FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[Schools] ([Id]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201612200536221_Initial', N'Waldorf.DataModel.Migrations.Configuration',  0x1F8B0800000000000400ED5DDD72DB3A92BEDFAA7D07952EA7CE58B193CC3993B267CA91ED139F44B6CB769299B949C1126C7186223524E513D5D63ED95EEC23ED2B2CF8231104D040830425CA51E526168146A3FBC35FA3BBF17FFFF3BFC77FFD3EF37BCF348ABD3038E91F1EBCEAF768300E275EF074D25F248F7FFCA5FFD7BFFCE77F1C9F4F66DF7B5F56E55EA7E558CD203EE94F9364FE6E3088C7533A23F1C1CC1B47611C3E2607E3703620937070F4EAD59F07878703CA48F419AD5EEFF8761124DE8C667FB03F876130A6F36441FC5138A17E5CFCCEBEDC65547B576446E33919D393FE57E24FC2E8F1E08C24242BDDEF9DFA1E618CDC51FFB1DF2341102624616CBEFB1CD3BB240A83A7BB39FB81F8F7CB3965E51E891FD382FD7765716C4F5E1DA53D19941557A4C68B38096796040F5F17A21988D56B09B8BF161D13DE391372B24C7B9D09F0A47F43A264D9EF892DBD1BFA515A8A132EFBEC050759F99F7AD55F7F5AC380A125FDF7536FB8F09345444F02BA4822E2FFD4BB593CF8DEF8235DDE87FFA2C149B0F07D9E33C61BFB56F981FD74138573CA1ABCA58F05BF97937E6F50AD37102BAEAB7175F2CE5C06C99FDEF47B57AC71F2E0D3B5E2B98EDF2561447FA5018D4842273724496814A43468263AA975A1AD4C3E778CD6224E9B5C359C02F140FA26F1A1A77DE1457192FE774D3589D8A0ECF746E4FB271A3C25D393FE5B360A2FBCEF74B2FAA1A0FC39F0D8106675926861DFF227B2A586CF19BCFCD3C924A271AC69FCE7B76D34FE0F6F3E64B535ED1EB6D2E9D32099B25FD8889E4FBD31F12FC24530C9D049FCBB6431F1E85A16EFC3D0A724B06FC2F7C3DFD94CCAAA8F48329E7EF59269B8484EE7F3287C267E53F2C5F4701F91201E47DE3CB9F07C6A00D0E12B9C304DB25B168D9F4E665E30649F58FD241E86B3B94FD9886EDAB5F75EF81491F974B9B12EDD44F49146119D185A6B6710B03F1F594F2F67E46933DD654B7454CED8AA668E7E69A3A36CF7408711251C46D29FEEBD1982D61579F69EB2212AE23145A117B33590AD2BE7DFD9278F6DA618815BEA67E5E3A937E7D7876F608D8B289CDD86FE6A91810A7EBB0B17515AFE3EC494BE27D1134D2C3A944D1174924D1B3761CCC4F55BF8C0FEE365BDD175CC5453EAA0BE02D451432DDB0EAF678ED5A446C978CA30994E2DDE239B9F4DFDC61210BB8FAB07480159D95A186C1AF292218926BA0E7385A44EADBF418C97056C993B672BD7C2A88E4A29913DEE23C01F5FC296C10BF21C465EBAADB41937DA5A62073485810EE96AD876F0D7884C9870A8AE3B5C1991F9F52780D5F2BB2D637CAFAE1FD93180B21D65A2E112AA20B2AC2E07F00F14B6EDCCF578BC9817FB41F42CA4AB24760A2E0B744C53C1B67329417630AF3BD9E2AA8B1DC6D402BA8EAA5A4708D929DDD4D555215587F26F1AB68B02B6CCDDD271389BD1E248F289A627641D9F407991656531807B7559DB8EA447F174CB971DEDD9B64ED307B9A8C8BE5802E05C2A66CBF40A61A8BDA4AAB0C8B85C06605D51D096F9CFC184464F8845422C28325DFD0E302C14B265F64BE82FD8144D23C6257D26418212B9B696D80D4D61A04FBA1AAA0E1E0F4A939FD610081E3BD0A64180C2DE5808B715C4ACD82237ED6ED8B2B6DA886CBC61360346497AB2B63F658BFBFD60E284CE2D8DE76C247B0F9ECF4442E3B345C299D8D4860E27869D74449BF1566F386B4FC136A35A4B683FB87503AC2A2B3B4D6F162E2873415AFE6B44E68C290B00D992DE43CA250260DB3CA486CA9595B9B023FC7126233CB2D695F69801DB2A8504DC4AAA0B5882AA24A2A15F8BF2D562F690CE37E062FCDAC95A3CFCF2C5D8929BFB0DB633F6A24CB5A33048A61B6CEFEF94B4DFBD0FA1CF4E5DB8AB6A77ED8DBCC9C4781DE7B241D48DB87D73E809B334435B4C9865A5FD8409B6B5B97BDD16F773B051DF022E30913D7C60ADEED2B67F75A162018A55953D04C0B672BF9AADF84B0D33F6366FD129AD30D99E2FFBE5F4E121A2CF5EB148D97A63D0A788D2F3D97C4A62CF608B69A34F5B705D6A73A073F391FD095EAEBC1FFC605B9CB0A4A390F4ADFDA50079297EEFD1E83AA043D6E5A7305A2AEF3764187CD35128EF3AAC2A4AF71E76B51BDD81E8BA5367B40844F6A306356AAA42D30E22555157C3E1FEF7103B1C4410EA282987059E806E78585071394C2ADDAB3B4C3822FB61821D269CD04CC3442AEA665F013AFE582001A4B10702D896A30D691736FAE17831639DCE6ABF88BD36C223ACDE4D9A1DE1FDE871A9FD1DB9475BBBF5D543D7728F1F347E241D73BF76C8C4A77295B44085AAFA1E19605B2F6201137C542DD022D4DC03056C6BBF81EB2EFE555ED3E8212057DE8F02B8ADBD032CDD3BC0B632882BCEFF16E3B7526F3F746114EF2F391D5D725688E63FD53A458CC83F4317FE5DB6CD7A8193667FA8FB586D94107AAED250D9CF5C705BFB4DC77ED3D192E9B781B7DDDEC9CE76F35169F1F5519DC158953894B74B57AE8EA9CFA1E9F07C36F7C3657AFE96888A9F6C3DA0BCC477B0B733ED80F2455D3F25BA59CFD340241AC4846FEC8C8EBD596AE2BA89D8FF8A8C87BFF47B7763920ACA1E537C239246E48F96D43F90F83D1B348F5ED2380398BB0521ADC83665BE2A6F92B9A6FB944B5AAF0D692C7F53B966C0A5E4B06CB868FDF430E9451F141F2FB52757D375442C8DE89054A591F78844BF86F3084863BF66826D39754C74E553082A12E95A58A7BE19F118228DC6406544D900BF5A718F76B0AD56EFC7B2DDA7CDB558566197B5A5DC5DBBDECF03DB6FF9A36D08E9368C9437D330A0C690D22327119E4E93E41ABC5EE883B92547A95C7F8F03723A1E67F1C385FBC133F52BD800CB586A2B0D8DCDD2EC521EF5877FAA611D8942DF4F0F5DCDCEA66D65232D54A7588AF361F66D5DA45C64AB5FA4E553F8EC38A564415D9D5352FA0831D720AB24325763D1903E47235808E2DB414EC69C1277D04ED1A4ED035443EA87BA20D417A074C3AC55055A2DB2546535F68B31D8169BD0294D36BE60E6CD1EB56D717A319787DBCA4E3F64CB6412E9645863A361B9F71626117B67571D99FDD400E3582536C5665D2A613B5E6AD8F761082D66BCF9497C84E332BEF0C953F9080C3E9B06231C8B8F7AB8024F2FF343F1976C6CF122A84A6D44D3E3C56A291C27DE33E3FF0BF117ECCF4349C695D237349864E3B6287E240B33179B469466A7F686B23535B04561F3B92EB1323F27AC8DE1D4F3270CDD9355AF201588B5D3C40B34966ABDD6D7FAE03D4DF3D124D57CA3AF393A2D847B3E59AC62BA8A9A6FF535EFE674EC119F0D45B1C93FD540993A3F554364A988EECAD0BD0C84F275C6AE9895CB993CB72BC92F5E4CB0721C1176B68AF223256E089ECE68C4A69FE0FCFB3C3F75E0C6E099C7D6DB78E82F1EB063EFCC8BC7E1338DB023EEB7E1FB46634CB11B6D080889E21647D7A7B56C5E19F4FB118B9DD37FA031738B85C9F0140B8FE1351618C37B081712E4CED7257F36941CAE4BFEA22F79514AFECF86C5ADECFBA141491F2ECBA2A699F2AC2C6A50D365C9EAA1414F9757655183A22EB96E1934F5F1AE2C6A50D5C7BF97450DBAFAC4316050D6A804C0A1415BA352AE47066D8D4A068E4CF371A9D82383B646A50A8E0CDA1A95723D32ED78CA617564D0D6A81C5747066D5D95723D3268EBEA4B59D4A0ADAB0F655183B6AE7E2B672083B6AE46655183B6AE4A10BE3668EBAA9C305E1BB4755522EBB5415BD7A5045E1BB4755DCEEBAF0DDABAE6A66B83B66E4A68BF3668EBB684F66B83B6EE4A61BD3168EBAE14D61B83B6EECB01F3C6A0ADFBBF95450DDAFA5C8E8237066D7DE18A1AB4F5855B070DDAFACA153568EB6B39B6DE18B4F5B5D4D61B83B6BE96A3E0ADA02DD4C64B72BC68B8ED12E86D6FD37513D1FCD8F98992FCA84BD1E7E475DDD33866676C92DEA5E1365B1FBD2C7A8744090D540D1BF0CC5797DB36203C3F9FAB5A35E03DAF28B767C0BE70B2E7DA338C84B2A2DCA6616470660F76003DF3223AE6ED1F86C1724327E4297C4A9F341D4E89C7E1C130D19DA577BAE13CBD5595DA34ED01F90B59E45EF0963E657DE41A3100E753F83B8DAEA352B2C3308C265E50B50E9916B4C7476F4CEF16F3791871CC1AD0733A1EA7067936322F587B59FC08B08DB49E9054D9B51CCE4F32F9ED4D5777E32C6A26C64E511F16ACCF5EEE6D899B9A4624CDF58D9B87EEE9781A847EF8B4C44E3E5FC3C89F7C22C1D3823C713C9976B18BD81B63E79B9B888C93EC39622FA037347A0C2336193C9D46498C9D796EA6CB38A5B0B6288EC2675A199A86F9E77C114D97C974B684A69C3A18975263B9C5B8407E8B189F33C8C6532CC47FA5D18C0458785F446CFCA0013E22C184445E8085F76F84F14E638A05F675C2AF8775E6412E22C3C505D176356FB9FF525F6ED4B132F3D1AC0DC55892DA9E1CDF9F6245F8FE0E3B70DE5F9C42A30607545D705253E8C2B477E5B2641598D200C4621C5543A156C96D7139203E9B82E9E48255CFDD0A915B9F70C1DAC1C23B9DFD2AD40D2BC33AA4397B1D37734E435BC5C32049F7289B5B24E478AEA6D76802C1EDA143D0B269C5088205F16154E02EA1243FEFA6775002C15D99B35CF866808ED10D650AD0DD9E68D3E92BFF010DD6827B7859906616B65DF526990B1FF2C637375858785B5427A3B7B5878FE479E5640C0954B7A7EDAB4514D3083D2FDD44F42356C9BCF10FABE7CCEEB30A0742BAD5642F5509750C2B556957C21ED6AB70FA1903A7D3380EC7F95D3D7F06FA063D0C5C6DFD3C98F4F8778A815AA56F78E93258C4C08D1862BC39C388972C53C556E8B316AE83339ABE23D94B27D3344E7B48E23199C8BE84AC77937ACCAD5CD1F90013E859E42ABB7F90B8B8A58F34CAD320B28D494AC00B12B14F37EC0C3CF6E6C4B7919D40A48773244D05B36E4EFC7246D9B623F501B51113868F75189ECCCCBA4D417B26C11D0F38A4A200AC7DC1363601595FBB23803630A902B6E181E036F18D13E9E6708E93DEAEE01DF5E0AE09F63822DD403F9257C520B07FF6B8C5616127F28D8D0E3BE9EECC2029E3090DE052C4161AC02EA3424354854A2ED6B14AF9D5C1C1A1B897B3EC78F906A8690AE04A76639CF30C29C4C63F89DAE23055886563635121815D1970F063A2261C6A6A7603973A061538D5BDCDDA226E1162DC188E1112DB155CAFDE4335A1785DAE1B982DD95120B47C16B6453C4A02D918FAA4BE771F6BF51E9B8320D0F0E5B91228BA244DF83D51B327EC60762A0FD339DC48D93D8489E8B5CDAB98CADEA28F27759B370B5BA37B07BB567E85B87ECCEE06699C18A65C75A56ECCBF006F7A396FE214AA17DAC6E668BD7CBA3F61E7BD009F3634ED16E08ADD80AF863F058435AF44B68864B30C378666B3B87605D18837084DD8C690E806CA519C2AF06EFB02648B83C046D81B1B0E3672DDA58191B97962E09F17EC0EC80B7E00282F3709D6AA68360AC9AA14760578AA171A4D1854D6E9061CD5AC2990A97ED8B245746A85B631A06AE5B32B9815DE8934C1552CDE0DA44A5C29402A3DA5D9223E21296D0C9A90407605958A771FF508902B7403990ABE14D8543D73D9223C61616D0CA0B05C7605A295D7094DD366B57037A029F0A480A5F070638B8854CB676368548B625790A87BC14E0F014DCD6E6054C7A002B0DAB7FC5A842F428E1BC33242643B00EC3A8F9180506AF43209077FF8B91C0BAFA3262F9C6CE1CE077EA409DD43C58B4D1AA13612A6FCE2531DFD399698F42A14BE3BF01351161294BB63DBAAD67506E17767213EE1ED038869E82104EEBC574469E0D104BC9E5009412872DC3BC48BFCAA82813FBD1B64ED6E6FC511127EAAC1C02DCE014D2D8C96762CE677229A4D7BB5F62746716D605F62140C8687320FF9563624FAF7380C90303DCEB15DC01A1E0391B88332FEB7895FBD04378761BDAC3A87E33C0D7F1A8D4FD2C4C7AB0C45F9655FFA33FD9E28E2503FC7B408458D8B17224408A564EF68C29D15B2FC4B65DAFFEA89515A7BAAF581E83615413008D0D48421F24CD192212ACBD0A06D3C8B8A05FB98181353EB555CD91CB7C61B08F1A10B3221DEFDDF4048E78B2E13D6F96B1B1A2A9D8365B2A593AD8188EC00A622A77213C313AE9EE6D4C34A77F8B36BA974CC44B554F1E334B4A4F1B892DBD1F825199AB1F3F08026291B1F1104434B44934B1BA2EAAB6599B0FA2AD6405CBA0394E94AB7670692B27D5F455575EF61202C98DD659A82D1DA404E632D5311D71A184DB8C0CC70F6131B64D5001664D806829EA9C1D55EB4099860976D8594682BB6C1C67D43761C07360AC5511DC5847A4F0BB306ED8185C6B86D99303F80B91C7A5C1D7EB2C0257F5098D04DE91FD602E1F671D2D6D4366D034714DEDC894795AAB4F092346DED4089DA6423500901998FA09E8491790478499B04E148E0C8A87650EE75A2E21512B28C8BAFA505CB7876AE8D1AFB7F57EAE1B6F1A00A006BA34A04B2B9B19E2865FB222F2EFE64E2481095430A240930085BD1055518762D59A8C2A7394215C61D09437BD08284838E1456F411132B5C4B7898185F8EB0B6E38E84CB1D2E215102C1A98AFEC9E1A9B5C4248795726438861B8BA05E40A442500E222B2B7268165BC9494B7F3AD768A2593825CC81706A77A9424418A55E75B6719890C02C2231D5828216D6060D9A35A3C546EDF90588B904271B4C8CA662CA304469D69A860CD19576AAAB2D409D2D0A1222366250D16944CC602D612262FD38BABA4E3B922B2A060D94B07D049B422656316CB5A46E157B26B660639974A89422FE492B7A558C14D07D214AAAB61885E82681CEB2157100A653483288201E45E7F4613CB5E4A50FBFE148021D74243ED9380C494E1F4AA2E821184C524B5E601008474DEE8C2329A92CD9909C4CC10D8ABE69C21B6AC94A1396C0D1531AF11D094CB4E343C2D2B9D92B3A0638DAD71212E020CFD1123BE14836DA5B064850682F70454F317EE0B54488F1DFE608EB6F639A4BB78E57B14AE08DBD93ABA26AE29FCCAB457713A453551397E40D1E856057648C8E00C765BD2464D7659DBC2DC52C3B2BD753A61359CAD77B1899EA5D9B0DDD079D9B5DCA18F465569A08D5135B0D010B6ECC0A61EA1C9D556E7AA2AB33BFAB595DA46A24033837572EEAD6B7A9AEBAAFBF8A30783EABD8D75F4658C86193B711B093332C142B83BBD927BA9E907006F656ECEA7A7F5B586E18075D55570D2EBAF5E467F0AC9588825E086871A6FEBE1597CFF5B7E3016B83CE48F1C3F1801519D379B220FE289C503F5E7D18B146D99E3F2E6B16BFF4EEE6649C3A11FEF1AEDFFB3EF383F8A43F4D92F9BBC120CE48C707336F1C8571F8981CB013E9804CC2C1D1AB577F1E1C1E0E66398DC1B8A20BD14175DD521246E4890A5FD34BD509BDF0A2383923097920E9232AC3C94C2A2638B8020E20ABC6AA3EACB252570E20ABF2E9FF2B8EB407293799100B7F57814629C20BD6ABF4B9B1AC8354B47EC8F558CDBB71FA38D8CA8F9873661EB2BDF22C809D9BE1DA5963FCE34E3C29E9239E6EA699F4BF558ADCCF785A9F888A54F92B9ED2F98C78FE7A1DE6A955BFE029FEC39BA740AC125BFF88A7731A2453F60B1B30F369F69A6BB8286C38C4BF4B16936C27C2B781AA60D1BEEF87BFE7334FE632F2D54BA6E122C9DD48521FBF4ADBA6C2F8765706D18804F97C77E1F95456B6A6988D8C97059DCC0F2935BE7E0EBC245EBB6788123616C7B7FDDE0B9FD8143E5DAAFBA7F86C3186A33426806D5364BAC2271B9AE12363E572C6A65E1559F12B9EF2E79846E29CB5FA0D4FE52CB7DD11496B950F32BDE38130FD8A73FC409AE485F5565C33502B0AE8F8D66C8941FA0122161D34A57696A1CB2066AC2CD2E94B20C37FB080EFDA63B6025BC08F5647892D7F51BAC5104600F7B3C5F2134C644AEB1FF1746E693C675B6BEFC1F3BD74A372B648A4F5012A63B93510D50AA602D8DED0B2F6DCB41A61FAC89F1A03CD92604BDB3EB16149CFAA022F0E3BF68E99CDD0641DC4658FAFE64DB478D0B0408469C308754BBD6F844B77078B9C9DA921CA40231A063F9ACAED20A36C113A87AA4BD4694147DB96EAD5227FDE96A7B6FACD82B72F5F5484B89F2DF617DFE75E94617B14B2E3A1B0CF103FD6A1FB774A22886CFE0D4FF543E84F6804180AA48FB674F3075D21C2FC575BCA6A7384F8AD33F38ADEA9DD665EE14279EDE7155DE576E615F549BBD6017B377633761EFA369AD7C45ADB23C186D87EF7DB225E74610836E85887CCDB6301AEDA8EE673A3A53C2BF0BF5BACDD5E1AD95A59B63D39D655CB4FA2B22CD85903CEE85344E9F96C3E25B1275801C46F78AA268B6C3353EC8E8C10951B7AB3B1A2C807613F6A3044DA193FBC5B8FB495963EBE643CC85E4DCE8061F016B303889158FB40A972A0C78DAA6C57D55F8DBC72AA7E4D509BBDFAB5C436A27E8E03A3FAA5B29D51BF5510908DF2E18437F6BAB7A0D58EEAE5AD82EDE6C0C9A6281C2F52F9645D57EF6080222F6ED1B20D3D6A8665CB044AF6006FDAC0DEBCBD35142E1DE36CD91C497A122D6205F0B67AA11B676C209D0D0294E9CDEC518023B337513AC101222CD0060262263A7BED1B29EC37493FC4264915DED80C9BE6C84E043C3144DA41E8DE236BEF9155732C19C3746D86513585A7FD0832D4DF5F33D85D33A8AE176CA88CC83F43C183A0F8C98286174834F29FF6D71B5603551B62DD6CD85A44A02306B115B5FD7AB85F0F3B35CC9CBB63B8F0C2D89AF345F9E885BC323674E300E3D87405B763B7399FCDFD70996A4626287EB358D5BCC41717B2FC279B757E1D782A2EF6DC078BDD4B389BD3202632C1EA977A14150E9DD2570B073F12BFA7017DF41261AEAA7CD8CED49C96677B115F15F0B4FAFDC5C64FE93260389E4B1BDCBB5AD06AFFDAB58E7BC6D61D179D045E0B4F0FD8EBD144A01B5748DB32E116390F1A5A6EF3571D6A186C818A6D6E56A07D85FC759316E09B69185055EC40E5C33683E3BFD207253DFE778BF0EDDFE3809C8EC759C0467159F34CC5D074A810BE9D348E218BA61797C6CA079B335514FA7E0A66F15855FEFE6217EE329150B3F902488D849830C09A2DCD1849446922EEF7F2DF6CA91CA9C81CED9EE9D055928C211B7C49247668F5636730AF4FE0E362DD049E1CAABB9A62C9B5B9C60A3CA8165AA9489B4687B6B1534DDBA4F095A9244C337AC2544AA3320AA529AA543B50453A34593828187084D46F9C721CD4600E7CF0B53646B51C0DC360921D9E7A97F1D5C2F74FFA8FC48FC168524597C55C5DD6B8A8F9BA463DB7732DC9FA0EE70ACD367A19A3A6FA35841D60B5D16B239D02B4959C5C021CF3F6885DA08D96947D888D5EEDF80744DC009827EC16C0F8B757BA0C5CBD7C1A03B75616E87A76492B18A32D92AA05B7412AE84E82BA5687F6D88673555B22F89B054EEBE053CAA15D77DFDA26E6A42CE29D42D6667124E7DAB6C3935CDFCE928FD2179499BCA6DEE4065A411994EABC5368C3C8A231ECC4ECEB66EB4A591677F9A050883AC37A4DE1AFA838008A3A7F7CA74001F7D61514B0861545F1A680E8A86D05CCA8DF29643434AE48F9D0C5226B935FF1CBFAEF753EF422177925497A269334E579268BB8C88B2E2627CF8BF47B4C00CFDE244D4C7EB76493DF2C83DBC1DDBFFDA1EF653741AB022312788F344EEEC37FD1E0A47FF4EAF0A8DF3BF53D12E749EE8BB4EBEFC68B3809672408C2A448818FC8C37EF83ACDC34E27B38158DD3E9B7B4A258E279541C019B579EB9D907DFD239570B0C2C72D7DEC41503A1E88158F15704CDB3EE93F784F5E2AD56CDCFE4A99D249B626A6415E415A90668CF67B29E8C8439AAFBF00DE40DB8294193D6F2E6BCB921497E32C27123C93683C4D73A98DC8F74F34784AA627FDB7AFAC0997B9C8DCD2ADDE066B68FFFCD69AF6FA524843F6D09E6554B2F41562EC5568CC875E9FB426F1B95644151925D102212263B6F3FABD50A43777CBBD90E7DC2D286FA46CE76E995F653FD7513DFAC59AED8A43404E9B619E265EDA034B5AC2D25B9D5CC535E4DD6530A1DF4FFAFF95557ED7BBFCDBB74AFD9F7AD7115BE1DEF55EF5FE5B2F2BFE924DBBBCA0D297EFF282538932703B9F9731076EE9725EAE0DD1B70E406848078A38D00F67FBC968E5B3673D4C8A9AD0005174123F422CF28EEFF24051A66EAC365967AFD73575364BF3BDD30ADEA03AE0FD189C71057B12C0AB1AC8C8BDCB4A5467F4AE7F8812B378D7A7B4F29BD5AC09AFED97042E9DB7DBBDA394D5BB2DF279766FB7D4A524DFDA0D484DF27CAAEF36E8238FD906EAE8D900CAA3BDCBB3416BA7C22EAEDCD8F4D7BBACD01F6413A6CE5EBDCB8AE31354B83D0DE67EE7CE4F9849A3C55E4C8F8D9F7E50E4DBB7DA757258987CE7767980484194F5C1B7DD838CC187C89A272DBD162C7E588FE39702365562ECFAD833B8F536D57E955EFBDA07335CBF20ED4B79B19D1B1A90A9A37759A6B66BF086B621EA248B3FC056A14932E75DC6E10F67C4D4E75ADE7955EED25E10AD337366E45DD6DB0F35CF6AD31CEFB216F70B7AB780664A58BCCB58DBFB60EC7D301A0D0E4D2EE25D1E173FA4D1B8098522E3B1E355ABC881EC7691F9414DD8E884C3BB3C6EF7EBD97E3D6B76A87FB937D8656A206E9A47487B55AF917D469BAFB8A191A129113139717D4A456662F404811926951CC56ED7A96AB6E262D6A0636F960678DC44EC7F71167E75F80B43E398A4648FEC373C52F2E2FAF2ADE42C5E8D167B32EEA65C3E53314C0AA56697A10D8D2EBEDABDE642A6EFD8E589D6E185FAAE5F69EB9215ECB28A81BD4BD345B19E5255645AD0A52A307C133A6C7133E46613D28699A092F05843FAC8DEFFB95EAC2B86349F04D9ED4E05CC815C5F6B95D4C73999986D7CFC5A3B482EEF71032B8CC32D009F72C26EBB5FD6C4CF218A2D48E7A32B1529947777362BB231BBB64C14C9999D9E673A69006D29487F9DC8B9C1346BB93E63121FEF2ECED54993EBEB7D833611488F5C8E177E73F90D17FF7D1E4C7AB7A1BFAAB5EA479A4EE5A0F865B4F0136FEE7B63D63843B194D9E73A38A369DC65EF749C675B1992784CE434E659B61BA875885B9E1FB04C95C33F480DDFA69910F26BFE6118A4043C3979F54DE405636F4EFC8A3C845248A0A79D5DD313BF9CD1390D52041BBA8E691A7C0BE578B06E465082491895AC4128A069C3A8C525B23380D3077F57706728BAE3F0B38882EF300A51D1DF5D05A375E83ACFA87DE5DD066CB338FF2E43188A6AE78022E4E95B4180FBB9AADC57070787927EAD61EF08225007DBC1091E90C6CC811B834019CADCD5A98A0BB6E659E07FDEEDE9058A26075AEBC2C401C74F7715459A886F9E255DB1DD461936E4BDC3A85B857A771563EB50749E81F2C7DDC68F3ACEBE9368A9F79E0EA455D3AB3E859E75C5AC7648A6C72AD4ED558AB58234ACE8DA811FFE712365EBD64F0D6D16A688D7713606173C3C556743D5E74DC0D11610EEE06873E8B37E5B65636B2BBF85BB7EBC0C12463E4E3ABAD07605831B5B7C6BC2AD0B9B3630A0BDABBB3838029FE748536AB7A1864C40D061C421E2D9BB8A3DCB507C914D9BAABB8DD226390B3A0EDDECBEB5CB005DEA20B87C612083F325741846AAA4015D459432C101CF8CBAC06E23CB9CD5A1C3E812F21874155862BA059E0FE9DB6EC3499B59A2C34832262AE80A96148CF2ACA83EEF36A24C9AE930A82A01FE5D9D9CAA5908782E842FBB0D234DB2850E23081F78DE1538E938E679D296DB6DA8A195D64DE0D579691C611EDDC895001C2159190F70A9177841807EF45DD97827EF09E0A7C437040C5B18EA5B696BC26BA478D7A8C379A375105BD2B3E22D69DD8029211C58ED2AD4A203633D853A7315422FDED817D5378025E1FD7048B342DC6711EF51FC66859122CCB8625F287E6A0513CA9EB58304F5D3DACA96F40FA46F4EEF5BF069DE340036EBD56C81812EB8351730B0704C45ABAFAD3B954EEC5B2CD4BC954D4A19F8B84D5829E339BB0B2D6D84ADCC155470C701878F33EE02F6F2A05B5627613568B40ECC9ED0EC91BE3392900712CB96A8B4D61D4D787346BF5746F056AD52AC4774464EFA938790E1200F015EEDB4E585AE4A1A8C8A951A034BAA9A070A23F831444BCA6C192A28B933C49C9A98B48F9993D8B627A1EA882D1544D7B87D93CC34F751C9CEFABBB9213EE4476A88FFA86A880F743235A48B02911AD6155631A28B9D3131560613486C949F548D96A113A62654CE935263AA42AA66E572560C4866491D2352610343D5F298894FE7E26FE2AC5218C159591EC399C61B51624C5356C597C67FD3C495AD4B9A72B1B22100AE6A681AB84E2DCD6C2F518C2DAD9A567BC248CDAB8BA95850FB0999D8909C27240EA412AAC625371253BBAA5B76A969552155EB72393303C2D5ACD4B6F05DD5AC70396D6A517B5F27B5AF2DADE24653013110106B237249ACB1126A2E0DCC5CE86762A8386622168DC29ADD02BC11976CDFC611599C29E581587C508EBFEC1B66BB5F184515DBFBE28B7A3B9F7D44730F9D3D813E41C5E19EAA6BC8EC71C73261D607331CF5B83AFC1A804B89A4F22358CB68FD8B74F244A432E2A88065446B42B5FB78D198CE47A0886C92F9341715EAAC984BCC50D491E090696440F9D54943D3588C754FB31979FBCAAE44CD9D45417182B675E00281EF18F7B346784881D7EE66E5A40BF513CCFBD1181BF2293DABC8FFECA8A3DA9334D47174EA8AC682305B113242BA628E04C59DFE21B100B9151A0B41B45864D5CA1F1B77B05EACBF420C0E9206543A6E361664A2D015D388D56C245151AF1473297A44FCBA5EE4B601F0ED0A03A2AE5ACD549F1D0D5B20261B1CC39818EEC6037A7BE2D059A2209160A38F1B8BC56881CBE8684A3912122AF81514977DE86C63C1D53312AE89DB547528E22248532B485520A71371A9CC8F65F536BA0C180AA1DE23E20F1B0B42670CCD48A80B3812886CBC8464A18F966B2C06C0189BD596BE39EABCCAC60A75DF1C48D45000B0553823A0FAEC480CA22D1712812E20A971F79536E9ACAEF0C551A7B53666480216B1190DC58130986794B4E59A8BAA4E34874A7A8DA34236B84F365AE47315C2A5DC8BFD9B9570817886363B69F203D4D16C4560F2D50346707A677D979D040C2CD24C217E6A2C2AC1AB5C21169DDFB960AEAF5CA814E6F9E237DD525FB9E5C957F8E22757DDD35B480D1ED60E4DA41BE82ACE6688F426AEC7FC9647BFDEA5151606C607D6814030D7821C2DA8205A4CABE74ED69E97EB6FC783FC56B1F881FD99841179A2A37042FD38FBF57870CBF613DE2C7F28E59831E33D95248E19CD80667EBC25D15599CBE0315CB99C0A1CAD8A888F8CD384B0530D394D0FBA649CB0CF633679B05D6EBFF785F88BD4083F7BA093CBE07A91CC1709EB329D3DF8956930755CD5B57F3C90783EBECEA41BBBE80263D34B9F0ABB0EDE2F3C7FB2E6FB42F10C0D4022F5882D5EEA497599DE6CD2A7E59AD25518200915E25B3BF2DED3D9DC4FB7EAD7C11D79A67578FB1CD34FF4898C97ECF7676F92E2102262564455ECC7671E61BBFA595CD028EBB33F198627B3EF7FF97FC147203BABFA0100 , N'6.1.3-40302')

