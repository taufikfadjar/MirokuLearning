namespace MirokuLearning.Business.Migrations
{
    using Bogus;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MirokuLearning.Business.MirokuLearningContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MirokuLearning.Business.MirokuLearningContext context)
        {
            var codeIds = 0;
            var itemGenerator = new Faker<Item>()
                .RuleFor(o => o.ItemDescription, f => f.Commerce.ProductAdjective() + " " + f.Commerce.Color())
                .RuleFor(o => o.ItemName, f => f.Commerce.ProductName())
                .RuleFor(o => o.ItemTotalQty, f => 0)
                .RuleFor(o => o.ItemCode, f => codeIds++ + "" + f.Random.AlphaNumeric(4).ToUpper());

            var items = itemGenerator.Generate(100).ToList();

            if (!context.Items.Any())
            {
                foreach (var item in items)
                {
                    context.Items.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
