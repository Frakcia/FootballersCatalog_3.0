﻿using System.Transactions;

namespace FootballersCatalog.Domain.Core.TransactionScopeFactory
{
    public static class TransactionScopeFactory
    {
        public static TransactionScope Serializable()
        {
            return new TransactionScope(
                TransactionScopeOption.RequiresNew,
                new TransactionOptions { IsolationLevel = IsolationLevel.Serializable });
        }
    }
}
