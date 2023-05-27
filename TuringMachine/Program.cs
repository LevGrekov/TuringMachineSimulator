public class TuringMachine
{
    private string tape = "";
    private int headPosition;
    private string state;
    private bool auto = true;
    private int InfinityLoopDetector = 0;

    private string[][] Programa;
    public TuringMachine()
    {
        getProgram();
        headPosition = 1;
        state = "q1";
    }

    public void getProgram()
    {
        Console.WriteLine("Введите Значение X");
        var x = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите Значение Y");
        var y = int.Parse(Console.ReadLine());

        this.tape += "0";
        for(int i = 0; i < x + 1; i++)
        {
            this.tape += "1";
        }
        this.tape += "0";
        for (int i = 0; i < y + 1; i++)
        {
            this.tape += "1";
        }
        this.tape += "0";

        Console.WriteLine("Введите кол-во команд");
        var amount = int.Parse(Console.ReadLine());
      

        Console.WriteLine("Если хотите чтобы запрос не был автоматическим, введите: 'N' ");
        string auto = Console.ReadLine();
        if (auto == "N") this.auto = false;


        Console.WriteLine("Вводите команды в формате q1 1 q2 0 R");
        string[][] Programa = new string[amount][];
        for(int i = 0; i < amount; i++)
        {
            var command = Console.ReadLine();
            Programa[i] = ParseCommand(command);
        }
        this.Programa = Programa;
    }

    private static string[] ParseCommand(string command)
    {
        string[] parsedCommand = command.Split(' ');

        if (parsedCommand.Length != 5)
        {
            throw new ArgumentException("Некорректная команда. Команда должна содержать 5 элементов, разделенных пробелами.");
        }

        return parsedCommand;
    }


    private static int CountOnes(string tape)
    {
        var result = 0;
        foreach(var ch in tape)
        {
            if (Convert.ToInt32(ch.ToString()) == 1) result++;
        }
        return result;
    }


    public void Run()
    {
        while (state != "q0")
        {
            if (auto)
            {
                Console.Clear();
            }
            
            Console.WriteLine(tape.Insert(headPosition, $"({state})"));

            if (auto)
            {
                Console.ReadKey(true);
            }


            string symbol = tape[headPosition].ToString();
            bool transitionFound = false;

            for (int i = 0; i < Programa.GetLength(0); i++)
            {
                if (Programa[i][0] == state && Programa[i][1] == symbol)
                {
                    var NewTape = tape.Remove(headPosition, 1).Insert(headPosition, Programa[i][3]);
                    tape = tape.Remove(headPosition, 1).Insert(headPosition, Programa[i][3]);

                    var oldHeadPos = headPosition;
                    switch (Programa[i][4])
                    {
                        case "R":
                            headPosition++;
                            break;
                        case "L":
                            headPosition--;
                            break;
                        case "S":
                            break;
                    }

                    if (NewTape == tape && headPosition == oldHeadPos)
                    {
                        InfinityLoopDetector++;
                        if (InfinityLoopDetector == 3)
                        {
                            Console.WriteLine("Бесконечный Цикл Детектед!");
                            return;
                        }
                    }
                    else
                    {
                        InfinityLoopDetector = 0;
                    }

                    state = Programa[i][ 2];
                    transitionFound = true;
                    break;
                }
            }

            if (!transitionFound)
            {
                Console.WriteLine("Ошибка: нет соответствующего перехода для символа {0} в состоянии {1}.", symbol, state);
                break;
            }            
        }
        if (state == "q0")
        {
            Console.WriteLine("Выполнение завершено.");
        }
        else
        {
            Console.WriteLine("Ошибка: достигнуто состояние {0}, для которого нет завершающего перехода.", state);
        }

        Console.WriteLine(CountOnes(tape));
    }
}

class Program
{
    static void Main(string[] args)
    {
        string input = "0001111101000";
        TuringMachine turingMachine = new TuringMachine();
        turingMachine.Run();
    }
}