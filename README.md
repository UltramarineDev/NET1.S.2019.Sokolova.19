## Задачи
:heavy_check_mark: 1. (deadline - 01.04.2019, 24.00) Реализовать метод, который принимает на вход строку source и количество итераций count (проект StringExtension).
```
 public string Convert(string source, int count)

```
На каждой итерации метода объединяются нечетные символы строки и переносятся в ее начало, и четные символы, которые переносяться в конец.
> Пример (строка «Привет Епам!»):

> 1 итерация: «Пие пмрвтЕа!»

> 2 итерация: «Пепртаи мвЕ!»

> ...

Результат работы метода – результат склеек символов через count итераций.

При реализации алгоритма учесть, что входная строка может содержать очень большое количество символов, а количество итераций может быть огромным. Оптимизировать код с точки зрения быстродействия и потребления ресурсов.

Проверить аргументы на валидность:
* Запрещается передавать пустые строки, строки из пробелов, null.
* Количество итераций должно быть больше 0.

При нарушении этих условий метод генерирует исключение.

Проверить работу метода с помощью модульных тестов (проект StringExtension.Tests), к предложенным тест кейсам добавить дополнительные.

Проверить возможность работы разработанного метода с большими строками и большим количеством итераций (проект StringExtensionWithFiles), замерить время счета.

go to [StringComverter.cs](https://github.com/UltramarineDev/NET1.S.2019.Sokolova.19/blob/master/StringExtension/StringConverter.cs)

:heavy_check_mark: 2. (deadline - 03.04.2019, 24.00) Для объектов класса Book, у которого есть свойства Title, Author, Year, PublishingHous, Edition, Pages и Price (за основу можно взять класс, разработанный ранее) реализовать возможность строкового представления различного вида. Например, для объекта со значениями Title = "C# in Depth", Author = "Jon Skeet", Year = 2019, PublishingHous = "Manning", Edition = 4, Pages = 900, Price = 40$. могут быть следующие варианты:

* Book record: Jon Skeet, C# in Depth, 2019, "Manning",
* Book record: Jon Skeet, C# in Depth, 2019
* Book record: Jon Skeet, C# in Depth
* Book record: C# in Depth, 2019, "Manning"
* Book record: C# in Depth и т.д.

Разработать модульные тесты.
go to [Book.cs](https://github.com/UltramarineDev/NET1.S.2019.Sokolova.19/blob/master/StringExtension/Book.cs)

:heavy_check_mark: 3. (deadline - 03.04.2019, 24.00) Не изменяя класс Book, добавить для объектов данного класса дополнительную (любую не существующую у класса изначально) возможность форматирования, не предусмотренную классом. Разработать модульные тесты.

go to [CustomFormatProvider.cs](https://github.com/UltramarineDev/NET1.S.2019.Sokolova.19/blob/master/StringExtension/CustomFormatProvider.cs)

:heavy_check_mark: 4. (deadline - 02.04.2019, 24.00) Представить решение задачи Day 4 - 26.03.2019. Task 3 в виде дополнительной возможности форматного вывода вещественного числа. Разработать модульные тесты.

go to [DoubleProvider.cs](https://github.com/UltramarineDev/NET1.S.2019.Sokolova.19/blob/master/StringExtension/DoubleProvider.cs)