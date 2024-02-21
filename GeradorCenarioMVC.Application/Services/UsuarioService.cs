using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository context, IMapper mapper)
        {
            _usuarioRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var UsuariosEntity = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(UsuariosEntity);
        }

        public async Task<UsuarioDTO> GetByIdAsync(int? id)
        {
            var UsuarioEntity = await _usuarioRepository.GetByIdAsync(id);
            return _mapper.Map<UsuarioDTO>(UsuarioEntity);
        }

        public async Task<UsuarioDTO> CreateAsync(UsuarioDTO entityDTO)
        {
            var UsuarioEntity = _mapper.Map<Usuario>(entityDTO);
            await _usuarioRepository.CreateAsync(UsuarioEntity);
            return entityDTO;
        }

        public async Task<UsuarioDTO> UpdateAsync(UsuarioDTO entityDTO)
        {
            var UsuarioEntity = _mapper.Map<Usuario>(entityDTO);
            await _usuarioRepository.UpdateAsync(UsuarioEntity);
            return entityDTO;
        }

        public async Task<UsuarioDTO> RemoveAsync(UsuarioDTO entityDTO)
        {
            var UsuarioEntity = _usuarioRepository.GetByIdAsync(entityDTO.id).Result;
            await _usuarioRepository.RemoveAsync(UsuarioEntity);
            return entityDTO;
        }
                

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

    }
}








