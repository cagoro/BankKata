namespace BankKata
{
    public class Transaction
    {
        public int Amount { get; private set; }

        public string Date { get; private set; }
    

        public Transaction(int amount, string date)
        {
            Amount = amount;
            Date = date;
        }

        protected bool Equals(Transaction other)
        {
            return Amount == other.Amount && string.Equals(Date, other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount * 397) ^ Date.GetHashCode();
            }
        }

        public static bool operator ==(Transaction left, Transaction right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Transaction left, Transaction right)
        {
            return !Equals(left, right);
        }
    }
}