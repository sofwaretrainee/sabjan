USE [master]
GO
/****** Object:  Database [student_db12]    Script Date: 05-03-2020 18:48:36 ******/
CREATE DATABASE [student_db12]
 
GO

USE [student_db12]
GO
CREATE TABLE [dbo].[student_info](
	[student_id] [int] IDENTITY(1,1) NOT NULL,
	[student_name] [varchar](50) NULL,
	[student_gender] [varchar](10) NULL,
	[student_marks] [int] NULL,
	[student_phone] [bigint] NULL,
	[student_address] [varchar](190) NULL,
	[student_nationality] [varchar](50) NULL,
 CONSTRAINT [PK_student_info] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[student_info] ON 

INSERT [dbo].[student_info] ([student_id], [student_name], [student_gender], [student_marks], [student_phone], [student_address], [student_nationality]) VALUES (28, N'Neha', N'female', 99, 654654654654, N'chikkodi,Belgavi,Karnataka ', N'India')
INSERT [dbo].[student_info] ([student_id], [student_name], [student_gender], [student_marks], [student_phone], [student_address], [student_nationality]) VALUES (29, N'swamy', N'male', 99, 56446337363, N'Kadur,Chikmagalur,Karnataka ', N'India')
SET IDENTITY_INSERT [dbo].[student_info] OFF
/****** Object:  StoredProcedure [dbo].[Select_Student]    Script Date: 05-03-2020 18:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Select_Student] 
	@Student_id int=0 
AS
BEGIN
	SELECT [student_id]
      ,[student_name]
      ,[student_gender]
      ,[student_marks]
      ,[student_phone]
      --,Replace(student_address,'|',' ') as [student_address]
	  ,student_address
      ,[student_nationality] FROM [dbo].[student_info] where student_id=@Student_id; 
END

GO
/****** Object:  StoredProcedure [dbo].[Stud_Insert]    Script Date: 05-03-2020 18:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Stud_Insert]
	@Student_id int=0 ,@Student_name varchar(50)=Null,@Student_gender varchar(10)=Null,@Student_marks int = Null,@Student_phone bigint = Null,@Student_address varchar(150)=Null,@Student_nationality varchar(50)=Null
AS
BEGIN  
INSERT INTO student_info (student_name,student_gender,student_marks,student_phone,student_address,student_nationality) VALUES(@Student_name,@Student_gender,@Student_marks,@Student_phone,@Student_address,@Student_nationality);
		
END

GO
/****** Object:  StoredProcedure [dbo].[Student_Delete]    Script Date: 05-03-2020 18:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Student_Delete]
	@Student_id int=0
AS
BEGIN
	DELETE FROM student_info WHERE student_id=@Student_id; 
END

GO
/****** Object:  StoredProcedure [dbo].[Student_Proc]    Script Date: 05-03-2020 18:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Student_Proc]
	-- Add the parameters for the stored procedure here
	@Student_id int=0 ,@Student_name varchar(50)=Null,@Student_gender varchar(10)=Null,@Student_marks int = Null,@Student_phone bigint = Null,@Student_address varchar(50)=Null,@Event varchar(10)
AS
BEGIN
    
	  IF(@Event='Select')  
		BEGIN  
			SELECT * FROM  student_info; 
		END
	  IF(@Event='Insert')  
		BEGIN  
			INSERT INTO student_info (student_name,student_gender,student_marks,student_phone,student_address) VALUES(@Student_name,@Student_gender,@Student_marks,@Student_phone,@Student_address);
		END
	  IF(@Event='Update')  
		BEGIN  
			UPDATE student_info SET student_name=@Student_name, student_gender=@Student_gender, student_marks=@Student_marks, student_phone=@Student_phone, student_address=@Student_address WHERE student_id=@Student_id;   
		END 
	  ELSE IF(@Event='SelectStu')  
		BEGIN  
			SELECT * FROM  student_info where student_id=@Student_id; 
		END 
	  ELSE  
		BEGIN  
			DELETE FROM student_info WHERE student_id=@Student_id;  
		END  
	
END

GO
/****** Object:  StoredProcedure [dbo].[Student_Select]    Script Date: 05-03-2020 18:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Student_Select] 
	
AS
BEGIN
	SELECT [student_id]
      ,[student_name]
      ,[student_gender]
      ,[student_marks]
      ,[student_phone]
      --,Replace(student_address,'|',' ') as [student_address]
	  ,student_address
      ,[student_nationality]
  FROM [dbo].[student_info]; 
END

GO
/****** Object:  StoredProcedure [dbo].[Student_Update]    Script Date: 05-03-2020 18:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Student_Update] 
	@Student_id int=0 ,@Student_name varchar(50)=Null,@Student_gender varchar(10)=Null,@Student_marks int = Null,@Student_phone bigint = Null,@Student_address varchar(150)=Null,@Student_nationality varchar(50)=Null
AS
BEGIN
	UPDATE student_info SET student_name=@Student_name, student_gender=@Student_gender, student_marks=@Student_marks, student_phone=@Student_phone, student_address=@Student_address, student_nationality=@Student_nationality WHERE student_id=@Student_id; 
END

GO
USE [master]
GO
ALTER DATABASE [student_db12] SET  READ_WRITE 
GO
