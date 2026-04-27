using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemadeTiquetess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatosIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Id", "Capacity", "IsActive", "Manufacturer", "Model", "RegistrationNumber" },
                values: new object[] { new Guid("a1000000-0000-0000-0000-000000000030"), 180, true, "Airbus", "A320neo", "N123AB" });

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[] { new Guid("a1000000-0000-0000-0000-000000000010"), "AV", true, "Avianca" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "City", "Country", "IataCode", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000020"), "Bogotá", "Colombia", "BOG", true, "El Dorado" },
                    { new Guid("a1000000-0000-0000-0000-000000000021"), "Miami", "Estados Unidos", "MIA", true, "Miami International" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000001"), "CO", true, "Colombia" },
                    { new Guid("a1000000-0000-0000-0000-000000000002"), "US", true, "Estados Unidos" }
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
                table: "Customers",
                columns: new[] { "Id", "DocumentNumber", "FullName", "IsActive" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000080"), "CC-1234567", "María López", true },
                    { new Guid("a1000000-0000-0000-0000-000000000081"), "CC-7654321", "Juan Pérez", true }
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
                table: "Flights",
                columns: new[] { "Id", "FlightNumber", "StatusId" },
                values: new object[] { new Guid("a1000000-0000-0000-0000-000000000100"), "AV0101", new Guid("a1000000-0000-0000-0000-000000000040") });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000070"), "Tarjeta de crédito" },
                    { new Guid("a1000000-0000-0000-0000-000000000071"), "Efectivo" }
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
                table: "ReservationPassengers",
                columns: new[] { "Id", "CustomerId", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000150"), new Guid("a1000000-0000-0000-0000-000000000080"), new Guid("a1000000-0000-0000-0000-000000000140"), "1A" },
                    { new Guid("a1000000-0000-0000-0000-000000000151"), new Guid("a1000000-0000-0000-0000-000000000081"), new Guid("a1000000-0000-0000-0000-000000000140"), "1B" }
                });

            migrationBuilder.InsertData(
                table: "ReservationStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000060"), "Pendiente" },
                    { new Guid("a1000000-0000-0000-0000-000000000061"), "Confirmada" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "FlightId", "ReservationDate", "Status" },
                values: new object[] { new Guid("a1000000-0000-0000-0000-000000000140"), new Guid("a1000000-0000-0000-0000-000000000080"), new Guid("a1000000-0000-0000-0000-000000000100"), new DateTime(2026, 4, 1, 10, 0, 0, 0, DateTimeKind.Utc), "Confirmada" });

            migrationBuilder.InsertData(
                table: "SeatAssignments",
                columns: new[] { "Id", "ReservationPassengerId", "SeatId" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000170"), new Guid("a1000000-0000-0000-0000-000000000150"), new Guid("a1000000-0000-0000-0000-000000000120") },
                    { new Guid("a1000000-0000-0000-0000-000000000171"), new Guid("a1000000-0000-0000-0000-000000000151"), new Guid("a1000000-0000-0000-0000-000000000121") }
                });

            migrationBuilder.InsertData(
                table: "SeatAvailabilities",
                columns: new[] { "Id", "FlightId", "IsAvailable", "SeatId" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000130"), new Guid("a1000000-0000-0000-0000-000000000100"), false, new Guid("a1000000-0000-0000-0000-000000000120") },
                    { new Guid("a1000000-0000-0000-0000-000000000131"), new Guid("a1000000-0000-0000-0000-000000000100"), true, new Guid("a1000000-0000-0000-0000-000000000121") },
                    { new Guid("a1000000-0000-0000-0000-000000000132"), new Guid("a1000000-0000-0000-0000-000000000100"), true, new Guid("a1000000-0000-0000-0000-000000000122") },
                    { new Guid("a1000000-0000-0000-0000-000000000133"), new Guid("a1000000-0000-0000-0000-000000000100"), true, new Guid("a1000000-0000-0000-0000-000000000123") }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Class", "Row", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000120"), "Economy", "1", "1A" },
                    { new Guid("a1000000-0000-0000-0000-000000000121"), "Economy", "1", "1B" },
                    { new Guid("a1000000-0000-0000-0000-000000000122"), "Economy", "2", "2A" },
                    { new Guid("a1000000-0000-0000-0000-000000000123"), "Economy", "2", "2B" }
                });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "Id", "DestinationAirportId", "FlightId", "OriginAirportId" },
                values: new object[] { new Guid("a1000000-0000-0000-0000-000000000110"), new Guid("a1000000-0000-0000-0000-000000000021"), new Guid("a1000000-0000-0000-0000-000000000100"), new Guid("a1000000-0000-0000-0000-000000000020") });

            migrationBuilder.InsertData(
                table: "TicketStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000050"), "Emitido" },
                    { new Guid("a1000000-0000-0000-0000-000000000051"), "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "IssueDate", "ReservationPassengerId", "StatusId", "TicketNumber" },
                values: new object[,]
                {
                    { new Guid("a1000000-0000-0000-0000-000000000180"), new DateTime(2026, 4, 1, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("a1000000-0000-0000-0000-000000000150"), new Guid("a1000000-0000-0000-0000-000000000050"), "TK-BOG-MIA-0001" },
                    { new Guid("a1000000-0000-0000-0000-000000000181"), new DateTime(2026, 4, 1, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("a1000000-0000-0000-0000-000000000151"), new Guid("a1000000-0000-0000-0000-000000000050"), "TK-BOG-MIA-0002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "CustomerContacts",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000090"));

            migrationBuilder.DeleteData(
                table: "CustomerContacts",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000091"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000080"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000081"));

            migrationBuilder.DeleteData(
                table: "FlightStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "FlightStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "FlightStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000100"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000070"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000071"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000160"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000161"));

            migrationBuilder.DeleteData(
                table: "ReservationPassengers",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000150"));

            migrationBuilder.DeleteData(
                table: "ReservationPassengers",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000151"));

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000060"));

            migrationBuilder.DeleteData(
                table: "ReservationStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000061"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000140"));

            migrationBuilder.DeleteData(
                table: "SeatAssignments",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000170"));

            migrationBuilder.DeleteData(
                table: "SeatAssignments",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000171"));

            migrationBuilder.DeleteData(
                table: "SeatAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000130"));

            migrationBuilder.DeleteData(
                table: "SeatAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000131"));

            migrationBuilder.DeleteData(
                table: "SeatAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000132"));

            migrationBuilder.DeleteData(
                table: "SeatAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000133"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000120"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000121"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000122"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000123"));

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000110"));

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000051"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000180"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000181"));
        }
    }
}
