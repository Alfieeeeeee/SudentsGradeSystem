//定義一個School 類別，包含一個List<Student> 類型的屬性，用於存儲學校中的學生。

using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace GradeSys
{
	public class School
	{
		List<Student> studentList;

		public School()
		{
            studentList = new List<Student>
			{
				new Student("Jone", "A99K0016", new Dictionary<string, double> { { "Math", 100 },{ "English", 77.0 } }),
                new Student("Jone", "A99K0018", new Dictionary<string, double> { { "Math", 55 },{ "English", 60.0 } }),
                new Student("Mary", "A99K0017", new Dictionary<string, double> { { "English", 90.0 } }),
			};

        }
	

        // 在School 類別中定義以下方法：

        // 添加學生
        public void stuAdd(Student student)
		{
            studentList.Add(student);
		}

        // 刪除學生
        public void stuDelet(string stuID)
		{
			bool check = false;

			for(int i =0; i < studentList.Count(); i++)
			{
				if (studentList[i].ID == stuID)
				{
					studentList.Remove(studentList[i]);
                    Console.WriteLine("刪除成功");
                    check = true;
                }
			}
			if (!check)
			{
                Console.WriteLine("找不到此學生");
            }
        }

        // 根據姓名或學號搜索學生

        public void stuSearch(string stuString)
        {
            bool check = false;

            foreach (Student student in studentList)
            {
                if (student.Name == stuString || student.ID == stuString)
                { 
                    Console.WriteLine(student);
                    check = true;
                }
            }
            if (!check)
            {
                Console.WriteLine("找不到此學生");
                Console.WriteLine("請重新輸入");
            }
            Console.WriteLine("搜尋完畢");
        }

    // 輸入或更新學生的成績

    public void gradeUpdat()
		{

            bool check = false;
            double stuGrade;
            string stuID;

            Console.WriteLine("請輸入學號");
            stuID = Console.ReadLine();

            for (int i = 0; i < studentList.Count; i++)
			{
                if (studentList[i].ID == stuID)
                {
                    Console.WriteLine("已找到學生資訊");

                    Console.WriteLine("請輸入科目：");
                    string subject = Console.ReadLine();

                    Console.WriteLine("請輸入分數：");

                    if (double.TryParse(Console.ReadLine(), out stuGrade))
                    {
                        studentList[i].Grade[subject] = stuGrade;
                    }

                    check = true;
                }
            }
            if (!check)
            {
                Console.WriteLine("找不到此學生");
                Console.WriteLine("請重新輸入");
            }
        }

        // 計算學生的平均成績
        public void gradeAvg(string stuID)
        {
            string stuName = "";
            double gradeSum = 0;
            int subjectCount = 0;

            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].ID == stuID)
                {
                    foreach (var grade in studentList[i].Grade)
                    {
                        gradeSum += grade.Value;
                        subjectCount++;
                    }
                    stuName = studentList[i].Name;
                    break; // 找到學生後，不再需要繼續迴圈
                }
            }

            double gradeAvg = gradeSum / subjectCount;
            Console.WriteLine($"{stuName} 全科目的平均分數為 {gradeAvg}");
        }


        // 打印學生列表及其成績

        public void stuListGrade()
		{
            foreach (Student student in studentList)
            {
                Console.WriteLine(student);
            }


        }

    }
}

