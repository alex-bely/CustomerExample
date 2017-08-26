using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExample
{
    public struct CustomerStruct : IEquatable<CustomerStruct>, IComparable<CustomerStruct>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerStruct(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object other)
        {
            if (other is CustomerStruct)
            {
                return this.Equals((CustomerStruct)other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id * 2 + FirstName.GetHashCode() * 3 + LastName.GetHashCode() * 4;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public bool Equals(CustomerStruct customer)
        {
            return Id == customer.Id;
        }

        public static bool operator ==(CustomerStruct lhs, CustomerStruct rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CustomerStruct lhs, CustomerStruct rhs)
        {
            return !(lhs.Equals(rhs));
        }

        public int CompareTo(CustomerStruct other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public int CompareTo(CustomerStruct other, Comparison<CustomerStruct> comparison)
        {
            return comparison(this, other);
        }

        public static bool operator >(CustomerStruct operand1, CustomerStruct operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }

        public static bool operator <(CustomerStruct operand1, CustomerStruct operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }
    }
}
