using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExample
{
    public class Customer : IEquatable<Customer>, IComparable<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as Customer);
        }

        public override int GetHashCode()
        {
            return this.Id * 2 + FirstName.GetHashCode() * 3 + LastName.GetHashCode() * 4;

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public bool Equals(Customer other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.Id == other.Id;
        }

        public static bool operator ==(Customer lhs, Customer rhs)
        {

            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Customer lhs, Customer rhs)
        {
            return !(lhs == rhs);
        }

        public int CompareTo(Customer other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }

        public int CompareTo(Customer other, Comparison<Customer> comparison)
        {
            if (other == null) return 1;
            return comparison(this, other);
        }

        public static bool operator >(Customer operand1, Customer operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }

        public static bool operator <(Customer operand1, Customer operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }
    }
}
