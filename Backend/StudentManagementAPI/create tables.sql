CREATE TABLE [dbo].[StudentDetail] (
    [StudentId]      INT NOT NULL,
    [RegistrationNo] NVARCHAR (50) NOT NULL,
    [FirstName]      NCHAR (50)    NULL,
    [LastName]       NCHAR (50)    NULL,
    [Age]            INT           NULL,
    [ContactNo]      NCHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([StudentId] ASC)
);



CREATE TABLE [dbo].[Teacher] (
    [TeacherId]   INT        NOT NULL,
    [TeacherName] NCHAR (50) NULL,
    [TeacherCode] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([TeacherId] ASC)
);


CREATE TABLE [dbo].[Subject] (
    [SubjectId]   INT        NOT NULL,
    [SubjectCode] NCHAR (10) NULL,
    [Subject]     NCHAR (10) NULL,
    [TeacherId]   INT        NULL,
    PRIMARY KEY CLUSTERED ([SubjectId] ASC),
    FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teacher] ([TeacherId])
);

CREATE TABLE [dbo].[Mark] (
    [Id]        INT  NOT NULL,
    [StudentId] INT        NULL,
    [SubjectId] INT        NULL,
    [Grade]     INT        NULL,
    [Year]      INT        NULL,
    [Mark]      FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[StudentDetail] ([StudentId])
);
