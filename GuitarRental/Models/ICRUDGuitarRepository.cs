using GuitarRental.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarRental.Models
{
    public interface ICRUDGuitarRepository
    {
        Guitar Add(Guitar guitar);
        void Delete(int id);
        Guitar Update(Guitar guitar);
        Guitar FindById(int id);
        IList<Guitar> FindAll();
    }

    public class EFCRUDGuitarRepository : ICRUDGuitarRepository
    {
        private AppDbContext context;
        public EFCRUDGuitarRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Guitar Add(Guitar guitar)
        {
            EntityEntry<Guitar> entityEntry = context.Guitars.Add(guitar);
            context.SaveChanges();
            return entityEntry.Entity;
        }
        public void Delete(int id)
        {
            context.Guitars.Remove(context.Guitars.Find(id));
            context.SaveChanges();

        }
        public Guitar FindById(int id)
        {
            return context.Guitars.Find(id);
        }
        public IList<Guitar> FindAll()
        {
            return context.Guitars.ToList();
        }
        public Guitar Update(Guitar guitar)
        {
            var entity = context.Guitars.Update(guitar).Entity;
            context.SaveChanges();
            return entity;
        }
    }
}
