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
Regex expRegex = new Regex(@"^\d*\.\d{1,7}([e][+-]?\d{1,6})?$", RegexOptions.IgnoreCase);
string dataexp1 = "22.22e22";
string dataexp2 = "13,11e6";

Console.WriteLine(expRegex.IsMatch(dataexp1));
Console.WriteLine(expRegex.IsMatch(dataexp2));

Console.WriteLine("Задача 4. Создать регулярное выражение, совпадающее с парой тегов <p> и </p> языка разметки XHTML и текстом между ними. Текст между этими тегами может содержать другие теги XHTML.");
Regex htmlmarkup = new Regex(@"<article>.*?</article>");
string htmlmarked1 = "<article> Лабораторная работа </article>";
string htmlmarked2 = "<article> hypertext mark language <africa>";
string htmlmarked3 = "<text> text sample </text>";

Console.WriteLine(htmlmarkup.IsMatch(htmlmarked1));
Console.WriteLine(htmlmarkup.IsMatch(htmlmarked2));
Console.WriteLine(htmlmarkup.IsMatch(htmlmarked3));

Console.WriteLine("Задача 5. Создать регулярное выражение, совпадающее с целым файлом HTML, которое будет проверять наличие тегов html, head, title и body и их вложенность. " +
    "Выражение не должно совпадать с файлами HTML, в которых отсутствуют требуемые теги.");


Console.WriteLine("Задача 6. Отыскать любое слово, расположенное между парой тегов <b> и </b> HTML, " +
    "без включения этих тегов в общее соответствие регулярному выражению. Например, для испытуемого текста Моя <b>лекция</b> очень скучна правильным соответствием будет лекция.");


Console.WriteLine("Задача 7. Создать регулярное выражение, совпадающее со списком слов удовлетворительно, хорошо и отлично, разделенных запятыми. Каждое слово может присутствовать в списке не менее одного раза.");


Console.WriteLine("Задача 8. Выполнить поиск с заменой, в процессе которого все адреса URL будут преобразованы в ссылки HTML, указывающие на эти адреса, и использовать обнаруженные адреса URL как замещающий текст. " +
    "Примем, что адреса URL начинаются с последовательности «http:», за которой следуют любые непробельные символы. Например, текст \r\nПожалуйста посетите https://youtu.be/dQw4w9WgXcQ?list=RDdQw4w9WgXcQ\r\n должен превратиться в текст " +
    "\r\nПожалуйста посетите <video src=\"https://youtu.be/dQw4w9WgXcQ?list=RDdQw4w9WgXcQ\" controls width=\"640\" height=\"360\">https://youtu.be/dQw4w9WgXcQ?list=RDdQw4w9WgXcQ</a>\r\n");


Console.WriteLine("Задача 9. Найти совпадение с любой непрерывной последовательностью из 10 цифр, например 1234567890. Преобразовать эту последовательность в формат представления телефонных номеров, например (12345) 67-89-01.");


Console.WriteLine("Задача 10. Создать замещающий текст, который заместит совпадение с регулярным выражением текстом, расположенным перед совпадением, всем испытуемым текстом и остатком испытуемого текста, расположенным после совпадения. " +
    "Например, если в тексте БаянУпражнениеШампур был найден фрагмент Упражнение, его следует заменить текстом ЛекцияУпражнениеЛабораторная, в результате должен получиться текст БаянЛекцияУпражнениеЛабораторнаяШампур.");

Console.ReadKey();