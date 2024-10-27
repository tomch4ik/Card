using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Card.town;

namespace Card
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            try
            {
                TownPopulation info1 = new TownPopulation("Odesa", 1000000);
                TownPopulation info2 = new TownPopulation("Kyiv", 3500000);
                info1 += 35000;
                info2 -= 50000;
                Console.WriteLine(info1);
                Console.WriteLine(info2);
                Console.WriteLine(info1 == info2);
                Console.WriteLine(info1 > info2);
                Console.WriteLine(info1 != info2);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
    internal class town
    {
        public class TownPopulation
        {
            public string Town { get; private set; }
            public long Population { get; private set; }
            public TownPopulation(string town, long population)
            {
                if (string.IsNullOrWhiteSpace(town))
                {
                    throw new ArgumentException("Поле ввода не может быть пустым");
                }
                if (population < 0)
                {
                    throw new ArgumentException("Население не может быть отрицательным");
                }
                Town = town;
                Population = population;
            }
            public static TownPopulation operator +(TownPopulation info, int sum)
            {
                info.Population += sum;
                return info;
            }
            public static TownPopulation operator -(TownPopulation info, int sum)
            {
                if (info.Population >= sum)
                {
                    info.Population -= sum;
                }
                else
                {
                    throw new ArgumentException("Недостаточно населения");
                }
                return info;
            }
            public static bool operator ==(TownPopulation info1, TownPopulation info2)
            {
                if (ReferenceEquals(info1, info2))
                    return true;

                if ((object)info1 == null || (object)info2 == null)
                    return false;

                return info1.Population == info2.Population;
            }
            public static bool operator !=(TownPopulation info1, TownPopulation info2)
            {
                return !(info1 == info2);
            }
            public static bool operator <(TownPopulation info1, TownPopulation info2)
            {
                return info1.Population < info2.Population;
            }
            public static bool operator >(TownPopulation info1, TownPopulation info2)
            {
                return info1.Population > info2.Population;
            }
            public override string ToString()
            {
                return $"Название города: {Town}, Население: {Population}.";
            }
            public override bool Equals(object obj)
            {
                if (obj == null || obj.GetType() != typeof(TownPopulation))
                {
                    return false;
                }
                TownPopulation info = (TownPopulation)obj;
                return Population == info.Population;
            }
            public override int GetHashCode()
            {
                return Population.GetHashCode();
            }
        }
    }
}

