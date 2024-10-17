using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using back_api.Controllers;
using back_api.Data;
using back_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_api.Tests.Controllers
{
    public class TicketControllerTests
    {


        [Fact]
        public async Task GetTickets_ReturnsBadRequest_WhenItemsPerPageIsLessThanOne()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "TicketTestDb1")
                .Options;

            using var context = new TicketContext(options);
            var controller = new TicketController(context);

            // Act
            var result = await controller.GetTickets(page: 1, items_per_page: 0);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Ticket>>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal("items_per_page must be between 1 and 100.", badRequestResult.Value);
        }


        [Fact]
        public async Task GetTickets_ReturnsBadRequest_WhenItemsPerPageIsGreaterThanOneHundred()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "TicketTestDb2")
                .Options;

            using var context = new TicketContext(options);
            var controller = new TicketController(context);

            // Act
            var result = await controller.GetTickets(page: 1, items_per_page: 101);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Ticket>>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal("items_per_page must be between 1 and 100.", badRequestResult.Value);
        }


        [Fact]
        public async Task GetTicket_ReturnsTicket_WhenTicketExists()
        {
            // Arrange: Create the in-memory database and context
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "TicketTestDb1")
                .Options;

            using var context = new TicketContext(options);
            var controller = new TicketController(context);

            // Add a test ticket to the in-memory database
            var testTicket = new Ticket { TicketId = 1, Description = "Test ticket", Status = "Open", Date = DateTime.Now };
            context.Tickets.Add(testTicket);
            await context.SaveChangesAsync();

            // Act: Call the GetTicket method
            var result = await controller.GetTicket(1);

            // Assert: Verify that the result is a ticket and matches the expected values
            var actionResult = Assert.IsType<ActionResult<Ticket>>(result);
            var okResult = Assert.IsType<Ticket>(actionResult.Value);
            Assert.Equal(testTicket.TicketId, okResult.TicketId);
            Assert.Equal(testTicket.Description, okResult.Description);
            Assert.Equal(testTicket.Status, okResult.Status);
        }

        [Fact]
        public async Task GetTicket_ReturnsNotFound_WhenTicketDoesNotExist()
        {
            // Arrange: Create the in-memory database and context
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "TicketTestDb2")
                .Options;

            using var context = new TicketContext(options);
            var controller = new TicketController(context);

            // Act: Call the GetTicket method for a non-existent ticket ID
            var result = await controller.GetTicket(99); // Assuming this ID does not exist

            // Assert: Verify that the result is a NotFound response
            var actionResult = Assert.IsType<ActionResult<Ticket>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task CreateTicket_ReturnsCreatedAtAction_WhenTicketIsCreatedSuccessfully()
        {
            // Arrange: Create an in-memory database context
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "CreateTicketTestDb")
                .Options;

            using (var context = new TicketContext(options))
            {
                var controller = new TicketController(context);

                // Create a new ticket object
                var newTicket = new Ticket { TicketId = 1, Description = "New Ticket", Status = "Open", Date = DateTime.Now };

                // Act: Call the CreateTicket method
                var result = await controller.CreateTicket(newTicket);

                // Assert: Check if the result is CreatedAtAction
                var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);

                // Check if the route name and route values are correct
                Assert.Equal(nameof(controller.GetTicket), createdResult.ActionName);
                Assert.Equal(1, createdResult.RouteValues["id"]);

                // Verify that the ticket returned in the result is the same as the one created
                var createdTicket = Assert.IsType<Ticket>(createdResult.Value);
                Assert.Equal(newTicket.TicketId, createdTicket.TicketId);
                Assert.Equal(newTicket.Description, createdTicket.Description);
                Assert.Equal(newTicket.Status, createdTicket.Status);

                // Verify that the ticket is actually saved in the database
                var ticketInDb = await context.Tickets.FindAsync(1);
                Assert.NotNull(ticketInDb);
                Assert.Equal("New Ticket", ticketInDb.Description);
                Assert.Equal("Open", ticketInDb.Status);
            }
        }

        [Fact]
        public async Task UpdateTicket_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            // Arrange: Create an in-memory database context
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "UpdateTicketSuccessTestDb")
                .Options;

            using (var context = new TicketContext(options))
            {
                // Seed the database with a test ticket
                context.Tickets.Add(new Ticket { TicketId = 1, Description = "Initial Ticket", Status = "Open" });
                await context.SaveChangesAsync();

                var controller = new TicketController(context);

                // Create an updated ticket instance
                var updatedTicket = new Ticket { TicketId = 1, Description = "Updated Ticket", Status = "Closed" };

                // Detach the original entity to avoid tracking conflicts
                var originalTicket = await context.Tickets.FindAsync(1);
                context.Entry(originalTicket).State = EntityState.Detached;  // Detaching the original entity

                // Act: Call the UpdateTicket method
                var result = await controller.UpdateTicket(1, updatedTicket);

                // Assert: Check if the result is NoContent
                Assert.IsType<NoContentResult>(result);

                // Verify that the ticket was updated
                var ticket = await context.Tickets.FindAsync(1);
                Assert.Equal("Updated Ticket", ticket.Description);
                Assert.Equal("Closed", ticket.Status);
            }
        }

        [Fact]
        public async Task UpdateTicket_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange: Create an in-memory database context
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "UpdateTicketIdMismatchTestDb")
                .Options;

            using (var context = new TicketContext(options))
            {
                // Seed the database with a test ticket
                context.Tickets.Add(new Ticket { TicketId = 1, Description = "Initial Ticket", Status = "Open" });
                await context.SaveChangesAsync();

                var controller = new TicketController(context);
                var updatedTicket = new Ticket { TicketId = 2, Description = "Updated Ticket", Status = "Closed" }; // Mismatched ID

                // Act: Call the UpdateTicket method
                var result = await controller.UpdateTicket(1, updatedTicket); // ID mismatch

                // Assert: Check if the result is BadRequest
                Assert.IsType<BadRequestResult>(result);
            }
        }

        [Fact]
        public async Task DeleteTicket_ReturnsNoContent_WhenTicketIsDeleted()
        {
            // Arrange: Set up an in-memory database
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "DeleteTicketDb")
                .Options;

            using (var context = new TicketContext(options))
            {
                // Seed the database with a test ticket
                var ticket = new Ticket { TicketId = 1, Description = "Test Ticket", Status = "Open" };
                context.Tickets.Add(ticket);
                await context.SaveChangesAsync();

                var controller = new TicketController(context);

                // Act: Call the DeleteTicket method
                var result = await controller.DeleteTicket(1);

                // Assert: Check that the result is NoContent and the ticket is deleted
                Assert.IsType<NoContentResult>(result);
                Assert.Null(await context.Tickets.FindAsync(1)); // Check that the ticket no longer exists
            }
        }

       [Fact]
        public async Task DeleteTicket_ReturnsNotFound_WhenTicketDoesNotExist()
        {
            // Arrange: Set up an in-memory database
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(databaseName: "DeleteTicketNotFoundDb")
                .Options;

            using (var context = new TicketContext(options))
            {
                var controller = new TicketController(context);

                // Act: Call the DeleteTicket method with a non-existent ticket ID
                var result = await controller.DeleteTicket(999); // ID 999 does not exist

                // Assert: Check that the result is NotFound
                Assert.IsType<NotFoundResult>(result);
            }
        }

    }


}
