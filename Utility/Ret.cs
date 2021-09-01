/// <summary>
/// Ret 的摘要说明
/// </summary>
public struct Ret
{
    public bool isOk { get; set; }
     
    public string errMsg { get; set; }
     
    public int statusCode { get; set; }

    public static Ret Success(string errMsg = "")
    {
        return new Ret()
        {
            isOk = true,
            errMsg = errMsg == "" ? "操作成功" : errMsg,
            statusCode = 0
        };
    }
     
    public static Ret Error(int statusCode, string errMsg = "")
    {
        if (statusCode == 0 || statusCode == 9999)
            statusCode = -1;
        return new Ret()
        {
            isOk = false,
            errMsg = errMsg,
            statusCode = statusCode
        };
    }

    public override string ToString()
    {
        return string.Format("isOk:{0};statusCode:{1};errMsg:{2}", (object)this.isOk, (object)this.statusCode, (object)this.errMsg);
    }

}

public struct Ret<TResult>
{
    /// <summary>是否成功</summary>
    public bool isOk { get; set; }

    /// <summary>失败时的异常信息，未必有值，具体参考Code</summary>
    public string errMsg { get; set; }

    /// <summary>
    /// -1:参数错误  0:成功 9999:成功返回，但是方法未执行
    /// <para>其他代码请参考每个方法的返回值</para>
    /// </summary>
    public int statusCode { get; set; }

    /// <summary>数据模型</summary>
    public TResult Result { get; set; }

    /// <summary>成功返回值</summary>
    /// <returns></returns>
    public static Ret<TResult> Success(TResult result, string errMsg = "")
    {
        return new Ret<TResult>()
        {
            isOk = true,
            errMsg = errMsg == "" ? "操作成功" : errMsg,
            statusCode = 0,
            Result = result
        };
    }

    /// <summary>失败返回值</summary>
    /// <param name="code"></param>
    /// <param name="errMsg"></param>
    /// <returns></returns>
    public static Ret<TResult> Error(int code, TResult result, string errMsg = "")
    {
        if (code == 0 || code == 9999)
            code = -1;
        return new Ret<TResult>()
        {
            isOk = false,
            errMsg = errMsg,
            statusCode = code,
            Result = result
        };
    }
    public override string ToString()
    {
        return string.Format("isOk:{0};statusCode:{1};errMsg:{2};Result:{3}", (object)this.isOk, (object)this.statusCode, (object)this.errMsg, (object)this.Result);
    }
}