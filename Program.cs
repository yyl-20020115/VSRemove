namespace VSRemove;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0 || args.Length > 0 && !Directory.Exists(args[0]))
        {
            Console.WriteLine("VSRemove <Path> [dirname:.vs]");
            Console.WriteLine("   Removes all .vs/other folders within speicified path to free disk space.");
        }
        else
        {
            var path = args[0];
            if (Directory.Exists(path))
            {
                var ext = args.Length > 1 ? args[1] : ".vs";
                Console.WriteLine("Searching for directories...");
                var directories = Directory.GetDirectories(path, ext, SearchOption.AllDirectories);
                foreach(var d in directories)
                {
                    Console.WriteLine(d);
                    try
                    {
                        Directory.Delete(d, true);
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }
    }
}
