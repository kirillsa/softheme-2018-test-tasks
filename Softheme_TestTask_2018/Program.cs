using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softheme_TestTask_2018
{
    class Program
    {
        static int[] coins = new int[] { 200, 100, 50, 20, 10, 5, 2, 1 }; // массив номиналов доступных монет
        static int countOfGoals = 0; // счетчик для успешных комбинаций монет
        
        static void Main(string[] args)
        {
            var goal = 200; // искомая сумма для комбинаций монет

            for (var i = 0; i < coins.Length; i++) // проходим по массиву номиналов монет и вызываем рекурсивный метод
            {
                Computation(i, goal); // вызываем рекурсивный метод с параметрами позиции текущего номинала монет в массиве монет и результата, который нужно получить при помощи комбинаций монет
            }
            Console.WriteLine(countOfGoals); // выводим результат в консоль
            Console.ReadKey(); // останавливаем выполнение программы до нажатия клавиши
        }
        
        /* Рекурсивный метод 
         * расчитывающий количество комбинаций 
         * из исходных номиналов монет
         * для получения искомого числа 
         Входные данные: i - позиция в массиве номиналов монет, 
                         result - текущий результат который нужно подобрать */
        static void Computation(int i, int result)
        {
            var numberOfAccurrancesCoinsInGoal = result / coins[i]; // целое число вхождений номинала монеты во входящий результат

            while (numberOfAccurrancesCoinsInGoal > 0) // пока число вхождений > 0, выполняется цикл
            {
                var bufRes = numberOfAccurrancesCoinsInGoal * coins[i]; //узнаем промежуточный результат для дальнейших действий
                if (bufRes == result) // если промежуточный результат равен входящему результату, значит мы нашли нужную комбинацию
                {
                    countOfGoals++; // счетчик правильных комбинаций +1
                }
                else // если промежуточный результат не равен входящему результату, значит нужно взять монеты ниже рангом
                {
                    for (var j = i + 1; j < coins.Length; j++) // цикл для перебора монет ниже рангом
                    {
                        Computation(j, result - bufRes); // рекурсивный вызов данного метода с использованием монет рангом ниже от текущего
                    }
                }
                if (coins[i] == 1) // чтобы программа не делала лишних расчетов при номинале монеты в 1 пенс, делаем проверку и принудительно выходим из цикла
                {
                    break;
                }
                numberOfAccurrancesCoinsInGoal--; 
            }
        }
    }
}