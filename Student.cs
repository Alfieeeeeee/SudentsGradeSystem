//定義一個Student 類別，包含屬性：姓名、學號、成績
//用一個Dictionary<string,double> 表示，key 為科目名稱，value 為成績
using System;
using System.Collections.Generic;

namespace GradeSys
{
	public class Student
	{
		private string m_name;
		private string m_id;
		Dictionary<string, double> m_grade;


        public string Name
        {
            get { return m_name; }
            set
            {
                if (value != "")
                {
                    m_name = value;
                }
                else
                {
                    Console.WriteLine("請輸入正確姓名");
                }
            }
        }

        public string ID { get; set; }

        public Dictionary<string, double> Grade
		{
            get { return m_grade; }
            set
            {
                if (value.All(g => g.Value >= 0 && g.Value <= 100))
                {
                    m_grade = value;
                }
                else
                {
                    Console.WriteLine("成績輸入錯誤");
                }
            }
     
        }

        public Student(string name ,string id, Dictionary<string, double> grade)
		{ 

			Name = name;
			ID = id;
            Grade = grade;
		}

        public override string ToString()
        {
            if (Grade == null)
            {
                return $"學生姓名：{Name}，學號：{ID}，成績：未提供";
            }
            string grades = string.Join(", ", Grade.Select(g => $"{g.Key}: {g.Value}"));
            return $"學生姓名：{Name}，學號：{ID}，成績：{grades}";
        }


    }
}

