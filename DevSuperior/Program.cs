//8.12 Desafio Plataforma de ensino
using Course.Entities;
using System.Collections.Generic;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Lesson> lessonList = new List<Lesson>();

            Console.Write("Quantas aulas tem o curso? ");
            int numberOfClasses = int.Parse(Console.ReadLine());

            CreateLesson(numberOfClasses, lessonList);       
            
            PrintTotalDuration(lessonList);
            
        }

        public static void CreateLesson(int numClasses, List<Lesson> lessons)
        {
            for(int i = 0; i < numClasses; i++)
            {    
                Console.WriteLine();
                Console.WriteLine($"Dados da {i+1}ª aula:");
                Console.Write("Conteúdo ou tarefa (c/t)? ");
                char lessonType = char.Parse(Console.ReadLine().ToLower());
                Console.Write("Título: ");
                string lessonTitle = Console.ReadLine();

                if(lessonType == 'c')
                {
                    CreateVideoClass(lessonTitle, lessons);
                }

                if(lessonType == 't')
                {
                    CreateTaskClass(lessonTitle, lessons);
                }
            }
        }

        public static void CreateVideoClass(string title, List<Lesson> list) {
            Console.Write("URL do vídeo: ");
            string lessonUrl = Console.ReadLine();
            Console.Write("Duração em segundos: ");
            int lessonDuration = int.Parse(Console.ReadLine());

            Video video = new Video(lessonUrl, lessonDuration, title);
            list.Add(video);
        }

        public static void CreateTaskClass(string title, List<Lesson> list)
        {
            Console.Write("Descrição: ");
            string lessonDescription = Console.ReadLine();
            Console.Write("Quantidade de questões: ");
            int lessonQuestions = int.Parse(Console.ReadLine());

            Entities.Task task = new Entities.Task(lessonDescription, lessonQuestions, title);

            list.Add(task);                   
    }

        public static void PrintTotalDuration(List<Lesson> list)
        {   
            int totalDuration = 0;

            foreach(Lesson lesson in list)
            {
                totalDuration += lesson.Duration();
            }

            Console.WriteLine();
            Console.WriteLine($"DURAÇÃO TOTAL DO CURSO = {totalDuration} segundos");
      
        }
    }
}
