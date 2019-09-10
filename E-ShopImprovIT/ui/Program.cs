using E_ShopImprovIT.core;
using E_ShopImprovIT.core.Components;
using System;

namespace E_ShopImprovIT
{
    class Program
    {
        static void Main(string[] args)
        {
            ComponentFactory componentFactory = new ComponentFactory();
            ProductFactory productFactory = new ProductFactory();
            SoftwareTypes softwareTypes = new SoftwareTypes();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to Our E-shop");
                Console.WriteLine("What would you like to buy ?\n " +
                    "press 'a' for  PC tower\n" +
                    "press 'b' for a PC screen\n" +
                    "press 'c' for a Personal Computer\n" +
                    "press 'd' for a Workstation\n"+
                    "press 'e' to exit\n");


                string answer = Console.ReadLine();

                if (answer.Equals("a"))
                {
                    PCTower pcTower = ConfigurePCTower(componentFactory, productFactory);
                    if (!pcTower.IsValidProduct())
                    {
                        CannotFinishTheOrder();
                        continue;
                    }

                    PrintReceiptInfo(pcTower);

                }
                else if (answer.Equals("b"))
                {
                    PCScreen pcScreen = ConfigurePCScreen(productFactory);
                    if (!pcScreen.IsValidProduct())
                    {
                        CannotFinishTheOrder();
                        continue;

                    }

                    PrintReceiptInfo(pcScreen);

                }
                else if (answer.Equals("c"))
                {
                    PersonalComputer personalComputer = ConfigurePersonalComputer(componentFactory, productFactory);
                    if (!personalComputer.IsValidProduct())
                    {
                        CannotFinishTheOrder();
                        continue;
                    }

                    PrintReceiptInfo(personalComputer);

                }
                else if (answer.Equals("d"))
                {
                    PersonalComputer personalComputer = ConfigurePersonalComputer(componentFactory, productFactory);
                    if (!personalComputer.IsValidProduct())
                    {
                        CannotFinishTheOrder();
                        continue;
                    }

                    Console.WriteLine("Please select one of the available softwares\n");
                    foreach (var type in softwareTypes.Types)
                    {
                        Console.WriteLine(type.Value + "\n");
                    }
                    answer = Console.ReadLine();
                    Software software = componentFactory.CreateComponent("Software") as Software;
                    if (!software.SetValue(answer))
                    {
                        WrongInput();
                        continue;
                    }

                    Workstation workstation = productFactory.CreateProduct("Workstation") as Workstation;
                    if(!workstation.SetPersonalComputer(personalComputer) || !workstation.SetSoftware(software))
                    {
                        continue;
                    }

                    if (!workstation.IsValidProduct())
                    {
                        CannotFinishTheOrder();
                        continue;
                    }
                    PrintReceiptInfo(workstation);

                }
                else if (answer.Equals("e"))
                {
                    exit = true;
                }
                else
                {
                    WrongInput();
                }


            }
        }

        private static void CannotFinishTheOrder()
        {
            Console.WriteLine("Something went wrong and unfortunetaly we cannnot finish your order, please try again\n");
        }

        private static PersonalComputer ConfigurePersonalComputer(ComponentFactory componentFactory, ProductFactory productFactory)
        {
            string answer;
            PersonalComputer personalComputer;

            PCTower pcTower = ConfigurePCTower(componentFactory, productFactory);

            if (!pcTower.IsValidProduct())
            {
                return productFactory.CreateProduct("PersonalComputer") as PersonalComputer;
            }

            PCScreen pcScreen = ConfigurePCScreen(productFactory);

            if (!pcScreen.IsValidProduct())
            {
                return productFactory.CreateProduct("PersonalComputer") as PersonalComputer;

            }

            Console.WriteLine("Set the size of the Hard Disk\n");
            answer = Console.ReadLine();

            HardDrive hardDrive = componentFactory.CreateComponent("HardDrive") as HardDrive;

            if (!hardDrive.SetValue(answer))
            {
                WrongInput();
                return productFactory.CreateProduct("PersonalComputer") as PersonalComputer;
            }

            personalComputer = productFactory.CreateProduct("PersonalComputer") as PersonalComputer;
            if (!personalComputer.SetScreen(pcScreen))
            {
                WrongInput();
                return productFactory.CreateProduct("PersonalComputer") as PersonalComputer;
            }
            
            if (!personalComputer.SetPCTower(pcTower))
            {
                WrongInput();
                return productFactory.CreateProduct("PersonalComputer") as PersonalComputer;
            }
            ;
            if (!personalComputer.SetHardDrive(hardDrive))
            {
                WrongInput();
                return productFactory.CreateProduct("PersonalComputer") as PersonalComputer;
            }

            if (!personalComputer.IsValidProduct())
            {
                return productFactory.CreateProduct("PersonalComputer") as PersonalComputer;
            }

            return personalComputer;
        }

        private static void PrintReceiptInfo(Product boughtProduct)
        {
            PrintTitleForABuy();
            Console.WriteLine(boughtProduct.GetProductDescription());
            SayThankYou();
        }

        /// <summary>
        /// Oλες οι configure μέθοδοι αν υπήρχε gui θα χαν ξεχωριστα τη λογικη ui και control 
        /// </summary>
        /// <param name="productFactory"></param>
        /// <returns></returns>
        private static PCScreen ConfigurePCScreen(ProductFactory productFactory)
        {
            string answer;
            Console.WriteLine("Insert screen size in inches\n");
            answer = Console.ReadLine();
            PCScreen pcScreen = productFactory.CreateProduct("PCScreen") as PCScreen;
            if (!pcScreen.SetScreenSize(answer))
            {
                WrongInput();
                return productFactory.CreateProduct("PCScreen") as PCScreen;
            }

            return pcScreen;

        }

        private static PCTower ConfigurePCTower(ComponentFactory componentFactory, ProductFactory productFactory)
        {
            string answer;
            PCTower pcTower;
            Console.WriteLine("Insert CPU frequency in GHz\n");
            answer = Console.ReadLine();
            CPU cpu = componentFactory.CreateComponent("CPU") as CPU;
            if (!cpu.SetValue(answer))
            {
                WrongInput();
                return productFactory.CreateProduct("PCTower") as PCTower;
            }

            Console.WriteLine("Insert size of Memory Ram in GB\n");
            answer = Console.ReadLine();
            MemoryRam memoryRam = componentFactory.CreateComponent("MemoryRam") as MemoryRam;
            if (!memoryRam.SetValue(answer))
            {
                WrongInput();
                return productFactory.CreateProduct("PCTower") as PCTower;
            }

            pcTower = productFactory.CreateProduct("PCTower") as PCTower;
            if (!pcTower.SetMemoryRam(memoryRam))
            {
                //handle exception demek 
                WrongInput();
                return productFactory.CreateProduct("PCTower") as PCTower;
            }
            if (!pcTower.SetCPU(cpu))
            {
                //handle exception 
                WrongInput();
                return productFactory.CreateProduct("PCTower") as PCTower;
            }
            return pcTower;
        }

        /// <summary>
        /// αντιστοιχα θα καναμε σε περιπτωση GUI 
        /// τετοιες λειτουργίες θα τις εξάγαμε σε controls
        /// </summary>
        private static void SayThankYou()
        {
            Console.WriteLine("Thank for your preference!\n");
        }

        private static void PrintTitleForABuy()
        {
            Console.WriteLine("$$$$$ Your product's description $$$$$\n");
        }

        private static void WrongInput()
        {
            Console.WriteLine("Wrong Input\n");
        }
    }
}
