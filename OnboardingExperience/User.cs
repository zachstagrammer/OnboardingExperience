﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingExperience

{
    public enum AccountType
    {
        Checking,
        Savings,
        Business
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAccountOwner { get; set; }
        public string PinNumber { get; set; }
        public int AccountNumber { get; set; }
        public string EmailAddress { get; set; }
        public AccountType AType { get; set; }
    }
}