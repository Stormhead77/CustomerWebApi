﻿using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using FluentAssertions;

namespace CustomerDatalayer.Tests.Repositories
{
    public class AddressRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var repository = new AddressRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldImplementIRepository()
        {
            var repository = new AddressRepository();
            repository.GetType().GetInterfaces().Should().Contain((typeof(IRepository<Address>)));
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            AddressesRepositoryFixture.DeleteAll();

            var repository = new AddressRepository();

            var address = AddressesRepositoryFixture.GetAddress();

            var createdAddress = repository.Create(address);

            createdAddress.Should().NotBeNull();
            createdAddress.AddressLine.Should().Be(address.AddressLine);
            createdAddress.AddressLine2.Should().Be(address.AddressLine2);
            createdAddress.AddressType.Should().Be(address.AddressType);
            createdAddress.City.Should().Be(address.City);
            createdAddress.PostalCode.Should().Be(address.PostalCode);
            createdAddress.State.Should().Be(address.State);
            createdAddress.Country.Should().Be(address.Country);
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            AddressesRepositoryFixture.DeleteAll();

            var repository = new AddressRepository();

            var customer = AddressesRepositoryFixture.GetAddress();

            var createdAddress = repository.Create(customer);
            var readAddress = repository.Read(createdAddress.AddressID);

            readAddress.Should().NotBeNull();
            readAddress.AddressLine.Should().Be(customer.AddressLine);
            readAddress.AddressLine2.Should().Be(customer.AddressLine2);
            readAddress.AddressType.Should().Be(customer.AddressType);
            readAddress.City.Should().Be(customer.City);
            readAddress.PostalCode.Should().Be(customer.PostalCode);
            createdAddress.State.Should().Be(customer.State);
            createdAddress.Country.Should().Be(customer.Country);
        }

        [Fact]
        public void ShouldNotBeAbleToReadAddress()
        {
            AddressesRepositoryFixture.DeleteAll();

            var repository = new AddressRepository();
            var readAddress = repository.Read(0);

            readAddress.Should().BeNull();
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            AddressesRepositoryFixture.DeleteAll();

            var repository = new AddressRepository();

            var customer = AddressesRepositoryFixture.GetAddress();

            var createdAddress = repository.Create(customer);

            createdAddress.AddressLine = "addressLine";
            repository.Update(createdAddress);

            var updatedAddress = repository.Read(createdAddress.AddressID);

            updatedAddress.Should().NotBeNull();
            updatedAddress.AddressLine.Should().Be("addressLine");
            updatedAddress.AddressLine2.Should().Be(createdAddress.AddressLine2);
            updatedAddress.AddressType.Should().Be(createdAddress.AddressType);
            updatedAddress.City.Should().Be(createdAddress.City);
            updatedAddress.PostalCode.Should().Be(createdAddress.PostalCode);
            createdAddress.State.Should().Be(customer.State);
            createdAddress.Country.Should().Be(customer.Country);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            AddressesRepositoryFixture.DeleteAll();

            var repository = new AddressRepository();

            var customer = AddressesRepositoryFixture.GetAddress();

            var createdAddress = repository.Create(customer);

            var deletedRows = repository.Delete(createdAddress.AddressID);

            deletedRows.Should().Be(1);
        }

        [Fact]
        public void ShouldBeAbleToGetAddressesByCustomerId()
        {
            CustomersRepositoryFixture.DeleteAll();

            var address = AddressesRepositoryFixture.GetAddress();

            var repository = new AddressRepository();

            repository.Create(address);

            var list = repository.GetAddressesByCustomerId(address.CustomerID);

            list.Should().HaveCount(1);
        }
    }

    public static class AddressesRepositoryFixture
    {
        public static void DeleteAll()
        {
            var repository = new AddressRepository();
            repository.DeleteAll();
        }

        public static Address GetAddress()
        {
            //CustomersRepositoryFixture.DeleteAll();
            var repository = new CustomerRepository();
            var customer = CustomersRepositoryFixture.GetCustomer();
            var createdCustomer = repository.Create(customer);

            var address = new Address
            {
                CustomerID = createdCustomer.CustomerID,
                AddressLine = "4100 Holly Street",
                AddressLine2 = "4101 Holly Street",
                AddressType = "Billing",
                City = "Blue Ridge",
                PostalCode = "30513",
                State = "GA",
                Country = "United States"
            };

            return address;
        }
    }
}
