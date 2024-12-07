using System.Text.RegularExpressions; // required for Regex function
/// Hint: you can use Regex functions to check for non-numerical values into numerical tags like ItemNumber, AmountOrdered, etc.

namespace SimpleShop{
    public class InvoicePosition{
        public uint ItemIdentifier = 0;
        public string ItemName = "";
        public uint Orders = 0;
        public decimal SingleUnitPrice = 0.0m;
        public Customer Customer;

        public virtual decimal Price(){
            return this.Customer.CalculatePrice(this.SingleUnitPrice * Orders);
        }

        public static InvoicePosition CreateFromPairs(KeywordPair[] pairs){
            return null; 
        }
    }
}