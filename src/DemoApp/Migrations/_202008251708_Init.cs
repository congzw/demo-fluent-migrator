using FluentMigrator;

namespace DemoApp.Migrations
{
    [Migration(202008251708)]
    public class _202008251708_Init : Migration
    {
        public override void Up()
        {
            Create.Table("Sites")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString();

        }

        public override void Down()
        {
            Delete.Table("Sites");
        }
    }
}