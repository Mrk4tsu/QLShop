﻿using System;
using Users.Data.Entities.Enums;

namespace Users.Data.Entities
{
    public class Transaction
    {
        public int Id { set; get; }
        public DateTime TransactionDate { set; get; }
        public string ExternalTransactionId { set; get; }
        public decimal Amount { set; get; }
        public decimal Fee { set; get; }
        public string Result { set; get; }
        public string Message { set; get; }
        public TransactionStatus Status { set; get; }
        public int Provider { set; get; }
        public Guid UserID { set; get; }
        public AppUsers AppUsers { set; get; }
    }
}
