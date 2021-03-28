// используем класс для работы с файлами
using System.IO;
using System;

namespace ToDo
{
    class App
    {
        static void deleteNotes()
        {
            // Перехват исключений
            try
            {
                // Узнаем путь к файлу
                string path = Directory.GetCurrentDirectory() + @"\List.txt";
                // Удаляем файл, поскольку мы в главном методе проверяем наличие файла
                File.Delete(path);
                Console.WriteLine("Успешная операция");
            }
            catch
            {
                Console.WriteLine("Произошла ошибка...");
            }
            // Вызываем главную функцию
            Main();
        }
        static void lookNotes()
        {
            // получаем путь к файлу
            string path = Directory.GetCurrentDirectory() + @"\List.txt";
            // Открываем файлы
            using (FileStream note = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader n = new StreamReader(note))
                {
                    // читаем весь файл
                    string l = n.ReadToEnd();
                    // делаем из него массив
                    string[] arr = l.Split(';');
                    // выводим с помощью for-цикла
                    Console.WriteLine("Вот ваши задачи: ");
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.WriteLine($"{i} -> {arr[i]}");
                        Console.WriteLine();
                    }
                }
            }
            // Вызываем главную функцию
            Main();
        }
        static void addNote()
        {
            // Перехват исключений
            try
            {
                // узнаем путь к файлу
                string path = Directory.GetCurrentDirectory() + @"\List.txt", enter;
                // Открываем файл
                using (FileStream note = new FileStream(path, FileMode.Append))
                {
                    using (StreamWriter n = new StreamWriter(note))
                    {
                        Console.Write("Введите что хотите запланировать: ");
                        enter = Console.ReadLine();
                        n.Write(enter + ";");
                    }
                }
                Console.WriteLine("Заметка успешно сохранена");
            }
            catch
            {
                Console.WriteLine("Возникла ошибка");
            }
            // Вызываем главную функцию
            Main();
            
        }
        static void service(int k)
        {
            if (k == 0) addNote();
            if (k == 1) lookNotes();
            if (k == 3) deleteNotes();
            // Если номер выходит из диапазона
            else
            {
                Console.WriteLine("Неправильный номер");
                Main();
            }
        }
        static void Main()
        {
            // Узнаем каталог где лежит программа
            string path = Directory.GetCurrentDirectory();
            // Проверяем существует ли файл который хранит в себе задачи, если нет то создаем его
            if (!File.Exists(path + @"\List.txt")) File.CreateText(path + @"\List.txt").Dispose();
            // Массив который включает в себя функции программы
            string[] services = { "Добавить заметку", "Смотреть заметки", "Удалить все заметки" };
            // С помощью массива печатаем массив
            for(int i = 0; i < services.Length; i++)
            {
                Console.WriteLine($"{i} -> {services[i]}");
            }
            // запрашиваем у пользователя номер
            Console.Write("Выберите номер услуги: ");
            // перехват сключений если пользователь ввел не число
            try
            {
                service(Int32.Parse(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("Надо было ввести число. Ну ладно, попробуй еще раз");
                Main();
                Console.WriteLine();
            }
        }
    }
}