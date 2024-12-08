namespace SimpleShop{

    public class Company : Customer
    {
        public override decimal CalculatePrice(decimal basePrice){
            return basePrice;
        }
    }

    public class Student : Customer
    {
        public override decimal CalculatePrice(decimal basePrice){
            return (1 + ValueAddedTax) *(basePrice-((decimal)0.2 * basePrice));
        }
    }
    
    public class Customer{
        public const decimal ValueAddedTax = 0.19m;
        public string Name = "";
        public virtual decimal CalculatePrice(decimal basePrice){
            return (1 + ValueAddedTax) * basePrice;
        }

        public static Customer CreateCustomer(string name, string customerType=""){
            if (customerType == "Company")
            {
                Company customer = new Company();
                customer.Name = name;
                return customer;
            }
            else if (customerType == "Student")
            {
                Student customer = new Student();
                customer.Name = name;
                return customer; 
            }
            
            Customer customer1 = new Customer();
            customer1.Name = name;
            return customer1;
            
        }
    }
}