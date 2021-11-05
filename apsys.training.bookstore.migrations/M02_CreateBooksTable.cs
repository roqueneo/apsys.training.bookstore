using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace apsys.training.bookstore.migrations
{
    [Migration(2)]
    public class M02_CreateBooksTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Books");
        }

        public override void Up()
        {
            Create.Table("Books")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("ISBN").AsString().NotNullable()
                .WithColumn("Genre").AsString().NotNullable()
                .WithColumn("PublishDate").AsDateTime().NotNullable()
                .WithColumn("AuthorId").AsGuid().NotNullable()
                .ForeignKey("FK_Authors_Books", "Authors", "Id");


                


        }
    }
}
