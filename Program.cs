namespace Final_Project
{
    internal class Program
    {
        public static string ReadString(string message = "Enter a string: ")
        {
            string str;
            Console.Write(message);
            str = Console.ReadLine();
            return str;
        }
        public static int ReadIntNumber(string message = "Enter an integer number: ")
        {
            int number;
            Console.Write(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.Write("Invalid input. Please enter a valid integer number: ");
            }
        }
        public static double ReadDoubleNumber(string message = "Enter a double number: ")
        {
            double number;
            Console.Write(message);
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.Write("Invalid input. Please enter a valid double number: ");
            }
        }

        public static double[] ReadArrayElements(double[] arr, int arrLength, string message = "Enter an arr element ")
        {
            for (int i = 0; i < arrLength; i++)
            {
                arr[i] = ReadDoubleNumber(message + $"{i + 1}: ");
            }
            return arr;
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        // The functions and procedures for exercise 1
        public static int SumTwoNumbers(int num1, int num2)
        {
            return num1 + num2;
        }
        public static bool AreTwoNumbersEqual(int num1, int num2)
        {
            return num1 == num2;
        }

        public static bool AreAgeEligible(double age)
        {
            return age >= 18;
        }

        public static string GetQuadrantOfTwoPoints(double x, double y)
        {
            if (x == 0 && y == 0)
                return "Origin";

            if (x == 0)
                return "On the Y-axis";

            if (y == 0)
                return "On the X-axis";

            if (x > 0)
                return y > 0 ? "First Quadrant" : "Fourth Quadrant";

            return y < 0 ? "Second Quadrant" : "Third Quadrant";
        }

        public static void DetermineTriangleType(double[] sides)
        {
            double sideA, sideB, sideC;
            sideA = sides[0];
            sideB = sides[1];
            sideC = sides[2];

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                Console.WriteLine("The provided side lengths do not form a valid triangle.\n");
                return;
            }

            if (sideA == sideB && sideB == sideC)
                Console.WriteLine("The triangle is Equilateral.\n");

            else if (sideA == sideB || sideB == sideC || sideA == sideC)
                Console.WriteLine("The triangle is Isosceles.\n");

            else if (Math.Pow(sideA, 2) + Math.Pow(sideB, 2) == Math.Pow(sideC, 2) ||
                     Math.Pow(sideA, 2) + Math.Pow(sideC, 2) == Math.Pow(sideB, 2) ||
                     Math.Pow(sideB, 2) + Math.Pow(sideC, 2) == Math.Pow(sideA, 2))

                Console.WriteLine("The triangle is a Right triangle.\n");

            else
                Console.WriteLine("The triangle is Scalene.\n");
        }

        public static double CalculateElectricityBill(double unitsConsumed)
        {
            double billAmount;

            if (unitsConsumed < 300)
                billAmount = unitsConsumed * 1.5;

            else if (unitsConsumed < 450)
                billAmount = unitsConsumed * 2;

            else if (unitsConsumed < 600)
                billAmount = unitsConsumed * 2.5;

            else
            {
                billAmount = unitsConsumed * 2.5;
                billAmount += billAmount * 0.10;
            }

            return billAmount;
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        // The functions and procedures for exercise 2
        public static int ClientIndex;

        public static void Deposit(object[,] clients)
        {
            double amount = ReadDoubleNumber("Enter the amount to deposit: ");
            double currentBalance = (double)clients[ClientIndex, 6];
            clients[ClientIndex, 6] = currentBalance + amount;
            Console.Clear();
            Console.WriteLine($"\nDeposit successful. Your new balance is: ${clients[ClientIndex, 6]}");
            return;
        }

        public static void Withdraw(object[,] clients)
        {
            double amount = ReadDoubleNumber("Enter the amount to withdraw: ");
            double currentBalance = (double)clients[ClientIndex, 6];
            if (amount <= currentBalance)
            {
                clients[ClientIndex, 6] = currentBalance - amount;
                Console.Clear();
                Console.WriteLine($"\nWithdrawal successful. Your new balance is: ${clients[ClientIndex, 6]}");
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Insufficient funds.");
                return;
            }
        }

        public static void DisplayInformation(object[,] clients)
        {
            Console.WriteLine("\nYour Information:");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Name: {clients[ClientIndex, 1]}");
            Console.WriteLine($"Email: {clients[ClientIndex, 4]}");
            Console.WriteLine($"Phone: {clients[ClientIndex, 5]}");
            Console.WriteLine($"Balance: ${clients[ClientIndex, 6]}");
            Console.WriteLine($"Account Type: {clients[ClientIndex, 7]}");
            return;
        }

        public static void IneerSceen(object[,] clients)
        {
            int PerformNumber;
            do
            {
                Console.Clear();
                Console.WriteLine("\n                                               Welcome to the Bank System        ");
                Console.WriteLine(new string('=', Console.WindowWidth - 1));
                Console.WriteLine("LogIn successfully");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("[1]. Deposit");
                Console.WriteLine("[2]. Withdraw");
                Console.WriteLine("[3]. Display Information");
                Console.WriteLine("[4]. Exit");
                Console.WriteLine("-------------------------------------------");

                PerformNumber = ReadIntNumber("What do you want to do? (Enter 1, 2, 3, or 4): ");

                switch (PerformNumber)
                {
                    case 1:
                        Deposit(clients);
                        break;
                    case 2:
                        Withdraw(clients);
                        break;
                    case 3:
                        DisplayInformation(clients);
                        break;
                    case 4:
                        Console.WriteLine("\nExiting. Thank you for using our service!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }

                if (PerformNumber != 4)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }

            } while (PerformNumber != 4);
        }

        public static bool CheckCredentials(string username, string password, object [,] clients)
        {
            for (int i = 0; i < clients.GetLength(0); i++)
            {
                string storedUsername = (string)clients[i, 2]; 
                string storedPassword = (string)clients[i, 3];

                if (username == storedUsername && password == storedPassword)
                {
                    ClientIndex = i;
                    return true;
                }
            }
            return false;
        }
        
        public static void PrintMainScreen()
        {            
            Console.Clear();
            Console.WriteLine("\n                                               Welcome To The Bank System        ");
            Console.WriteLine(new string('=', Console.WindowWidth - 1));
            Console.WriteLine("\nPlease log in to proceed...");
            Console.WriteLine("-------------------------------------------");
        }
        public static void BankSystem(object[,] clients)
        {
            PrintMainScreen();

            int attemptCount = 0;
            bool loginSuccess = false;

            while (attemptCount < 3 && !loginSuccess)
            {
                string username = ReadString("Username: ");
                string password = ReadString("Password: ");

                loginSuccess = CheckCredentials(username, password, clients);

                if (!loginSuccess)
                {
                    attemptCount++;
                    if (attemptCount < 3)
                    {
                        PrintMainScreen();
                        Console.WriteLine($"Invalid username or password. You have {3 - attemptCount} attempts left.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nYou have exceeded the maximum number of login attempts.");
                    }
                }
            }

            if (loginSuccess)
                IneerSceen(clients);
        }

        static void Main(string[] args)
        {
            
            // Exercise 1-1
            int num1 = ReadIntNumber("Enter the first number: ");
            int num2 = ReadIntNumber("Enter the second number: ");
            int sum = SumTwoNumbers(num1, num2);

            if (AreTwoNumbersEqual(num1, num2))
                Console.WriteLine($"Sum = {sum} and Sum-Cubed = {Math.Pow(sum, 3)}\n");
            else          
                Console.WriteLine($"Sum = {sum} and the two numbers are not equivalent.\n");

            // Exercise 1-2
            double studentAge = ReadDoubleNumber("Enter your age: ");

            if (AreAgeEligible(studentAge))
                Console.WriteLine($"Your age is eligible.\n");
            else
                Console.WriteLine($"Your age is not eligible.\n");

            // Exercise 1-3
            double pointOne = ReadDoubleNumber("Enter point one: ");
            double pointTwo = ReadDoubleNumber("Enter point two: ");
            Console.WriteLine($"The point [{pointOne}, {pointTwo}] is located in: {GetQuadrantOfTwoPoints(pointOne, pointTwo)}\n");

            // Exercise 1-4
            double[] sides = new double [3];
            sides = ReadArrayElements(sides, 3, $"Enter side ");
            DetermineTriangleType(sides);

            // Exercise 1-5
            double unitsConsumed = ReadDoubleNumber("Enter the amount of units consumed: ");
            Console.WriteLine($"The total electricity bill for {unitsConsumed} units is: ${CalculateElectricityBill(unitsConsumed)}\n");
            
            Console.WriteLine("\nWating...");
            Thread.Sleep(4000); // 4-second delay before starting exercise 2  
            
            // Exercise 2
            object[,] clients = new object[,]
            {
                { 1,  "Ahmad Khalid",  "ahmadk",  "pass123", "ahmad.khalid@gmail.com",   "+962789001234", 3400.75, "Savings"  },
                { 2,  "Sara Mahmoud",  "saram",   "pass234", "sara.mahmoud@yahoo.com",   "+962785002345", 1500.50, "Checking" },
                { 3,  "Yousef Hani",   "yousefh", "pass345", "yousef.hani@hotmail.com",  "+962789003456", 7800.00, "Savings"  },
                { 4,  "Layla Omar",    "laylao",  "pass456", "layla.omar@gmail.com",     "+962789004567", 5000.20, "Checking" },
                { 5,  "Omar Ali",      "omarali", "pass567", "omar.ali@yahoo.com",       "+962789005678", 9200.10, "Savings"  },
                { 6,  "Rania Nabil",   "ranian",  "pass678", "rania.nabil@hotmail.com",  "+962789006789", 2600.00, "Checking" }, 
                { 7,  "Hassan Fadi",   "hassanf", "pass789", "hassan.fadi@gmail.com",    "+962789007890", 4300.40, "Savings"  },
                { 8,  "Mariam Sameer", "mariams", "pass890", "mariam.sameer@yahoo.com",  "+962789008901", 3100.00, "Checking" },
                { 9,  "Khaled Samir",  "khaleds", "pass901", "khaled.samir@hotmail.com", "+962789009012", 6700.50, "Savings"  },
                { 10, "Abeer Adel",    "abeera",  "pass012", "abeer.adel@gmail.com",     "+962789010123", 8900.30, "Checking" }
            };
            
            BankSystem(clients);

            Console.WriteLine("\nWating...");
            Thread.Sleep(3000); // 3-second delay before starting exercise 2 

            Console.Clear();

            // Exercise 3
            int numberOfStudents = ReadIntNumber("Enter the number of students: ");
            double[] arrGrades = new double[numberOfStudents];
            arrGrades = ReadArrayElements(arrGrades, numberOfStudents, $"Enter mark ");

            double averageGrade = arrGrades.Average();
            int aboveAverageCount = arrGrades.Count(grade => grade > averageGrade);
            int belowAverageCount = arrGrades.Count(grade => grade < averageGrade);

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine($"The number of students is: {numberOfStudents}");
            Console.WriteLine($"The minimum mark of students is: {arrGrades.Min()}");
            Console.WriteLine($"The maximum mark of students is: {arrGrades.Max()}");
            Console.WriteLine($"The average mark of students is: {averageGrade}");
            Console.WriteLine($"Number of students above average: {aboveAverageCount}");
            Console.WriteLine($"Number of students below average: {belowAverageCount}");
            
        }
    }
}
