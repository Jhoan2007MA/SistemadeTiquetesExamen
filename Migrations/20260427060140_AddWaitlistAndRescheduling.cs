using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemadeTiquetess.Migrations
{
    /// <inheritdoc />
    public partial class AddWaitlistAndRescheduling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Flights",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Flights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Flights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RescheduleHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReservationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PreviousFlightId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NewFlightId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ChangeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RescheduleHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RescheduleHistories_Flights_NewFlightId",
                        column: x => x.NewFlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RescheduleHistories_Flights_PreviousFlightId",
                        column: x => x.PreviousFlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RescheduleHistories_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Waitlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReservationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FlightId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RequestDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waitlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waitlists_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Waitlists_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000100"),
                columns: new[] { "DepartureDate", "Destination", "Origin" },
                values: new object[] { new DateTime(2026, 4, 2, 10, 0, 0, 0, DateTimeKind.Utc), "MIA", "BOG" });

            migrationBuilder.InsertData(
                table: "ReservationStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000062"), "Reprogramada" },
                    { new Guid("a1000000-0000-0000-0000-000000000063"), "En espera" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RescheduleHistories_NewFlightId",
                table: "RescheduleHistories",
                column: "NewFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_RescheduleHistories_PreviousFlightId",
                table: "RescheduleHistories",
                column: "PreviousFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_RescheduleHistories_ReservationId",
                table: "RescheduleHistories",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Waitlists_FlightId",
                table: "Waitlists",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Waitlists_ReservationId",
                table: "Waitlists",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RescheduleHistories");

            migrationBuilder.DropTable(
                name: "Waitlists");

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000062"));

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000063"));

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Flights");

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IataCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReservationPassengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReservationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SeatNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPassengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationPassengers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationPassengers_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DestinationAirportId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FlightId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OriginAirportId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segments_Airports_DestinationAirportId",
                        column: x => x.DestinationAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Segments_Airports_OriginAirportId",
                        column: x => x.OriginAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Segments_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PaymentMethodId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReservationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeatAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReservationPassengerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SeatId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatAssignments_ReservationPassengers_ReservationPassengerId",
                        column: x => x.ReservationPassengerId,
                        principalTable: "ReservationPassengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatAssignments_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReservationPassengerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StatusId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IssueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TicketNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_ReservationPassengers_ReservationPassengerId",
                        column: x => x.ReservationPassengerId,
                        principalTable: "ReservationPassengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "City", "Country", "IataCode", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000020"), "Bogotá", "Colombia", "BOG", true, "El Dorado" },
                    { new Guid("a1000000-0000-0000-0000-000000000021"), "Miami", "Estados Unidos", "MIA", true, "Miami International" }
                });

            migrationBuilder.InsertData(
                table: "CustomerContacts",
                columns: new[] { "Id", "CustomerId", "Email", "IsActive", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000090"), new Guid("a1000000-0000-0000-0000-000000000080"), "maria.lopez@example.com", true, "+57 300 1112233" },
                    { new Guid("a1000000-0000-0000-0000-000000000091"), new Guid("a1000000-0000-0000-0000-000000000081"), "juan.perez@example.com", true, "+57 300 3334455" }
                });

            migrationBuilder.InsertData(
                table: "FlightStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000040"), "Programado" },
                    { new Guid("a1000000-0000-0000-0000-000000000041"), "En vuelo" },
                    { new Guid("a1000000-0000-0000-0000-000000000042"), "Aterrizado" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000070"), "Tarjeta de crédito" },
                    { new Guid("a1000000-0000-0000-0000-000000000071"), "Efectivo" }
                });

            migrationBuilder.InsertData(
                table: "ReservationPassengers",
                columns: new[] { "Id", "CustomerId", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000150"), new Guid("a1000000-0000-0000-0000-000000000080"), new Guid("a1000000-0000-0000-0000-000000000140"), "1A" },
                    { new Guid("a1000000-0000-0000-0000-000000000151"), new Guid("a1000000-0000-0000-0000-000000000081"), new Guid("a1000000-0000-0000-0000-000000000140"), "1B" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentMethodId", "ReservationId" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000160"), 350.00m, new DateTime(2026, 4, 1, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("a1000000-0000-0000-0000-000000000070"), new Guid("a1000000-0000-0000-0000-000000000140") },
                    { new Guid("a1000000-0000-0000-0000-000000000161"), 50.00m, new DateTime(2026, 4, 1, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("a1000000-0000-0000-0000-000000000071"), new Guid("a1000000-0000-0000-0000-000000000140") }
                });

            migrationBuilder.InsertData(
                table: "SeatAssignments",
                columns: new[] { "Id", "ReservationPassengerId", "SeatId" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000170"), new Guid("a1000000-0000-0000-0000-000000000150"), new Guid("a1000000-0000-0000-0000-000000000120") },
                    { new Guid("a1000000-0000-0000-0000-000000000171"), new Guid("a1000000-0000-0000-0000-000000000151"), new Guid("a1000000-0000-0000-0000-000000000121") }
                });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "Id", "DestinationAirportId", "FlightId", "OriginAirportId" },
                values: new object[] { new Guid("a1000000-0000-0000-0000-000000000110"), new Guid("a1000000-0000-0000-0000-000000000021"), new Guid("a1000000-0000-0000-0000-000000000100"), new Guid("a1000000-0000-0000-0000-000000000020") });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "IssueDate", "ReservationPassengerId", "StatusId", "TicketNumber" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000180"), new DateTime(2026, 4, 1, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("a1000000-0000-0000-0000-000000000150"), new Guid("a1000000-0000-0000-0000-000000000050"), "TK-BOG-MIA-0001" },
                    { new Guid("a1000000-0000-0000-0000-000000000181"), new DateTime(2026, 4, 1, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("a1000000-0000-0000-0000-000000000151"), new Guid("a1000000-0000-0000-0000-000000000050"), "TK-BOG-MIA-0002" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CustomerId",
                table: "CustomerContacts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReservationId",
                table: "Payments",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPassengers_CustomerId",
                table: "ReservationPassengers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPassengers_ReservationId",
                table: "ReservationPassengers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatAssignments_ReservationPassengerId",
                table: "SeatAssignments",
                column: "ReservationPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatAssignments_SeatId",
                table: "SeatAssignments",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_DestinationAirportId",
                table: "Segments",
                column: "DestinationAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_FlightId",
                table: "Segments",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_OriginAirportId",
                table: "Segments",
                column: "OriginAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationPassengerId",
                table: "Tickets",
                column: "ReservationPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");
        }
    }
}
