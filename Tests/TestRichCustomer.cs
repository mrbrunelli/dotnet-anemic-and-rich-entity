using AnemicAndRichEntity;
using FluentAssertions;

namespace Tests
{
    public class RichCustomerTests
    {
        private const string LongString170 = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

        [Fact]
        public void Constructor_ValidParameters_CreatesCustomer()
        {
            // Arrange
            int id = 1;
            string name = "John Doe";
            string address = "123 Main St";

            // Act
            var customer = new RichCustomer(id, name, address);

            // Assert
            customer.Id.Should().Be(id);
            customer.Name.Should().Be(name);
            customer.Address.Should().Be(address);
        }

        [Theory]
        [InlineData(-1, "John Doe", "123 Main St")]
        [InlineData(1, "", "123 Main St")]
        [InlineData(1, "John", "")]
        [InlineData(1, LongString170, "123 Main St")]
        public void Constructor_InvalidParameters_ThrowsException(int id, string name, string address)
        {
            // Act and Assert
            Action act = () => new RichCustomer(id, name, address);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Update_ValidParameters_UpdatesCustomer()
        {
            // Arrange
            var customer = new RichCustomer(1, "John Doe", "123 Main St");
            int newId = 2;
            string newName = "Jane Doe";
            string newAddress = "456 Elm St";

            // Act
            customer.Update(newId, newName, newAddress);

            // Assert
            customer.Id.Should().Be(newId);
            customer.Name.Should().Be(newName);
            customer.Address.Should().Be(newAddress);
        }

        [Theory]
        [InlineData(-1, "John Doe", "123 Main St")]
        [InlineData(1, "", "123 Main St")]
        [InlineData(1, "John", "")]
        [InlineData(1, LongString170, "123 Main St")]
        public void Update_InvalidParameters_ThrowsException(int id, string name, string address)
        {
            // Arrange
            var customer = new RichCustomer(1, "John Doe", "123 Main St");

            // Act and Assert
            Action act = () => customer.Update(id, name, address);
            act.Should().Throw<ArgumentException>();
        }
    }
}
