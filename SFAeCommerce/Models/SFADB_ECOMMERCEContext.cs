using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class SFADB_ECOMMERCEContext : DbContext
    {
        public SFADB_ECOMMERCEContext()
        {
        }

        public SFADB_ECOMMERCEContext(DbContextOptions<SFADB_ECOMMERCEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AttributeValue> AttributeValues { get; set; }
        public virtual DbSet<AttributeValueEntity> AttributeValueEntities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientCriteriaValue> ClientCriteriaValues { get; set; }
        public virtual DbSet<ClientCriteriaValueClient> ClientCriteriaValueClients { get; set; }
        public virtual DbSet<Criterion> Criteria { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemBrand> ItemBrands { get; set; }
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<ItemPriceList> ItemPriceLists { get; set; }
        public virtual DbSet<ItemTaxAssignment> ItemTaxAssignments { get; set; }
        public virtual DbSet<ItemUom> ItemUoms { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<PriceListAssignment> PriceListAssignments { get; set; }
        public virtual DbSet<TransactionBody> TransactionBodies { get; set; }
        public virtual DbSet<TransactionBodyDistributionCode> TransactionBodyDistributionCodes { get; set; }
        public virtual DbSet<TransactionHeader> TransactionHeaders { get; set; }
        public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; }
        public virtual DbSet<TransactionStatusHistory> TransactionStatusHistories { get; set; }
        public virtual DbSet<Uom> Uoms { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseCurrentStock> WarehouseCurrentStocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LJIKIG9\\SQL_INSTANCE_01;Database=SFADB_ECOMMERCE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.HasKey(e => e.AttributeCode);

                entity.ToTable("attribute");

                entity.Property(e => e.AttributeCode)
                    .HasMaxLength(50)
                    .HasColumnName("attribute_code");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(100)
                    .HasColumnName("alt_description");

                entity.Property(e => e.AttributeType).HasColumnName("attribute_type");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.EntityType).HasColumnName("entity_type");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsRequired).HasColumnName("is_required");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ParentAttributeCode)
                    .HasMaxLength(50)
                    .HasColumnName("parent_attribute_code");

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sort_order")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AttributeValue>(entity =>
            {
                entity.HasKey(e => e.AttributeValueCode);

                entity.ToTable("attribute_value");

                entity.Property(e => e.AttributeValueCode)
                    .HasMaxLength(50)
                    .HasColumnName("attribute_value_code");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(100)
                    .HasColumnName("alt_description");

                entity.Property(e => e.AttributeCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("attribute_code");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ParentAttributeValueCode)
                    .HasMaxLength(50)
                    .HasColumnName("parent_attribute_value_code");

                entity.HasOne(d => d.AttributeCodeNavigation)
                    .WithMany(p => p.AttributeValues)
                    .HasForeignKey(d => d.AttributeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_attribute_value_attribute");
            });

            modelBuilder.Entity<AttributeValueEntity>(entity =>
            {
                entity.HasKey(e => e.AttributeValueEntityCode);

                entity.ToTable("attribute_value_entity");

                entity.Property(e => e.AttributeValueEntityCode)
                    .HasMaxLength(50)
                    .HasColumnName("attribute_value_entity_code");

                entity.Property(e => e.AttributeCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("attribute_code");

                entity.Property(e => e.AttributeValue)
                    .HasMaxLength(100)
                    .HasColumnName("attribute_value");

                entity.Property(e => e.AttributeValueCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("attribute_value_code");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EntityCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("entity_code");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.EntityCodeNavigation)
                    .WithMany(p => p.AttributeValueEntities)
                    .HasForeignKey(d => d.EntityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_attribute_value_entity_item");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientCode)
                    .HasName("PK_clients");

                entity.ToTable("client");

                entity.Property(e => e.ClientCode)
                    .HasMaxLength(50)
                    .HasColumnName("client_code");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(400)
                    .HasColumnName("alt_description");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnName("approval_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApproverUserCode)
                    .HasMaxLength(50)
                    .HasColumnName("approver_user_code");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .HasColumnName("barcode");

                entity.Property(e => e.BillingAddressType)
                    .HasColumnName("billing_address_type")
                    .HasComment("Bill to and Ship to (0), Bill to Only (1), Ship to Only (2)");

                entity.Property(e => e.ClientType)
                    .HasColumnName("client_type")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Client(1),Supplier(2),Both(3)");

                entity.Property(e => e.CreatorUserCode)
                    .HasMaxLength(50)
                    .HasColumnName("creator_user_code");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(50)
                    .HasColumnName("currency_code");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultUserCode)
                    .HasMaxLength(50)
                    .HasColumnName("default_user_code");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .HasColumnName("description");

                entity.Property(e => e.ErpClientCode)
                    .HasMaxLength(50)
                    .HasColumnName("erp_client_code");

                entity.Property(e => e.GenerationDate)
                    .HasColumnName("generation_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GeneratorUserCode)
                    .HasMaxLength(50)
                    .HasColumnName("generator_user_code");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))")
                    .HasComment("0 for HandHeld, 1 for BackEnd");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("longitude");

                entity.Property(e => e.NfcCode)
                    .HasMaxLength(50)
                    .HasColumnName("nfc_code");

                entity.Property(e => e.ParentClientCode)
                    .HasMaxLength(50)
                    .HasColumnName("parent_client_code");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0 For HeadQuarter, 1 For Branch");

                entity.Property(e => e.UniqueIdentifier).HasColumnName("unique_identifier");
            });

            modelBuilder.Entity<ClientCriteriaValue>(entity =>
            {
                entity.ToTable("client_criteria_value");

                entity.Property(e => e.ClientCriteriaValueId).HasColumnName("client_criteria_value_id");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(250)
                    .HasColumnName("alt_description");

                entity.Property(e => e.ClientCriteriaValueErpCode)
                    .HasMaxLength(50)
                    .HasColumnName("client_criteria_value_erp_code");

                entity.Property(e => e.CriteriaId)
                    .HasColumnName("criteria_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.ClientCriteriaValues)
                    .HasForeignKey(d => d.CriteriaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_client_criteria_value_criteria");
            });

            modelBuilder.Entity<ClientCriteriaValueClient>(entity =>
            {
                entity.HasKey(e => new { e.ClientCriteriaValueId, e.ClientCode })
                    .HasName("PK_clients_criteria_list_clients");

                entity.ToTable("client_criteria_value_client");

                entity.Property(e => e.ClientCriteriaValueId).HasColumnName("client_criteria_value_id");

                entity.Property(e => e.ClientCode)
                    .HasMaxLength(50)
                    .HasColumnName("client_code");

                entity.Property(e => e.CurrentCriteriaExpiryDate).HasColumnName("current_criteria_expiry_date");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MainClientCriteriaValueId)
                    .HasColumnName("main_client_criteria_value_id")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.NextClientCriteriaValueId)
                    .HasColumnName("next_client_criteria_value_id")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.NextCriteriaValueEndDate).HasColumnName("next_criteria_value_end_date");

                entity.Property(e => e.NextCriteriaValueStartDate).HasColumnName("next_criteria_value_start_date");
            });

            modelBuilder.Entity<Criterion>(entity =>
            {
                entity.HasKey(e => e.CriteriaId);

                entity.ToTable("criteria");

                entity.Property(e => e.CriteriaId)
                    .HasColumnName("criteria_id")
                    .HasComment("this table contained the criterias that can be used for filtration. this table is used for clients, users, and items,  Differentiate between types are done using type field");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(250)
                    .HasColumnName("alt_description");

                entity.Property(e => e.CriteriaType)
                    .HasColumnName("criteria_type")
                    .HasComment("\"1\" for clients, \"2\" for users, 3 for \"items\", 4 for sites, 5 for projects,\r\n20-40 site_criteria\r\n21 for construcations\r\n22 for maintenance\r\n23 for telecome");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEditable)
                    .IsRequired()
                    .HasColumnName("is_editable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsRequired).HasColumnName("is_required");

                entity.Property(e => e.IsSupervisorRequired).HasColumnName("is_supervisor_required");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReportingVisibility)
                    .IsRequired()
                    .HasColumnName("reporting_visibility")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SortOrder).HasColumnName("sort_order");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode);

                entity.ToTable("currency");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(50)
                    .HasColumnName("currency_code");

                entity.Property(e => e.AltDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("alt_description");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeadAmount)
                    .HasColumnName("dead_amount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.ErpCurrencyCode)
                    .HasMaxLength(50)
                    .HasColumnName("erp_currency_code");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsMain).HasColumnName("is_main");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ratio).HasColumnName("ratio");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("symbol");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.ImageId)
                    .ValueGeneratedNever()
                    .HasColumnName("image_id");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(50)
                    .HasColumnName("alt_description");

                entity.Property(e => e.BasePath)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("base_path");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.FolderPath)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("folder_path");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.IsUploaded).HasColumnName("is_uploaded");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OwnerCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("owner_code");

                entity.Property(e => e.OwnerType)
                    .HasColumnName("owner_type")
                    .HasComment(" ITEM=1, BRAND=2, SURVEY_INSTANCE=3, SURVEY_ANSWER=4, ASSET=5;");

                entity.Property(e => e.PhysicalFileName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("physical_file_name");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(50)
                    .HasColumnName("user_code");

                entity.HasOne(d => d.OwnerCodeNavigation)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.OwnerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_image_item");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemCode);

                entity.ToTable("item");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(50)
                    .HasColumnName("item_code");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(250)
                    .HasColumnName("alt_description");

                entity.Property(e => e.BaseUomCode)
                    .HasMaxLength(50)
                    .HasColumnName("base_uom_code");

                entity.Property(e => e.BrandCode)
                    .HasMaxLength(50)
                    .HasColumnName("brand_code");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.DistributionType)
                    .HasColumnName("distribution_type")
                    .HasComment("None(1), Serialized(2), Lot Controlled(3)");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsConsignment).HasColumnName("is_consignment");

                entity.Property(e => e.IsDual).HasColumnName("is_dual");

                entity.Property(e => e.IsNew).HasColumnName("is_new");

                entity.Property(e => e.ItemErpCode)
                    .HasMaxLength(50)
                    .HasColumnName("item_erp_code");

                entity.Property(e => e.ItemOrder).HasColumnName("item_order");

                entity.Property(e => e.ItemType).HasColumnName("Item_type");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MainUomCode)
                    .HasMaxLength(50)
                    .HasColumnName("main_uom_code");

                entity.Property(e => e.PurchaseUomCode)
                    .HasMaxLength(50)
                    .HasColumnName("purchase_uom_code");

                entity.Property(e => e.ReturnType)
                    .HasColumnName("return_type")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShortageLimit).HasColumnName("shortage_limit");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StockUomCode)
                    .HasMaxLength(50)
                    .HasColumnName("stock_uom_code");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(50)
                    .HasColumnName("tax_code");
            });

            modelBuilder.Entity<ItemBrand>(entity =>
            {
                entity.HasKey(e => e.ItemBrandCode);

                entity.ToTable("item_brand");

                entity.Property(e => e.ItemBrandCode)
                    .HasMaxLength(50)
                    .HasColumnName("item_brand_code");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(50)
                    .HasColumnName("alt_description");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(50)
                    .HasColumnName("currency_code");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ItemGroup>(entity =>
            {
                entity.HasKey(e => new { e.ItemCode, e.GroupId });

                entity.ToTable("item_group");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(50)
                    .HasColumnName("item_code");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ItemPriceList>(entity =>
            {
                entity.ToTable("item_price_list");

                entity.Property(e => e.ItemPriceListId)
                    .ValueGeneratedNever()
                    .HasColumnName("item_price_list_id");

                entity.Property(e => e.AddedPrice)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("added_price");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("currency_code");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultDiscount).HasColumnName("default_discount");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsTtc).HasColumnName("is_ttc");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("item_code");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("price");

                entity.Property(e => e.PriceListCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("price_list_code");

                entity.Property(e => e.PriceMargin).HasColumnName("price_margin");

                entity.Property(e => e.ReturnPrice)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("return_price");

                entity.Property(e => e.UomCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("uom_code");

                entity.HasOne(d => d.ItemCodeNavigation)
                    .WithMany(p => p.ItemPriceLists)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_item_price_list_item");
            });

            modelBuilder.Entity<ItemTaxAssignment>(entity =>
            {
                entity.ToTable("item_tax_assignment");

                entity.Property(e => e.ItemTaxAssignmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("item_tax_assignment_id");

                entity.Property(e => e.AssignedCode)
                    .HasMaxLength(50)
                    .HasColumnName("assigned_code");

                entity.Property(e => e.AssignedType)
                    .HasColumnName("assigned_type")
                    .HasComment("Default(-1), Client(1), Client Criteria(2)");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TargetCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("target_code");

                entity.Property(e => e.TargetType)
                    .HasColumnName("target_type")
                    .HasComment("Item(1), Item Criteria(2)");

                entity.Property(e => e.TaxCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tax_code");
            });

            modelBuilder.Entity<ItemUom>(entity =>
            {
                entity.ToTable("item_uom");

                entity.Property(e => e.ItemUomId)
                    .ValueGeneratedNever()
                    .HasColumnName("item_uom_id");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(250)
                    .HasColumnName("barcode");

                entity.Property(e => e.ConsignmentItemCode)
                    .HasMaxLength(50)
                    .HasColumnName("consignment_item_code");

                entity.Property(e => e.ConversionMargin).HasColumnName("conversion_margin");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultDiscount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("default_discount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Depth).HasColumnName("depth");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(50)
                    .HasColumnName("item_code");

                entity.Property(e => e.ItemUomErpCode)
                    .HasMaxLength(50)
                    .HasColumnName("item_uom_erp_code");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("last_modified_by");

                entity.Property(e => e.PackTypeId).HasColumnName("pack_type_id");

                entity.Property(e => e.PricingUomCode)
                    .HasMaxLength(50)
                    .HasColumnName("pricing_uom_code");

                entity.Property(e => e.RatioToBaseUom).HasColumnName("ratio_to_base_uom");

                entity.Property(e => e.UomCode)
                    .HasMaxLength(50)
                    .HasColumnName("uom_code");

                entity.Property(e => e.Volume)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("volume")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("weight")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<PriceList>(entity =>
            {
                entity.HasKey(e => e.PriceListCode);

                entity.ToTable("price_list");

                entity.Property(e => e.PriceListCode)
                    .HasMaxLength(50)
                    .HasColumnName("price_list_code");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("alt_description");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasColumnName("start_date");
            });

            modelBuilder.Entity<PriceListAssignment>(entity =>
            {
                entity.ToTable("price_list_assignment");

                entity.Property(e => e.PriceListAssignmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("price_list_assignment_id");

                entity.Property(e => e.AssignedCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("assigned_code");

                entity.Property(e => e.AssignedType)
                    .HasColumnName("assigned_type")
                    .HasComment("Client(1), Client Criteria(2), Address(3)");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistributorCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("distributor_code")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PriceListCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("price_list_code");
            });

            modelBuilder.Entity<TransactionBody>(entity =>
            {
                entity.ToTable("transaction_body");

                entity.Property(e => e.TransactionBodyId)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_body_id");

                entity.Property(e => e.AddedPrice).HasColumnName("added_price");

                entity.Property(e => e.ApprovedQuantity).HasColumnName("approved_quantity");

                entity.Property(e => e.Comment)
                    .HasMaxLength(1000)
                    .HasColumnName("comment");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(50)
                    .HasColumnName("currency_code");

                entity.Property(e => e.CurrencyRate)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("currency_rate");

                entity.Property(e => e.DateAdded).HasColumnName("date_added");

                entity.Property(e => e.DefaultDiscountPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("default_discount_percentage");

                entity.Property(e => e.DummyVariable)
                    .HasMaxLength(50)
                    .HasColumnName("dummy_variable");

                entity.Property(e => e.DummyVariableDescription)
                    .HasMaxLength(50)
                    .HasColumnName("dummy_variable_description");

                entity.Property(e => e.HeaderDiscountPercentage)
                    .HasColumnName("header_discount_percentage")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HeaderDiscountValue)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("header_discount_value")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsProcessed).HasColumnName("is_processed");

                entity.Property(e => e.IsStockProcessed).HasColumnName("is_Stock_processed");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("item_code");

                entity.Property(e => e.ItemDefaultPrice)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("item_default_price");

                entity.Property(e => e.ItemStatus).HasColumnName("item_status");

                entity.Property(e => e.LastEdited).HasColumnName("last_edited");

                entity.Property(e => e.LineId).HasColumnName("line_id");

                entity.Property(e => e.PackageBarcode)
                    .HasMaxLength(50)
                    .HasColumnName("package_barcode");

                entity.Property(e => e.PackageType)
                    .HasColumnName("package_type")
                    .HasComment("Box(0), Bag(1)");

                entity.Property(e => e.PriceListCode)
                    .HasMaxLength(50)
                    .HasColumnName("price_list_code");

                entity.Property(e => e.PromotionDiscountPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("promotion_discount_percentage");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.ReasonId).HasColumnName("reason_id");

                entity.Property(e => e.RequestedQuantity).HasColumnName("requested_quantity");

                entity.Property(e => e.SecondaryUomCode)
                    .HasMaxLength(50)
                    .HasColumnName("secondary_uom_code");

                entity.Property(e => e.SecondaryUomQuantity)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("secondary_uom_quantity");

                entity.Property(e => e.SecondaryUomRequestedQuantity)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("secondary_uom_requested_quantity");

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.Property(e => e.SuggestedQuantity).HasColumnName("suggested_quantity");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(50)
                    .HasColumnName("tax_code");

                entity.Property(e => e.TaxPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("tax_percentage");

                entity.Property(e => e.TotalDefaultPrice)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total_default_price");

                entity.Property(e => e.TotalFinalDiscount)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total_final_discount");

                entity.Property(e => e.TotalFinalPrice)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total_final_price");

                entity.Property(e => e.TotalTax)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total_tax");

                entity.Property(e => e.TransactionHeaderId).HasColumnName("transaction_header_id");

                entity.Property(e => e.UomCode)
                    .HasMaxLength(50)
                    .HasColumnName("uom_code");
            });

            modelBuilder.Entity<TransactionBodyDistributionCode>(entity =>
            {
                entity.ToTable("transaction_body_distribution_code");

                entity.Property(e => e.TransactionBodyDistributionCodeId)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_body_distribution_code_id");

                entity.Property(e => e.BreakPolicy).HasColumnName("break_policy");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistributionCodeFrom)
                    .HasMaxLength(150)
                    .HasColumnName("distribution_code_from");

                entity.Property(e => e.DistributionCodeTo)
                    .HasMaxLength(50)
                    .HasColumnName("distribution_code_to");

                entity.Property(e => e.DistributionCodeType)
                    .HasColumnName("distribution_code_type")
                    .HasDefaultValueSql("((1))")
                    .HasComment("None(1), Serialized(2), Lot Controlled(3)");

                entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(50)
                    .HasColumnName("item_code");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RequestedQuantity).HasColumnName("requested_quantity");

                entity.Property(e => e.RequestedSecondaryQuantity).HasColumnName("requested_secondary_quantity");

                entity.Property(e => e.SecondaryQuantity).HasColumnName("secondary_quantity");

                entity.Property(e => e.SelectedDate)
                    .HasColumnName("selected_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionBodyId).HasColumnName("transaction_body_id");

                entity.Property(e => e.TransactionHeaderId).HasColumnName("transaction_header_id");

                entity.Property(e => e.UomCode)
                    .HasMaxLength(50)
                    .HasColumnName("uom_code");
            });

            modelBuilder.Entity<TransactionHeader>(entity =>
            {
                entity.ToTable("transaction_header");

                entity.HasComment("1 for Client, 2 For User");

                entity.Property(e => e.TransactionHeaderId)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_header_id");

                entity.Property(e => e.AddedPrice).HasColumnName("added_price");

                entity.Property(e => e.AppVersion)
                    .HasMaxLength(50)
                    .HasColumnName("app_version")
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .HasColumnName("barcode");

                entity.Property(e => e.BillTo)
                    .HasMaxLength(50)
                    .HasColumnName("bill_to");

                entity.Property(e => e.ClientTotalAmount)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("client_total_amount")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.ClientTotalDue)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("client_total_due")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Comment)
                    .HasMaxLength(1000)
                    .HasColumnName("comment");

                entity.Property(e => e.CompletedIn)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("completed_in")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(50)
                    .HasColumnName("currency_code");

                entity.Property(e => e.CurrencyRate)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("currency_rate")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.CurrentUserCode)
                    .HasMaxLength(50)
                    .HasColumnName("current_user_code");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("destination_code");

                entity.Property(e => e.DestinationType)
                    .HasColumnName("destination_type")
                    .HasComment("1 for Client, 2 For User");

                entity.Property(e => e.DistributorCode)
                    .HasMaxLength(50)
                    .HasColumnName("distributor_code");

                entity.Property(e => e.ErpTransactionHeaderCode)
                    .HasMaxLength(50)
                    .HasColumnName("erp_transaction_header_code");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnName("expected_delivery_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpectedPaymentDate)
                    .HasColumnName("expected_payment_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpectedPaymentType)
                    .HasColumnName("expected_payment_type")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.FarBy)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("far_by")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.HeaderDiscountPercentage)
                    .HasColumnName("header_discount_percentage")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HeaderDiscountValue)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("header_discount_value")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsExpress).HasColumnName("is_express");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.IsTreated)
                    .HasColumnName("is_treated")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemBrandCode)
                    .HasMaxLength(50)
                    .HasColumnName("item_brand_code");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(50)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(50)
                    .HasColumnName("longitude");

                entity.Property(e => e.NextApproverUserCode)
                    .HasMaxLength(50)
                    .HasColumnName("next_approver_user_code");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.ParentTransactionHeaderId)
                    .HasColumnName("parent_transaction_header_id")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.PrintCount).HasColumnName("print_count");

                entity.Property(e => e.ProblemId).HasColumnName("problem_id");

                entity.Property(e => e.ReasonId)
                    .HasColumnName("reason_id")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .HasColumnName("ship_to");

                entity.Property(e => e.SourceCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("source_code");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 for Client, 2 For User");

                entity.Property(e => e.StampValue)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("stamp_value");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total_amount");

                entity.Property(e => e.TotalDiscount)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total_discount");

                entity.Property(e => e.TotalTax)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("total_tax");

                entity.Property(e => e.TransactionHeaderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("transaction_header_code");

                entity.Property(e => e.TransactionStatus).HasColumnName("transaction_status");

                entity.Property(e => e.TransactionType).HasColumnName("transaction_type");

                entity.Property(e => e.TripCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("trip_code");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(50)
                    .HasColumnName("user_code");

                entity.Property(e => e.VisitId)
                    .HasColumnName("visit_id")
                    .HasDefaultValueSql("((-1))");
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("transaction_status");

                entity.Property(e => e.AllowFilterBy).HasColumnName("allow_filter_by");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(50)
                    .HasColumnName("alt_description");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.DateAdded).HasColumnName("date_added");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsCustom)
                    .IsRequired()
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited).HasColumnName("last_edited");

                entity.Property(e => e.LevelId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("level_id")
                    .HasDefaultValueSql("((-1))")
                    .IsFixedLength(true);

                entity.Property(e => e.MobileColor)
                    .HasMaxLength(50)
                    .HasColumnName("mobile_color");

                entity.Property(e => e.StatusId).HasColumnName("status_id");
            });

            modelBuilder.Entity<TransactionStatusHistory>(entity =>
            {
                entity.ToTable("transaction_status_history");

                entity.Property(e => e.TransactionStatusHistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_status_history_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastEditedBy)
                    .HasMaxLength(50)
                    .HasColumnName("last_edited_by");

                entity.Property(e => e.LineId).HasColumnName("line_id");

                entity.Property(e => e.Originater)
                    .HasMaxLength(50)
                    .HasColumnName("originater");

                entity.Property(e => e.SourceFunction)
                    .HasMaxLength(50)
                    .HasColumnName("source_function");

                entity.Property(e => e.TransactionHeaderCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("transaction_header_code");

                entity.Property(e => e.TransactionHeaderId).HasColumnName("transaction_header_id");

                entity.Property(e => e.TransactionStatus).HasColumnName("transaction_status");

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_code");

                entity.Property(e => e.WarehouseDispatchingListCode)
                    .HasMaxLength(50)
                    .HasColumnName("warehouse_dispatching_list_code");

                entity.Property(e => e.WarehouseDispatchingListId).HasColumnName("warehouse_dispatching_list_id");
            });

            modelBuilder.Entity<Uom>(entity =>
            {
                entity.HasKey(e => e.UomCode);

                entity.ToTable("UOM");

                entity.Property(e => e.UomCode)
                    .HasMaxLength(50)
                    .HasColumnName("uom_code");

                entity.Property(e => e.AltDescription)
                    .HasMaxLength(50)
                    .HasColumnName("alt_description");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DecimalDigits).HasColumnName("decimal_digits");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("symbol");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.WarehouseCode)
                    .HasName("PK__warehous__33764D055398D7F7");

                entity.ToTable("warehouse");

                entity.Property(e => e.WarehouseCode)
                    .HasMaxLength(50)
                    .HasColumnName("warehouse_code");

                entity.Property(e => e.AltDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("alt_description");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Depth).HasColumnName("depth");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MainWarehouseCode)
                    .HasMaxLength(50)
                    .HasColumnName("main_warehouse_code");

                entity.Property(e => e.MaxWeight)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("max_weight")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type")
                    .HasComment("Fixed(1), Mobile With Stock(2), Mobile Without Stock(3)");

                entity.Property(e => e.Volume)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("volume")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<WarehouseCurrentStock>(entity =>
            {
                entity.ToTable("warehouse_current_stock");

                entity.Property(e => e.WarehouseCurrentStockId)
                    .ValueGeneratedNever()
                    .HasColumnName("warehouse_current_stock_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsProcessed)
                    .HasColumnName("is_processed")
                    .HasDefaultValueSql("((2))")
                    .HasComment("");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("item_code");

                entity.Property(e => e.ItemIdentifier).HasColumnName("item_identifier");

                entity.Property(e => e.LastEdited)
                    .HasColumnName("last_edited")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("quantity");

                entity.Property(e => e.ReasonId)
                    .HasColumnName("reason_id")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.SecondaryUomCode)
                    .HasMaxLength(50)
                    .HasColumnName("secondary_uom_code");

                entity.Property(e => e.SecondaryUomQuantity)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("secondary_uom_quantity");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1 for Good, 2 for Damaged");

                entity.Property(e => e.UomCode)
                    .HasMaxLength(50)
                    .HasColumnName("uom_code");

                entity.Property(e => e.WarehouseCode)
                    .HasMaxLength(50)
                    .HasColumnName("warehouse_code");

                entity.HasOne(d => d.ItemCodeNavigation)
                    .WithMany(p => p.WarehouseCurrentStocks)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_warehouse_current_stock_item");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
