﻿CREATE TABLE [fb].[Formula]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[RootNodeId] INT NOT NULL,
	CONSTRAINT [FK_Formula_RootNodeId] FOREIGN KEY(RootNodeId) REFERENCES [fb].[Node](Id)
)
