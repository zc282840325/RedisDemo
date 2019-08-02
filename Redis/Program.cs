using ServiceStack.Redis;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            var redisManger = new RedisManagerPool("127.0.0.1:6379");
            var redis = redisManger.GetClient();
            var redisDemos = redis.As<Demo>();
            var newDemo = new Demo { ID=1,Name="zc",Age=28,Sex="男"};
            var newDemo2 = new Demo { ID = 2, Name = "zc", Age = 28, Sex = "男" };

            redisDemos.Store(newDemo);
            redisDemos.Store(newDemo2);
            var alldemo = redisDemos.GetAll();
            Demo saveTodo = redisDemos.GetById(newDemo.ID);              
            "Saved Todo: {0}".Print(alldemo.Dump());

            saveTodo.Name = "zc132";
            redisDemos.Store(saveTodo);

            var updateDemo = redisDemos.GetById(newDemo.ID);
            "Update Todo: {0}".Print(updateDemo.Dump());

            redisDemos.DeleteById(newDemo.ID);

            var remainDemo = redisDemos.GetAll();
            "All Todo: {0}".Print(remainDemo.Dump());

        }
    }
}
