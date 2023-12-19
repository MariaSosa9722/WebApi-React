using Domain.Dto;
using Domain.Entities;

namespace WepApi.Services.IServices
{
    public interface IUsuarioServices
    {

        public Task<Response<List<Usuario>>> GetAll();
        public Task<Response<Usuario>> GetbyId(int id);
        public Task<Response<Usuario>> Create(UsuarioResponse request);
        public Task<Response<Usuario>> Update(UsuarioResponse request, int id);
        public Task<Response<Usuario>> Delete(int id);

    }
}
