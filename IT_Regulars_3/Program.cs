using System.Collections.Specialized;
using System.Text.RegularExpressions;

// Задача 1
Console.WriteLine("Задача 1. Создать регулярное выражение, которое совпадает с " +
    "52-битным шестнадцатеричным числом.");

Regex ftstRegex = new Regex(@"\b[a-f0-9]{1,13}\b", RegexOptions.IgnoreCase); // Fifty Two bit SixTeen rank = 52-битное шестнадцатеричное число
// 0-9a-f - ограничения шестнадцатеричной системы, IgnoreCase нужен так как регистр неважен.
// 1-13 - количество разрядов для 52-битной системы, 52 бита необходимо разделить на 4 (полубит)

string data1 = "24"; // проверка только численных значений
string data2 = "AABBCCDDEE"; // проверка только буквенные значения
string data3 = "123AB45CD67EFF"; // проверка при вводе > 13 символов
string data4 = "111222333444G"; // проверка при выходе за пределы буквенного значения

Console.WriteLine(ftstRegex.IsMatch(data1)); // True
Console.WriteLine(ftstRegex.IsMatch(data2)); // True
Console.WriteLine(ftstRegex.IsMatch(data3)); // False
Console.WriteLine(ftstRegex.IsMatch(data4)); // False


// Задача 2
Console.WriteLine("Задача 2. Создать регулярное выражение, которое совпадает с " +
    "52-битным шестнадцатеричным числом с необязательным суффиксом h.");
Regex hRegex = new Regex(@"\b[0-9a-f]{1,13}h?\b", RegexOptions.IgnoreCase);

string datah1 = "24h";
string datah2 = "24";
string datah3 = "1a2b3c4d5e6f7h"; // h? = h{0,1}
string datah4 = "1a2b3c4d5e6f7hh"; 

Console.WriteLine(hRegex.IsMatch(datah1)); // True
Console.WriteLine(hRegex.IsMatch(datah2)); // True
Console.WriteLine(hRegex.IsMatch(datah3)); // True
Console.WriteLine(hRegex.IsMatch(datah4)); // False

// Задача 3
Console.WriteLine("Задача 3. Создать регулярное выражение, которое " +
    "совпадает с вещественным числом с необязательной целой частью, " +
    "обязательной дробной частью и необязательной экспонентой. " +
    "Максимальная длина дробной части - 7 символов." +
    "Максимальная длина порядка - 6 символов.");
//Regex expRegex = new Regex(@"\d*\{1,6}.\d+(e\d+){1,7}", RegexOptions.IgnoreCase);
Regex expRegex = new Regex(@"\d*{{1,6}\.\d+e(\d+){1,7}");
string dataexp1 = "22.22e22";

Console.WriteLine(expRegex.IsMatch(dataexp1));


Console.WriteLine();


Console.WriteLine();


Console.WriteLine();


Console.WriteLine();


Console.WriteLine();


Console.WriteLine();


Console.WriteLine();

Console.ReadKey();