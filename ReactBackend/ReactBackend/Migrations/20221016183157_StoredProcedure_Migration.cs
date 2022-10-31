using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;
using ReactBackend.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

//[DbContext(typeof(DataContext))]
//[Migration("StoredProcedure_Migration")]
namespace ReactBackend.Migrations
{
    public partial class StoredProcedure_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(File.ReadAllText("Migrations/20191029025018_RunSqlScripts.sql"));

            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE sp_GetAllPosts
                                    AS
                                    BEGIN
                                        Select * FROM Posts
                                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop procedure sp_GetAllPosts");
        }
    }
}
