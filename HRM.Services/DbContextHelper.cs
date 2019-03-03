﻿using HRM.Common;
using HRM.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class DbContextHelper
    {
        HRMDbContext _dbcontext;

        public DbContextHelper()
        {
            _dbcontext = new HRMDbContext();
        }

        public void AttachToContext<T>(T entity) where T : class, IRecordInfo
        {
            try
            {
                var entry = _dbcontext.Entry(entity);

                if (entity.ID == 0)
                {
                    AddEntityValues(entity);
                }

                if (entry.State == EntityState.Detached)
                {
                    var attachedEntity = FindExistingEntity<T>(entity.ID);
                    if (EntityExists(attachedEntity))
                    {
                        UpdateEntityValues(attachedEntity, entity);
                    }
                    else
                    {
                        entry.State = EntityState.Modified;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public T FindExistingEntity<T>(int id) where T : class
        {
            var set = _dbcontext.Set<T>();
            return set.Find(id);
        }

        public void AddEntityValues<T>(T newItem) where T : class
        {
            _dbcontext.Set<T>().Add(newItem);
            _dbcontext.SaveChanges();
        }

        public void UpdateEntityValues<T>(T existing, T updated) where T : class
        {
            var attachedEntry = _dbcontext.Entry(existing);
            attachedEntry.CurrentValues.SetValues(updated);
            _dbcontext.SaveChanges();
        }

        public void DeleteEntity<T>(T entity) where T : class
        {
            _dbcontext.Set<T>().Remove(entity);
            _dbcontext.SaveChanges();
        }

        private bool EntityExists(object entity)
        {
            return entity != null;
        }
    }
}
