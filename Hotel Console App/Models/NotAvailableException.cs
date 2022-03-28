using System;

namespace Hotel_Console_App.Models
{
    public class NotAvailableException: Exception
    {
        public NotAvailableException() {}

        public NotAvailableException(string message):base(message) {}
    }
}