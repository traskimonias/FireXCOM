using System;
public class Debug
{
    private static  int ShowType = 0;
    public static void ShowText(string text){
        if (ShowType==0){
            Console.WriteLine(text);
        }else{
            Console.WriteLine(text);
        }
    }
}