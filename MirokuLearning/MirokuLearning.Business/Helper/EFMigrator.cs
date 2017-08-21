using MirokuLearning.Business.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.Business.Helper
{
    public class EFMigrator
    {
        public static void Migrate()
        {
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }

        public static void Down(string lmsConnectionString)
        {
            using (var dbIdentity = new MirokuLearningContext())
            {
                var migration = new MirokuLearning.Business.Migrations.initial();
                migration.Down();
                dbIdentity.RunMigration(migration);
            }
        }
    }
}
