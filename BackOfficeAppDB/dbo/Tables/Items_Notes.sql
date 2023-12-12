CREATE TABLE [dbo].[Items_Notes] (
    [Id]     INT    PRIMARY KEY        IDENTITY (1, 1) NOT NULL,
    [ItemId] INT NOT NULL,
    [NoteId] INT NOT NULL,
    
    FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([Id]),
    FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Notes] ([Id])
);

