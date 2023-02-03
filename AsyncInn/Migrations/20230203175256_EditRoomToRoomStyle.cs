using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncInn.Migrations
{
    /// <inheritdoc />
    public partial class EditRoomToRoomStyle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.CreateTable(
                name: "RoomStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Layout = table.Column<int>(type: "int", nullable: false),
                    HotelRoomHotelId = table.Column<int>(type: "int", nullable: true),
                    HotelRoomRoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStyles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomStyles_HotelRooms_HotelRoomHotelId_HotelRoomRoomId",
                        columns: x => new { x.HotelRoomHotelId, x.HotelRoomRoomId },
                        principalTable: "HotelRooms",
                        principalColumns: new[] { "HotelId", "RoomId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomStyles_HotelRoomHotelId_HotelRoomRoomId",
                table: "RoomStyles",
                columns: new[] { "HotelRoomHotelId", "HotelRoomRoomId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_RoomStyles_RoomId",
                table: "RoomAmenities",
                column: "RoomId",
                principalTable: "RoomStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_RoomStyles_RoomId",
                table: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "RoomStyles");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRoomHotelId = table.Column<int>(type: "int", nullable: true),
                    HotelRoomRoomId = table.Column<int>(type: "int", nullable: true),
                    Layout = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_HotelRooms_HotelRoomHotelId_HotelRoomRoomId",
                        columns: x => new { x.HotelRoomHotelId, x.HotelRoomRoomId },
                        principalTable: "HotelRooms",
                        principalColumns: new[] { "HotelId", "RoomId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelRoomHotelId_HotelRoomRoomId",
                table: "Rooms",
                columns: new[] { "HotelRoomHotelId", "HotelRoomRoomId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
