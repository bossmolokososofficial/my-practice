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
class textResult
{
    public string Text;
    public int Words;
    public string Shortest;
    public string Longest;
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
            text1 = Console.ReadLine();
            
            if (text1 == null)
                return;
            if (text1.Length > 100)
                break;
            Console.WriteLine($"Вы ввели {text1.Length} символов. А нужно минимум 100!");
        }

        TextResult result = new TextResult();
        result.Text = text1;
        string lowerText = text1.ToLowerInvariant();
        char[] characters = lowerText.ToCharArray();
        for (int i = 0; i < characters.Length; i++)
        {
            if (!char.IsLetter(characters[i]))
            {
                characters[i] = ' ';
            }
            
        }
        string onlyWords = new string(characters);
        string[] words = onlyWords.Split(' ');
        result.Longest = "";
        result.Shortest = "";
        if (words.Length > 0)
        {
            result.Shortest = words[0];
            result.Longest = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length < result.Shortest.Length)
                {
                    result.shortest = words[i];
                }

                if (words[i].Length > result.Longest.Length)
                {
                    result.Longest = words[i];
                }
            }
        }

        string vowels = "аеёиоуыэюяaeiou";
        string consonants = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz";
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
            else
        }

    }
}