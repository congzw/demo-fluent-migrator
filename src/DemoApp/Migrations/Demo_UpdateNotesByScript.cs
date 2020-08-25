//using FluentMigrator;

//namespace DemoApp.Migrations
//{
//    public class Demo_UpdateNotesByScript
//    {

//        /// <summary>
//        /// Update notes.
//        /// </summary>
//        /// <remarks>
//        /// This is only run when the migration 20090906205440 was already applied to the database.
//        /// </remarks>
//        [Migration(20190416112000)]
//        public class UpdateNotesByScript : Migration
//        {
//            /// <inheritdoc />
//            public override void Up()
//            {
//                Execute.Sql(@"/* this is a test script */
//update Notes set body=body || ' (modified)';
//");
//            }

//            /// <inheritdoc />
//            public override void Down()
//            {
//                // Nothing to do here
//            }
//        }
//    }
//}
