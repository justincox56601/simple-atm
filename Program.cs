using System;


namespace ATM
{
    class CardHolder
    {
        String cardNum;
        int pin;
        String firstName;
        String lastName;
        double balance;

        public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public string getCardNum() { return cardNum; }
        public int getPin() { return pin; }
        public String getFirstName() { return firstName; }
        public String getLastName() { return lastName; }
        public double getBalance() { return balance; }

        public void setCardNum(string cardNum)
        {
            this.cardNum = cardNum;
        }

        public void setPin(int pin) { this.pin = pin; }

        public void setFirstName(String firstName) { this.firstName = firstName; }
        public void setLastName(String lastName) { this.lastName = lastName; }
        public void setBalance(double balance) { this.balance = balance; }

    }

    class Atm
    {

        public void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1: Deposit");
            Console.WriteLine("2: Withdraw");
            Console.WriteLine("3: Show Balance");
            Console.WriteLine("4: Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit?");
            double amount = Double.Parse(Console.ReadLine());
            currentUser.setBalance(amount + currentUser.getBalance());
            Console.WriteLine("Thank you, your new balance is: $" + currentUser.getBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?");
            double amount = Double.Parse(Console.ReadLine());
            if(currentUser.getBalance() > amount)
            {
                currentUser.setBalance(currentUser.getBalance() - amount);
                Console.WriteLine("Success!  Your new balance is: $" + currentUser.getBalance());
            }
            else
            {
                Console.WriteLine("Insufficient Funds.  Your balance is: $" + currentUser.getBalance());
            }
        }

        void showBalance(CardHolder currentUser)
        {
            Console.WriteLine("Your balance is: $" + currentUser.getBalance());
        }

        public static void Main(String[] args)
        {
            Atm atm = new Atm();
            string cardNumber = "";
            int userPin = 0;
            int selection = 0;
            CardHolder currentUser;

            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder("4532772818527395", 1234, "John", "Smith", 150.31));
            cardHolders.Add(new CardHolder("4532772818527386", 4567, "Ashley", "Griffen", 321.56));
            cardHolders.Add(new CardHolder("4532772811527345", 1111, "Frida", "Dickerson", 1200.44));
            cardHolders.Add(new CardHolder("4532772818525309", 0000, "Dawn", "harding", 21954.65));
            Console.WriteLine(cardHolders.Count);


            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("Please enter your card number");
            while (true)
            {
                try
                {
                    cardNumber = Console.ReadLine();
                    currentUser = cardHolders.Find(a => a.getCardNum() == cardNumber);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Card number not recognized. Please try again");
                    }
                }
                catch {
                    Console.WriteLine("Card number not recognized. Please try again");
                }
            }

            Console.WriteLine("Please enter your pin");
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if(currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect pin number.  Please try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect pin number.  Please try again");
                }
            }

            do
            {
                Console.WriteLine("Hello, " + currentUser.getFirstName() + " please choose and option");
                atm.printOptions();
                
                try { 
                    selection = int.Parse(Console.ReadLine());

                    switch (selection)
                    {
                        case 1: 
                            atm.deposit(currentUser);
                            break;
                        case 2:
                            atm.withdraw(currentUser);
                            break;
                        case 3:
                            atm.showBalance(currentUser);
                            break;
                        case 4:
                            break;

                    }
                }catch { }
            }
            while (selection != 4);

            Console.WriteLine("Thank you, have a great day");
        }
    }
    
}

