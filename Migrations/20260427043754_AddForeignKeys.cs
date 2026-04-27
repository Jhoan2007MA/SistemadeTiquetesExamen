using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemadeTiquetess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Reservations",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000140"),
                column: "StatusId",
                value: new Guid("a1000000-0000-0000-0000-000000000061"));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationPassengerId",
                table: "Tickets",
                column: "ReservationPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

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
                name: "IX_SeatAvailabilities_FlightId",
                table: "SeatAvailabilities",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatAvailabilities_SeatId",
                table: "SeatAvailabilities",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatAssignments_ReservationPassengerId",
                table: "SeatAssignments",
                column: "ReservationPassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatAssignments_SeatId",
                table: "SeatAssignments",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FlightId",
                table: "Reservations",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StatusId",
                table: "Reservations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPassengers_CustomerId",
                table: "ReservationPassengers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPassengers_ReservationId",
                table: "ReservationPassengers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReservationId",
                table: "Payments",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StatusId",
                table: "Flights",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CustomerId",
                table: "CustomerContacts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContacts_Customers_CustomerId",
                table: "CustomerContacts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightStatuses_StatusId",
                table: "Flights",
                column: "StatusId",
                principalTable: "FlightStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentMethods_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Reservations_ReservationId",
                table: "Payments",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationPassengers_Customers_CustomerId",
                table: "ReservationPassengers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationPassengers_Reservations_ReservationId",
                table: "ReservationPassengers",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_FlightId",
                table: "Reservations",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationStatuses_StatusId",
                table: "Reservations",
                column: "StatusId",
                principalTable: "ReservationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatAssignments_ReservationPassengers_ReservationPassengerId",
                table: "SeatAssignments",
                column: "ReservationPassengerId",
                principalTable: "ReservationPassengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatAssignments_Seats_SeatId",
                table: "SeatAssignments",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatAvailabilities_Flights_FlightId",
                table: "SeatAvailabilities",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatAvailabilities_Seats_SeatId",
                table: "SeatAvailabilities",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Airports_DestinationAirportId",
                table: "Segments",
                column: "DestinationAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Airports_OriginAirportId",
                table: "Segments",
                column: "OriginAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Flights_FlightId",
                table: "Segments",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ReservationPassengers_ReservationPassengerId",
                table: "Tickets",
                column: "ReservationPassengerId",
                principalTable: "ReservationPassengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketStatuses_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "TicketStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContacts_Customers_CustomerId",
                table: "CustomerContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightStatuses_StatusId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentMethods_PaymentMethodId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Reservations_ReservationId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationPassengers_Customers_CustomerId",
                table: "ReservationPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationPassengers_Reservations_ReservationId",
                table: "ReservationPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_FlightId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationStatuses_StatusId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatAssignments_ReservationPassengers_ReservationPassengerId",
                table: "SeatAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatAssignments_Seats_SeatId",
                table: "SeatAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatAvailabilities_Flights_FlightId",
                table: "SeatAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatAvailabilities_Seats_SeatId",
                table: "SeatAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Airports_DestinationAirportId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Airports_OriginAirportId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Flights_FlightId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ReservationPassengers_ReservationPassengerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketStatuses_StatusId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ReservationPassengerId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Segments_DestinationAirportId",
                table: "Segments");

            migrationBuilder.DropIndex(
                name: "IX_Segments_FlightId",
                table: "Segments");

            migrationBuilder.DropIndex(
                name: "IX_Segments_OriginAirportId",
                table: "Segments");

            migrationBuilder.DropIndex(
                name: "IX_SeatAvailabilities_FlightId",
                table: "SeatAvailabilities");

            migrationBuilder.DropIndex(
                name: "IX_SeatAvailabilities_SeatId",
                table: "SeatAvailabilities");

            migrationBuilder.DropIndex(
                name: "IX_SeatAssignments_ReservationPassengerId",
                table: "SeatAssignments");

            migrationBuilder.DropIndex(
                name: "IX_SeatAssignments_SeatId",
                table: "SeatAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_FlightId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StatusId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_ReservationPassengers_CustomerId",
                table: "ReservationPassengers");

            migrationBuilder.DropIndex(
                name: "IX_ReservationPassengers_ReservationId",
                table: "ReservationPassengers");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ReservationId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Flights_StatusId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_CustomerContacts_CustomerId",
                table: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("a1000000-0000-0000-0000-000000000140"),
                column: "Status",
                value: "Confirmada");
        }
    }
}
