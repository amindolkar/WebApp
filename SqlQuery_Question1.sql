 --for question a ---
 Select City, Count(FirstName) as UserCount from Users group by city having Count(FirstName) >300



 ---for question b----

 CREATE TABLE Student (
    ID int NOT NULL,
    LastName varchar(255)  NULL,
    FirstName varchar(255) Not Null,
    PRIMARY KEY (ID)
);

CREATE TABLE [Subject] (
   ID int NOT NULL,
    SubjectName varchar(255) NOT NULL,   
    PRIMARY KEY (ID)   
);

CREATE TABLE [ScoreCard] (
   ID int NOT NULL,
    StudentId int,
	SubjectId int,
	 Score varchar(255) Null,  
    PRIMARY KEY (ID),
	FOREIGN KEY (StudentId) REFERENCES Student(ID)  ,
	FOREIGN KEY (SubjectId) REFERENCES [Subject](ID)   
	 
);

Select FirstName,LastName,Sum(Score) From ScoreCard sc
INNER JOIN Student st(NOLOCK) ON st.ID=sc.StudentId
INNER JOIN [Subject] sub (NOLOCK)ON  sub.Id=sc.SubjectId
Group by st.FirstName,st.LastName
Having sum(Score) > 60
