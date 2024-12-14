using System.Text.RegularExpressions; // required for Regex function
/// Hint: you can use Regex functions to check for non-numerical values into numerical tags like ItemNumber, AmountOrdered, etc.

namespace SimpleShop
{
    public class InvoicePosition
    {
        public uint ItemIdentifier = 0;
        public string ItemName = "";
        public uint Orders = 0;
        public decimal SingleUnitPrice = 0.0m;
        public Customer Customer;

        public virtual decimal Price()
        {
            return this.Customer.CalculatePrice(this.SingleUnitPrice * Orders);
        }

        public static InvoicePosition CreateFromPairs(KeywordPair[] pairs)
        {
            var position = new InvoicePosition();
            position.Customer = new Customer();
            foreach (var pair in pairs)
            {
                var keywordStr = pair.Key.GetString();
                if (keywordStr == "CustomerType")
                {
                    if (pair.Value == "Company")
                    {
                        position.Customer = new Company();
                    }
                    else if (pair.Value == "Student")
                    {
                        position.Customer = new Student();
                    }
                }
                else if (keywordStr.Equals("ItemNumber"))
                {
                    position.ItemIdentifier = uint.Parse(pair.Value);
                }
                else if (keywordStr.Equals("CustomerName"))
                {
                    position.Customer.Name = pair.Value;
                }
                else if (keywordStr.Equals("ItemName"))
                {
                    position.ItemName = pair.Value;
                }
                else if (keywordStr.Equals("AmountOrdered"))
                {
                    if (uint.TryParse(pair.Value, out uint amount))
                    {
                        position.Orders = amount;
                    }
                    else
                    {
                        foreach (var ch in pair.Value)
                        {
                            if (uint.TryParse(ch.ToString(), out uint amount1))
                            {
                                position.Orders = amount1;
                                break;
                            }
                        }
                    }
                }
                else if (keywordStr.Equals("NetPrice"))
                {
                    if (decimal.TryParse(pair.Value, out decimal price))
                    {
                        position.SingleUnitPrice = price;
                    }
                    else
                    {
                        position.SingleUnitPrice = decimal.Parse(pair.Value.Replace("%&öä/", ""));
                    }
                }
            }

            return position;
        }
    }
}