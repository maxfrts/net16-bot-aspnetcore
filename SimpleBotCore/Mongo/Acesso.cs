using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Mongo
{
    public class Acesso
    {
        ConfigMongo conexao;
        MongoClient cliente { get; set; }
        IMongoDatabase db { get; set; }

        IMongoCollection<SimpleMessage> col {get; set;}

        public Acesso()
        {
            this.cliente = new MongoClient(conexao.Url);

            this.db = cliente.GetDatabase(conexao.Db);

            this.col = db.GetCollection<SimpleMessage>(conexao.Col);
        }

        public void InsereMensagemUsuario(SimpleMessage message)
        {
            this.col.InsertOne(message);
        }
    }
}
