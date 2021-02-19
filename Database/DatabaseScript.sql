
DECLARE @TableName VARCHAR(50) = 'Sensor'

IF (NOT EXISTS (SELECT 
				* 
		    FROM
				INFORMATION_SCHEMA.TABLES 
            WHERE
				TABLE_NAME = @TableName))
	BEGIN
		SET ANSI_NULLS ON

		SET QUOTED_IDENTIFIER ON

		CREATE TABLE [dbo].[Sensor](
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		[CreatedAt] [DATETIME] NOT NULL,
		[Step] [bigint] NOT NULL,

		CONSTRAINT [PK_Sensor] PRIMARY KEY CLUSTERED
		(
			[Id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]


		ALTER TABLE [dbo].[Sensor] ADD CONSTRAINT [DF_Sensor_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
		PRINT ('Table: ' + @TableName + ' successfully created!')
	END
ELSE
	BEGIN
		PRINT 'Table: ' + @TableName +  ' already exists!' 
	END
