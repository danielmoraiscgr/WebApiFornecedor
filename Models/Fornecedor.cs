using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using System.Linq;

namespace WebApiFornecedor.Models
{
    public class Fornecedor
    {
        public int id { get; set; }
        public string razaosocial { get; set; }
        public string nomeempresa { get; set; }
        public string ramoatividade { get; set; }

        // private List<Fornecedor> _listafor = new List<Fornecedor>();

        // public Fornecedor()
        // {
        //     _listafor.Add(new Fornecedor() { id = 1, razaosocial = "Fort Atacadista", nomeempresa = "Fort Atacadista", ramoatividade = "Atacado e Varejo" });
        //     _listafor.Add(new Fornecedor() { id = 2, razaosocial = "Comercio Pereira de Alimentos", nomeempresa = "Supermercados Comper", ramoatividade = "Atacado e Varejo" });
        //     _listafor.Add(new Fornecedor() { id = 3, razaosocial = "Atacadao", nomeempresa = "Atacadao", ramoatividade = "Atacado e Varejo" });
        //     _listafor.Add(new Fornecedor() { id = 4, razaosocial = "Farmacia Popular", nomeempresa = "Farmacia Popular", ramoatividade = "Medicamentos" });
        //     _listafor.Add(new Fornecedor() { id = 5, razaosocial = "Posto Ipiringa", nomeempresa = "Posto Ipiringa", ramoatividade = "Combustivel" });
        //     Console.Write(_listafor);
        // }

        public List<Fornecedor> ListaFornecedores()
        {
            var dbFornecedores = AppDomain.CurrentDomain.BaseDirectory + @"base.json";
            var json = File.ReadAllText(dbFornecedores);
            var listaFornecedores = JsonConvert.DeserializeObject<List<Fornecedor>>(json);

            return listaFornecedores; 
        }

        public bool AtualizarDbFor(List<Fornecedor> listaFornecedores)
        {
            var dbFornecedores = AppDomain.CurrentDomain.BaseDirectory + @"base.json";
            var json = JsonConvert.SerializeObject(listaFornecedores, Formatting.Indented);
            File.WriteAllText(dbFornecedores, json);
            return true;
        }

        public Fornecedor InserirFornecedor(Fornecedor fornec){
            Console.WriteLine(JsonConvert.SerializeObject(fornec));
            var ListaFornecedores = this.ListaFornecedores();
            var maxId = ListaFornecedores.Max(f => f.id); // Max using System.LINQ
            fornec.id = maxId + 1;      
            ListaFornecedores.Add(fornec);      
            AtualizarDbFor(ListaFornecedores);
            return fornec;
        }

        public Fornecedor AtualizarFornecedor(int id, Fornecedor fornec){
            Console.WriteLine(JsonConvert.SerializeObject(fornec));
            var ListaFornecedores = this.ListaFornecedores();
            var itemIndex = ListaFornecedores.FindIndex( p=> p.id == id);
            if (itemIndex >= 0) 
            {
                fornec.id = id;
                ListaFornecedores[itemIndex] = fornec;
                
            }
            else
            {
                return null;
            }           

            AtualizarDbFor(ListaFornecedores);
            return fornec;
        }

        public bool DeletarFornecedor(int id){
            var ListaFornecedores = this.ListaFornecedores(); 
            var itemIndex = ListaFornecedores.FindIndex( f => f.id == id);
            if (itemIndex >= 0)
            {
                ListaFornecedores.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }
            AtualizarDbFor(ListaFornecedores);
            return true; 
        }





    }
}
