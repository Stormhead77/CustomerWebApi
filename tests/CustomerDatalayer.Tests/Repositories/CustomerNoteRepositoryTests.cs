using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using CustomerDatalayer.Tests.Entities;
using FluentAssertions;

namespace CustomerDatalayer.Tests.Repositories
{
    public class CustomerNoteRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerNoteRepository()
        {
            CustomerNoteRepository repository = new CustomerNoteRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldImplementIRepository()
        {
            CustomerNoteRepository repository = new CustomerNoteRepository();
            repository.GetType().GetInterfaces().Should().Contain((typeof(IRepository<CustomerNote>)));
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomerNote()
        {
            CustomerNotesRepositoryFixture.DeleteAll();

            CustomerNoteRepository repository = new CustomerNoteRepository();

            var note = CustomerNotesRepositoryFixture.GetCustomerNote();

            var createdNote = repository.Create(note);

            createdNote.Should().NotBeNull();
            createdNote.CustomerID.Should().Be(note.CustomerID);
            createdNote.NoteText.Should().Be(note.NoteText);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomerNote()
        {
            CustomerNotesRepositoryFixture.DeleteAll();

            CustomerNoteRepository repository = new CustomerNoteRepository();

            var note = CustomerNotesRepositoryFixture.GetCustomerNote();

            var createdNote = repository.Create(note);
            var readNote = repository.Read(createdNote.CustomerID);

            readNote.Should().NotBeNull();
            createdNote.CustomerID.Should().Be(note.CustomerID);
            createdNote.NoteText.Should().Be(note.NoteText);
        }

        [Fact]
        public void ShouldNotBeAbleToReadCustomerNote()
        {
            CustomerNotesRepositoryFixture.DeleteAll();

            CustomerNoteRepository repository = new CustomerNoteRepository();
            var readNote = repository.Read(0);

            readNote.Should().BeNull();
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomerNote()
        {
            CustomerNotesRepositoryFixture.DeleteAll();

            CustomerNoteRepository repository = new CustomerNoteRepository();

            var note = CustomerNotesRepositoryFixture.GetCustomerNote();

            var createdNote = repository.Create(note);

            createdNote.NoteText = "addressLine";
            repository.Update(createdNote);

            var updatedNote = repository.Read(createdNote.CustomerID);

            updatedNote.Should().NotBeNull();
            createdNote.CustomerID.Should().Be(note.CustomerID);
            createdNote.NoteText.Should().Be("addressLine");
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomerNote()
        {
            CustomerNotesRepositoryFixture.DeleteAll();

            CustomerNoteRepository repository = new CustomerNoteRepository();

            var customer = CustomerNotesRepositoryFixture.GetCustomerNote();

            var createdNote = repository.Create(customer);

            int deletedRows = repository.Delete(createdNote.CustomerID);

            deletedRows.Should().Be(1);
        }
    }

    public static class CustomerNotesRepositoryFixture
    {
        public static void DeleteAll()
        {
            CustomerNoteRepository repository = new CustomerNoteRepository();
            repository.DeleteAll();
        }

        public static CustomerNote GetCustomerNote()
        {
            //CustomersRepositoryFixture.DeleteAll();
            CustomerRepository repository = new CustomerRepository();
            var customer = CustomersRepositoryFixture.GetCustomer();
            var createdCustomer = repository.Create(customer);

            var address = new CustomerNote
            {
                CustomerID = createdCustomer.CustomerID,
                NoteText = "text"
            };

            return address;
        }
    }
}
