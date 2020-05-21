using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// validChecker의 요약 설명입니다.
/// </summary>
public class ValidChecker
{
	public ValidChecker()
	{
        
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}
    public static bool checkStringValid(string targetString)
    {
        if (targetString == null) return false;
        targetString = targetString.Trim();
        if ((targetString.Equals("")) || (targetString.Length==0) || (targetString==null))
        {
            return false;
        }
        return true;
    }
}