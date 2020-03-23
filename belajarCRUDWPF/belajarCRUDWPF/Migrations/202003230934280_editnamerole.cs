namespace belajarCRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editnamerole : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TB_M_Supplier", name: "Role_Id_Id", newName: "Role_Id");
            RenameIndex(table: "dbo.TB_M_Supplier", name: "IX_Role_Id_Id", newName: "IX_Role_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TB_M_Supplier", name: "IX_Role_Id", newName: "IX_Role_Id_Id");
            RenameColumn(table: "dbo.TB_M_Supplier", name: "Role_Id", newName: "Role_Id_Id");
        }
    }
}
