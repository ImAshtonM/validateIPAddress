bool validIPLength;
bool noLeadingZeros;
bool validIPNumberRange;

string testIP1 = "1.1.1.1";
string testIP2 = "255.255.255.255";
string testIP3 = "1.1.1";
string testIP4 = "100.015.100.015";
string testIP5 = "200.256.256.256";
string testIP6 = "200.0.0.255";

ValidateIP(testIP1);
ValidateIP(testIP2);
ValidateIP(testIP3);
ValidateIP(testIP4);
ValidateIP(testIP5);
ValidateIP(testIP6);


void ValidateIP(string address)
{
    validIPLength = false;
    noLeadingZeros = false;
    validIPNumberRange = false;
    
    string[] splitIP = address.Split(".");

    ValidateLength(splitIP);
    ValidateNoLeadingZeros(splitIP);
    ValidateIPRange(splitIP);

    if (validIPLength && noLeadingZeros && validIPNumberRange)
    {
        Console.WriteLine($"This {address} is a valid IP address. It passed all validation tests.");
    }
    else
    {
        Console.WriteLine($"This {address} is NOT a valid IP address.");
    }

    Console.WriteLine();

}

void ValidateLength(string[] splitIP)
{
    if (splitIP.Length == 4)
    {
        Console.WriteLine("IP as a valid length.");
        validIPLength = true;
    }
}

void ValidateNoLeadingZeros(string[] splitIP)
{
    int validateCounter = 0;
    for (int i = 0; i < splitIP.Length; i++)
    {
        if (Int32.TryParse(splitIP[i].ToString(), out int parsedIPInt))
        {
            if (parsedIPInt == 0)
            {
                validateCounter += 1;
            }
            else
            {
                char[] splitIPToChars = splitIP[i].ToCharArray();
                if (Int32.TryParse(splitIPToChars[0].ToString(), out int leadingDigit))
                {
                    if (leadingDigit != 0)
                    {
                        Console.WriteLine($"Section {i + 1} of the IP address does not have any leading zeros.");
                        validateCounter += 1;
                        
                    }
                    else
                    {
                        Console.WriteLine($"Section {i + 1} of the IP address contains a leading zero.");
                        return;
                    }
                }
            }
        }
    }
    if (validateCounter == 4)
    {
        Console.WriteLine("The IP address does not contain any leading zeros.");
        noLeadingZeros = true;
    }
}

void ValidateIPRange(string[] splitIP)
{
    int validateCounter = 0;
    for (int i = 0; i < splitIP.Length; i++)
    {
        if (Int32.TryParse(splitIP[i].ToString(), out int parsedIPInt))
        {
            if (parsedIPInt < 0 || parsedIPInt > 255)
            {
                Console.WriteLine($"Section {i + 1} of the IP address, {parsedIPInt} is not within acceptable range.");
                return;
            }
            else
            {
                Console.WriteLine($"Section {i + 1} of the IP address, {parsedIPInt} is within acceptable range.");
                validateCounter += 1;
            }
        }
        if (validateCounter == 4)
        {
            Console.WriteLine("The IP address does not contain any numbers out of range.");
            validIPNumberRange = true;
        }
    }
}