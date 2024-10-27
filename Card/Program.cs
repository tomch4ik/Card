using System;

namespace Card
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CreditCard card1 = new CreditCard(1234123412341234, "Мирный Александер", 123, new DateTime(2024, 12, 31), 10000);
                CreditCard card2 = new CreditCard(5678567856785678, "Белый Николай", 456, new DateTime(2026, 10, 23), 7000);
                card1 += 3500;  
                card2 -= 5000;  
                Console.WriteLine(card1);
                Console.WriteLine(card2);
                Console.WriteLine(card1 == card2);  
                Console.WriteLine(card1 > card2); 
                Console.WriteLine(card1 != card2); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
    public class CreditCard
    {
        public long CardNumber { get; private set; }
        public string Person { get; private set; }
        public int CVC { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Balance { get; private set; }
        public CreditCard(long cardNumber, string person, int cvc, DateTime endDate, int balance)
        {
            if (!IsValidCardNumber(cardNumber))
            {
                throw new ArgumentException("Неправильный номер карты");
            }
            if (string.IsNullOrWhiteSpace(person))
            {
                throw new ArgumentException("Некорректное ФИО владельца");
            }
            if (!IsValidCVC(cvc))
            {
                throw new ArgumentException("Неправильное CVC");
            }
            if (endDate < DateTime.Now)
            {
                throw new ArgumentException("Просроченная карта");
            }
            CardNumber = cardNumber;
            Person = person;
            CVC = cvc;
            EndDate = endDate;
            Balance = balance;
        }
        private bool IsValidCardNumber(long cardNumber)
        {
            return cardNumber.ToString().Length == 16;
        }
        private bool IsValidCVC(int cvc)
        {
            return cvc.ToString().Length == 3;
        }
        public static CreditCard operator +(CreditCard card, int sum)
        {
            card.Balance += sum;
            return card;
        }
        public static CreditCard operator -(CreditCard card, int sum)
        {
            if (card.Balance >= sum)
            {
                card.Balance -= sum;
            }
            else
            {
                throw new ArgumentException("Недостаточно денег на карте");
            }
            return card;
        }
        public static bool operator ==(CreditCard card1, CreditCard card2)
        {
            if (ReferenceEquals(card1, card2))
                return true;

            if ((object)card1 == null || (object)card2 == null)
                return false;

            return card1.CVC == card2.CVC;
        }
        public static bool operator !=(CreditCard card1, CreditCard card2)
        {
            return !(card1 == card2);
        }
        public static bool operator <(CreditCard card1, CreditCard card2)
        {
            return card1.Balance < card2.Balance;
        }
        public static bool operator >(CreditCard card1, CreditCard card2)
        {
            return card1.Balance > card2.Balance;
        }
        public override string ToString()
        {
            return $"Номер карты: {CardNumber}, Владелец: {Person}, Баланс: {Balance} грн.";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(CreditCard))
            {
                return false;
            }
            CreditCard card = (CreditCard)obj;
            return CardNumber == card.CardNumber && CVC == card.CVC;
        }
        public override int GetHashCode()
        {
            return CardNumber.GetHashCode();
        }
    }
}






