﻿// <auto-generated />
using System;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(ObjectSearchContext))]
    [Migration("20210509035644_fk_coordinatorid")]
    partial class fk_coordinatorid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.Cycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cycles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam nec volutpat elit. Pellentesque sit amet ullamcorper leo. In dictum hendrerit tempus. Mauris ultrices ante eu leo elementum, in pretium neque semper. ",
                            EndDate = new DateTime(2021, 5, 9, 7, 24, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            StartDate = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            Title = "Облет леса"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ut maximus aliquam leo, eu congue neque consequat eget. Integer non nulla augue. Vestibulum odio est, posuere ac orci sed, mollis dapibus massa. Nullam mattis neque ac scelerisque euismod. Aliquam pretium nisi sed leo iaculis molestie ut ac erat.",
                            EndDate = new DateTime(2021, 5, 9, 7, 24, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            StartDate = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            Title = "Облет поля"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.DetectedObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDesired")
                        .HasColumnType("bit");

                    b.Property<int?>("MissionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("MissionId");

                    b.ToTable("DetectedObjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "На Севере лукоморья",
                            ImageId = 1,
                            IsDesired = false,
                            MissionId = 1,
                            Title = "Кот на дубе",
                            X = "53.22104557790858",
                            Y = "34.11112667059104"
                        },
                        new
                        {
                            Id = 2,
                            Description = "На Юго-Западе леса",
                            ImageId = 2,
                            IsDesired = false,
                            MissionId = 1,
                            Title = "Кот в камышах",
                            X = "53.21104557790858",
                            Y = "34.11012667059104"
                        },
                        new
                        {
                            Id = 3,
                            Description = "В деревне",
                            ImageId = 1,
                            IsDesired = true,
                            MissionId = 1,
                            Title = "Кот Матроскин",
                            X = "53.23204557790858",
                            Y = "34.12212667059104"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Желает жить дружно",
                            ImageId = 2,
                            IsDesired = false,
                            MissionId = 1,
                            Title = "Кот Леопольд",
                            X = "53.23104557790858",
                            Y = "34.13112667059104"
                        },
                        new
                        {
                            Id = 5,
                            Description = "В чаще",
                            ImageId = 2,
                            IsDesired = false,
                            Title = "Кот Баюн",
                            X = "53.21204557790858",
                            Y = "34.17212667059104"
                        },
                        new
                        {
                            Id = 6,
                            Description = "На Востоке",
                            ImageId = 3,
                            IsDesired = false,
                            MissionId = 2,
                            Title = "Кот в сапогах",
                            X = "53.25104557790858",
                            Y = "34.16012667059104"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CycleId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtyFindObject")
                        .HasColumnType("int");

                    b.Property<int>("QtyVerifiedObject")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeCreate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CycleId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CycleId = 1,
                            Path = "https://thumbs.dreamstime.com/b/%D0%BB%D0%B5%D1%81-%D1%81%D0%B2%D0%B5%D1%80%D1%85%D1%83-%D0%BB%D0%B5%D1%82%D0%BE%D0%BC-%D0%B2%D0%B8%D0%B4-%D1%81-%D0%B2%D0%BE%D0%B7%D0%B4%D1%83%D1%85%D0%B0-%D0%BE%D0%B1%D0%BE%D0%B5%D0%B2-%D0%BB%D0%B5%D1%81%D0%B0-153275483.jpg",
                            QtyFindObject = 1,
                            QtyVerifiedObject = 1,
                            TimeCreate = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473)
                        },
                        new
                        {
                            Id = 2,
                            CycleId = 1,
                            Path = "https://i.pinimg.com/736x/c5/dc/53/c5dc53070960ee2ea4fb07ed2ff325b3.jpg",
                            QtyFindObject = 1,
                            QtyVerifiedObject = 1,
                            TimeCreate = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473)
                        },
                        new
                        {
                            Id = 3,
                            CycleId = 1,
                            Path = "https://envato-shoebox-0.imgix.net/4c17/f9ef-0fc2-4571-8819-373327ab564c/trip+mix-12.jpg?auto=compress%2Cformat&fit=max&mark=https%3A%2F%2Felements-assets.envato.com%2Fstatic%2Fwatermark2.png&markalign=center%2Cmiddle&markalpha=18&w=700&s=e56aa60d45ab74037c9f43d3a088bbdf",
                            QtyFindObject = 1,
                            QtyVerifiedObject = 1,
                            TimeCreate = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473)
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Missions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoordinatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CoordinatorId");

                    b.ToTable("Operations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoordinatorId = 1,
                            Date = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            IsSuccess = false,
                            Title = "Поиск кота"
                        },
                        new
                        {
                            Id = 2,
                            CoordinatorId = 1,
                            Date = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            IsSuccess = true,
                            Title = "Поиск червя"
                        },
                        new
                        {
                            Id = 3,
                            CoordinatorId = 1,
                            Date = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            IsSuccess = true,
                            Title = "Поиск себя"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.OperationUser", b =>
                {
                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OperationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("OperationUser");

                    b.HasData(
                        new
                        {
                            OperationId = 1,
                            UserId = 2
                        },
                        new
                        {
                            OperationId = 1,
                            UserId = 4
                        },
                        new
                        {
                            OperationId = 2,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("LostTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("TargetStatusId")
                        .HasColumnType("int");

                    b.Property<int>("TargetTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("TargetStatusId");

                    b.HasIndex("TargetTypeId");

                    b.ToTable("Targets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Рыжий и пушистый",
                            LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            OperationId = 1,
                            TargetStatusId = 2,
                            TargetTypeId = 1,
                            Title = "Кот"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ленточный или кольчатый",
                            LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            OperationId = 2,
                            TargetStatusId = 3,
                            TargetTypeId = 1,
                            Title = "Червь"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Фундаментальная категория философского дискурса, которая фиксирует основу существования",
                            LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            OperationId = 3,
                            TargetStatusId = 3,
                            TargetTypeId = 1,
                            Title = "Бытие"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Объективная реальность, существующая вне и независимо от человеческого сознания",
                            LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            OperationId = 3,
                            TargetStatusId = 3,
                            TargetTypeId = 1,
                            Title = "Материя"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Состояние психической жизни организма, выражающееся в субъективном переживании событий внешнего мира и тела организма",
                            LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            OperationId = 3,
                            TargetStatusId = 3,
                            TargetTypeId = 1,
                            Title = "Сознание"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Мягкий и свежий",
                            LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            OperationId = 1,
                            TargetStatusId = 3,
                            TargetTypeId = 1,
                            Title = "Хлеб"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.TargetStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("TargetStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Найден"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Требует проверки!"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Не найден"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.TargetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("TargetTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Человек"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Автомобиль"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("bit");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.HasIndex("UserStatusId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Андрей",
                            IsBusy = false,
                            MiddleName = "Алексеевич",
                            SecondName = "Подоляко",
                            UserRoleId = 3,
                            UserStatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Максим",
                            IsBusy = false,
                            MiddleName = "Сергеевич",
                            SecondName = "Кириченко",
                            UserRoleId = 4,
                            UserStatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Дмитрий",
                            IsBusy = false,
                            MiddleName = "Булатицкий",
                            SecondName = "Иванович",
                            UserRoleId = 2,
                            UserStatusId = 1
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Андрей",
                            IsBusy = false,
                            MiddleName = "",
                            SecondName = "Селифонтов",
                            UserRoleId = 4,
                            UserStatusId = 1
                        });
                });

            modelBuilder.Entity("DataLayer.Models.UserPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPositions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 2,
                            X = "53.23676313746632",
                            Y = "34.111866214361854"
                        },
                        new
                        {
                            Id = 2,
                            UserId = 2,
                            X = "53.238406958742566",
                            Y = "34.0783918288512"
                        },
                        new
                        {
                            Id = 3,
                            UserId = 2,
                            X = "53.246727851106336",
                            Y = "34.067062448291985"
                        },
                        new
                        {
                            Id = 4,
                            UserId = 4,
                            X = "53.256690247883384",
                            Y = "34.029811613072425"
                        },
                        new
                        {
                            Id = 5,
                            UserId = 4,
                            X = "53.25833330694125",
                            Y = "34.05487493477459"
                        },
                        new
                        {
                            Id = 6,
                            UserId = 4,
                            X = "53.268190335912614",
                            Y = "34.10225374722882"
                        },
                        new
                        {
                            Id = 7,
                            UserId = 4,
                            X = "53.26007898803503",
                            Y = "34.19048819371207"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Title = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Title = "Руководитель ПСР"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Title = "Координатор ПСР"
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Title = "Участник ПСР"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Активен"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Неактивен"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.DetectedObject", b =>
                {
                    b.HasOne("DataLayer.Models.Image", "Image")
                        .WithMany("DetectedObjects")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Mission", "Mission")
                        .WithMany("DetectedObjects")
                        .HasForeignKey("MissionId");

                    b.Navigation("Image");

                    b.Navigation("Mission");
                });

            modelBuilder.Entity("DataLayer.Models.Image", b =>
                {
                    b.HasOne("DataLayer.Models.Cycle", "Cycle")
                        .WithMany("Images")
                        .HasForeignKey("CycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cycle");
                });

            modelBuilder.Entity("DataLayer.Models.Mission", b =>
                {
                    b.HasOne("DataLayer.Models.User", "User")
                        .WithMany("Missions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Models.Operation", b =>
                {
                    b.HasOne("DataLayer.Models.User", "User")
                        .WithMany("СontrolledOperations")
                        .HasForeignKey("CoordinatorId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Models.OperationUser", b =>
                {
                    b.HasOne("DataLayer.Models.Operation", "Operation")
                        .WithMany("Users")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.User", "User")
                        .WithMany("Operations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Models.Target", b =>
                {
                    b.HasOne("DataLayer.Models.Operation", "Operation")
                        .WithMany("Targets")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.TargetStatus", "TargetStatus")
                        .WithMany("Targets")
                        .HasForeignKey("TargetStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.TargetType", "TargetType")
                        .WithMany("Targets")
                        .HasForeignKey("TargetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("TargetStatus");

                    b.Navigation("TargetType");
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.HasOne("DataLayer.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.UserStatus", "UserStatus")
                        .WithMany("Users")
                        .HasForeignKey("UserStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");

                    b.Navigation("UserStatus");
                });

            modelBuilder.Entity("DataLayer.Models.UserPosition", b =>
                {
                    b.HasOne("DataLayer.Models.User", "User")
                        .WithMany("UserPositions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Models.Cycle", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("DataLayer.Models.Image", b =>
                {
                    b.Navigation("DetectedObjects");
                });

            modelBuilder.Entity("DataLayer.Models.Mission", b =>
                {
                    b.Navigation("DetectedObjects");
                });

            modelBuilder.Entity("DataLayer.Models.Operation", b =>
                {
                    b.Navigation("Targets");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DataLayer.Models.TargetStatus", b =>
                {
                    b.Navigation("Targets");
                });

            modelBuilder.Entity("DataLayer.Models.TargetType", b =>
                {
                    b.Navigation("Targets");
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Navigation("СontrolledOperations");

                    b.Navigation("Missions");

                    b.Navigation("Operations");

                    b.Navigation("UserPositions");
                });

            modelBuilder.Entity("DataLayer.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DataLayer.Models.UserStatus", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}