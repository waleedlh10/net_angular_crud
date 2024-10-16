using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace back_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Date", "Description", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 1: User cannot log in", "Open" },
                    { 2, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 2: Payment issue", "Closed" },
                    { 3, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 3: Bug in the report generation", "Open" },
                    { 4, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 4: UI layout issue on mobile", "Open" },
                    { 5, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 5: Feature request for new dashboard", "Open" },
                    { 6, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 6: Email notifications not working", "Closed" },
                    { 7, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 7: Performance issues on data load", "Open" },
                    { 8, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 8: Incorrect data displayed on profile", "Open" },
                    { 9, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 9: Search functionality not returning results", "Closed" },
                    { 10, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 10: Session timeout issue", "Open" },
                    { 11, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 11: Feedback submission not working", "Open" },
                    { 12, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 12: Data export to CSV not functioning", "Closed" },
                    { 13, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 13: Mobile app crashes on startup", "Open" },
                    { 14, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 14: API response time is too slow", "Open" },
                    { 15, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 15: Data synchronization issue", "Closed" },
                    { 16, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 16: Calendar integration not working", "Open" },
                    { 17, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 17: User roles not updating correctly", "Open" },
                    { 18, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 18: Dashboard widget not loading", "Closed" },
                    { 19, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 19: Data visualization issue", "Open" },
                    { 20, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 20: User unable to reset password", "Open" },
                    { 21, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 21: Error message on checkout page", "Closed" },
                    { 22, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 22: Image upload feature not working", "Open" },
                    { 23, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 23: Browser compatibility issues", "Open" },
                    { 24, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 24: Report filtering not functioning", "Closed" },
                    { 25, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 25: Incorrect invoice amount", "Open" },
                    { 26, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 26: Payment method not accepted", "Open" },
                    { 27, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 27: Notifications not being sent", "Closed" },
                    { 28, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 28: Website loading issues", "Open" },
                    { 29, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 29: Account settings not saving", "Open" },
                    { 30, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticket 30: Language settings not working", "Closed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 30);
        }
    }
}
