using AutoMapper;
using Desafio.Application.Features.Clientes.Commands.CreateCliente;
using Desafio.Application.Features.Clientes.Commands.DeleteCliente;
using Desafio.Application.Features.Clientes.Commands.UpdateCliente;
using Desafio.Application.Features.Clientes.Queries.GetClienteList;
using Desafio.Application.Features.Clientes.Queries.GetClientesExport;
using Desafio.Application.Features.Telefones.Commands.CreateTelefone;
using Desafio.Application.Features.Telefones.Commands.DeleteTelefone;
using Desafio.Application.Features.Telefones.Commands.UpdateTelefone;
using Desafio.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Desafio.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteListVm>().ReverseMap();
            CreateMap<Cliente, CreateClienteCommand>().ReverseMap();
            CreateMap<Cliente, UpdateClienteCommand>().ReverseMap();
            CreateMap<Cliente, DeleteClienteCommand>().ReverseMap();
            CreateMap<Cliente, ClienteTelefonesDto>().ReverseMap();
            CreateMap<Cliente, CreateClienteDto>().ReverseMap();
            CreateMap<Cliente, ClienteExportDto>().ReverseMap();

            CreateMap<Telefone, UpdateTelefoneCommand>().ReverseMap();
            CreateMap<Telefone, DeleteTelefoneCommand>().ReverseMap();
            CreateMap<Telefone, CreateTelefoneCommand>().ReverseMap();
            CreateMap<Telefone, CreateTelefoneDto>().ReverseMap(); 
            CreateMap<Telefone, ClienteTelefonesDto>().ReverseMap();
            CreateMap<Telefone, CreateClienteTelefoneDto>().ReverseMap();

        }
    }
}
