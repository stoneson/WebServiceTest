using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceTest
{
    /// 通用返回实体
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// 返回码
        /// </summary>
        //[DataMember]
        public int code { get; set; } = 0;
        /// <summary>
        /// 返回结果描述
        /// </summary>
        //[DataMember]
        public string msg { get; set; } = "成功";

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name = "_data" ></ param >
        /// < returns ></ returns >
        public static ResponseResult Success()
        {
            return new ResponseResult() { code = 0, msg = "OK" };
        }

        //public static ResponseResult<T> Default<T>()
        //{
        //    var result = new ResponseResult<T>();
        //    result.code = 0;
        //    result.msg = "";
        //    return result;
        //}

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseResultObj Success(object data, string message = "")
        {
            var result = new ResponseResultObj();
            result.data = data;
            result.code = 0;
            result.msg = message;
            return result;
        }

        ///// 返回异常
        ///// </summary>
        ///// <param name="ex"></param>
        ///// <returns></returns>
        //public static ResponseResult<T> Exception<T>(Exception ex, T data = default(T))
        //{
        //    return new ResponseResult<T>() { code = 102, msg = "调用失败：" + ex.ToString(), data = data };
        //}
        ///// <summary>
        ///// 返回调用失败
        ///// </summary>
        ///// <param name="msg"></param>
        ///// <returns></returns>
        //public static ResponseResult<T> Exception<T>(string message, T data = default(T))
        //{
        //    return new ResponseResult<T>() { code = 102, msg = message, data = data };
        //}


        /// 返回异常
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static ResponseResult Exception(Exception ex)
        {
            return new ResponseResult() { code = 102, msg = "调用失败：" + ex.StackTrace };
        }
        /// <summary>
        /// 返回调用失败
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResponseResult Exception(string message)
        {
            return new ResponseResult() { code = 102, msg = message };
        }
        public static ResponseResult Faild(int code, string message)
        {
            return new ResponseResult() { code = code, msg = message };
        }
        public static ResponseResult Faild(string message)
        {
            return new ResponseResult() { code = 101, msg = message };
        }

        public static ResponseResult NotAuthorization(string message)
        {
            return new ResponseResult() { code = 403, msg = message };
        }
    }
    public class ResponseResultObj : ResponseResult // where T : class, new()
    {
        public ResponseResultObj()
        {
            this.data = null;// new T();
        }

        public object data
        {
            get;
            set;
        }

        public static ResponseResultObj Default()
        {
            var result = new ResponseResultObj();
            result.code = 0;
            result.msg = "";
            return result;
        }

        //public static ResponseResult<T> Success(T t, string message = "")
        //{
        //    var result = new ResponseResult<T>();
        //    result.data = t;
        //    result.code = 0;
        //    result.msg = message;
        //    return result;
        //}

        public new static ResponseResultObj Exception(string message)
        {
            var result = new ResponseResultObj();
            result.code = 102;
            result.msg = message;
            return result;
        }

        public new static ResponseResultObj Faild(string message)
        {
            var result = new ResponseResultObj();
            result.code = 101;
            result.msg = message;
            return result;
        }

        public new static ResponseResultObj NotAuthorization(string message)
        {
            var result = new ResponseResultObj();
            result.code = 403;
            result.msg = message;
            return result;
        }
    }

    //public enum ResponseResultStatus
    //{
    //    Default = 0,
    //    Succeed = 100,
    //    Faild = 101,
    //    Exception = 102,
    //    NotAuthorization = 403
    //}
}
