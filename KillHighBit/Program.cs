// See https://aka.ms/new-console-template for more information
Console.WriteLine("KillHighBit");
Console.WriteLine("Kills the high bits of every byte (useful for ancient programs - 1970s - and MDOS4 DEBUGDD.SYS...)");

try
{
    if (!File.Exists(args[0]))
    {
        Console.WriteLine("File does not exist!");
        Environment.Exit(1);    
    }

    byte[] bytes = File.ReadAllBytes(args[0]);

    for (int curByte = 0; curByte < bytes.Length; curByte++)
    {
        bytes[curByte] = (byte)(bytes[curByte] & (byte)0x7f); // OR by 0x80 to kill high byte
    }

    File.WriteAllBytes(args[0], bytes);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Done!");
    Console.ResetColor();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: \n\n{ex}");
    Environment.Exit(2);
}