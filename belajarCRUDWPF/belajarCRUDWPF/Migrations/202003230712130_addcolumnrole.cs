namespace belajarCRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_M_Supplier", "Role_Id_Id", c => c.Int());
            CreateIndex("dbo.TB_M_Supplier", "Role_Id_Id");
            AddForeignKey("dbo.TB_M_Supplier", "Role_Id_Id", "dbo.TB_M_Role", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_M_Supplier", "Role_Id_Id", "dbo.TB_M_Role");
            DropIndex("dbo.TB_M_Supplier", new[] { "Role_Id_Id" });
            DropColumn("dbo.TB_M_Supplier", "Role_Id_Id");
        }
    }
}
