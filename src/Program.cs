using System;

public class EscapeRoomGame
{
    public static void Main(string[] args)
    {
        Main(args, 0);
    }

    public static void Main(string[] args, int ventilationAttempts)
    {
        string playerName;

        Console.WriteLine("Введите ваше имя:");
        playerName = Console.ReadLine();

        bool hasKey = false;
        bool hasLockpick = false;
        bool[] artifacts = { false, false, false }; 

        while (true)
        {
            Console.WriteLine($"\n{playerName}, что вы хотите сделать?");
            Console.WriteLine("1. Открыть дверь");
            Console.WriteLine("2. Заглянуть под кровать");
            Console.WriteLine("3. Открыть ящик в углу комнаты");
            Console.WriteLine("4. Открыть вентиляцию");
            Console.WriteLine("5. Взглянуть на тумбочку");
            Console.WriteLine("6. Взглянуть на статую");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": 
                    if (hasLockpick)
                    {
                        Console.WriteLine($"{playerName}, вы сбежали!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, дверь заперта. Вам нужна отмычка.");
                    }
                    break;
                case "2": 
                    if (!artifacts[0])
                    {
                        Console.WriteLine($"{playerName}, вы нашли Артефакт 1!");
                        artifacts[0] = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, под кроватью больше ничего нет.");
                    }
                    break;
                case "3": 
                    if (hasKey)
                    {
                        if (!hasLockpick)
                        {
                            Console.WriteLine($"{playerName}, вы нашли отмычку!");
                            hasLockpick = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, в ящике больше ничего нет.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, ящик заперт. Вам нужен ключ.");
                    }
                    break;
                case "4": 
                    ventilationAttempts++;
                    if (ventilationAttempts < 3)
                    {
                        Console.WriteLine($"{playerName}, вентиляция не открывается. Попробуйте ещё.");
                    }
                    else if (!artifacts[1])
                    {
                        Console.WriteLine($"{playerName}, вы нашли Артефакт 2!");
                        artifacts[1] = true;
                        ventilationAttempts = 0;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, в вентиляции больше ничего нет.");
                        ventilationAttempts = 0;
                    }
                    break;
                case "5": 
                    if (!artifacts[2])
                    {
                        Console.WriteLine($"{playerName}, вы нашли Артефакт 3!");
                        artifacts[2] = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, на тумбочке больше ничего нет.");
                    }
                    break;
                case "6": 
                    if (artifacts[0] && artifacts[1] && artifacts[2])
                    {
                        Console.WriteLine($"{playerName}, вы активировали статую и получили ключ от ящика!");
                        hasKey = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, статуя не реагирует. Вам нужно найти все артефакты.");
                    }
                    break;
                default:
                    Console.WriteLine($"{playerName}, неверный выбор.");
                    break;
            }
        }
    }
}
