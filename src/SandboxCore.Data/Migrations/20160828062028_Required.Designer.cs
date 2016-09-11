using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SandboxCore.Data;

namespace SandboxCore.Data.Migrations
{
    [DbContext(typeof(CommandDbContext))]
    [Migration("20160828062028_Required")]
    partial class Required
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SandboxCore.Data.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int?>("ProjectCategoryProductCategoryId")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.HasIndex("ProjectCategoryProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SandboxCore.Data.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("ProductCategoryName")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SandboxCore.Data.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("ProjectName")
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SandboxCore.Data.Models.WorkItem", b =>
                {
                    b.Property<int>("WorkItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int?>("ProjectId");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("WorkItemId");

                    b.HasIndex("ProjectId");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("SandboxCore.Data.Models.Product", b =>
                {
                    b.HasOne("SandboxCore.Data.Models.ProductCategory", "ProjectCategory")
                        .WithMany("WorkItems")
                        .HasForeignKey("ProjectCategoryProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SandboxCore.Data.Models.WorkItem", b =>
                {
                    b.HasOne("SandboxCore.Data.Models.Project", "Project")
                        .WithMany("WorkItems")
                        .HasForeignKey("ProjectId");
                });
        }
    }
}
