using CustomerDatalayer.Entities;

namespace CustomerDatalayer.Tests.Entities
{
    public class CustomerNoteTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerNote()
        {
            var note = new CustomerNote
            {
                CustomerID = 1,
                NoteText = "text"
            };

            Assert.NotNull(note);
            Assert.Equal(1, note.CustomerID);
            Assert.Equal("text", note.NoteText);
        }
    }
}
