using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Xml.Linq;
using GradeSys;

namespace GradeSys;
class Program
{
    static string stuName;
    static string stuID;
    static string subject;
    static double stuGrade;
    static string stuString;
    static Dictionary<string, double> grade;

    static void Main(string[] args)
    {
        School school = new School();
        grade = new Dictionary<string, double>();

        Console.WriteLine("Students Grade System");

        while (true)
        {
            Console.WriteLine("請選擇要使用的功能");
            Console.WriteLine("1.新增學生 2.刪除學生 3.更新成績 4.計算學生平均成績 5.搜尋學生資料");
            int num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Student student = ADD();
                        school.stuAdd(student);
                        school.stuListGrade();
                        break;
                    case 2:
                        stuID = Remove();
                        school.stuDelet(stuID);
                        school.stuListGrade();
                        break;
                    case 3:
                        school.gradeUpdat();
                        school.stuListGrade();
                        break;
                    case 4:
                        stuID = Avg();
                        school.gradeAvg(stuID);
                        school.stuListGrade();
                        break;
                    case 5:
                        stuString = NameId();
                        school.stuSearch(stuString);
                        break;
                    default:
                        Console.WriteLine("無效的選擇，請輸入正確的數字。");
                        Console.WriteLine("請按任意鍵重新輸入。");
                        break;
                }
            Console.ReadKey();
        }

    }

    static Student ADD()
    {
            // 添加學生

        Console.WriteLine("-----新增學生-----");

        Console.WriteLine("請輸入學生姓名：");
        stuName = Console.ReadLine();

        Console.WriteLine("請輸入學號：");
        stuID = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("請選擇科目：");
            subject = Console.ReadLine();

            Console.WriteLine("請輸入成績：");

            if (double.TryParse(Console.ReadLine(), out stuGrade))
            {
                grade.Add(subject, stuGrade);
                Console.WriteLine("新增成功！");
                Console.WriteLine("是否繼續新增成績？(Y/N)");

                Student student = new Student(stuName, stuID, grade);

                if (Console.ReadLine().ToUpper() == "N")
                {
                    return student;
                    //break;
                }
            }
            else
            {
                Console.WriteLine("輸入的成績不是有效的數字");
                Console.WriteLine("請重新輸入成績：");
            }

        }

    }

    static string Remove()
    {
        Console.WriteLine("請輸入要刪除的學生學號");
        stuID = Console.ReadLine();
        if (stuID != "")
        {
            return stuID;

        }
        else
        {
            Console.WriteLine("刪除失敗請重新輸入");
            return null;
        }
    }

    static string NameId()
    {
        Console.WriteLine("請輸入學生姓名或是學號");
        string stuString = Console.ReadLine();
        return stuString;
    }

    static string Avg()
    {
        Console.WriteLine("請輸入學生ID");
        string subID = Console.ReadLine();
        return subID;
    }
}

