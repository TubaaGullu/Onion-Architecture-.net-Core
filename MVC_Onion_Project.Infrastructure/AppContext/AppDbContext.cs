using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVC_Onion_Project.Domain.Core.Base;
using MVC_Onion_Project.Domain.Core.Interfaces;
using MVC_Onion_Project.Domain.Entities;
using MVC_Onion_Project.Domain.Enums;
using MVC_Onion_Project.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace MVC_Onion_Project.Infrastructure.AppContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<CategoriesBooks> CategoriesBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = Guid.Parse("9e107d9d-5168-4a95-9e73-2ce83f1dd3d0"),
                Name = "Ihsan",
                Surname = "Oktay Anar",
                DateofBirth = new DateTime(1960, 6, 8),
                UpdateBy = null,
                UpdatedDate = null,
                CreateBy = "Kullanıcı bulunamadı",
                CreatedDate = DateTime.Now,
                Status = Status.Created,
                DeleteBy = null,
                DeletedDate = null
            },
             new Author
             {
                 Id = Guid.Parse("63609ebd-5a72-4115-d141-08db95addb04"),
                 Name = "Cal",
                 Surname = "Newport",
                 DateofBirth = new DateTime(1982, 6, 23),
                 UpdateBy = null,
                 UpdatedDate = null,
                 CreateBy = "Kullanıcı bulunamadı",
                 CreatedDate = DateTime.Now,
                 Status = Status.Created,
                 DeleteBy = null,
                 DeletedDate = null
             },
             new Author
             {
                 Id = Guid.Parse("680f2198-c3f2-43c0-d140-08db95addb04"),
                 Name = "Mark",
                 Surname = "Twain",
                 DateofBirth = new DateTime(1835, 11, 30),
                 UpdateBy = null,
                 UpdatedDate = null,
                 CreateBy = "Kullanıcı bulunamadı",
                 CreatedDate = DateTime.Now,
                 Status = Status.Created,
                 DeleteBy = null,
                 DeletedDate = null
             });
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = Guid.Parse("2a7004bb-0c1c-430f-30fd-08db8d1ff64e"),
                Name = "Kişisel Gelişim",
                Description = "Kişisel gelişim kategorisi açıklaması.",
                UpdateBy = null,
                UpdatedDate = null,
                CreateBy = "Kullanıcı bulunamadı",
                CreatedDate = DateTime.Now,
                Status = Status.Created,
                DeleteBy = null,
                DeletedDate = null
            },
            new Category
            {
                Id = Guid.Parse("0a973472-f620-419f-d50a-08db8d23f378"),
                Name = "Psikoloji",
                Description = "Psikoloji kategorisi açıklaması.",
                UpdateBy = null,
                UpdatedDate = null,
                CreateBy = "Kullanıcı bulunamadı",
                CreatedDate = DateTime.Now,
                Status = Status.Created,
                DeleteBy = null,
                DeletedDate = null
            },
            new Category
            {
                Id = Guid.Parse("e4195304-94aa-4b27-6094-08db8dc31b09"),
                Name = "Tarih",
                Description = "Tarih kategorisi açıklaması.",
                UpdateBy = null,
                UpdatedDate = null,
                CreateBy = "Kullanıcı bulunamadı",
                CreatedDate = DateTime.Now,
                Status = Status.Created,
                DeleteBy = null,
                DeletedDate = null
            },
            new Category
            {
                Id = Guid.Parse("25cb3479-fb99-4e1f-06bc-08db8dcf64a6"),
                Name = "Roman",
                Description = "Roman kategorisi açıklaması.",
                UpdateBy = null,
                UpdatedDate = null,
                CreateBy = "Kullanıcı bulunamadı",
                CreatedDate = DateTime.Now,
                Status = Status.Created,

            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("b58a002a-ff06-45e2-c755-08db9523f708"),
                Name = "Puslu Kıtalar Atlası",
                PublicationDate = new DateTime(1995, 1, 1),
                AuthorId = Guid.Parse("9e107d9d-5168-4a95-9e73-2ce83f1dd3d0"),
                CreateBy = "Kullanıcı bulunamadı",
                CreatedDate = DateTime.Now,
                Status = Status.Created,
                DeleteBy = null,
                DeletedDate = null
            });


            modelBuilder.Entity<CategoriesBooks>().HasData(
                new CategoriesBooks
                {
                    Id = Guid.NewGuid(),
                    BookId = Guid.Parse("b58a002a-ff06-45e2-c755-08db9523f708"),
                    CategoryId = Guid.Parse("e4195304-94aa-4b27-6094-08db8dc31b09"),
                    CreateBy = "Kullanıcı bulunamadı",
                    CreatedDate = DateTime.Now,
                    Status = Status.Created
                },
                new CategoriesBooks
                {
                    Id = Guid.NewGuid(),
                    BookId = Guid.Parse("b58a002a-ff06-45e2-c755-08db9523f708"),
                    CategoryId = Guid.Parse("25cb3479-fb99-4e1f-06bc-08db8dcf64a6"),
                    CreateBy = "Kullanıcı bulunamadı",
                    CreatedDate = DateTime.Now,
                    Status = Status.Created
                });


            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.Parse("564cea4e-79e9-4be3-801a-08db95adf750"),
                    Name = "Pür-Dikkat",
                    PublicationDate = new DateTime(1999, 1, 1),
                    AuthorId = Guid.Parse("63609ebd-5a72-4115-d141-08db95addb04"),
                    CreateBy = "Kullanıcı bulunamadı",
                    CreatedDate = DateTime.Now,
                    Status = Status.Created,
                    DeleteBy = null,
                    DeletedDate = null
                });

            modelBuilder.Entity<CategoriesBooks>().HasData(
                new CategoriesBooks
                {
                    Id = Guid.NewGuid(),
                    BookId = Guid.Parse("564cea4e-79e9-4be3-801a-08db95adf750"),
                    CategoryId = Guid.Parse("25cb3479-fb99-4e1f-06bc-08db8dcf64a6"),
                    CreateBy = "Kullanıcı bulunamadı",
                    CreatedDate = DateTime.Now,
                    Status = Status.Created
                }
            );
        }




        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var userId = "user bulunamadı";

            foreach (var entry in entries)
            {
                SetIfAdded(entry, userId);
                SetIfModified(entry, userId);
                SetIfDeleted(entry, userId);
            }
        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State != EntityState.Deleted)
            {
                return;
            }

            if (entry.Entity is not AuditableEntity entity)
            {
                return;
            }

            entry.State = EntityState.Modified;
            entity.DeletedDate = DateTime.Now;
            entity.Status = Domain.Enums.Status.Deleted;
            entity.DeleteBy = userId;
        }

        private void SetIfModified(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.Status = Domain.Enums.Status.Updated;
                entry.Entity.UpdateBy = userId;
                entry.Entity.UpdatedDate = DateTime.Now;
            }
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Status = Domain.Enums.Status.Created;
                entry.Entity.CreatedDate = DateTime.Now;
                entry.Entity.CreateBy = userId;
            }
        }

    }
}
