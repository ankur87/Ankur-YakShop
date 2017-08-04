using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using BusinessLogic;
using Models;


namespace WebApplication2.Controllers
{
    public class YakShopController : ApiController
    {
        private IHerd _herds;
        IComputeStock _stock;
        IList<IYak> _yaks;
        public YakShopController()
        {
            _yaks = new List<IYak>();
            _yaks.Add(new Yak() { Name = "Betty-1", Age = 4, Sex = "F" });
            _yaks.Add(new Yak() { Name = "Betty-2", Age = 8, Sex = "F" });
            _yaks.Add(new Yak() { Name = "Betty-3", Age = 9.5, Sex = "F" });

            _herds = new Herd(_yaks);
            _stock = new ComputeStock(_herds);
        }


        [HttpGet]
        [Route("yak-shop/stock/{id}")]
        public IHttpActionResult GetStock(int id)
        {

            _stock.GetMilkStock(id);
            _stock.GetSkinStock(id);

            var obj = new { milk = _herds.MilkStock.ToString(), skins = _herds.Skins.ToString() };

            return Ok(obj);
        }

        [HttpGet]
        [Route("yak-shop/herd/{id}")]
        public IHttpActionResult GetHerd(int id)
        {

            _stock.GetMilkStock(id);
            _stock.GetSkinStock(id);
            List<object> xyz = new List<object>();
            foreach (var obj1 in _yaks)
            {
                var obj2 = new { name = obj1.Name, age = obj1.Age + .01 * id, shaved = obj1.AgeLastShaved };
                xyz.Add(obj2);
            }

            return Ok(xyz);
        }
        [Route("yak-shop/order/{id}")]
        [HttpPost]
        public IHttpActionResult PostOrder(int id, [FromBody]Orders orders)
        {
            _stock.GetMilkStock(id);
            _stock.GetSkinStock(id);

            if (_herds.MilkStock >= orders.order.milk || _herds.Skins >= orders.order.skins)
            {
                if (_herds.MilkStock >= orders.order.milk && _herds.Skins >= orders.order.skins)
                {
                    return Content(HttpStatusCode.Created, new { milk = orders.order.milk, skins = orders.order.skins });
                }
                if (_herds.Skins < orders.order.skins)
                {
                    return Content(HttpStatusCode.PartialContent, new { milk = orders.order.milk });
                }
                if (_herds.MilkStock < orders.order.milk)
                {
                    return Content(HttpStatusCode.PartialContent, new { skins = orders.order.skins });
                }
            }
            return NotFound();

        }

        [Route("story1/{day}")]
        [HttpPost]
        public string story1Post(int day, [FromBody]herd herdss)
        {
            _stock.GetMilkStock(day);
            _stock.GetSkinStock(day);

            string ouput = "In Stock" + Environment.NewLine + "" + _herds.MilkStock + " litres of milk " + Environment.NewLine + " " + _herds.Skins +
                " skins of wool " + Environment.NewLine + ",  Herd " + Environment.NewLine + "";

            foreach (var ya in _herds.yaks)
            {
                ouput += ya.Name + " " + (ya.Age + .01 * day).ToString() + " years of age " + Environment.NewLine + "";
            }

            return ouput;
        }

        //[HttpGet]
        //[Route("yak-shop/getHerdData")]
        //public IHttpActionResult GetHerdData()
        //{
        //    herd abc = new herd()
        //    {
        //        labyak = new herdLabyak[] {
        //            new herdLabyak { age = 12, name = "ss", sex = "male" },
        //            new herdLabyak { age = 11, name = "s2121s", sex = "sssmale" }
        //        }
        //    };


        //    //var obj = new { milk = _herds.MilkStock.ToString(), skins = _herds.Skins.ToString() };

        //    return Ok(abc);
        //}

    }
}
