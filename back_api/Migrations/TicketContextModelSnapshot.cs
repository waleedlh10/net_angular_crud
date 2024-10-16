﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back_api.Data;

#nullable disable

namespace back_api.Migrations
{
    [DbContext(typeof(TicketContext))]
    partial class TicketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("back_api.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            Date = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 1: User cannot log in",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 2,
                            Date = new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 2: Payment issue",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 3,
                            Date = new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 3: Bug in the report generation",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 4,
                            Date = new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 4: UI layout issue on mobile",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 5,
                            Date = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 5: Feature request for new dashboard",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 6,
                            Date = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 6: Email notifications not working",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 7,
                            Date = new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 7: Performance issues on data load",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 8,
                            Date = new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 8: Incorrect data displayed on profile",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 9,
                            Date = new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 9: Search functionality not returning results",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 10,
                            Date = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 10: Session timeout issue",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 11,
                            Date = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 11: Feedback submission not working",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 12,
                            Date = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 12: Data export to CSV not functioning",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 13,
                            Date = new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 13: Mobile app crashes on startup",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 14,
                            Date = new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 14: API response time is too slow",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 15,
                            Date = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 15: Data synchronization issue",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 16,
                            Date = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 16: Calendar integration not working",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 17,
                            Date = new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 17: User roles not updating correctly",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 18,
                            Date = new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 18: Dashboard widget not loading",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 19,
                            Date = new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 19: Data visualization issue",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 20,
                            Date = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 20: User unable to reset password",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 21,
                            Date = new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 21: Error message on checkout page",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 22,
                            Date = new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 22: Image upload feature not working",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 23,
                            Date = new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 23: Browser compatibility issues",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 24,
                            Date = new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 24: Report filtering not functioning",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 25,
                            Date = new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 25: Incorrect invoice amount",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 26,
                            Date = new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 26: Payment method not accepted",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 27,
                            Date = new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 27: Notifications not being sent",
                            Status = "Closed"
                        },
                        new
                        {
                            TicketId = 28,
                            Date = new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 28: Website loading issues",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 29,
                            Date = new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 29: Account settings not saving",
                            Status = "Open"
                        },
                        new
                        {
                            TicketId = 30,
                            Date = new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ticket 30: Language settings not working",
                            Status = "Closed"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
