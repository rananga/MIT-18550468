Alter TABLE [dbo].[ExamSchedules] alter column  [MarksReleasedDate] datetime  NULL

Alter TABLE [dbo].[ExamSchedules] add  [PeriodID] int  NOT NULL
-- Creating foreign key on [PeriodID] in table 'ExamSchedules'
ALTER TABLE [dbo].[ExamSchedules]
ADD CONSTRAINT [FK_PeriodSetupExamSchedule]
    FOREIGN KEY ([PeriodID])
    REFERENCES [dbo].[PeriodSetups]
        ([PeriodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodSetupExamSchedule'
CREATE INDEX [IX_FK_PeriodSetupExamSchedule]
ON [dbo].[ExamSchedules]
    ([PeriodID]);
GO