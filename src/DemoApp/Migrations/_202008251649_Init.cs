using FluentMigrator;

namespace DemoApp.Migrations
{
    [Migration(202008251649)]
    public class _202008251649_Init : Migration
    {
        public override void Up()
        {
            Create.Table("Orgs")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString();

            Create.Table("Users")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("Username").AsString().Unique("UK_Users_Username");
        }

        public override void Down()
        {
            Delete.Table("Orgs");
            Delete.Table("Users");
        }
    }
}
