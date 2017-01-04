using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataAccessManager;

namespace JK.GISService.Migrations
{
    [DbContext(typeof(DomainModelContext))]
    [Migration("20170104135548_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("DomainModel.tabBaseInfo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("addLayerList");

                    b.Property<int>("addOverviewMap");

                    b.Property<int>("addScaleLine");

                    b.Property<int>("addZoomBar");

                    b.Property<string>("initLayers");

                    b.Property<string>("initMapURL");

                    b.Property<double>("initScale");

                    b.Property<double>("initX");

                    b.Property<double>("initY");

                    b.Property<string>("mapProject");

                    b.Property<Guid>("pjid");

                    b.HasKey("id");

                    b.ToTable("tabBaseInfo");
                });

            modelBuilder.Entity("DomainModel.tabProjectInfo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("cdTime");

                    b.Property<string>("pdesc");

                    b.Property<string>("pname");

                    b.Property<string>("projectMark");

                    b.HasKey("id");

                    b.ToTable("tabProjectInfo");
                });
        }
    }
}
