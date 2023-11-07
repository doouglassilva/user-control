using System;
using System.Collections.Generic;
using Usuario.Application.Interfaces;
using Usuario.Domain.Entities;
using Usuario.Domain.Enums;
using Usuario.Domain.Interfaces;
using Usuario.DTO.DTO;
using Usuario.DTO.DTO.Mappers;

namespace Usuario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioDTO Criar(UsuarioDTO usuarioDTO)
        {
            DeveConterEmail(usuarioDTO.Email);
            JáExisteUsuarioComEmail(usuarioDTO.Email);
            DeveConterDataNascimento(usuarioDTO.DataNascimento);
            DataDeveSerMaiorQueHoje(usuarioDTO.DataNascimento);
            EscolaridadeInválida(usuarioDTO.Escolaridade.GetDescription());

            var usuario = _usuarioRepository.Criar(UsuarioMapper.UsuarioDTOParaUsuario(usuarioDTO));

            return UsuarioMapper.UsuarioParaUsuarioDTO(usuario);
        }

        public bool Deletar(int usuarioId)
        {
            DeveSerUsuario(usuarioId);
            return _usuarioRepository.Deletar(usuarioId);
        }

        public UsuarioDTO Obter(int usuarioId)
        {
            var usuario = _usuarioRepository.Obter(usuarioId);

            return UsuarioMapper.UsuarioParaUsuarioDTO(usuario);
        }

        public List<UsuarioDTO> ObterTodos()
        {
            var usuarios = _usuarioRepository.ObterTodos();

            return UsuarioMapper.ListaUsuariosParaRespostaUsuario(usuarios);
        }

        public bool Atualizar(UsuarioDTO usuarioDTO)
        {
            DeveSerUsuario(usuarioDTO.Id);
            return _usuarioRepository.Atualizar(UsuarioMapper.UsuarioDTOParaUsuario(usuarioDTO));
        }

        private bool DeveSerUsuario(int usuarioId)
        {
            var usuario = _usuarioRepository.Obter(usuarioId);
            if (usuario == null)
            {
                throw new ArgumentException("Usuário não encontrado!");
            }
            return true;
        }

        private static bool DeveConterEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email é obrigatório");
            }
            return true;
        }

        private bool JáExisteUsuarioComEmail(string email)
        {
            var existeUsuario = _usuarioRepository.JaExisteUsuarioComEmail(email);
            if (existeUsuario)
            {
                throw new ArgumentException("Já existe um usuário com esse email");
            }
            return true;
        }

        private static bool DeveConterDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento == DateTime.MinValue)
            {
                throw new ArgumentException("Data de nascimento é obrigatória");
            }
            return true;
        }

        private static bool DataDeveSerMaiorQueHoje(DateTime dataNascimento)
        {
            if (dataNascimento >= DateTime.Now)
            {
                throw new ArgumentException("A data de nascimento não pode ser maior que hoje.");
            }
            return true;
        }

        private static bool EscolaridadeInválida(string escolaridadeDescricao)
        {
            if (escolaridadeDescricao != EnumEscolaridade.Infantil.GetDescription() &&
                escolaridadeDescricao != EnumEscolaridade.Fundamental.GetDescription() &&
                escolaridadeDescricao != EnumEscolaridade.Medio.GetDescription() &&
                escolaridadeDescricao != EnumEscolaridade.Superior.GetDescription())
            {
                throw new ArgumentException("Escolaridade inválida.");
            }
            return true;
        }
    }
}
