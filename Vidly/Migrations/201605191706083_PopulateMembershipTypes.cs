namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (SignupFee, DurationInMonths, DiscountRate) VALUES (0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (SignupFee, DurationInMonths, DiscountRate) VALUES (30, 1, 0)");
            Sql("INSERT INTO MembershipTypes (SignupFee, DurationInMonths, DiscountRate) VALUES (90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (SignupFee, DurationInMonths, DiscountRate) VALUES (300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
