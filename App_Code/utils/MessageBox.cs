using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web;

/// <summary>
/// MessageBox의 요약 설명입니다.
/// </summary>
public static class MessageBox
{
    public static void show(string message, Page page)
    { 
        page.ClientScript.RegisterStartupScript(page.GetType(), "MessageBox",
                            "alert(\"" + message.Replace(@"\", @"\\") + "\");", true);
    }
}