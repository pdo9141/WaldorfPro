﻿--SELECT * FROM [dbo].[__MigrationHistory]
SELECT * FROM [dbo].[Addresses]
SELECT * FROM [dbo].[ApprovedMatchPostedJobPositions]
SELECT * FROM [dbo].[CreditCards]
SELECT * FROM [dbo].[Evaluations]
SELECT * FROM [dbo].[FavoritedParties]
SELECT * FROM [dbo].[FavoritedPostedJobPositions]
SELECT * FROM [dbo].[Graduates]
SELECT * FROM [dbo].[JobPositionTierOneCategories]
SELECT * FROM [dbo].[JobPositionTierTwoCategories]
SELECT * FROM [dbo].[JobPositionWrappers]
SELECT * FROM [dbo].[OccupationalCertifications]
SELECT * FROM [dbo].[Parties]
SELECT * FROM [dbo].[PartyTypeWrappers]
SELECT * FROM [dbo].[PostedJobPositionCategories]
SELECT * FROM [dbo].[PostedJobPositions]
SELECT * FROM [dbo].[RecommendationLetters]
SELECT * FROM [dbo].[SchoolDescriptionTypeWrappers]
SELECT * FROM [dbo].[Schools]
SELECT * FROM [dbo].[StateCredentials]
SELECT * FROM [dbo].[Undergraduates]
SELECT * FROM [dbo].[WaldorfTeachingCertificationTypeWrappers]

--DELETE [dbo].[__MigrationHistory] WHERE ContextKey = 'Waldorf.DataModel.Migrations.Configuration'
--DELETE [dbo].[__MigrationHistory] WHERE MigrationId = '201612102229360_PostedJobPositionForeignKey'
--DROP TABLE [dbo].[Evaluations]
--DROP TABLE [dbo].[RecommendationLetters]
--DROP TABLE [dbo].[Graduates]
--DROP TABLE [dbo].[OccupationalCertifications]
--DROP TABLE [dbo].[StateCredentials]
--DROP TABLE [dbo].[Undergraduates]
--DROP TABLE [dbo].[WaldorfTeachingCertificationTypeWrappers]
--DROP TABLE [dbo].[JobPositionWrappers]
--DROP TABLE [dbo].[PartyTypeWrappers]
--DROP TABLE [dbo].[FavoritedParties]
--DROP TABLE [dbo].[FavoritedPostedJobPositions]
--DROP TABLE [dbo].[ApprovedMatchPostedJobPositions]
--DROP TABLE [dbo].[Parties]
--DROP TABLE [dbo].[PostedJobPositions]
--DROP TABLE [dbo].[PostedJobPositionCategories]
--DROP TABLE [dbo].[SchoolDescriptionTypeWrappers]
--DROP TABLE [dbo].[Schools]
--DROP TABLE [dbo].[Addresses]
--DROP TABLE [dbo].[JobPositionTierOneCategories]
--DROP TABLE [dbo].[JobPositionTierTwoCategories]
--DROP TABLE [dbo].[CreditCards]

--Party Linkage
SELECT * FROM [dbo].[Parties]
SELECT * FROM [dbo].[JobPositionWrappers]
SELECT * FROM [dbo].[JobPositionTierOneCategories]
SELECT * FROM [dbo].[JobPositionTierTwoCategories]

--PostedJob Linkage
SELECT * FROM [dbo].[PostedJobPositions]
SELECT * FROM [dbo].[PostedJobPositionCategories]
SELECT * FROM [dbo].[JobPositionTierOneCategories]
SELECT * FROM [dbo].[JobPositionTierTwoCategories]

