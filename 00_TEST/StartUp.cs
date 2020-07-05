namespace _00_TEST
{
    using System;
    using System.Reflection;

    public class StartUp
    {
        static void Main()
        {
            var properties = typeof(Cat).GetProperties();
            foreach (var prop in properties)
            {
                Console.WriteLine(prop.Name);
            }
            Cat cat = new Cat("Ivan", 3);
           
            Type typeClass = typeof(Cat); // това работи върху Класа.
            Type type = cat.GetType(); // това работи върху инстанцията на Класа. В случая - cat
            Type typeByName = Type.GetType("_00_TEST.Cat"); // взема  типа ако знаем името и namespace -а
            Type baseType = type.BaseType; // може да се вземе и базов клас през наследник - cat;

            if (baseType != null) // може да няма базов клас, затова проверяваме...
            {
                var baseProp = baseType.GetProperties(); // вече може да се достъпят и пропъртита на базата
                Console.WriteLine(baseType.IsAbstract); //може да питаме дали е абстрактен базовия клас
            }

            // друго:
            // за да достъпим private fields ->
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance); // | - това е "и", защото са флагове-- чете се искам да взема непублични И инстанционни филдове

            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
                var value = field.GetValue(cat);
                Console.WriteLine(value);
            }

            var fieldString = type.GetField("id", BindingFlags.Instance | BindingFlags.NonPublic); // ако има филд с име id
            fieldString.SetValue(cat, 53421); // сетва се стойност във филд поле отвън :)
            Console.WriteLine(cat.GetID());// за проверка

            var interfaces = type.GetInterfaces(); // взем всички интерфейси към обета type и ги прави на масив, взима и наследниците.. може да се форичва.

            foreach (var interf in interfaces)
            {
                Console.WriteLine(interf.Name);
                var interfMetods = interf.GetMethods(); // може да вземем методите[] на всеки Интерфейс.
                foreach (var metod in interfMetods)
                {
                    Console.WriteLine(metod.Name);
                }
            }

            //Като вземем типа , <Type> Class , можем да намерим пропърти и филдове, методи и т.н. на този class

            //Използване на активататор за създаване на инстанции в хода на програмата.....хм...интересно ;)
            //var activCat = Activator.CreateInstance<Cat>(); // това ще съдаде котка, ако няма конструктор

            var newActivCat = (Cat)Activator.CreateInstance(type, new object[] { "Peshо", 9 }); // с подаване на параметри към конструктор, трябва да се кастне към КОТКА, защото бай дизайн връща обект.
            // ВАЖНО - с рефлекшън имаме шанс да се прецакаме, ако не знаем какво да дадем в конструктора при създаване... например ако вкараме само името, без годините. Т.е. трябва предварително да знаем какво приема конструктора. т.е. да знаем как е имплементиран класа.
              
            Console.WriteLine(newActivCat.Name);

            var property = type.GetProperty("Name");
            var valueProperty = property?.GetValue(cat); // if == null ползва се запис ?.

            var constructors = type.GetConstructors(); // можем да вземем конструкторите и параметрите им:
            foreach (var constr in constructors)
            {
                foreach (var param in constr.GetParameters())
                {
                    Console.WriteLine(param.Name + " " + param.ParameterType);
                }
            }
        }
    }
}
