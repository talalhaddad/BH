﻿CREATE TABLE [dbo].[Transactions] (
    [Id]                  NVARCHAR (450) CONSTRAINT [DF_Transactions_TransactionID] DEFAULT (newid()) NOT NULL,
    [UserID]              NVARCHAR (450) NOT NULL,
    [TransactionAmount]   MONEY          NOT NULL,
    [TransactionDateTime] DATETIME       NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC)
);
