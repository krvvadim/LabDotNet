using lab4.Models;
using lab4.Models.ProductModels;
using lab4.Models.ProductModels.ComputerComponentsModels;
using lab4.Models.ProductModels.ComputerComponentsModels.Enums;
using lab4.Models.ProductModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Monitor = lab4.Models.ProductModels.ComputerComponentsModels.Monitor;

namespace lab4
{
    /*Реалізувати задачу «Інтернет-магазин по продажу комп’ютерної техніки». Товари - комплектуючі. 
     У кожного товару є категорія, назва, артикул та ціна. Для товару в категорії «Процесор» необхідно вказувати тактову частоту, кількість ядер тощо. 
     І так само для товарів у інших категоріях вказуються свої параметри. Крім продажу окремих комплектуючих, 
     інтернет-магазин може продавати системні блоки, котрі збираються з наявних комплектуючих, з надбавкою 15% за збірку 
     або комп’ютери повністю (системний блок+монітор) з надбавкою 5%, або інші варіації з різною надбавкою.*/


    public enum Menu
    {
        ShowInformation = 1,
        AddProductInStore,
        RemoveProductFromStore,
        ShowAllProductsInStore,
        CreateComputerSystem,
        AddItemToCart,
        RemoveItemFromCart,
        Checkout,
        Exit
    }

    public class Program
    {

