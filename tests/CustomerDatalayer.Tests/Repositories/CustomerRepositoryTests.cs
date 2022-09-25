using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using FluentAssertions;

namespace CustomerDatalayer.Tests.Repositories
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = new CustomerRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldImplementIRepository()
        {
            var repository = new CustomerRepository();
            repository.GetType().GetInterfaces().Should().Contain((typeof(IRepository<Customer>)));
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            var repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            createdCustomer.Should().NotBeNull();
            createdCustomer.FirstName.Should().Be(customer.FirstName);
            createdCustomer.LastName.Should().Be(customer.LastName);
            createdCustomer.PhoneNumber.Should().Be(customer.PhoneNumber);
            createdCustomer.Email.Should().Be(customer.Email);
            createdCustomer.TotalPurchasesAmount.Should().Be(customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            var repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);
            var readCustomer = repository.Read(createdCustomer.CustomerID);

            readCustomer.Should().NotBeNull();
            readCustomer.FirstName.Should().Be(customer.FirstName);
            readCustomer.LastName.Should().Be(customer.LastName);
            readCustomer.PhoneNumber.Should().Be(customer.PhoneNumber);
            readCustomer.Email.Should().Be(customer.Email);
            readCustomer.TotalPurchasesAmount.Should().Be(customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldNotBeAbleToReadCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            var repository = new CustomerRepository();
            var readCustomer = repository.Read(0);

            readCustomer.Should().BeNull();
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            var repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            createdCustomer.FirstName = "Garry";
            repository.Update(createdCustomer);

            var updatedCustomer = repository.Read(createdCustomer.CustomerID);

            updatedCustomer.Should().NotBeNull();
            updatedCustomer.FirstName.Should().Be("Garry");
            updatedCustomer.LastName.Should().Be(createdCustomer.LastName);
            updatedCustomer.PhoneNumber.Should().Be(createdCustomer.PhoneNumber);
            updatedCustomer.Email.Should().Be(createdCustomer.Email);
            updatedCustomer.TotalPurchasesAmount.Should().Be(createdCustomer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            var repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            var deletedRows = repository.Delete(createdCustomer.CustomerID);

            deletedRows.Should().Be(1);
        }
    }

    public static class CustomersRepositoryFixture
    {
        public static void DeleteAll()
        {
            var repository = new CustomerRepository();
            repository.DeleteAll();
        }

        public static Customer GetCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Harold",
                LastName = "Johnson",
                PhoneNumber = "+12673935933",
                Email = "HaroldSJohnson@armyspy.com",
                TotalPurchasesAmount = 0
            };

            return customer;
        }
    }
}
