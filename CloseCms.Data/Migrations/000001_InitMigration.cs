using FluentMigrator;

namespace CloseCms.Data.Migrations
{
    [Migration(1)]
    public class InitMigration : Migration
    {
        private const string ResourceTableName = "Resource";

        public override void Up()
        {
            Create.Table(ResourceTableName)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("AssemblyPath").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(ResourceTableName);
        }
    }
}
