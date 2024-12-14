using NUnit.Framework;
using SimpleShop;

// Remember [UnitOfWork_StateUnderTest_ExpectedBehaviour]

namespace SimpleShop.Test
{
    public class Tests
    {
        private KeywordPair[] validKeywordPars;
        private KeywordPair[] invalidRepitedKeywordPars;
        private KeywordPair[] invalidCicularKeywordPars;

        [SetUp]
        public void Setup()
        {
            this.validKeywordPars = new KeywordPair[]
            {
                new KeywordPair(new Keyword("ItemNumber"), ""),
                new KeywordPair(new Keyword("ItemName"), ""),
                new KeywordPair(new Keyword("CustomerName"), ""),
                new KeywordPair(new Keyword("AmountOrdered"), ""),
                new KeywordPair(new Keyword("NetPrice"), ""),
            };

            this.invalidRepitedKeywordPars = new KeywordPair[]
            {
                new KeywordPair(new Keyword("ItemNumber"), ""),
                new KeywordPair(new Keyword("ItemNumber"), ""),
                new KeywordPair(new Keyword("ItemNumber"), ""),
                new KeywordPair(new Keyword("AmountOrdered"), ""),
                new KeywordPair(new Keyword("NetPrice"), ""),
            };

            this.invalidCicularKeywordPars = new KeywordPair[]
            {
                new KeywordPair(new Keyword("ItemNumber"), ""),
                new KeywordPair(new Keyword("ItemName"), ""),
                new KeywordPair(new Keyword("CustomerName"), ""),
                new KeywordPair(new Keyword("AmountOrdered"), ""),
                new KeywordPair(new Keyword("NetPrice"), ""),
                new KeywordPair(new Keyword("ItemNumber"), ""),
            };
        }

        /// <summary>
        /// Check if the Keyword opening is modified with added <Keyword> when using the appropriate method from the class
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Keyword")]
        public void Parsing_KeywordStartTag_AddedBraces()
        {
            const string keywordText = "hasan";
            var keyword = new Keyword(keywordText);
            const string expectedOpening = "<" + keywordText + ">";
            var opening = keyword.GetStart();
            Assert.AreEqual(expectedOpening, opening);
        }

        /// <summary>
        /// Check if the Keyword closing is modified with added </Keyword> when using the appropriate method from the class
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Keyword")]
        public void Parsing_KeywordEndTag_AddedSlashAndBraces()
        {
            const string keywordText = "hasan";
            var keyword = new Keyword(keywordText);
            const string expectedClosing = "</" + keywordText + ">";
            var closing = keyword.GetStart();
            Assert.AreEqual(expectedClosing, closing);
        }

        /// <summary>
        /// Set the Keywords and check if they are valid. Construct one valid and one invalid list of keywords and test accordingly.
        /// Rating 1
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_SetKeywords_OrderOfKeywordsIsCorrect()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Set the Keyword types and check if they are valid.
        /// Rating 1
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void ShopParser_SetKeyword_Type()
        {
            const string keywordText = "hasan";
            var keyword = new Keyword(keywordText, KeywordTypes.Decimal);
            Assert.AreEqual(keyword.WhichType(), KeywordTypes.Decimal);

            keyword = new Keyword(keywordText, KeywordTypes.Int);
            Assert.AreEqual(keyword.WhichType(), KeywordTypes.Int);

            keyword = new Keyword(keywordText);
            Assert.AreEqual(keyword.WhichType(), KeywordTypes.String);
        }


        /// <summary>
        /// Check if the parser works correctly. Make examples and see if you can find problems with the code.
        /// Literals represent KeywordPairs with different Keywords
        /// A B C D
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_ValidFindings_True()
        {
            Assert.IsTrue(ShopParser.ValidateFindings(validKeywordPars));
        }

        /// <summary>
        /// Check if the parser works correctly. This time you should check if repetition invalidates the findings. Hint: you can construct your own 'incorrect' tag file for testing.
        /// A A B B C C
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_InvalidatedFindingsWithRepeatedEntry_False()
        {
            Assert.IsFalse(ShopParser.ValidateFindings(invalidRepitedKeywordPars));
        }

        /// <summary>
        /// Check if the parser works correctly. This time with circular keywords.
        /// A B C A
        /// Rating 3
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_InvalidatedFindingsCircular_False()
        {
            Assert.IsFalse(ShopParser.ValidateFindings(invalidCicularKeywordPars));
        }

        /// <summary>
        /// See Tagfile (SampleOrder.tag) for more information. Are the correct number of keywords recognized ? 
        /// Rating 1
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_KeywordsSetTagString_CorrectNumberOfEntries()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Again consult the Tagfile for more information. The parsing should follow the order of the keywords you provided.
        /// Make sure to make it adaptable to different configurations.
        /// Rating 2
        /// </summary>
        [Test]
        [Category("ShopParser")]
        public void Parsing_KeywordsSetTagString_ListOfProvidedTagsInOrder()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test if the VAT is calculated correctly for the Customer.CalculatePrice
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Customer")]
        public void Invoice_CalculateNormalCustomer_AddValueAddedTax()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test if the function CreateCustomer returns a customer
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Customer")]
        public void Invoice_CreateCustomer_ReturnsCustomer()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test if the InvoicePosition.Price calculates correctly:
        /// Provided Orders, NetPrice is set.
        /// Rating 1
        /// </summary>
        [Test]
        [Category("Invoice")]
        public void Invoice_OrdersAndNetPriceValid_CalculateCorrectPrice()
        {
            Assert.Fail();
        }
    }
}