bool validIPLength;
bool noLeadingZeros;
bool validIPNumberRange;

string testIP1 = "1.1.1.1";
string testIP2 = "255.255.255.255";
string testIP3 = "1.1.1";
string testIP4 = "100.015.100.015";
string testIP5 = "200.256.256.256";

ValidateIP(testIP1);
ValidateIP(testIP2);
ValidateIP(testIP3);
ValidateIP(testIP4);
ValidateIP(testIP5);


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
        Console.WriteLine($"This {address} is not a valid IP address.");
    }

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
        char[] splitIPToChars = splitIP[i].ToCharArray();
        if (Int32.TryParse(splitIPToChars[0].ToString(), out _))
        {
            Console.WriteLine($"Section {i + 1} of the IP address does not have any leading zeros.");
            validateCounter += 1;
        }
        else
        {
            Console.WriteLine($"Section {i + 1} of the IP address contains a leading zero.");
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
            if (parsedIPInt > 0 && parsedIPInt < 256)
            {
                Console.WriteLine($"Section {i + 1} of the IP address is within acceptable range.");
                validateCounter += 1;
            }
            else
            {
                Console.WriteLine($"Section {i + 1} of the IP address is not within acceptable range.");
                break;
            }
        }
        if (validateCounter == 4)
        {
            Console.WriteLine("The IP address does not contain any numbers out of range.");
            validIPNumberRange = true;
        }
    }
}