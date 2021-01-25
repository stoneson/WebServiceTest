using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;
using HCenter;

namespace WebServiceTest
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService//, IServiceTest
    {
        private static readonly string[] Summaries = new[]
          {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        [WebMethod]
        public void DoWork()
        {
            HCenter.CommonUtils.log4Helper.Info($"DoWork: {DateTime.Now}");
        }

        [WebMethod]
        public List<WeatherForecast> HelloWorld()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                code = index,
                msg = "成功"+ index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();
            //return "Hello World";
        }
        [WebMethod]
        public int GetInt(int a, int b)
        {
            return b + a;
        }
        [WebMethod]
        public DateTime GetDate()
        {
            var rng = new Random();
            return DateTime.Now;
        }

        [WebMethod]
        public WeatherForecast getBySummarie(string summarie)
        {
            var rng = new Random();
            var ls = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                code = index,
                msg = "成功" + index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
             .ToList();
            var fd = ls.FirstOrDefault(f => f.Summary == summarie);
            if (fd == null) fd = ls.FirstOrDefault();
            return fd;
        }
        [WebMethod]
        public string AddCar(MyCar MyCar)
        {
            var _car = MyCar;

            return ResponseResultObj.Success(_car, "Success").ToJson();
        }
        [WebMethod]
        public string AddCar2(MyCar car1, MyCar car2)
        {

            return ResponseResultObj.Success(new List<MyCar> { car1, car2 }, "Success").ToJson();
        }

        [WebMethod]
        public string AddCars(List<MyCar> cars)
        {
            var _car = cars;

            return ResponseResultObj.Success(_car, "Success").ToJson();
        }
        [WebMethod]
        public string AddCars2(List<MyCar> cars, MyCar car2)
        {
            var _car = cars;
            if (car2 != null) _car.Add(car2);

            return ResponseResultObj.Success(_car, "Success").ToJson();
        }
        [WebMethod]
        public string AddWeather(WeatherForecast wf)
        {
            return ResponseResultObj.Success(wf, "Success").ToJson();
        }
    }
    public class MyCar
    {
       // public MyCar() { }
        //[DataMember]
        public string id { get; set; }
        //[DataMember]
        public string name { get; set; }
        public string mycode2 { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
       // [DataMember]
        public int code1 { get; set; }
        /// <summary>
        /// 返回结果描述
        /// </summary>
        //[DataMember]
        public string msg1 { get; set; }
       // [DataMember]

        public List<WeatherForecast> wfList { get; set; }
       // [DataMember]
        public WeatherForecast wf { get; set; }

        public override string ToString()
        {
            return $"{id},{name},{code1},{mycode2},{msg1};wf:{wf}";
        }
    }
    public class MyCar2
    {
        // public MyCar() { }
        //[DataMember]
        public string id { get; set; }
        //[DataMember]
        public string name { get; set; }
        public string mycode2 { get; set; }
    }
        public class WeatherForecast
    {
        public WeatherForecast() { }
        /// <summary>
        /// 返回码
        /// </summary>
        //[DataMember]
        public int code { get; set; }
        /// <summary>
        /// 返回结果描述
        /// </summary>
        //[DataMember]
        public string msg { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public MyCar2 myCar { get; set; }
        public List<MyCar2> MyCar2List { get; set; }
        public override string ToString()
        {
            return $"{Summary},{code},{msg},{Date},{TemperatureC}";
        }
    }
}
