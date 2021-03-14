using System;
namespace WebApiFornecedor.Data
{
    public class DbContext
    {
        
        public string CaminhoBanco()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"base.json";
        }
    }
}
