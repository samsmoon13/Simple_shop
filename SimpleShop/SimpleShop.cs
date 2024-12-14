﻿using System;
using System.IO;
using System.Globalization;

namespace SimpleShop
{
    public static class SimpleShop
    {
        public static string[] ReadFileLineByLine(string path)
        {
            //change cultureinfo to en US
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            var reader =
                new System.IO.StreamReader(
                    path); // similar to Console.ReadLine but it reads input from files instead of Console
            var line_counter = 0;
            var needed_space = 0;
            // determine number of lines to create the correct size of array
            for (var line = ""; line != null; line = reader.ReadLine(), ++line_counter)
            {
                if (line.Length > 0 && line[0] != '#')
                {
                    ++needed_space;
                }
            }

            // Set Position to beginning of file
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            reader.DiscardBufferedData();

            // Read actual data
            var lines = new string[needed_space];

            for (var tag_lines = 0; line_counter > 1; --line_counter)
            {
                var tmp = reader.ReadLine();
                if (tmp[0] == '#')
                {
                    continue;
                }

                lines[tag_lines++] = tmp;
            }

            return lines;
        }

        static void PrintWelcome()
        {
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("#########################################\n" +
                          "#\t\t\t\t\t#\n" +
                          "#\tWelcome to the SimpleShop\t#\n" +
                          "#\t\t\t\t\t#\n#" +
                          "########################################\n\n");
            Console.ForegroundColor = tmp;
        }

        static void PrintInvoice(InvoicePosition ivp)
        {
            Console.WriteLine(String.Join(", ", new string[]
            {
                ivp.Customer.Name, ivp.ItemName, ivp.Orders.ToString(), ivp.Price().ToString("0.##")
            }));
        }


        /**
        *Per default the main method expects the path to the tag file as an argument, either given via console or in the run properties. However, should you decide to extend your testing methodology with extra tag files,
         * feel free to alter the behaviour. However, it is necessary to point out - if you decide to put static folder paths to your tag files - ensure they are not full paths specific only to your PC but in some other form.
         * (Full path example could look something like C:/Users/JohnDoe/Assignment4 or any other path specific to your PC, in which case the grader will not be able to open the files properly to test)
         * Also note: would be pretty nice if you also leave a txt/pdf in your submission in case you have any specific instructions for operating your SimpleShop.
        */
        public static int Main(string[] args)
        {
            // check if path to input file is provided
            if (args.Length != 1)
            {
                Console.WriteLine("That is not how you use this shop!");
                return 1;
            }

            // check if input file exists at given path and whether it contains order data or not
            if (!File.Exists(args[0]))
            {
                ReadFileLineByLine(args[0]);
                Console.WriteLine("Orders not found!");
                return 1;
            }

            PrintWelcome();
            var orders = ReadFileLineByLine(args[0]);
            var pairs = new Keyword[]
            {
                new Keyword("ItemNumber"),
                new Keyword("ItemName"),
                new Keyword("CustomerName"),
                new Keyword("AmountOrdered"),
                new Keyword("NetPrice")
            };
            Console.WriteLine("Invoices:");
            var shopParser = new ShopParser();
            shopParser.SetKeywords(pairs);

            foreach (var order in orders)
            {
                var list = ShopParser.ExtractFromTAG(shopParser, order);
                var invoice = InvoicePosition.CreateFromPairs(list);
                PrintInvoice(invoice);
            }


            //#############################################################################
            //# Code to modify starts here:
            //# (1) Setup the ShopParser
            //# (2) Parse the "orders"
            //# (3) Create Invoices from "orders" (which should be in TAG format)
            //# (4) Output the sum for each customer, you must use the "PrintInvoice" function
            //#############################################################################

            return 0;
        }
    }
}