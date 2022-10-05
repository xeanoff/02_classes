using Employees;
using Products;
using Factories;

namespace main
{
    class Program
    {
        public static CategoryType getCategory(string? category)
        {
            if (category!.ToLower() == "food")
                return CategoryType.Food;
            else
            {
                if (category!.ToLower() == "car details")
                    return CategoryType.CarDetails;
                else
                {
                    if (category!.ToLower() == "electronic")
                        return CategoryType.Electronic;
                    else { return CategoryType.Default; }
                }
            }

        }
        internal static void Main()
        {
            Console.WriteLine("Створення нового пiдприємства..");

            Console.Write("Введiть назву пiдприємства: ");
            string? factoryName = Console.ReadLine();

            Console.Write("Введiть кiлькiсть працiвникiв пiдприємства: ");
            string? EmpCount = Console.ReadLine();
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < Convert.ToInt32(EmpCount); i++)
            {
                Console.Write($"Працiвник {i + 1}:\nIм'я: ");
                string? name = Console.ReadLine();

                Console.Write("Прiзвище: ");
                string? surname = Console.ReadLine();

                Console.Write("Дата народження: ");
                DateTime birthDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Заробiтна плата: ");
                decimal? salary = Convert.ToDecimal(Console.ReadLine());

                Employee employee = new Employee(name, surname, birthDate, salary);
                employees.Add(employee);

                Console.WriteLine();
            }

            Console.Write("Введiть кiлькiсть продуктiв пiдприємства: ");
            string? ProdCount = Console.ReadLine();
            List<Product> products = new List<Product>();
            for (int i = 0; i < Convert.ToInt32(ProdCount); i++)
            {
                Console.Write($"Товар {i + 1}:\nНазва: ");
                string? name = Console.ReadLine();

                Console.Write("Категорія (Food/Car Details/Electronic): ");
                getCategory(Console.ReadLine());

                Console.Write("Ціна: ");
                decimal? price = Convert.ToDecimal(Console.ReadLine());

                Product product = new Product(name, CategoryType.CarDetails, price);
                products.Add(product);

                Console.WriteLine();
            }
            Factory factory = new Factory(factoryName, employees, products);
            Console.WriteLine();

            employees.ForEach((i) => { Console.WriteLine(i.ToString()); Console.WriteLine(); });
            Console.WriteLine();

            products.ForEach((i) => { Console.WriteLine(i.ToString()); Console.WriteLine(); });
            Console.WriteLine();

            Console.WriteLine(factory.ToString());
        }
    }
}