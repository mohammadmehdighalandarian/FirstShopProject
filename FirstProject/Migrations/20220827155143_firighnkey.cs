using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstProject.Migrations
{
    public partial class firighnkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_Users_UsersId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_order_Orderid",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_Productid",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_order_UsersId",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "order");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "order",
                newName: "Orderid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_Productid",
                table: "OrderDetails",
                newName: "IX_OrderDetails_Productid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_Orderid",
                table: "OrderDetails",
                newName: "IX_OrderDetails_Orderid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_order_Userid",
                table: "order",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_order_Users_Userid",
                table: "order",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_order_Orderid",
                table: "OrderDetails",
                column: "Orderid",
                principalTable: "order",
                principalColumn: "Orderid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_Productid",
                table: "OrderDetails",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_Users_Userid",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_order_Orderid",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_Productid",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_order_Userid",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "Orderid",
                table: "order",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_Productid",
                table: "OrderDetail",
                newName: "IX_OrderDetail_Productid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_Orderid",
                table: "OrderDetail",
                newName: "IX_OrderDetail_Orderid");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_order_UsersId",
                table: "order",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_Users_UsersId",
                table: "order",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_order_Orderid",
                table: "OrderDetail",
                column: "Orderid",
                principalTable: "order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_Productid",
                table: "OrderDetail",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
