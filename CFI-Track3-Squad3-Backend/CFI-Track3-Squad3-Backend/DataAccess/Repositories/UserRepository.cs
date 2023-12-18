using AutoMapper;
using CFI_Track3_Squad3_Backend.DataAccess.Repositories.Interfaces;
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Entities;
using CFI_Track3_Squad3_Backend.Helper;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace CFI_Track3_Squad3_Backend.DataAccess.Repositories
{
    /// <summary>
    /// Clase de repositorio para la entidad User, que hereda de la clase base Repository e implementa la interfaz IUserRepository.
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase que recibe instancias del contexto de base de datos y AutoMapper.
        /// </summary>
        /// <param name="contextDB">Instancia del contexto de base de datos.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public UserRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los usuarios según el parámetro especificado.
        /// </summary>
        /// <param name="parameter">Parámetro para filtrar usuarios (0 para no eliminados, 1 para todos).</param>
        /// <returns>Lista de usuarios como objetos UserDTO.</returns>
        public virtual async Task<List<UserDTO>> GetAllUsers(int parameter)
        {
            try
            {
                if (parameter == 0)
                {
                    List<User> users = await _contextDB.Users.Include(user => user.Role).Where(user => user.IsDelete != true).ToListAsync();
                    return _mapper.Map<List<UserDTO>>(users);
                }
                else if (parameter == 1)
                {
                    List<User> users = await _contextDB.Users.Include(user => user.Role).ToListAsync();
                    return _mapper.Map<List<UserDTO>>(users);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene un usuario por su ID según el parámetro especificado.
        /// </summary>
        /// <param name="id">ID del usuario a obtener.</param>
        /// <param name="parameter">Parámetro para filtrar usuarios (0 para no eliminados, 1 para todos).</param>
        /// <returns>Usuario como objeto UserDTO o null si no se encuentra.</returns>
        public async Task<UserDTO> GetUserById(int id, int parameter)
        {
            try
            {
                User user = await _contextDB.Users.Include(x => x.Role).Where(x => x.Id == id).FirstOrDefaultAsync();

                if (user == null)
                {
                    return null;
                }

                if (user.IsDelete != true && parameter == 0)
                {
                    return _mapper.Map<UserDTO>(user);
                }
                if (parameter == 1)
                {
                    return _mapper.Map<UserDTO>(user);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos a partir de un objeto UserRegisterDTO.
        /// </summary>
        /// <param name="userRegisterDTO">Objeto que contiene la información del usuario a insertar.</param>
        /// <returns>true si la inserción es exitosa, false si hay un error.</returns>
        public virtual async Task<bool> InsertUser(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userRegisterDTO);
                var response = await base.Insert(user);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Actualiza un usuario existente en la base de datos a partir de un objeto UserRegisterDTO y un ID.
        /// </summary>
        /// <param name="userRegisterDTO">Objeto que contiene la información del usuario a actualizar.</param>
        /// <param name="id">ID del usuario a actualizar.</param>
        /// <param name="parameter">Parámetro para indicar el tipo de actualización (0 para reemplazar datos antiguos).</param>
        /// <returns>true si la actualización es exitosa, false si hay un error.</returns>
        public async Task<bool> UpdateUser(UserRegisterDTO userRegisterDTO, int id, int parameter)
        {
            try
            {
                var userFinding = await GetById(id);
                if (userFinding == null)
                {
                    return false;
                }
                if (parameter == 0)
                {
                    var user = _mapper.Map<User>(userRegisterDTO);
                    _mapper.Map(user, userFinding);
                    _contextDB.Update(userFinding);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un usuario de forma lógica o permanente según el parámetro especificado.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar.</param>
        /// <param name="parameter">Parámetro para indicar el tipo de eliminación (0 para eliminar de forma lógica, 1 para eliminar de forma permanente).</param>
        /// <returns>true si la eliminación es exitosa, false si hay un error.</returns>
        public async Task<bool> DeleteUserById(int id, int parameter)
        {
            try
            {
                User userFinding = await base.GetById(id);
                if (userFinding == null)
                {
                    return false;
                }
                if (parameter == 0)
                {
                    userFinding.IsDelete = true;
                    userFinding.DeletedTimeUtc = DateTime.UtcNow;
                    _contextDB.Update(userFinding);
                    return true;
                }
                if (parameter == 1)
                {
                    _contextDB.Users.Remove(userFinding);
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Autentica las credenciales de un usuario.
        /// </summary>
        /// <param name="authenticateDTO">Objeto que contiene las credenciales del usuario.</param>
        /// <returns>Usuario autenticado o null si no se encuentra.</returns>
        public async Task<User?> AuthenticateCredentials(AuthenticateDTO authenticateDTO)
        {
            try
            {
                return await _contextDB.Users.Include(user => user.Role).SingleOrDefaultAsync
                    (user => user.Email == authenticateDTO.Email && user.Password == PasswordEncryptHelper.EncryptPassword(authenticateDTO.Password, authenticateDTO.Email));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
