﻿
using APIDeps.Dtos;
using APIDeps.Models;

namespace APIDeps.Interfaces
{
    public interface IPortalTransparenciaAPI
    {
        Task<ResponseGenerico<List<PepCpfModel>>> PepConsultaPorCPF(string cpf);
    }
}
