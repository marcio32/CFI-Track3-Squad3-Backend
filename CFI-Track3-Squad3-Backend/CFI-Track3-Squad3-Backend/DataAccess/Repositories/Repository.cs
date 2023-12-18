﻿using CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces;
using CFI_Track3_Squad3_Backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories
{
    /// <summary>
    /// Implementación para operaciones CRUD en la base de datos.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que se manejará en el repositorio.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ContextDB _contextDB;
        ///// <summary>
        ///// Constructor para inicializar el repositorio con el contexto de la base de datos.
        ///// </summary>
        ///// <param name="contextDB">Contexto de la base de datos.</param>
        public Repository(ContextDB contextDB) 
        {
            _contextDB = contextDB;
        }

        /// <summary>
        /// Obtiene todas las entidades del tipo T.
        /// </summary>
        /// <returns>Una lista de todas las entidades.</returns>
        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                var entity = await _contextDB.Set<T>().ToListAsync();
                return entity;
            }
            catch (Exception)
            {

                return null;
            }
        }

        ///// <summary>
        ///// Obtiene una entidad por su ID.
        ///// </summary>
        ///// <param name="id">ID de la entidad a buscar.</param>
        ///// <returns>La entidad encontrada o null si no se encuentra.</returns>
        public virtual async Task<T> GetById(int id)
        {
            try
            {
                var entity = await _contextDB.Set<T>().FindAsync(id);
                if (entity != null)
                {
                    return entity;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///// <summary>
        ///// Inserta una nueva entidad en la base de datos.
        ///// </summary>
        ///// <param name="entity">Entidad a insertar.</param>
        ///// <returns>True si la inserción fue exitosa, False en caso contrario.</returns>
        public virtual async Task<bool> Insert(T entity)
        {
            try
            {
                _contextDB.Set<T>().Add(entity);
                await _contextDB.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;                
            }
        }

        ///// <summary>
        ///// Actualiza una entidad existente en la base de datos.
        ///// </summary>
        ///// <param name="entity">Entidad a actualizar.</param>
        ///// <returns>True si la actualización fue exitosa, False en caso contrario.</returns>
        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                _contextDB.Set<T>().Update(entity);
                await _contextDB.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        ///// <summary>
        ///// Elimina una entidad de la base de datos.
        ///// </summary>
        ///// <param name="entity">Entidad a eliminar.</param>
        ///// <returns>True si la eliminación fue exitosa, False en caso contrario.</returns>
        public virtual async Task<bool> DeleteHardById(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity != null)
                {
                    _contextDB.Set<T>().Remove(entity);
                    
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;                
            }
        }

    }
}