        public static void ShowAllProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                products[i].Show();
            }

        }
        public static void ShowAllProductsWithNumbers(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                products[i].Show();
            }

        }

        public static double GetTotalPrice(List<Product> products)
        {
            double result = 0;

            for(int i = 0; i < products.Count; i++)
            {
                result += products[i].Price;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;


            Menu selectedOption;
            Store store = new Store("Rozetka");
            List<Product> cart = new List<Product>();

            do
            {
                Console.WriteLine("===== Меню =====");
                Console.WriteLine("1. Показати інформацію");
                Console.WriteLine("2. Додати товар в магазин");
                Console.WriteLine("3. Видалити товар з магазину");
                Console.WriteLine("4. Показати всі товари в магазині");
                Console.WriteLine("5. Створити готову комп'ютерну систему");
                Console.WriteLine("6. Додати товар у кошик");
                Console.WriteLine("7. Видалити товар з кошика");
                Console.WriteLine("8. Оформити замовлення");
                Console.WriteLine("9. Вихід");
                Console.WriteLine("=================");
                Console.Write("Оберіть пункт меню: ");

                string input = Console.ReadLine();
                Enum.TryParse(input, out selectedOption);
                Console.Clear();

                switch (selectedOption)
                {
                    case Menu.ShowInformation:
                        {
                            store.Show();
                        }
                        break;
                    case Menu.AddProductInStore:
                        {
                            Console.WriteLine("Оберіть тип товару:");
                            Console.WriteLine("1. Процесор");
                            Console.WriteLine("2. Материнська плата");
                            Console.WriteLine("3. Оперативна пам'ять");
                            Console.WriteLine("4. Відеокарта");
                            Console.WriteLine("5. Жорсткий диск");
                            Console.WriteLine("6. Блок живлення");
                            Console.WriteLine("7. Корпус");
                            Console.WriteLine("8. SSD");
                            Console.WriteLine("9. Кулер");
                            Console.WriteLine("10. Монітор");
                            Console.WriteLine("=================");
                            Console.Write("Оберіть тип товару: ");

                            bool result = Enum.TryParse(Console.ReadLine(), out ProductCategory productCategory);

                            if (!result || productCategory == ProductCategory.ComputerConfiguration)
                            {
                                Console.WriteLine("Невірний вибір. Будь ласка, оберіть існуючий тип товару.");
                                continue;
                            }

                            Console.Write("Введіть назву товару: ");
                            string productName = Console.ReadLine();

                            Console.Write("Введіть артикул товару: ");
                            string productArticle = Console.ReadLine();

                            double productPrice = 0;
                            do
                            {
                                Console.Write("Введіть ціну товару: ");
                            } while (!double.TryParse(Console.ReadLine(), out productPrice) || productPrice <= 0);


                            switch (productCategory)
                            {
                                case ProductCategory.Processor:
                                    {
                                        int productCores = 0;
                                        do
                                        {
                                            Console.Write("Введіть кількість ядер: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productCores) || productCores <= 0);

                                        int productThreads = 0;
                                        do
                                        {
                                            Console.Write("Введіть кількість потоків: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productThreads) || productThreads <= 0);

                                        int productFreqency = 0;
                                        do
                                        {
                                            Console.Write("Введіть частоту: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productFreqency) || productFreqency <= 0);

                                        Console.Write("Введіть сокет: ");
                                        string productSocket = Console.ReadLine();

                                        store.AddProduct(new Processor(productName, productArticle, productPrice,
                                            productCores, productThreads, productFreqency, productSocket));

                                        Console.WriteLine("Процесор було додано!");
                                    }
                                    break;
                                case ProductCategory.Motherboard:
                                    {
                                        Console.Write("Введіть сокет: ");
                                        string productSocket = Console.ReadLine();

                                        Console.Write("Введіть чіпсет: ");
                                        string productChipset = Console.ReadLine();

                                        Console.WriteLine("Оберіть тип материнської плати:");
                                        Console.WriteLine("1. ATX");
                                        Console.WriteLine("2. MicroATX");
                                        Console.WriteLine("3. MiniATX");
                                        Console.WriteLine("=================");
                                        Console.Write("Оберіть тип материнської плати: ");
                                        int motherboardTypeInput;
                                        do
                                        {
                                            if (!int.TryParse(Console.ReadLine(), out motherboardTypeInput) ||
                                                motherboardTypeInput < 1 || motherboardTypeInput > 3)
                                            {
                                                Console.WriteLine("Невірний ввід. Будь ласка, введіть існуюче число.");
                                                continue;
                                            }
                                        } while (motherboardTypeInput < 1 || motherboardTypeInput > 3);

                                        MotherboardType motherboardType = (MotherboardType)motherboardTypeInput;

                                        store.AddProduct(new Motherboard(productName, productArticle, productPrice,
                                            productSocket, productChipset, motherboardType));

                                        Console.WriteLine("Материнську плату було додано!");
                                    }
                                    break;
                                case ProductCategory.RAM:
                                    {
                                        int productMemory = 0;
                                        do
                                        {
                                            Console.Write("Введіть об'єм пам'яті: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productMemory) || productMemory <= 0);

                                        Console.WriteLine("Оберіть форм-фактор пам'яті:");
                                        Console.WriteLine("1. DIMM");
                                        Console.WriteLine("2. SO-DIMM");
                                        Console.WriteLine("=================");
                                        Console.Write("Оберіть форм-фактор пам'яті: ");
                                        int ramFormFactorInput;
                                        do
                                        {
                                            if (!int.TryParse(Console.ReadLine(), out ramFormFactorInput) ||
                                                ramFormFactorInput < 1 || ramFormFactorInput > 2)
                                            {
                                                Console.WriteLine("Невірний ввід. Будь ласка, введіть число.");
                                                continue;
                                            }

                                        } while (ramFormFactorInput < 1 || ramFormFactorInput > 2);

                                        RAMFormFactor ramFormFactor = (RAMFormFactor)ramFormFactorInput;

                                        Console.WriteLine("Оберіть тип пам'яті:");
                                        Console.WriteLine("1. DDR1");
                                        Console.WriteLine("2. DDR2");
                                        Console.WriteLine("3. DDR3");
                                        Console.WriteLine("4. DDR4");
                                        Console.WriteLine("5. DDR5");
                                        Console.WriteLine("=================");
                                        Console.Write("Оберіть тип пам'яті: ");
                                        int ramTypeInput;
                                        do
                                        {
                                            if (!int.TryParse(Console.ReadLine(), out ramTypeInput) ||
                                                ramTypeInput < 1 || ramTypeInput > 5)
                                            {
                                                Console.WriteLine("Невірний ввід. Будь ласка, введіть число.");
                                                continue;
                                            }

                                        } while (ramTypeInput < 1 || ramTypeInput > 5);

                                        RAMType ramType = (RAMType)ramTypeInput;

                                        store.AddProduct(new RandomAccessMemory(productName, productArticle, productPrice,
                                            productMemory, ramType, ramFormFactor));

                                        Console.WriteLine("Оперативну пам'ять було додано!");
                                    }
                                    break;
                                case ProductCategory.VideoCard:
                                    {

                                        int productMemory = 0;
                                        do
                                        {
                                            Console.Write("Введіть об'єм пам'яті: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productMemory) || productMemory <= 0);

                                        Console.WriteLine("Оберіть тип пам'яті:");
                                        Console.WriteLine("1. DDR1");
                                        Console.WriteLine("2. DDR2");
                                        Console.WriteLine("3. DDR3");
                                        Console.WriteLine("4. DDR4");
                                        Console.WriteLine("5. DDR5");
                                        Console.WriteLine("=================");
                                        Console.Write("Оберіть тип пам'яті: ");
                                        int ramTypeInput;
                                        do
                                        {
                                            if (!int.TryParse(Console.ReadLine(), out ramTypeInput) ||
                                                ramTypeInput < 1 || ramTypeInput > 5)
                                            {
                                                Console.WriteLine("Невірний ввід. Будь ласка, введіть число.");
                                                continue;
                                            }

                                        } while (ramTypeInput < 1 || ramTypeInput > 5);

                                        RAMType ramType = (RAMType)ramTypeInput;

                                        int productFreqency = 0;
                                        do
                                        {
                                            Console.Write("Введіть частоту: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productFreqency) || productFreqency <= 0);


                                        store.AddProduct(new VideoCard(productName, productArticle, productPrice,
                                            productMemory, productFreqency, ramType));
                                        Console.WriteLine("Відеокарту було додано!");
                                    }
                                    break;
                                case ProductCategory.HardDrive:
                                    {
                                        int productMemory = 0;
                                        do
                                        {
                                            Console.Write("Введіть об'єм пам'яті: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productMemory) || productMemory <= 0);

                                        int productRPM = 0;
                                        do
                                        {
                                            Console.Write("Введіть швидкість обертання (RPM): ");
                                        } while (!int.TryParse(Console.ReadLine(), out productRPM) || productRPM <= 0);

                                        double productFormFactor = 0;
                                        do
                                        {
                                            Console.Write("Введіть форм-фактор (дюйми): ");
                                        } while (!double.TryParse(Console.ReadLine(), out productFormFactor) || productFormFactor <= 0);


                                        store.AddProduct(new HardDrive(productName, productArticle, productPrice,
                                            productMemory, productRPM, productFormFactor));

                                        Console.WriteLine("Жорсткий диск було додано!");
                                    }
                                    break;
                                case ProductCategory.PowerSupplyUnit:
                                    {
                                        int productPower = 0;
                                        do
                                        {
                                            Console.Write("Введіть потужність: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productPower) || productPower <= 0);

                                        store.AddProduct(new PowerSupplyUnit(productName, productArticle, productPrice, productPower));

                                        Console.WriteLine("Блок живлення додано!");
                                    }
                                    break;
                                case ProductCategory.Case:
                                    {
                                        Console.WriteLine("Оберіть форм-фактор кейса:");
                                        Console.WriteLine("1. ATX");
                                        Console.WriteLine("2. MicroATX");
                                        Console.WriteLine("3. MiniATX");
                                        Console.WriteLine("=================");
                                        Console.Write("Оберіть форм-фактор кейса: ");
                                        int motherboardTypeInput;
                                        do
                                        {
                                            if (!int.TryParse(Console.ReadLine(), out motherboardTypeInput) ||
                                                motherboardTypeInput < 1 || motherboardTypeInput > 3)
                                            {
                                                Console.WriteLine("Невірний ввід. Будь ласка, введіть існуюче число.");
                                                continue;
                                            }
                                        } while (motherboardTypeInput < 1 || motherboardTypeInput > 3);

                                        MotherboardType motherboardType = (MotherboardType)motherboardTypeInput;


                                        store.AddProduct(new Case(productName, productArticle, productPrice, motherboardType));
                                        Console.WriteLine("Кейс було додано!");
                                    }
                                    break;
                                case ProductCategory.SSD:
                                    {
                                        int productMemory = 0;
                                        do
                                        {
                                            Console.Write("Введіть об'єм пам'яті: ");
                                        } while (!int.TryParse(Console.ReadLine(), out productMemory) || productMemory <= 0);

                                        int productSpeed = 0;
                                        do
                                        {
                                            Console.Write("Введіть швидкість запису): ");
                                        } while (!int.TryParse(Console.ReadLine(), out productSpeed) || productSpeed <= 0);

                                        store.AddProduct(new SSD(productName, productArticle, productPrice, productMemory, productSpeed));
                                        Console.WriteLine("SSD було додано!");
                                    }
                                    break;
                                case ProductCategory.Cooler:
                                    {
                                        Console.WriteLine("Оберіть тип системи охолодження:");
                                        Console.WriteLine("1. Водяне охолодження");
                                        Console.WriteLine("2. Баштове охолодження");
                                        Console.WriteLine("=================");
                                        Console.Write("Оберіть тип системи охолодження: ");
                                        int coolerTypeInput;
                                        do
                                        {
                                            if (!int.TryParse(Console.ReadLine(), out coolerTypeInput) ||
                                                coolerTypeInput < 1 || coolerTypeInput > 2)
                                            {
                                                Console.WriteLine("Невірний ввід. Будь ласка, введіть число.");
                                                continue;
                                            }
                                        } while (coolerTypeInput < 1 || coolerTypeInput > 2);

                                        CoolerType coolerType = (CoolerType)coolerTypeInput;

                                        store.AddProduct(new Cooler(productName, productArticle, productPrice, coolerType));
                                        Console.WriteLine("Систему охолодження було додано!");
                                    }
                                    break;
                                case ProductCategory.Monitor:
                                    {
                                        double productDiagonal = 0;
                                        do
                                        {
                                            Console.Write("Введіть діагональ монітора (дюйми): ");
                                        } while (!double.TryParse(Console.ReadLine(), out productDiagonal) || productDiagonal <= 0);

                                        int productFrequency = 0;
                                        do
                                        {
                                            Console.Write("Введіть частоту монітора (Гц): ");
                                        } while (!int.TryParse(Console.ReadLine(), out productFrequency) || productFrequency <= 0);

                                        Console.WriteLine("Оберіть тип матриці:");
                                        Console.WriteLine("1. IPS");
                                        Console.WriteLine("2. OLED");
                                        Console.WriteLine("3. TN");
                                        Console.WriteLine("4. VA");
                                        Console.WriteLine("5. TFT");
                                        Console.WriteLine("=================");
                                        Console.Write("Оберіть тип матриці: ");
                                        int matrixTypeInput;
                                        do
                                        {
                                            if (!int.TryParse(Console.ReadLine(), out matrixTypeInput) ||
                                                matrixTypeInput < 1 || matrixTypeInput > 5)
                                            {
                                                Console.WriteLine("Невірний ввід. Будь ласка, введіть число.");
                                                continue;
                                            }
                                        } while (matrixTypeInput < 1 || matrixTypeInput > 5);

                                        MatrixType matrixType = (MatrixType)matrixTypeInput;

                                        store.AddProduct(new Monitor(productName, productArticle, productPrice,
                                            productDiagonal, productFrequency, matrixType));

                                        Console.WriteLine("Монітор було додано!");
                                    }
                                    break;
                                default:
                                    {
                                        Console.WriteLine("Невірний вибір. Будь ласка, оберіть існуючий тип товару.");
                                    }
                                    break;
                            }

                        }
                        break;
                    case Menu.RemoveProductFromStore:
                        {
                            store.ShowAllProductsWithNumbers();
                            Console.Write("Введіть номер товару для видалення: ");
                            int.TryParse(Console.ReadLine(), out int removeIndex);
                            removeIndex--;

                            if (removeIndex >= 0 && removeIndex < store.Products.Count)
                            {
                                store.Products.RemoveAt(removeIndex);
                                Console.WriteLine("Товар було видалено!");
                            }
                            else
                            {
                                Console.WriteLine("Помилка! Не вірний номер товару!");
                            }
                        }
                        break;
                    case Menu.ShowAllProductsInStore:
                        {
                            store.ShowAllProducts();
                        }
                        break;
                    case Menu.CreateComputerSystem:
                        {
                            Console.Write("Введіть назву товару: ");
                            string productName = Console.ReadLine();

                            Console.Write("Введіть артикул товару: ");
                            string productArticle = Console.ReadLine();

                            int indexToAdd = 0;
                            List<Product> products = new List<Product>();
                            store.ShowAllProductsWithNumbers();
                            do
                            {
                                Console.WriteLine("Введiть номер для додавання(0 - щоб вийти): ");
                                int.TryParse(Console.ReadLine(), out indexToAdd);
                                
                                if(indexToAdd != 0 && indexToAdd - 1 >= 0 && indexToAdd - 1 < store.Products.Count)
                                {
                                    products.Add(store.Products[indexToAdd - 1]);
                                    Console.WriteLine("Товар додано!");
                                    Thread.Sleep(500);
                                    Console.Clear();
                                    store.ShowAllProductsWithNumbers();
                                }
                                else
                                {
                                    Console.WriteLine("Помилка! Не вірний номер товару!");
                                }

                            } while (indexToAdd != 0);

                            if(products.Count == 0)
                            {
                                Console.WriteLine("Ви не додали компоненти, помилка!");
                                continue;
                            }

                            int productPurchase = 0;
                            do
                            {
                                Console.Write("Введіть об'єм націнки(в процентному відношені): ");
                            } while (!int.TryParse(Console.ReadLine(), out productPurchase) || productPurchase <= 0);

                            store.AddProduct(ComputerSystemFacade.AssembleComputerSystem(productName, productArticle, 0, products, productPurchase));
                            Console.WriteLine("Систему було додано!");
                        }
                        break;
                    case Menu.AddItemToCart:
                        {
                            store.ShowAllProductsWithNumbers();
                            Console.Write("Введіть номер товару для додаваня: ");
                            int.TryParse(Console.ReadLine(), out int addIndex);
                            addIndex--;

                            if (addIndex >= 0 && addIndex < store.Products.Count)
                            {
                                cart.Add(store.Products[addIndex]);
                                Console.WriteLine("Товар було додано!");
                            }
                            else
                            {
                                Console.WriteLine("Помилка! Не вірний номер товару!");
                            }
                        }
                        break;
                    case Menu.RemoveItemFromCart:
                        {
                            ShowAllProductsWithNumbers(cart);
                            Console.Write("Введіть номер товару для видалення: ");
                            int.TryParse(Console.ReadLine(), out int removeIndex);
                            removeIndex--;

                            if (removeIndex >= 0 && removeIndex < cart.Count)
                            {
                                cart.RemoveAt(removeIndex);
                                Console.WriteLine("Товар було видалено!");
                            }
                            else
                            {
                                Console.WriteLine("Помилка! Не вірний номер товару!");
                            }
                        }
                        break;
                    case Menu.Checkout:
                        {
                            if(cart.Count == 0)
                            {
                                Console.WriteLine("У вас нема товарів у кошику!");
                                continue;
                            }

                            ShowAllProducts(cart);
                            Console.WriteLine($"Загальна ціна: {GetTotalPrice(cart).ToString("C")}");
                            Console.WriteLine("Покупка зроблена!");
                            cart = new List<Product>();
                        }
                        break;
                    case Menu.Exit:
                        {
                            Console.WriteLine("Вихід...");
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Невірний вибір. Будь ласка, оберіть існуючий пункт меню.");
                        }
                        break;
                }

            } while (selectedOption != Menu.Exit);
        }
    }
}
