﻿//using FluentMigrator;

//namespace DemoApp.Migrations
//{
//    [Migration(20090906205440)]
//    public class Demo_AddNotesTable : Migration
//    {
//        public override void Up()
//        {
//            Create.Table("Notes")
//                .WithIdColumn()
//                .WithColumn("Body").AsString(4000).NotNullable()
//                .WithTimeStamps()
//                .WithColumn("User_id").AsInt32();
//        }

//        public override void Down()
//        {
//            Delete.Table("Notes");
//        }
//    }
//}
