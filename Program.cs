using System.Text;

class HexAsciiConverter
{
    
    public static string AsciiToHex(string asciiStr)
    {
        string cleanStr=asciiStr.Replace(" ","");
        StringBuilder hexBuilder = new StringBuilder();
        for (int i = 0; i < cleanStr.Length; i += 2)
        {
            string charPair = cleanStr.Substring(i, 2);

            foreach (char c in charPair)
            {
                hexBuilder.AppendFormat("{0:X2}", (int)c);
            }
            hexBuilder.Append(" ");
        }
        return hexBuilder.ToString().Trim();
    }
    
    public static string HexToAscii(string hexStr)
    {
        hexStr = hexStr.Replace(" ", "");
        if (hexStr.Length % 2 != 0)
        {
            throw new ArgumentException("Input value should be in pair!");
        }

        var asciiBuilder = new StringBuilder();
        for (int i = 0; i < hexStr.Length; i += 2)
        {
            string hexPair = hexStr.Substring(i, 2);
            int charCode = Convert.ToInt32(hexPair, 16);
            asciiBuilder.Append((char)charCode);
            if ((i + 2) % 4 == 0 && i + 2 < hexStr.Length)
            {
                asciiBuilder.Append(" ");
            }
        }
        return asciiBuilder.ToString();
    }
    public static byte[] HexStringToByteArray(string hex)
    {
        hex = hex.Replace(" ", "");
        if (hex.Length % 2 != 0)
        {
            //throw new ArgumentException("Hexadecimal string must contain an even number of characters.");
        }
        //byte[] utf8Bytes = Encoding.UTF8.GetBytes(hex);
        byte[] byteArray = Enumerable.Range(0, hex.Length / 2)
                                     .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                                     .ToArray();
        return byteArray;
    }

    //public static string BytesToHex(byte[] byteArray)
    //{
    //    StringBuilder hexInput= new StringBuilder(byteArray.Length*2);
    //    foreach(byte b in byteArray)
    //    {
    //        hexInput.AppendFormat("{0:X2}", b);
    //    }
    //    return hexInput.ToString();
    //}
    public static string ByteArrayToHex(byte[] byteArray)
    {
        StringBuilder hexBuilder = new StringBuilder(byteArray.Length * 2);
        foreach (byte b in byteArray)
        {
            hexBuilder.AppendFormat("{0:X2} ", b);
        }
        return hexBuilder.ToString();
    }
    public static string BinaryToHex(string binaryStr)
    {
        int length = binaryStr.Length;
        if (length % 4 != 0)
        {
            binaryStr = binaryStr.PadLeft(((length / 4) + 1) * 4, '0');
        }

        StringBuilder hexBuilder = new StringBuilder();

        for (int i = 0; i < binaryStr.Length; i += 4)
        {
            string binaryChunk = binaryStr.Substring(i, 4);
            int decimalValue = Convert.ToInt32(binaryChunk, 2);
            hexBuilder.AppendFormat("{0:X1} ", decimalValue);
        }

        return hexBuilder.ToString();
    }
    public static string HexToBinary(string hexStr)
    {
        StringBuilder binaryBuilder = new StringBuilder();
 
        foreach (char hexChar in hexStr.Replace(" ", ""))
        {
            int decimalValue = Convert.ToInt32(hexChar.ToString(), 16);
            string binaryValue = Convert.ToString(decimalValue, 2).PadLeft(4, '0');
            binaryBuilder.Append(binaryValue);
        }

        return binaryBuilder.ToString();
    }


    static void Main(String[]args)
    {
        while(true)
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine();
            Console.WriteLine("1. Convert ASCII to Hexadecimal");
            Console.WriteLine("2. Convert Hexadecimal to ASCII");
            Console.WriteLine("3. Convert Hexadecimal to Byte Array");
            Console.WriteLine("4. Convert Byte Array to Hexadecimal");
            Console.WriteLine("5. Convert Binary to Hexadecimal");
            Console.WriteLine("6. Convert Hexadecimal to Binary");
            Console.WriteLine("7. Exit");
            Console.WriteLine();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter the ASCII string: ");
                    string ascii = Console.ReadLine();
                    string hexOutput = AsciiToHex(ascii);
                    Console.WriteLine("Hexadecimal representation: " + hexOutput);
                    break;
                case "2":
                    Console.Write("Enter the Hexadecimal string Pair: ");
                    string hex = Console.ReadLine();
                    string asciiOutput = HexToAscii(hex);
                    Console.WriteLine("ASCII representation: " + asciiOutput);
                    break;
                case "3":
                    Console.Write("Enter the Hexadecimal string Pair: ");
                    string hexStr= Console.ReadLine();
                    byte[] byteArray = HexStringToByteArray(hexStr);
                    Console.WriteLine("Byte array:");
                    Console.WriteLine(string.Join(". ", byteArray));
                    break;
                case "4":
                    Console.Write("Enter the byte array as a space-separated list of numbers: ");
                    string byteInput = Console.ReadLine();
                    byte[] byteArrayInput = byteInput.Split(' ')
                                                    .Select(byte.Parse)
                                                    .ToArray();
                    string hexFromBytes = ByteArrayToHex(byteArrayInput);
                    Console.WriteLine("Hexadecimal representation: " + hexFromBytes);
                    break;
                case "5":
                    Console.Write("Enter the binary string: ");
                    string binaryStr = Console.ReadLine();
                    string hexFromBinary = BinaryToHex(binaryStr);
                    Console.WriteLine("Hexadecimal representation: " + hexFromBinary);
                    break;

                case "6":
                    Console.Write("Enter the hexadecimal string: ");
                    string hexStrInput = Console.ReadLine();
                    string binaryFromHex = HexToBinary(hexStrInput);
                    Console.WriteLine("Binary representation: " + binaryFromHex);
                    break;
                case "7":
                    Console.WriteLine("Thank You for Using this Converter!Kindly Press Enter Again");
                    break;
            }
            if (choice == "7")
            {
                break;
            }
        }
    }
}
