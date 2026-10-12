using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhones;

namespace MobilePhones
{
    // The Mobile class stores the details and balance of a mobile phone
    class Mobile
    {
        // Private attributes for the mobile account
        private string company, accType, device, number;
        private decimal balance;

        // Company names and their call and text charges
        private string[] mobileCompanies = { "O2", "Tesco", "Vodafone", "EE", "Smart" };
        private decimal[] callCharges = { 0.55m, 0.45m, 0.55m, 0.57m, 0.32m };
        private decimal[] textCharges = { 0.07m, 0.02m, 0.13m, 0.18m, 0.13m };

        // Creates a new mobile account and sets its balance to zero
        public Mobile(string company, string accType, string device, string number)
        {
            this.company = company;
            this.accType = accType;
            this.device = device;
            this.number = number;
            this.balance = 0.0m;
        }

        // Getter methods return the mobile account details
        public string getCompany()
        {
            return this.company;
        }

        public string getAccType()
        {
            return this.accType;
        }

        public string getDevice()
        {
            return this.device;
        }

        public string getNumber()
        {
            return this.number;
        }

        public string getBalance()
        {
            return this.balance.ToString("C");
        }

        // Setter methods update the mobile account details
        public void setCompany(string company)
        {
            this.company = company;
        }

        public void setAccType(string accType)
        {
            this.accType = accType;
        }

        public void setDevice(string device)
        {
            this.device = device;
        }

        public void setNumber(string number)
        {
            this.number = number;
        }

        public void setBalance(double balance)
        {
            this.balance = (decimal)balance;
        }

        // Adds credit to the current balance
        public void addCredit(double amount)
        {
            this.balance += (decimal)amount;
            Console.WriteLine("Credit added successfully. New balance: " + getBalance());
        }

        // Calculates the call cost and subtracts it from the balance
        public void makeCall(string company, int minutes)
        {
            for (int i = 0; i < mobileCompanies.Length; i++)
            {
                if (company == mobileCompanies[i])
                {
                    decimal cost = minutes * callCharges[i];
                    this.balance -= cost;
                }
            }

            Console.WriteLine("Call made. New balance: " + getBalance());
        }

        // Calculates the text cost and subtracts it from the balance
        public void sendText(string company, int numTexts)
        {
            for (int i = 0; i < mobileCompanies.Length; i++)
            {
                if (company == mobileCompanies[i])
                {
                    decimal cost = numTexts * textCharges[i];
                    this.balance -= cost;
                }
            }

            Console.WriteLine("Text sent. New balance: " + getBalance());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creates a new mobile account
        Mobile newMobile = new Mobile(
            "Tesco",
            "Monthly",
            "Samsung Galaxy S21",
            "07712223344"
        );

        // Displays the mobile account details
        Console.WriteLine("Mobile Details:");
        Console.WriteLine("Company: " + newMobile.getCompany());
        Console.WriteLine("Account Type: " + newMobile.getAccType());
        Console.WriteLine("Device: " + newMobile.getDevice());
        Console.WriteLine("Number: " + newMobile.getNumber());
        Console.WriteLine("Balance: " + newMobile.getBalance());
        Console.WriteLine();

        // Asks the user how much credit to add
        Console.Write("Enter top-up amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        newMobile.addCredit(amount);

        // Asks how many minutes the user wants to call
        Console.Write("Enter number of minutes to call: ");
        int minutes = Convert.ToInt32(Console.ReadLine());
        newMobile.makeCall(newMobile.getCompany(), minutes);

        // Asks how many texts the user wants to send
        Console.Write("Enter number of texts to send: ");
        int texts = Convert.ToInt32(Console.ReadLine());
        newMobile.sendText(newMobile.getCompany(), texts);

        // Keeps the window open so the user can read the results
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
