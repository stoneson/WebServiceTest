using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServiceTest
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IServiceTest”。
    [ServiceContract]
    public interface IServiceTest
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<WeatherForecast> HelloWorld();

        [OperationContract]
        int GetInt(int a, int b);

        [OperationContract]
        DateTime GetDate();

        [OperationContract]
        WeatherForecast getBySummarie(string summarie);

        [OperationContract]
        string AddCar(MyCar MyCar);

        [OperationContract]
        string AddCar2(MyCar car1, MyCar car2);

        [OperationContract]
        string AddCars(List<MyCar> cars);
        [OperationContract]
        string AddCars2(List<MyCar> cars, MyCar car2);
        [OperationContract]
        string AddWeather(WeatherForecast wf);
    }
}
