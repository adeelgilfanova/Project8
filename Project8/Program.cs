using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8
{
    class Program
    {
        static void Main(string[] args)
        {
            Employer employer = new Employer("Дмитрий", "Тумаков");
            int count_workers = 10;
            List<Worker> workers = new List<Worker>(count_workers);
            workers.Add(new Worker("Мария", "Мошкина"));
            workers.Add(new Worker("Денис", "Сабаев"));
            workers.Add(new Worker("Амир", "Сагдуллин"));
            workers.Add(new Worker("Настя", "Сучок"));
            workers.Add(new Worker("Маша", "Белая"));
            workers.Add(new Worker("Мари", "Головина"));
            workers.Add(new Worker("Юля", "Жидкова"));
            workers.Add(new Worker("Лилия", "Агиева"));
            workers.Add(new Worker("Илья", "Братухин"));
            workers.Add(new Worker("Ильдар", "Ахметов"));
            Customer customer = new Customer("Huawei");
            List<Task> tasks = new List<Task>(count_workers);
            tasks.Add(new Task("Создать процессор", employer));
            tasks.Add(new Task("Создать дисплей", employer));
            tasks.Add(new Task("Создать клавиатуру", employer));
            tasks.Add(new Task("Создать видеокарту", employer));
            tasks.Add(new Task("Создать карту памяти", employer));
            tasks.Add(new Task("Создать батарейку", employer));
            tasks.Add(new Task("Создать ПО", employer));
            tasks.Add(new Task("Создать мышку", employer));
            tasks.Add(new Task("Создать флэшку", employer));
            tasks.Add(new Task("Создать рекламу", employer));
            DateTime date = DateTime.Now.AddDays(365);
            Project project = new Project("Создать новую модель компьютера", date, employer, customer);
            project.AddTasksInProject(tasks);
            Worker.GiveTask(workers, tasks);
            Console.ReadKey();
            Console.Clear();
            while (workers.Count > 0)
            {
                Console.WriteLine("Чтобы сдать отчет, выберите сотрудника");
                Console.WriteLine("Сотрудники");
                for (int i = 0; i < workers.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {workers[i].Print()}");
                }
                int index;
                while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > workers.Count)
                {
                    Console.WriteLine("Неверный ввод");
                }
                Report report = Report.CreateReport(workers[index - 1]);
                Console.WriteLine($"Утверждает ли инициатор отчёт сотрудника {workers[index - 1].Print()}");
                Console.WriteLine("Отчёт:");
                report.Print();
                string answer = Console.ReadLine().ToLower();
                while (!answer.Equals("да") && !answer.Equals("нет"))
                {
                    Console.WriteLine("Повторите ввод");
                    answer = Console.ReadLine();
                }
                if (answer.Equals("да"))
                {
                    Task.CloseTask(workers[index - 1]);
                    workers.Remove(workers[index - 1]);
                    report = null;
                }
                else
                {
                    Console.WriteLine("Отчет не завершен");
                    report = null;
                }
            }
            project.CloseProject();
        }
    }
}
