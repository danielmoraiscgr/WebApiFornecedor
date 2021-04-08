using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using System.Linq;
using WebApiFornecedor.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApiFornecedor.Models
{
    public class Fornecedor
    {
        public int id { get; set; }
        public string razaosocial { get; set; }
        public string nomeempresa { get; set; }
        public string ramoatividade { get; set; }
        public string data { get; set; }

        private readonly DbContext _dbContext;

        public Fornecedor()
        {
            _dbContext = new DbContext();
        }

        public List<Fornecedor> ListaFornecedores()
        {
            var json = File.ReadAllText(_dbContext.CaminhoBanco());
            var listaFornecedores = JsonConvert.DeserializeObject<List<Fornecedor>>(json);

            return listaFornecedores; 
        }

        public bool AtualizarDbFor(List<Fornecedor> listaFornecedores)
        {
            var json = JsonConvert.SerializeObject(listaFornecedores, Formatting.Indented);
            File.WriteAllText(_dbContext.CaminhoBanco(), json);
            return true;
        }

        public Fornecedor InserirFornecedor(Fornecedor fornec){
            var ListaFornecedores = this.ListaFornecedores();
            var maxId = ListaFornecedores.Max(f => f.id);
            fornec.id = maxId + 1;      
            ListaFornecedores.Add(fornec);      
            AtualizarDbFor(ListaFornecedores);
            return fornec;
        }

        public Fornecedor AtualizarFornecedor(int id, Fornecedor fornec){          
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
