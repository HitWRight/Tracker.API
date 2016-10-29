using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Tracker.API.Models;

namespace ttrs.Migrations
{
    [DbContext(typeof(TimetrackDBContext))]
    partial class TimetrackDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tracker.API.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<byte[]>("Macaddress")
                        .IsRequired()
                        .HasColumnName("macaddress")
                        .HasColumnType("binary(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("computer");
                });

            modelBuilder.Entity("Tracker.API.Models.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasAnnotation("MaxLength", 511);

                    b.Property<int>("ProductivityLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("productivity_level")
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.ToTable("software");
                });

            modelBuilder.Entity("Tracker.API.Models.Usage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id");

                    b.Property<int>("SoftwareId")
                        .HasColumnName("software_id");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<int>("ComputerId")
                        .HasColumnName("computer_id");

                    b.Property<int>("SecondsSpent")
                        .HasColumnName("seconds_spent");

                    b.HasKey("Id", "SoftwareId", "Date", "ComputerId")
                        .HasName("PK_usage");

                    b.ToTable("usage");
                });

            modelBuilder.Entity("Tracker.API.Models.UsageBuffer", b =>
                {
                    b.Property<int>("ComputerId")
                        .HasColumnName("computer_id");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("timestamp")
                        .HasColumnType("datetime");

                    b.Property<string>("UsedProgram")
                        .IsRequired()
                        .HasColumnName("used_program")
                        .HasAnnotation("MaxLength", 511);

                    b.HasKey("ComputerId", "Timestamp")
                        .HasName("PK_usage_buffer");

                    b.ToTable("usage_buffer");
                });

            modelBuilder.Entity("Tracker.API.Models.User", b =>
                {
                    b.Property<Guid>("UserUid")
                        .HasColumnName("user_uid");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("binary(64)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasAnnotation("MaxLength", 127);

                    b.HasKey("UserUid")
                        .HasName("PK_user");

                    b.ToTable("user");
                });
        }
    }
}
