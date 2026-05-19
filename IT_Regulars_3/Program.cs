using System.Collections.Specialized;
using System.Text.RegularExpressions;

// Задача 1
Console.WriteLine("\nЗадача 1. Создать регулярное выражение, которое совпадает с " +
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
Console.WriteLine("\nЗадача 2. Создать регулярное выражение, которое совпадает с " +
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
Console.WriteLine("\nЗадача 3. Создать регулярное выражение, которое " +
    "совпадает с вещественным числом с необязательной целой частью, " +
    "обязательной дробной частью и необязательной экспонентой. " +
    "Максимальная длина дробной части - 7 символов." +
    "Максимальная длина порядка - 6 символов.");
Regex expRegex = new Regex(@"^\d*\.\d{1,7}([e][+-]?\d{1,6})?$", RegexOptions.IgnoreCase);
string dataexp1 = "22.22e22";
string dataexp2 = "13,11e6";

Console.WriteLine(expRegex.IsMatch(dataexp1));// True
Console.WriteLine(expRegex.IsMatch(dataexp2));// False

Console.WriteLine("\nЗадача 4. Создать регулярное выражение, совпадающее с парой тегов <p> и </p> языка разметки XHTML и текстом между ними. Текст между этими тегами может содержать другие теги XHTML.");
Regex htmlmarkup = new Regex(@"<article>.*?</article>", RegexOptions.IgnoreCase);
string htmlmarked1 = "<article> Лабораторная работа </article>";
string htmlmarked2 = "<article> hypertext mark language <africa>";
string htmlmarked3 = "<text> text sample </text>";

Console.WriteLine(htmlmarkup.IsMatch(htmlmarked1));// True
Console.WriteLine(htmlmarkup.IsMatch(htmlmarked2));// False
Console.WriteLine(htmlmarkup.IsMatch(htmlmarked3));// False

Console.WriteLine("\nЗадача 5. Создать регулярное выражение, совпадающее с целым файлом HTML, которое будет проверять наличие тегов <p> и </p> и их вложенность. " +
    "Выражение не должно совпадать с файлами HTML, в которых отсутствуют требуемые теги.");
string HTMLtext = "<p>widebody text</p>"; 
string SecondHTMLtext = "<head><p>hypertext</p></head>"; 
string ThirdHTMLtext = "<p>without closing tag<p>"; 
Regex tagCheck = new Regex(@"<p>.*?</p>", RegexOptions.IgnoreCase);
Console.WriteLine(tagCheck.IsMatch(HTMLtext)); // True
Console.WriteLine(tagCheck.IsMatch(SecondHTMLtext)); // True
Console.WriteLine(tagCheck.IsMatch(ThirdHTMLtext)); // False

Console.WriteLine("\nЗадача 6. Отыскать любое слово, расположенное между парой тегов <p> и </p> HTML, " +
    "без включения этих тегов в общее соответствие регулярному выражению. Например, для испытуемого текста Моя <p>лекция</p> " +
    "очень скучна правильным соответствием будет лекция.");
string checkA = "Сок <p>из</p> спелых фруктов.";
string checkB = "Не <p>люблю<p> газировку.";
string checkC = "Я <p>пью воду";
Regex checkWord = new Regex(@"(?<=<p>)\w+(?=</p>)");
Console.WriteLine(checkWord.IsMatch(checkA)); // True
Console.WriteLine(checkWord.IsMatch(checkB)); // False
Console.WriteLine(checkWord.IsMatch(checkC)); // False

Console.WriteLine("\nЗадача 7. Создать регулярное выражение, совпадающее со списком слов дыня, арбуз, малина, клубника, разделенных запятыми. " +
    "Каждое слово может присутствовать в списке не менее одного раза.");
Regex wordList = new Regex(@"\b(?:(?:(дыня)|(арбуз)|(малина)|(клубника))(?:,|\b)){4,}(?(1)|(?!) )(?(2)|(?!))(?(3)|(?!))(?(4)|(?!))", RegexOptions.IgnoreCase);
string wordsFull = "Летом любимые фрукты и ягоды это: дыня, арбуз, малина и клубника.";
string wordsRepeat = "Дыня, дыня, арбуз, малина, клубника";
string wordsMinusOne = "Дыня, арбуз, малина";
Console.WriteLine(wordList.IsMatch(wordsFull)); // True
Console.WriteLine(wordList.IsMatch(wordsRepeat)); // True
Console.WriteLine(wordList.IsMatch(wordsMinusOne)); // False

Console.WriteLine("\nЗадача 8. Выполнить поиск с заменой, в процессе которого все адреса URL будут преобразованы в ссылки HTML, указывающие на эти адреса, и использовать обнаруженные адреса URL как замещающий текст. " +
    "Примем, что адреса URL начинаются с последовательности «http:», за которой следуют любые непробельные символы. Например, текст \r\nПожалуйста посетите https://youtu.be/dQw4w9WgXcQ?list=RDdQw4w9WgXcQ\r\n должен превратиться в текст " +
    "\r\nПожалуйста посетите <video src=\"https://youtu.be/dQw4w9WgXcQ?list=RDdQw4w9WgXcQ\" controls width=\"640\" height=\"360\">https://youtu.be/dQw4w9WgXcQ?list=RDdQw4w9WgXcQ</a>\r\n");


Console.WriteLine("\nЗадача 9. Найти совпадение с любой непрерывной последовательностью из 11 цифр, например 12345678901. Преобразовать эту последовательность в формат представления телефонных номеров, например (12345) 67-89-01.");
Console.WriteLine("Решение 1:");
string pattern = @"\b(?<area>\d{5})(?<exchange>\d{2})(?<number>\d{2})(?<number>\d{2})\b";
string replace = "(${area}) ${exchange}-${number}-${number}";
string FirstNum = "10000303030";
string resultReplace = Regex.Replace(FirstNum, pattern, replace); 
Console.WriteLine(resultReplace); // скорректирует под формат
string SecondNum = "101301zxc45";
Console.WriteLine(resultReplace = Regex.Replace(SecondNum, pattern, replace)); // не скорректирует, так как выражение содержит буквы.
Console.WriteLine("\nРешение 2:");
string secondPattern = @"\b(\d{5})(\d{2})(\d{2})(\d{2})\b";
string secondReplace = "($1) •$2-$3-$4";
string ThirdNum = "88005553535";
string ForthNum = "8zxc801010";
string secondResultReplace = Regex.Replace(ThirdNum, secondPattern, secondReplace);
Console.WriteLine(secondResultReplace); // скорректирует под формат
Console.WriteLine(secondResultReplace = Regex.Replace(ForthNum, secondPattern, secondReplace)); // не скорректирует, так как выражение содержит буквы.

Console.WriteLine("\nЗадача 10. Создать замещающий текст, который заместит совпадение с регулярным выражением текстом, расположенным перед совпадением, всем испытуемым текстом и остатком испытуемого текста, расположенным после совпадения. " +
    "Например, если в тексте БаянУпражнениеШампур был найден фрагмент Упражнение, его следует заменить текстом ЛекцияУпражнениеЛабораторная, в результате должен получиться текст БаянЛекцияУпражнениеЛабораторнаяШампур.");


Console.ReadKey();