﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class populateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO users (username, password, fullname, refreshtoken, refreshtokenexpirytime) VALUES('leandro', '24-0B-E5-18-FA-BD-27-24-DD-B6-F0-4E-EB-1D-A5-96-74-48-D7-E8-31-C0-8C-8F-A8-22-80-9F-74-C7-20-A9', 'LEANDRO DA COSTA GONCALVES', 'h9lzVOoLlBoTbcQrh/e16/aIj+4p6C67lLdDbBRMsjE=', '2020-09-27 17:30:49'); ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from users");
        }
    }
}
