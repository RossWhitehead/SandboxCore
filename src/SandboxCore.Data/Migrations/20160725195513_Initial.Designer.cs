using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SandboxCore.Data;

namespace SandboxCore.Data.Migrations
{
    [DbContext(typeof(SandboxCoreDbContext))]
    [Migration("20160725195513_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SandboxCore.Data.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectName")
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });
        }
    }
}
