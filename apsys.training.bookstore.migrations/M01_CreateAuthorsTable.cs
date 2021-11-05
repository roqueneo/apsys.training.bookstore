using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace apsys.training.bookstore.migrations
{
    [Migration(1)]
    public class M01_CreateAuthorsTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Authors"); 
        }

        public override void Up()
        {
            Create.Table("Authors")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("FisrtName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable();

        }
    }
}
