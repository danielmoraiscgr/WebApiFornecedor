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

        public List<Fornecedor> ListaFornecedores()
        {
            var dbFornecedores = AppDomain.CurrentDomain.BaseDirectory + @"base.json";
            var json = File.ReadAllText(dbFornecedores);
            var listaFornecedores = JsonConvert.DeserializeObject<List<Fornecedor>>(json);
            Console.WriteLine(dbFornecedores);
            Console.WriteLine(listaFornecedores);
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
            var ListaFornecedores = this.ListaFornecedores();
            var maxId = ListaFornecedores.Max(f => f.id); // Max using System.LINQ
            fornec.id = maxId + 1;
            
            AtualizarDbFor(ListaFornecedores);
            return fornec;
        }

        public Fornecedor AtualizarFornecedor(int id, Fornecedor fornec){
            var ListaFornecedores = this.ListaFornecedores();
            var itemIndex = ListaFornecedores.FindIndex( f => f.id == id);
            if (itemIndex>=0) 
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
            if (itemIndex >=0)
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
