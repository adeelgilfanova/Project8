using System;
namespace Project8
{
    class Report
    {
        private string text;
        private DateTime date;
        private Worker worker;
        public Report(Worker worker, string text)
        {
            this.worker = worker;
            this.text = text;
        }
        public static Report CreateReport(Worker worker)
        {
            Console.WriteLine("Напишите отчет");
            string text = Console.ReadLine();
            Task.StatusReport(worker);
            return new Report(worker, text);
        }
        public void Print()
        {
            Console.WriteLine($"{text}");
        }
    }
}

