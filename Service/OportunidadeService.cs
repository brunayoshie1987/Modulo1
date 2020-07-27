using Modulo1.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo1.Service
{
    public class OportunidadeService
    {
        public Oportunidade Salvar(string nome, string salario)
        {
            Oportunidade oportunidade = new Oportunidade();
            oportunidade.nome = nome;
            oportunidade.Salario = salario;

            return oportunidade;
        }

        public Oportunidade AtribuirCandidatoAprovado(Oportunidade oportunidade,string nomeCandidato)
        {
            oportunidade.Candidatos.ForEach(c =>
            {
                if (c.nome == nomeCandidato)
                    c.Aprovado = true;
            });
                  return oportunidade;

        }

    }
}
