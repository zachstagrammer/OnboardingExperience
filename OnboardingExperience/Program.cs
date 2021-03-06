﻿using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;

namespace OnboardingExperience
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();

            Console.WriteLine("Hello! Welcome to the Onboarding Experience");

            user.FirstName = AskQuestion("What is your first name?");
            Console.WriteLine("Awesome, your first name is: " + user.FirstName);

            user.LastName = AskQuestion("What is your last name?");
            Console.WriteLine("Excellent! Your full name is: " + user.FirstName + " " + user.LastName);

            user.AType = AType("What type of account are you trying to access? Options: Checking, Savings, or Business");
            Console.WriteLine("You are have requested access for the " + user.AType + " account");

            user.IsAccountOwner = AskBoolQuestion("Are you the account owner? ");

            user.PinNumber = AskPinNumber("What is your 4-digit pin number:", 4);
            Console.WriteLine("Awesome! Your new 4-digit PIN is: " + user.PinNumber);

            Console.WriteLine();
            Console.WriteLine("Press \"Enter\" to quit application");

            Console.ReadLine();
        }

        static string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        static bool AskBoolQuestion(string question)
        {
            var isAccountOwner = false;

            while (!isAccountOwner)
            {
                var response = AskQuestion(question + "(y/n)");
                
                if (response == "y")
                {
                    isAccountOwner = true;
                    Console.WriteLine("Welcome! You are the account owner.");
                }
                else if (response == "n")
                {
                    Console.WriteLine("You must be the account owner to continue ");
                }
            }

            return isAccountOwner;

        }

        public static AccountType AType(string question)
        {
            AccountType? aType = null;

            while (aType == null)
            {
                var response = AskQuestion(question);

                if (Enum.TryParse(response, out AccountType actualType))
                {
                    aType = actualType;
                }
                else
                {
                    Console.Write("Not a valid input. ");
                }
            }

            return (AccountType)aType;

        }

        static string AskPinNumber(string question, int length)
        {
            string numString = null;

            while (numString == null)
            {
                var response = AskQuestion(question);

                if (response.Length == length && Int32.TryParse(response, out int _))
                {
                    numString = response;
                }
            }

            return numString;

        }
    }
}
