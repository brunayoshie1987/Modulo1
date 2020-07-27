using System;
using Modulo1.Dto;
using Modulo1.Service;
using System.Collections.Generic;


namespace Modulo1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome da Oportunidade");
            string oportunidadeNome = Console.ReadLine();
            Console.WriteLine("Digite o salario da oportunidade");
            string Salario = Console.ReadLine();
            
            
            OportunidadeService oportunidadeService = new OportunidadeService();

            var oportunidade = oportunidadeService.Salvar(oportunidadeNome, Salario);

            oportunidade.Candidatos = new List<Candidato>();

            Candidato candidato = new Candidato();
            candidato.nome = "João";
            candidato.Email = "joao@joao.com";
            candidato.Nota = 5;

            oportunidade.Candidatos.Add(candidato);

            candidato = new Candidato();
            candidato.nome = "maria";
            candidato.Email = "maria@maria.com";
            candidato.Nota = 8;

            oportunidade.Candidatos.Add(candidato);

            bool existeCandidato = true;

            while(existeCandidato == true)
            {

                candidato = new Candidato();
                Console.WriteLine("Digite o Nome do Candidato");
                candidato.nome = Console.ReadLine();
                Console.WriteLine("Digite o e-mail do candidato");
                candidato.Email = Console.ReadLine();
                Console.WriteLine("Digite a Nota do candidato");

                string nota = Console.ReadLine();
                if (nota == "")
                    candidato.Nota = 0;
                else
                    candidato.Nota = Convert.ToInt32(nota);

                
                candidato.nome = "maria";
                candidato.Email = "maria@maria.com";
                candidato.Nota = 8;

                oportunidade.Candidatos.Add(candidato);

                if (candidato.nome == "")
                    existeCandidato = false;
                else
                    oportunidade.Candidatos.Add(candidato);
            }
            Console.WriteLine("Digite o nome do candidato aprovado");
            string nomeCandidatoAprovado = Console.ReadLine();

            oportunidade = oportunidadeService.AtribuirCandidatoAprovado(oportunidade, nomeCandidatoAprovado);

            Console.WriteLine($"A oportunidade {oportunidade.nome} possui o salario no valor de {oportunidade.Salario}");

            if (oportunidade.Candidatos.Count > 0)
               
                   
            {


                Console.WriteLine("Estes são sop candidatos");

                oportunidade.Candidatos.ForEach(c =>
                {
                    if (c.Aprovado)

                        Console.WriteLine($" - {c.nome} ::: {c.Email}  ::: Nota: {c.Nota}[Aprovado]");
                    else
                        Console.WriteLine($" - {c.nome} ::: {c.Email}  ::: Nota: {c.Nota}");

                });
            }
        }
    }
}
