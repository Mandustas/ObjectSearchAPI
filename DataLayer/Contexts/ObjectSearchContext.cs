using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts
{
    public class ObjectSearchContext : DbContext
    {
        public ObjectSearchContext(DbContextOptions options) : base(options) { }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<DetectedObject> DetectedObjects { get; set; }
        //public DbSet<ObjectStatus> ObjectStatuses { get; set; }
        public DbSet<TargetStatus> TargetStatuses { get; set; }
        public DbSet<TargetType> TargetTypes { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<OperationUser> OperationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationUser>()
              .HasKey(e => new { e.OperationId, e.UserId });

            modelBuilder.Entity<User>(
                entity =>
                {
                    entity.HasOne(d => d.UserRole)
                        .WithMany(p => p.Users)
                        .HasForeignKey("UserRoleId");
                });

            modelBuilder.Entity<User>(
                entity =>
                {
                    entity.HasOne(d => d.UserStatus)
                        .WithMany(p => p.Users)
                        .HasForeignKey("UserStatusId");
                });

            modelBuilder.Entity<Target>(
                entity =>
                {
                    entity.HasOne(d => d.TargetStatus)
                        .WithMany(p => p.Targets)
                        .HasForeignKey("TargetStatusId");
                });

            modelBuilder.Entity<Target>(
                entity =>
                {
                    entity.HasOne(d => d.TargetType)
                        .WithMany(p => p.Targets)
                        .HasForeignKey("TargetTypeId");
                });

            modelBuilder.Entity<Target>(
                entity =>
                {
                    entity.HasOne(d => d.Operation)
                        .WithMany(p => p.Targets)
                        .HasForeignKey("OperationId");
                });

            modelBuilder.Entity<Mission>(
                entity =>
                {
                    entity.HasOne(d => d.User)
                        .WithMany(p => p.Missions)
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity<Image>(
                entity =>
                {
                    entity.HasOne(d => d.Cycle)
                        .WithMany(p => p.Images)
                        .HasForeignKey("CycleId");
                });

            modelBuilder.Entity<DetectedObject>(
                entity =>
                {
                    entity.HasOne(d => d.Image)
                        .WithMany(p => p.DetectedObjects)
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity<DetectedObject>(
                entity =>
                {
                    entity.HasOne(d => d.Mission)
                        .WithMany(p => p.DetectedObjects)
                        .HasForeignKey("MissionId");
                });


            modelBuilder.Entity<UserPosition>(
                entity =>
                {
                    entity.HasOne(d => d.User)
                        .WithMany(p => p.UserPositions)
                        .HasForeignKey("UserId");
                });

            //modelBuilder.Entity<OperationUser>(
            //    entity =>
            //    {
            //        entity.HasOne(d => d.Operation)
            //            .WithMany(p => p.Users)
            //            .HasForeignKey("OperationId");
            //    });

            //modelBuilder.Entity<OperationUser>(
            //    entity =>
            //    {
            //        entity.HasOne(d => d.User)
            //            .WithMany(p => p.Operations)
            //            .HasForeignKey("UserId");
            //    });

            modelBuilder
                .Entity<Operation>()
                .HasMany(c => c.Users)
                .WithMany(s => s.Operations)
                .UsingEntity<OperationUser>(
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.OperationUsers)
                    .HasForeignKey(pt => pt.UserId),
                j => j
                    .HasOne(pt => pt.Operation)
                    .WithMany(p => p.OperationUsers)
                    .HasForeignKey(pt => pt.OperationId),
                j => 
                {
                    j.HasKey(t => new { t.OperationId, t.UserId });
                });

            modelBuilder.Entity<Operation>(
                entity =>
                {
                    entity.HasOne(d => d.Coordinator)
                        .WithMany(p => p.СontrolledOperations)
                        .HasForeignKey("CoordinatorId");
                });


            //modelBuilder.Entity<DetectedObject>(
            //    entity =>
            //    {
            //        entity.HasOne(d => d.ObjectStatus)
            //            .WithMany(p => p.DetectedObjects)
            //            .HasForeignKey("ObjectStatusId");
            //    });

            modelBuilder.Entity<Target>().HasData(
                new Target[]
                {
                    new Target { Id = 1, Title = "Кот", Description = "Рыжий и пушистый", LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),OperationId=1,TargetStatusId=2,TargetTypeId=1},
                    new Target { Id = 2, Title = "Червь", Description = "Ленточный или кольчатый", LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473) , OperationId=2,TargetStatusId=3,TargetTypeId=1},
                    new Target { Id = 3, Title = "Бытие", Description = "Фундаментальная категория философского дискурса, которая фиксирует основу существования", LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473) , OperationId=3,TargetStatusId=3,TargetTypeId=1},
                    new Target { Id = 4, Title = "Материя", Description = "Объективная реальность, существующая вне и независимо от человеческого сознания", LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473)  , OperationId=3,TargetStatusId=3,TargetTypeId=1},
                    new Target { Id = 5, Title = "Сознание", Description = "Состояние психической жизни организма, выражающееся в субъективном переживании событий внешнего мира и тела организма", LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473)  , OperationId=3,TargetStatusId=3,TargetTypeId=1},
                    new Target { Id = 6, Title = "Хлеб", Description = "Мягкий и свежий", LostTime = new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),OperationId=1,TargetStatusId=3,TargetTypeId=1},


                });

            modelBuilder.Entity<UserRole>().HasData(
            new UserRole[]
                {
                    new UserRole { Id = 1, Title = "Администратор", Description="" },
                    new UserRole { Id = 2, Title = "Руководитель ПСР" , Description=""},
                    new UserRole { Id = 3, Title = "Координатор ПСР" , Description=""},
                    new UserRole { Id = 4, Title = "Участник ПСР", Description=""},
                });
            modelBuilder.Entity<UserStatus>().HasData(
                new UserStatus[]
                {
                    new UserStatus { Id = 1, Title = "Активен" },
                    new UserStatus { Id = 2, Title = "Неактивен" }
                });


            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = 1, FirstName="Андрей", SecondName="Подоляко", MiddleName = "Алексеевич", IsBusy=false , UserRoleId = 3, UserStatusId = 1},
                    new User { Id = 2, FirstName="Максим", SecondName="Кириченко", MiddleName = "Сергеевич", IsBusy=false , UserRoleId = 4, UserStatusId = 1},
                    new User { Id = 3, FirstName="Дмитрий", SecondName="Иванович", MiddleName = "Булатицкий", IsBusy=false , UserRoleId = 2, UserStatusId = 1},
                    new User { Id = 4, FirstName="Андрей", SecondName="Селифонтов",MiddleName = "", IsBusy=false , UserRoleId = 4, UserStatusId = 1}
                });

            modelBuilder.Entity<Operation>().HasData(
                new Operation[]
                {
                    new Operation { Id = 1,  Title = "Поиск кота", CoordinatorId=1, Date=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),IsSuccess=false},
                    new Operation { Id = 2,  Title = "Поиск червя", CoordinatorId=1, Date=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),IsSuccess=true },
                    new Operation { Id = 3,  Title = "Поиск себя", CoordinatorId=1, Date=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473),IsSuccess=true },
                });

            modelBuilder.Entity<Mission>().HasData(
                new Mission[]
                {
                    new Mission { Id = 1, UserId = 2},
                    new Mission { Id = 2, UserId = 4},
                });

            modelBuilder.Entity<Cycle>().HasData(
                new Cycle[]
                {
                    new Cycle { Id = 1, Title="Облет леса", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam nec volutpat elit. Pellentesque sit amet ullamcorper leo. In dictum hendrerit tempus. Mauris ultrices ante eu leo elementum, in pretium neque semper. ",StartDate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), EndDate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473).AddMinutes(20)},
                    new Cycle { Id = 2, Title="Облет поля", Description="Ut maximus aliquam leo, eu congue neque consequat eget. Integer non nulla augue. Vestibulum odio est, posuere ac orci sed, mollis dapibus massa. Nullam mattis neque ac scelerisque euismod. Aliquam pretium nisi sed leo iaculis molestie ut ac erat.",StartDate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), EndDate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473).AddMinutes(20)},
                });

            modelBuilder.Entity<Image>().HasData(
                new Image[]
                {
                    new Image { Id = 1, Path="https://thumbs.dreamstime.com/b/%D0%BB%D0%B5%D1%81-%D1%81%D0%B2%D0%B5%D1%80%D1%85%D1%83-%D0%BB%D0%B5%D1%82%D0%BE%D0%BC-%D0%B2%D0%B8%D0%B4-%D1%81-%D0%B2%D0%BE%D0%B7%D0%B4%D1%83%D1%85%D0%B0-%D0%BE%D0%B1%D0%BE%D0%B5%D0%B2-%D0%BB%D0%B5%D1%81%D0%B0-153275483.jpg", QtyFindObject=1, QtyVerifiedObject=1,TimeCreate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), CycleId=1},
                    new Image { Id = 2, Path="https://i.pinimg.com/736x/c5/dc/53/c5dc53070960ee2ea4fb07ed2ff325b3.jpg", QtyFindObject=1, QtyVerifiedObject=1,TimeCreate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), CycleId=1},
                    new Image { Id = 3, Path="https://envato-shoebox-0.imgix.net/4c17/f9ef-0fc2-4571-8819-373327ab564c/trip+mix-12.jpg?auto=compress%2Cformat&fit=max&mark=https%3A%2F%2Felements-assets.envato.com%2Fstatic%2Fwatermark2.png&markalign=center%2Cmiddle&markalpha=18&w=700&s=e56aa60d45ab74037c9f43d3a088bbdf", QtyFindObject=1, QtyVerifiedObject=1,TimeCreate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473), CycleId=1},
                });

            modelBuilder.Entity<DetectedObject>().HasData(
                new DetectedObject[]
                {
                    new DetectedObject { Id = 1, X="53.22104557790858", Y="34.11112667059104", Title = "Кот на дубе", Description="На Севере лукоморья",ImageId=1, MissionId=1},
                    new DetectedObject { Id = 2, X="53.21104557790858", Y="34.11012667059104", Title = "Кот в камышах", Description="На Юго-Западе леса", ImageId=2, MissionId=1},
                    new DetectedObject { Id = 3, X="53.23204557790858", Y="34.12212667059104", Title = "Кот Матроскин", Description="В деревне", ImageId=1, MissionId=1, IsDesired=true},
                    new DetectedObject { Id = 4, X="53.23104557790858", Y="34.13112667059104", Title = "Кот Леопольд", Description="Желает жить дружно", ImageId=2, MissionId=1, IsDesired=false},
                    new DetectedObject { Id = 5, X="53.21204557790858", Y="34.17212667059104", Title = "Кот Баюн", Description="В чаще", ImageId=2},
                    new DetectedObject { Id = 6, X="53.25104557790858", Y="34.16012667059104", Title = "Кот в сапогах", Description="На Востоке",ImageId=3, MissionId=2},
                });

            //modelBuilder.Entity<ObjectStatus>().HasData(
            //    new ObjectStatus[]
            //    {
            //        new ObjectStatus { Id = 1, Title = "Не распределен" },
            //        new ObjectStatus { Id = 2, Title = "Распределен" },
            //        new ObjectStatus { Id = 3, Title = "Проверен" },
            //    });

            modelBuilder.Entity<TargetStatus>().HasData(
                new TargetStatus[]
                {
                    new TargetStatus { Id = 1, Title = "Найден"},
                    new TargetStatus { Id = 2, Title = "Требует проверки!" },
                    new TargetStatus { Id = 3, Title = "Не найден"},
                });

            modelBuilder.Entity<TargetType>().HasData(
                new TargetType[]
                {
                    new TargetType { Id = 1, Title = "Человек" },
                    new TargetType { Id = 2, Title = "Автомобиль" },
                });

            modelBuilder.Entity<UserPosition>().HasData(
                new UserPosition[]
                {
                    new UserPosition { Id = 1, X = "53.23676313746632", Y = "34.111866214361854" , UserId = 2 },
                    new UserPosition { Id = 2, X = "53.238406958742566", Y = "34.0783918288512" , UserId = 2},
                    new UserPosition { Id = 3, X = "53.246727851106336", Y = "34.067062448291985" , UserId = 2},
                    new UserPosition { Id = 4, X = "53.256690247883384", Y = "34.029811613072425" , UserId = 4},
                    new UserPosition { Id = 5, X = "53.25833330694125", Y = "34.05487493477459" , UserId = 4},
                    new UserPosition { Id = 6, X = "53.268190335912614", Y = "34.10225374722882" , UserId = 4},
                    new UserPosition { Id = 7, X = "53.26007898803503", Y = "34.19048819371207" , UserId = 4},
                });

            modelBuilder.Entity<OperationUser>().HasData(
                new OperationUser[]
                {
                    new OperationUser { OperationId = 1, UserId = 2 },
                    new OperationUser { OperationId = 1, UserId = 4 },
                    new OperationUser { OperationId = 2, UserId = 4 },
                });


        }
    }
}
