using API.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static API.Busines.IRepositoryCRUD;

namespace API.Busines
{
    public interface IManagerCRUD
    {
        Response<bool> insertPeople(EntityPeople people);
        Response<EntityPeople> getPeople(int idPeople);
        Response<List<EntityPeople>> getListPeople();    

    }
    public class ManagerCRUD: IManagerCRUD
    {
        private IRepositoryCRUD _repository;
        private readonly SettingsDataAccess _dataBase;
        private readonly string _sectionDataBase = "DataBase";

        public ManagerCRUD(IConfiguration configuracion)
        {
            _dataBase = new SettingsDataAccess();
            configuracion.GetSection(_sectionDataBase).Bind(_dataBase);
            _repository = new RepositoryCRUD(_dataBase);
        }
        public Response<bool> insertPeople(EntityPeople people)
        {
            try
            {
                var response = _repository.insertPeople(people);
                return Response<bool>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<bool>.error(ex.Message);
            }
        }
        public Response<EntityPeople> getPeople(int idPeople)
        {
            try
            {
                var response = _repository.getPeople(idPeople);
                return Response<EntityPeople>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<EntityPeople>.error(ex.Message);
            }
        }


        public Response<List<EntityPeople>> getListPeople()
        {
            try
            {
                var response = _repository.getListPeople();
                return Response<List<EntityPeople>>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<List<EntityPeople>>.error(ex.Message);
            }
        }
            
    }
}
