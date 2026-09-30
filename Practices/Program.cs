// Необходимо написать программу, которая будет принимать текст от пользователя и делать над ним определённые действия.
// Функциональные требования:
// Программа принимает от пользователя минимум 100 символов
// Подсчёт количества слов в тексте
// Поиск самого короткого слова
// Подсчёт количества предложений
// Подсчёт количества гласных и согласных букв
// Поиск самого длинного слова
// Создание статистики по частоте встречаемости каждой буквы
// Возможность продолжить работу с новым текстом
// Сохранение всей статистики в список 
// Возможность вывести статистику по прошлым текстам
using System;
using System.Collections.Generic;
using System.Net.Mime;

using System;
using System.Collections.Generic;

class TextResult
{
    public string Text = "";
    public int Words;
    public string Shortest = "";
    public string Longest = "";
    public int Sentences;
    public int Vowels;
    public int Consonants;

    public Dictionary<char, int> Letters = new Dictionary<char, int>();
}

class stats
{
    private List<TextResult> history = new List<TextResult>();

    public void text()
    {
        string text1;

        while (true)
        {
            Console.WriteLine("Введите текст не менее 100 символов:");
            text1 = Console.ReadLine() ?? "";

            if (text1.Length >= 100)
                break;

            Console.WriteLine(
                $"Вы ввели {text1.Length} символов. А нужно минимум 100!");
        }

        TextResult result = new TextResult();
        result.Text = text1;

        string lowerText = text1.ToLowerInvariant();
        char[] characters = lowerText.ToCharArray();

        // Заменяем всё, кроме букв, пробелами
        for (int i = 0; i < characters.Length; i++)
        {
            if (!char.IsLetter(characters[i]))
            {
                characters[i] = ' ';
            }
        }

        string onlyWords = new string(characters);

        // Убираем пустые элементы между пробелами
        string[] words = onlyWords.Split(
            new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);

        result.Words = words.Length;

        if (words.Length > 0)
        {
            result.Shortest = words[0];
            result.Longest = words[0];

            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length < result.Shortest.Length)
                {
                    result.Shortest = words[i];
                }

                if (words[i].Length > result.Longest.Length)
                {
                    result.Longest = words[i];
                }
            }
        }

        string vowels = "аеёиоуыэюяaeiou";
        string consonants =
            "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz";

        bool hasContent = false;

        for (int i = 0; i < lowerText.Length; i++)
        {
            char symbol = lowerText[i];

            if (vowels.IndexOf(symbol) >= 0)
            {
                result.Vowels++;
            }
            else if (consonants.IndexOf(symbol) >= 0)
            {
                result.Consonants++;
            }

            // Частота букв
            if (char.IsLetter(symbol))
            {
                if (result.Letters.ContainsKey(symbol))
                {
                    result.Letters[symbol]++;
                }
                else
                {
                    result.Letters.Add(symbol, 1);
                }
            }

            // Подсчёт предложений
            if (char.IsLetterOrDigit(symbol))
            {
                hasContent = true;
            }

            if (symbol == '.' || symbol == '!' || symbol == '?')
            {
                if (hasContent)
                {
                    result.Sentences++;
                    hasContent = false;
                }
            }
        }

        // Последнее предложение может быть без точки
        if (hasContent)
        {
            result.Sentences++;
        }

        history.Add(result);
        Print(result);
    }

    public void Print(TextResult result)
    {
        Console.WriteLine("\n--- Статистика ---");
        Console.WriteLine($"Текст: {result.Text}");
        Console.WriteLine($"Символов: {result.Text.Length}");
        Console.WriteLine($"Слов: {result.Words}");

        if (result.Words > 0)
        {
            Console.WriteLine(
                $"Самое короткое слово: {result.Shortest}");
            Console.WriteLine(
                $"Самое длинное слово: {result.Longest}");
        }
        else
        {
            Console.WriteLine("В тексте нет слов.");
        }

        Console.WriteLine($"Предложений: {result.Sentences}");
        Console.WriteLine($"Гласных: {result.Vowels}");
        Console.WriteLine($"Согласных: {result.Consonants}");
        Console.WriteLine("Частота букв:");

        foreach (var pair in result.Letters)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }

    public void PrintHistory()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("История пустая.");
            return;
        }

        for (int i = 0; i < history.Count; i++)
        {
            Console.WriteLine($"\nЗапись №{i + 1}");
            Print(history[i]);
        }
    }
}

class Program
{
    static void Main()
    {
        stats analyzer = new stats();

        while (true)
        {
            Console.WriteLine("\n1 — Ввести новый текст");
            Console.WriteLine("2 — Посмотреть историю");
            Console.WriteLine("0 — Выйти");

            string choice = Console.ReadLine() ?? "0";

            if (choice == "0")
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    analyzer.text();
                    break;

                case "2":
                    analyzer.PrintHistory();
                    break;

                default:
                    Console.WriteLine("Такого пункта нет.");
                    break;
            }
        }
    }
}