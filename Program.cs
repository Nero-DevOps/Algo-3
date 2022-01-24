using ConsoleTables;
using System.Text.RegularExpressions;


namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            // define the file name
            string fileName = @"retailer.csv";
            // get the directory path
            string path = Path.GetFullPath(fileName);
            path = path.Replace("\\bin\\Debug\\net6.0", "");
            bool count = false;
            Point point = new Point(-10.0, -10.0);
            Rectangle region = new Rectangle(point, 200.0, 200.0);
            // Creation of QuadTree 
            QuadTree<Retailer> tree = new QuadTree<Retailer>(20000, region);
            Console.WriteLine("Your Required QuadTree has been created");
            Console.WriteLine("\n");

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    // read row from csv 
                    var line = reader.ReadLine();
                    if (count == false) // skip the header of csv file 
                    {
                        count = true;
                        continue;
                    }
                    // define a regex to split row from commas and skip the comma inside the double quotes
                    // split function return an array of string that we have stored in value array
                    var values = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    // getting the values from values array and assign it to the variable
                    string retailerName = values[1];
                    string storeName = values[3];
                    string streetName = values[4];
                    string town = values[6];
                    string postalCode = values[8];
                    string sizeBrand = values[15];
                    double xCoordinate = Convert.ToDouble(values[9]);
                    double yCoordinate = Convert.ToDouble(values[10]);
                    // store the retailer info to the object
                    Retailer retailer = new Retailer(retailerName, storeName, streetName, town, postalCode, sizeBrand, xCoordinate, yCoordinate);
                    // add that object to the hashtable
                    Point Pos = new Point(xCoordinate, yCoordinate);
                    tree.Add(Pos, retailer);
                }
            }

            Console.WriteLine("Your Required QuadTree Points have been added!");
            Console.WriteLine("\n \n");

            while (true)
            {
                // This Lines to find the value with respect to quadtree
                Console.Write("Write x coordinate: ");
                double long_x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Write y coordinate: ");
                double long_y = Convert.ToDouble(Console.ReadLine());
                Point pos1 = new Point(long_x, long_y);
                var foundNode = tree.FindNode(pos1);
                Console.WriteLine();
                if (foundNode == null)
                {
                    Console.WriteLine("No Value has been founded on this point.");
                }
                else
                {
                    Retailer R1 = foundNode as Retailer;
                    ConsoleTable consoleTable = new ConsoleTable("Retailer Name", "Store Name", "Street", "Town", "PostCode", "Size band");
                    consoleTable.AddRow(R1.RetailerName, R1.StoreName, R1.StreetName, R1.Town, R1.PostalCode, R1.SizeBrand);
                    consoleTable.Write();
                }
                Console.Write("\nEnter 0 to quit or anything else to continue: ");
                string input = Console.ReadLine();
                Console.WriteLine();
                if (input == "0")
                {
                    break;
                }
            }
        }
    }
}