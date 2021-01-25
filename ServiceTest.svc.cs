using HCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServiceTest
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceTest”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceTest.svc 或 ServiceTest.svc.cs，然后开始调试。
    public class ServiceTest : IServiceTest
    {
        public void DoWork()
        {
            HCenter.CommonUtils.log4Helper.Info($"DoWork: {DateTime.Now}");
        }

        private static readonly string[] Summaries = new[]
          {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public List<WeatherForecast> HelloWorld()
        {
            HCenter.CommonUtils.log4Helper.Info($"HelloWorld: {DateTime.Now}");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                code = index,
                msg = "成功" + index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();
            //return "Hello World";
        }

        public int GetInt(int a, int b)
        {
            HCenter.CommonUtils.log4Helper.Info($"GetInt:( {a},  {b})={b + a}");
            return b + a;
        }
        public DateTime GetDate()
        {
            HCenter.CommonUtils.log4Helper.Info($"GetDate:( {DateTime.Now})");
            return DateTime.Now;
        }

        public WeatherForecast getBySummarie(string summarie)
        {
            HCenter.CommonUtils.log4Helper.Info($"getBySummarie:( {summarie})");
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
        public string AddCar(MyCar MyCar)
        {
            HCenter.CommonUtils.log4Helper.Info($"AddCar:( {MyCar})");
            var _car = MyCar;

            return ResponseResultObj.Success(_car, "Success").ToJson();
        }
        public string AddCar2(MyCar car1, MyCar car2)
        {
            HCenter.CommonUtils.log4Helper.Info($"AddCar2:( {car1},{car2})");
            var ss = System.ServiceModel.Web.WebOperationContext.Current;
            return ResponseResultObj.Success(new List<MyCar> { car1, car2 }, "Success").ToJson();
        }

        public string AddCars(List<MyCar> cars)
        {
            HCenter.CommonUtils.log4Helper.Info($"AddCars:( {cars})");
            var _car = cars;

            return ResponseResultObj.Success(_car, "Success").ToJson();
        }
        public string AddCars2(List<MyCar> cars, MyCar car2)
        {
            HCenter.CommonUtils.log4Helper.Info($"AddCars2:( {cars}，{car2})");
            var _car = cars;
            if (car2 != null) _car.Add(car2);

            return ResponseResultObj.Success(_car, "Success").ToJson();
        }

        public string AddWeather(WeatherForecast wf)
        {
            HCenter.CommonUtils.log4Helper.Info($"AddWeather:( {wf})");
            return ResponseResultObj.Success(wf, "Success").ToJson();
        }
    }
}
