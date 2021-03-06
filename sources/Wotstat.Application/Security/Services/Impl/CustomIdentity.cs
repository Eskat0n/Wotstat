﻿namespace Wotstat.Application.Security.Services.Impl
{
    using System;
    using System.Security.Principal;

    [Serializable]
    public class CustomIdentity: MarshalByRefObject, IIdentity
    {
        private readonly AccountEntry _accountEntry;

        public CustomIdentity(AccountEntry accountEntry, string name)
        {
            Name = name;
            _accountEntry = accountEntry;
        }

        private string Token
        {
            get { return _accountEntry.Token; }
        }

        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return Token !=null; }
        }
    }
}