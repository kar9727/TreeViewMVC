namespace TreeViewMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TreeViewMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TreeViewMVC.context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TreeViewMVC.context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Categories.AddOrUpdate(c => c.nodeName,
            new Category { nodeId = 1, nodeName = "parent-1", IsActive = true, startdate = DateTime.Now, parentNodeId = null },
            new Category { nodeId = 2, nodeName = "child-1", IsActive = true, startdate = DateTime.Now, parentNodeId = 1 },
            new Category { nodeId = 3, nodeName = "child-2", IsActive = true, startdate = DateTime.Now, parentNodeId = 2 },
            new Category { nodeId = 4, nodeName = "child-1-2", IsActive = true, startdate = DateTime.Now, parentNodeId = 3 },
            new Category { nodeId = 5, nodeName = "child-1-2", IsActive = true, startdate = DateTime.Now, parentNodeId = 4 },
            new Category { nodeId = 6, nodeName = "child-1-1-2", IsActive = true, startdate = DateTime.Now, parentNodeId = 5 },
            new Category { nodeId = 7, nodeName = "parent-2", IsActive = true, startdate = DateTime.Now, parentNodeId = null },
            new Category { nodeId = 8, nodeName = "child-1", IsActive = true, startdate = DateTime.Now, parentNodeId = 7 },
            new Category { nodeId = 9, nodeName = "child-2", IsActive = true, startdate = DateTime.Now, parentNodeId = 8 },
            new Category { nodeId = 10, nodeName = "child-1-2", IsActive = true, startdate = DateTime.Now, parentNodeId = 9 }
            );
        }
    }
}
